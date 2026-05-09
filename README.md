# HACK Web Forms Scaffold

This repository now includes a beginner-friendly ASP.NET Web Forms version of the HACK portfolio site.

## Included files

- `Site.master` for the shared navbar and footer
- `Home.aspx` for the landing page
- `Blog.aspx` for dynamic blog posts from a C# list
- `Register.aspx` for the ASP.NET server-side registration form
- `App_Code/ClubModels.cs` for in-memory data models and stores

## Notes

- This is classic ASP.NET Web Forms, so it targets .NET Framework 4.8.
- Visual Studio Code can edit the files, but running/debugging usually happens through IIS Express or Visual Studio on Windows.
- The existing `styles.css`, `script.js`, and `resource/` folder are reused to keep the UI the same.

## How it works

- The registration form uses ASP.NET server controls and validators.
- Submitted registrations are stored in memory only, so they reset when the app restarts.
- Blog posts are loaded from a predefined C# list in `App_Code/ClubModels.cs`.

## Suggested next step

If you want, the next improvement should be adding a `Default.aspx` redirect or connecting the registration form to a database.