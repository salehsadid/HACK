using System;
using System.Collections.Generic;

namespace HACK.WebForms
{
    public class BlogPost
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
    }

    public class RegistrationEntry
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public string Batch { get; set; }
        public string InterestArea { get; set; }
        public string Motivation { get; set; }
        public DateTime SubmittedAt { get; set; }
    }

    public static class BlogRepository
    {
        private static readonly List<BlogPost> Posts = new List<BlogPost>
        {
            new BlogPost
            {
                Category = "Workshop Recap",
                Title = "ESP32 Bootcamp: Zero To Live Dashboard",
                Summary = "Teams deployed sensor dashboards and practiced telemetry architecture in one weekend."
            },
            new BlogPost
            {
                Category = "Build Log",
                Title = "Line Follower Tuning Notes",
                Summary = "PID balancing results, track test metrics, and battery-performance comparisons."
            },
            new BlogPost
            {
                Category = "Team Culture",
                Title = "Inside HACK Demo Night",
                Summary = "Mentors reviewed prototypes and teams received technical feedback for next sprint goals."
            }
        };

        public static IReadOnlyList<BlogPost> GetPosts()
        {
            return Posts;
        }
    }

    public static class RegistrationStore
    {
        private static readonly object SyncRoot = new object();
        private static readonly List<RegistrationEntry> Registrations = new List<RegistrationEntry>();

        public static void Add(RegistrationEntry entry)
        {
            lock (SyncRoot)
            {
                Registrations.Add(entry);
            }
        }

        public static IReadOnlyList<RegistrationEntry> GetAll()
        {
            lock (SyncRoot)
            {
                return Registrations.AsReadOnly();
            }
        }
    }
}