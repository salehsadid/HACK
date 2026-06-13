# HACK Club Website

This is an academic web project for the Hardware Acceleration Club of KUET. The project is built with ASP.NET Web Forms and C#. It has a public website and an admin panel.

## Main Features

- Public home page for club information
- Editable hero section from admin panel
- Editable statistics and "What We Do" section
- Notices, projects, gallery, and achievements management
- About page with moderators and executive members
- Member registration form
- Applicant approval system
- Member management from admin panel
- Image upload, replace, and remove option
- Default person icon when no image is uploaded
- Admin login protection
- Responsive layout
- Dark and light theme toggle
- SQL database tables are created automatically from code
- Server-side validation

## Technology Used

- ASP.NET Web Forms
- C#
- .NET Framework 4.8
- SQL Server LocalDB
- HTML
- CSS
- JavaScript

## Project Structure

- `Home.aspx` contains the public home page.
- `About.aspx` contains the public about page.
- `Register.aspx` contains the member registration form.
- `Admin/` contains all admin panel pages.
- `App_Code/` contains models and database repository code.
- `ImageHandler.ashx` loads images from the database.
- `styles.css` contains public website styles.
- `admin.css` contains admin panel styles.
- `script.js` contains small client-side features like theme toggle.
- `Web.config` contains the database connection string and project configuration.
- `database/` contains the SQL script backup.
- `resources/` contains static project resources.

## How To Run

1. Open the project in Visual Studio.
2. Make sure .NET Framework 4.8 is installed.
3. Make sure SQL Server LocalDB is available.
4. Run the project using IIS Express.
5. Open the website in the browser.

The database and required tables are created automatically when the project runs.

## Admin Login

Default admin login:

```text
Username: admin
Password: admin
```

After login, the admin can manage homepage content, notices, projects, gallery, achievements, applicants, members, moderators, and executives.

## Notes

This project is made for academic purpose. It demonstrates a complete club website with content management, registration, database operations, and admin control.
