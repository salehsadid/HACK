using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HACK.WebForms
{
    public static class HackRepository
    {
        private static readonly object BootstrapLock = new object();
        private static bool isBootstrapped;

        private static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["HackDb"].ConnectionString; }
        }

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        private static void EnsureDatabase()
        {
            if (isBootstrapped)
            {
                return;
            }

            lock (BootstrapLock)
            {
                if (isBootstrapped)
                {
                    return;
                }

                var builder = new SqlConnectionStringBuilder(ConnectionString);
                var databaseName = builder.InitialCatalog;
                builder.InitialCatalog = "master";

                using (var conn = new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();

                    using (var existsCmd = new SqlCommand("SELECT DB_ID(@DatabaseName)", conn))
                    {
                        existsCmd.Parameters.Add("@DatabaseName", SqlDbType.NVarChar, 128).Value = databaseName;

                        if (existsCmd.ExecuteScalar() == DBNull.Value)
                        {
                            using (var createCmd = new SqlCommand("CREATE DATABASE " + QuoteSqlIdentifier(databaseName), conn))
                            {
                                createCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                using (var conn = CreateConnection())
                using (var cmd = new SqlCommand(BootstrapSql, conn))
                {
                    cmd.Parameters.Add("@AdminUsername", SqlDbType.NVarChar, 50).Value = "admin";
                    cmd.Parameters.Add("@AdminPassword", SqlDbType.NVarChar, 4000).Value = "admin";
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                isBootstrapped = true;
            }
        }

        private const string BootstrapSql = @"
IF OBJECT_ID('dbo.AdminUsers', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.AdminUsers (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Username NVARCHAR(50) NOT NULL UNIQUE,
        PasswordHash VARBINARY(32) NOT NULL
    );
END;

IF NOT EXISTS (SELECT 1 FROM dbo.AdminUsers WHERE Username = @AdminUsername)
BEGIN
    INSERT INTO dbo.AdminUsers (Username, PasswordHash)
    VALUES (@AdminUsername, HASHBYTES('SHA2_256', CONVERT(VARCHAR(4000), @AdminPassword)));
END;

IF OBJECT_ID('dbo.Members', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Members (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        FullName NVARCHAR(120) NOT NULL,
        Email NVARCHAR(120) NOT NULL,
        Phone NVARCHAR(30) NOT NULL,
        Department NVARCHAR(80) NOT NULL,
        Batch NVARCHAR(30) NOT NULL,
        InterestArea NVARCHAR(80) NOT NULL,
        Motivation NVARCHAR(600) NOT NULL,
        SubmittedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
    );
END;

IF OBJECT_ID('dbo.Applicants', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Applicants (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        FullName NVARCHAR(120) NOT NULL,
        Email NVARCHAR(120) NOT NULL,
        Phone NVARCHAR(30) NOT NULL,
        Department NVARCHAR(80) NOT NULL,
        Batch NVARCHAR(30) NOT NULL,
        InterestArea NVARCHAR(80) NOT NULL,
        Motivation NVARCHAR(600) NOT NULL,
        SubmittedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
    );
END;

IF COL_LENGTH('dbo.Members', 'InterestArea') IS NOT NULL
    ALTER TABLE dbo.Members ALTER COLUMN InterestArea NVARCHAR(80) NOT NULL;

IF COL_LENGTH('dbo.Members', 'Motivation') IS NOT NULL
    ALTER TABLE dbo.Members ALTER COLUMN Motivation NVARCHAR(600) NOT NULL;

IF OBJECT_ID('dbo.ClubContent', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.ClubContent (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        ContentType NVARCHAR(30) NOT NULL,
        Title NVARCHAR(160) NOT NULL,
        Subtitle NVARCHAR(220) NULL,
        Body NVARCHAR(900) NULL,
        ImageUrl NVARCHAR(260) NULL,
        Meta NVARCHAR(120) NULL,
        DisplayOrder INT NOT NULL DEFAULT 0,
        IsActive BIT NOT NULL DEFAULT 1,
        CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
    );
END;

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Members_SubmittedAt' AND object_id = OBJECT_ID('dbo.Members'))
    CREATE INDEX IX_Members_SubmittedAt ON dbo.Members (SubmittedAt DESC);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Applicants_SubmittedAt' AND object_id = OBJECT_ID('dbo.Applicants'))
    CREATE INDEX IX_Applicants_SubmittedAt ON dbo.Applicants (SubmittedAt DESC);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_ClubContent_TypeOrder' AND object_id = OBJECT_ID('dbo.ClubContent'))
    CREATE INDEX IX_ClubContent_TypeOrder ON dbo.ClubContent (ContentType, DisplayOrder, CreatedAt DESC);

IF NOT EXISTS (SELECT 1 FROM dbo.ClubContent)
BEGIN
    INSERT INTO dbo.ClubContent (ContentType, Title, Subtitle, Body, ImageUrl, Meta, DisplayOrder) VALUES
    ('notice', 'Recruitment window is open', 'Apply before orientation week', 'HACK is taking new members for embedded systems, robotics, FPGA, IoT, and mechanical prototyping teams.', NULL, 'May 2026', 1),
    ('notice', 'ESP32 lab sprint', 'Firmware and sensor telemetry', 'A weekend sprint covering board bring-up, sensor calibration, MQTT telemetry, and dashboard wiring.', NULL, 'Workshop', 2),
    ('achievement', 'National Robotics Challenge finalist', 'Autonomous navigation team', 'Our robot platform reached the final round with stable line tracking, obstacle handling, and rapid field repair workflow.', 'https://images.unsplash.com/photo-1485827404703-89b55fcc595e?auto=format&fit=crop&w=1200&q=85', '2026', 1),
    ('achievement', 'Inter-university IoT showcase winner', 'Smart campus prototype', 'The team built an energy monitoring network using ESP32 nodes, current sensors, and live analytics.', 'https://images.unsplash.com/photo-1518770660439-4636190af475?auto=format&fit=crop&w=1200&q=85', 'Award', 2),
    ('project', 'Modular rover platform', 'Robotics and control', 'A reusable rover chassis with swappable sensor decks, motor control modules, and telemetry firmware.', 'https://images.unsplash.com/photo-1581091226825-a6a2a5aee158?auto=format&fit=crop&w=1200&q=85', 'Active', 1),
    ('project', 'FPGA signal lab', 'Digital design', 'Hands-on HDL practice with timing analysis, waveform inspection, and hardware acceleration experiments.', 'https://images.unsplash.com/photo-1555664424-778a1e5e1b48?auto=format&fit=crop&w=1200&q=85', 'Research', 2),
    ('gallery', 'PCB assembly night', 'Soldering, inspection, and bring-up', 'Members practiced SMD soldering, continuity checks, and first-power-up discipline.', 'https://images.unsplash.com/photo-1518770660439-4636190af475?auto=format&fit=crop&w=1200&q=85', 'Lab', 1),
    ('gallery', 'Prototype review desk', 'Mentor feedback session', 'Teams reviewed enclosure, wiring, firmware, and maintainability before public demos.', 'https://images.unsplash.com/photo-1581092160562-40aa08e78837?auto=format&fit=crop&w=1200&q=85', 'Review', 2);
END;

UPDATE dbo.ClubContent SET ImageUrl = 'https://images.unsplash.com/photo-1518770660439-4636190af475?auto=format&fit=crop&w=1200&q=85' WHERE ImageUrl IN ('resource/hw2.jpg', 'resource/arduino.avif');
UPDATE dbo.ClubContent SET ImageUrl = 'https://images.unsplash.com/photo-1581092160562-40aa08e78837?auto=format&fit=crop&w=1200&q=85' WHERE ImageUrl = 'resource/hw3.jpg';
UPDATE dbo.ClubContent SET ImageUrl = 'https://images.unsplash.com/photo-1555664424-778a1e5e1b48?auto=format&fit=crop&w=1200&q=85' WHERE ImageUrl = 'resource/Hardware.webp';

IF OBJECT_ID('dbo.ClubPersons', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.ClubPersons (
        Id            INT IDENTITY(1,1) PRIMARY KEY,
        PersonType    NVARCHAR(30)  NOT NULL,
        ClubDesignation NVARCHAR(100) NOT NULL,
        Name          NVARCHAR(120) NOT NULL,
        PicUrl        NVARCHAR(500) NULL,
        Info          NVARCHAR(300) NULL,
        DisplayOrder  INT NOT NULL DEFAULT 0,
        IsActive      BIT NOT NULL DEFAULT 1,
        ImageData     VARBINARY(MAX) NULL,
        ImageMimeType NVARCHAR(50) NULL
    );
END;

IF COL_LENGTH('dbo.ClubContent', 'ImageData') IS NULL
    ALTER TABLE dbo.ClubContent ADD ImageData VARBINARY(MAX) NULL;
IF COL_LENGTH('dbo.ClubContent', 'ImageMimeType') IS NULL
    ALTER TABLE dbo.ClubContent ADD ImageMimeType NVARCHAR(50) NULL;
IF COL_LENGTH('dbo.ClubPersons', 'ImageData') IS NULL
    ALTER TABLE dbo.ClubPersons ADD ImageData VARBINARY(MAX) NULL;
IF COL_LENGTH('dbo.ClubPersons', 'ImageMimeType') IS NULL
    ALTER TABLE dbo.ClubPersons ADD ImageMimeType NVARCHAR(50) NULL;";

        public static int GetAdminCount()
        {
            EnsureDatabase();

            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.AdminUsers", conn))
            {
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public static bool ValidateAdmin(string username, string password)
        {
            EnsureDatabase();

            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(@"
SELECT COUNT(*)
FROM dbo.AdminUsers
WHERE Username = @Username
    AND PasswordHash = HASHBYTES('SHA2_256', CONVERT(VARCHAR(4000), @Password))", conn))
            {
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 4000).Value = password;
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public static DataTable GetMembers()
        {
            return GetPeople("dbo.Members");
        }

        public static DataTable GetApplicants()
        {
            return GetPeople("dbo.Applicants");
        }

        private static DataTable GetPeople(string tableName)
        {
            EnsureDatabase();

            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand("SELECT Id, FullName, Email, Phone, Department, Batch, InterestArea, Motivation, SubmittedAt FROM " + tableName + " ORDER BY SubmittedAt DESC", conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public static void InsertApplicant(RegistrationEntry entry)
        {
            InsertPerson("dbo.Applicants", entry);
        }

        public static void InsertMember(RegistrationEntry entry)
        {
            InsertPerson("dbo.Members", entry);
        }

        private static void InsertPerson(string tableName, RegistrationEntry entry)
        {
            EnsureDatabase();

            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(@"INSERT INTO " + tableName + @" (FullName, Email, Phone, Department, Batch, InterestArea, Motivation, SubmittedAt)
VALUES (@FullName, @Email, @Phone, @Department, @Batch, @InterestArea, @Motivation, @SubmittedAt)", conn))
            {
                AddPersonParameters(cmd, entry);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateMember(int id, RegistrationEntry entry)
        {
            EnsureDatabase();

            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(@"UPDATE dbo.Members
SET FullName = @FullName, Email = @Email, Phone = @Phone, Department = @Department, Batch = @Batch,
    InterestArea = @InterestArea, Motivation = @Motivation
WHERE Id = @Id", conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                AddPersonParameters(cmd, entry);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteMember(int id)
        {
            DeleteById("dbo.Members", id);
        }

        public static void DeleteApplicant(int id)
        {
            DeleteById("dbo.Applicants", id);
        }

        public static void ApproveApplicant(int id)
        {
            EnsureDatabase();

            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(@"
BEGIN TRANSACTION;
INSERT INTO dbo.Members (FullName, Email, Phone, Department, Batch, InterestArea, Motivation, SubmittedAt)
SELECT FullName, Email, Phone, Department, Batch, InterestArea, Motivation, SubmittedAt
FROM dbo.Applicants
WHERE Id = @Id;
DELETE FROM dbo.Applicants WHERE Id = @Id;
COMMIT TRANSACTION;", conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private static void DeleteById(string tableName, int id)
        {
            EnsureDatabase();

            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand("DELETE FROM " + tableName + " WHERE Id = @Id", conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable GetContent()
        {
            EnsureDatabase();

            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(@"SELECT Id, ContentType, Title, Subtitle, Body, ImageUrl, Meta, DisplayOrder, IsActive, CreatedAt
FROM dbo.ClubContent
ORDER BY ContentType, DisplayOrder, CreatedAt DESC", conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public static DataTable GetContent(string contentType)
        {
            EnsureDatabase();

            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(@"SELECT Id, ContentType, Title, Subtitle, Body, ImageUrl, Meta, DisplayOrder, IsActive, CreatedAt,
    CAST(CASE WHEN ImageData IS NOT NULL OR (ImageUrl IS NOT NULL AND LEN(ImageUrl) > 0) THEN 1 ELSE 0 END AS BIT) AS HasImage
FROM dbo.ClubContent
WHERE ContentType = @ContentType AND IsActive = 1
ORDER BY DisplayOrder, CreatedAt DESC", conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@ContentType", SqlDbType.NVarChar, 30).Value = contentType;
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public static void InsertContent(ClubContentItem item)
        {
            EnsureDatabase();

            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(@"INSERT INTO dbo.ClubContent (ContentType, Title, Subtitle, Body, ImageData, ImageMimeType, Meta, DisplayOrder, IsActive)
VALUES (@ContentType, @Title, @Subtitle, @Body, @ImageData, @ImageMimeType, @Meta, @DisplayOrder, @IsActive)", conn))
            {
                AddContentParameters(cmd, item);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateContent(int id, ClubContentItem item)
        {
            EnsureDatabase();

            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(@"UPDATE dbo.ClubContent
SET ContentType = @ContentType, Title = @Title, Subtitle = @Subtitle, Body = @Body,
    ImageData     = CASE WHEN @ImageData IS NULL THEN ImageData ELSE @ImageData END,
    ImageMimeType = CASE WHEN @ImageData IS NULL THEN ImageMimeType ELSE @ImageMimeType END,
    Meta = @Meta, DisplayOrder = @DisplayOrder, IsActive = @IsActive
WHERE Id = @Id", conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                AddContentParameters(cmd, item);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteContent(int id)
        {
            DeleteById("dbo.ClubContent", id);
        }

        // ── About text ────────────────────────────────────────

        public static string GetAboutText()
        {
            EnsureDatabase();

            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(
                "SELECT TOP 1 Body FROM dbo.ClubContent WHERE ContentType = 'about' AND IsActive = 1 ORDER BY DisplayOrder", conn))
            {
                conn.Open();
                var result = cmd.ExecuteScalar();
                return (result == null || result == DBNull.Value) ? string.Empty : result.ToString();
            }
        }

        public static void SaveAboutText(string body)
        {
            EnsureDatabase();

            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(@"
IF EXISTS (SELECT 1 FROM dbo.ClubContent WHERE ContentType = 'about')
    UPDATE dbo.ClubContent SET Body = @Body, IsActive = 1 WHERE ContentType = 'about'
ELSE
    INSERT INTO dbo.ClubContent (ContentType, Title, Body, DisplayOrder, IsActive)
    VALUES ('about', 'About HACK', @Body, 0, 1)", conn))
            {
                cmd.Parameters.Add("@Body", SqlDbType.NVarChar, 900).Value = NullSafe(body);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ── Club persons (moderators / executives) ────────────

        public static DataTable GetClubPersons()
        {
            EnsureDatabase();

            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(
                "SELECT Id, PersonType, ClubDesignation, Name, PicUrl, Info, DisplayOrder, IsActive FROM dbo.ClubPersons ORDER BY PersonType, DisplayOrder", conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public static DataTable GetClubPersons(string personType)
        {
            EnsureDatabase();

            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(
                "SELECT Id, PersonType, ClubDesignation, Name, PicUrl, Info, DisplayOrder FROM dbo.ClubPersons WHERE PersonType = @PersonType AND IsActive = 1 ORDER BY DisplayOrder", conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@PersonType", SqlDbType.NVarChar, 30).Value = personType;
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public static void InsertClubPerson(ClubPerson person)
        {
            EnsureDatabase();

            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(@"INSERT INTO dbo.ClubPersons (PersonType, ClubDesignation, Name, ImageData, ImageMimeType, Info, DisplayOrder, IsActive)
VALUES (@PersonType, @ClubDesignation, @Name, @ImageData, @ImageMimeType, @Info, @DisplayOrder, @IsActive)", conn))
            {
                AddClubPersonParameters(cmd, person);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateClubPerson(int id, ClubPerson person)
        {
            EnsureDatabase();

            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(@"UPDATE dbo.ClubPersons
SET PersonType = @PersonType, ClubDesignation = @ClubDesignation, Name = @Name,
    ImageData     = CASE WHEN @ImageData IS NULL THEN ImageData ELSE @ImageData END,
    ImageMimeType = CASE WHEN @ImageData IS NULL THEN ImageMimeType ELSE @ImageMimeType END,
    Info = @Info, DisplayOrder = @DisplayOrder, IsActive = @IsActive
WHERE Id = @Id", conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                AddClubPersonParameters(cmd, person);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteClubPerson(int id)
        {
            DeleteById("dbo.ClubPersons", id);
        }

        private static void AddClubPersonParameters(SqlCommand cmd, ClubPerson person)
        {
            cmd.Parameters.Add("@PersonType",      SqlDbType.NVarChar, 30).Value  = NullSafe(person.PersonType);
            cmd.Parameters.Add("@ClubDesignation", SqlDbType.NVarChar, 100).Value = NullSafe(person.ClubDesignation);
            cmd.Parameters.Add("@Name",            SqlDbType.NVarChar, 120).Value = NullSafe(person.Name);
            var imgParam = cmd.Parameters.Add("@ImageData", SqlDbType.VarBinary, -1);
            imgParam.Value = person.ImageData != null ? (object)person.ImageData : DBNull.Value;
            cmd.Parameters.Add("@ImageMimeType",   SqlDbType.NVarChar, 50).Value  = DbValue(person.ImageMimeType);
            cmd.Parameters.Add("@Info",            SqlDbType.NVarChar, 300).Value = DbValue(person.Info);
            cmd.Parameters.Add("@DisplayOrder",    SqlDbType.Int).Value            = person.DisplayOrder;
            cmd.Parameters.Add("@IsActive",        SqlDbType.Bit).Value            = person.IsActive;
        }

        public static ImageResult GetContentImage(int id)
        {
            EnsureDatabase();
            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(
                "SELECT ImageData, ImageMimeType, ImageUrl FROM dbo.ClubContent WHERE Id = @Id", conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                {
                    if (reader.Read())
                    {
                        return new ImageResult
                        {
                            Data        = reader["ImageData"] as byte[],
                            MimeType    = reader["ImageMimeType"] as string,
                            FallbackUrl = reader["ImageUrl"] as string
                        };
                    }
                }
            }
            return new ImageResult();
        }

        public static ImageResult GetPersonImage(int id)
        {
            EnsureDatabase();
            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(
                "SELECT ImageData, ImageMimeType FROM dbo.ClubPersons WHERE Id = @Id", conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                {
                    if (reader.Read())
                    {
                        return new ImageResult
                        {
                            Data     = reader["ImageData"] as byte[],
                            MimeType = reader["ImageMimeType"] as string
                        };
                    }
                }
            }
            return new ImageResult();
        }

        private static void AddPersonParameters(SqlCommand cmd, RegistrationEntry entry)
        {
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 120).Value = NullSafe(entry.FullName);
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 120).Value = NullSafe(entry.Email);
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 30).Value = NullSafe(entry.Phone);
            cmd.Parameters.Add("@Department", SqlDbType.NVarChar, 80).Value = NullSafe(entry.Department);
            cmd.Parameters.Add("@Batch", SqlDbType.NVarChar, 30).Value = NullSafe(entry.Batch);
            cmd.Parameters.Add("@InterestArea", SqlDbType.NVarChar, 80).Value = NullSafe(entry.InterestArea);
            cmd.Parameters.Add("@Motivation", SqlDbType.NVarChar, 600).Value = NullSafe(entry.Motivation);
            cmd.Parameters.Add("@SubmittedAt", SqlDbType.DateTime2).Value = entry.SubmittedAt == DateTime.MinValue ? DateTime.UtcNow : entry.SubmittedAt;
        }

        private static void AddContentParameters(SqlCommand cmd, ClubContentItem item)
        {
            cmd.Parameters.Add("@ContentType",   SqlDbType.NVarChar, 30).Value  = NullSafe(item.ContentType);
            cmd.Parameters.Add("@Title",         SqlDbType.NVarChar, 160).Value = NullSafe(item.Title);
            cmd.Parameters.Add("@Subtitle",      SqlDbType.NVarChar, 220).Value = DbValue(item.Subtitle);
            cmd.Parameters.Add("@Body",          SqlDbType.NVarChar, 900).Value = DbValue(item.Body);
            var imgParam = cmd.Parameters.Add("@ImageData", SqlDbType.VarBinary, -1);
            imgParam.Value = item.ImageData != null ? (object)item.ImageData : DBNull.Value;
            cmd.Parameters.Add("@ImageMimeType", SqlDbType.NVarChar, 50).Value  = DbValue(item.ImageMimeType);
            cmd.Parameters.Add("@Meta",          SqlDbType.NVarChar, 120).Value = DbValue(item.Meta);
            cmd.Parameters.Add("@DisplayOrder",  SqlDbType.Int).Value            = item.DisplayOrder;
            cmd.Parameters.Add("@IsActive",      SqlDbType.Bit).Value            = item.IsActive;
        }

        private static string NullSafe(string value)
        {
            return (value ?? string.Empty).Trim();
        }

        private static string QuoteSqlIdentifier(string value)
        {
            value = NullSafe(value);
            if (value.Length == 0)
            {
                throw new InvalidOperationException("The HackDb connection string must include an Initial Catalog database name.");
            }

            return "[" + value.Replace("]", "]]") + "]";
        }

        private static object DbValue(string value)
        {
            value = NullSafe(value);
            return value.Length == 0 ? (object)DBNull.Value : value;
        }
    }
}
