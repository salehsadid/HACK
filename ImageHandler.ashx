<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Web;

public class ImageHandler : IHttpHandler
{
    public bool IsReusable { get { return true; } }

    public void ProcessRequest(HttpContext context)
    {
        var src = (context.Request.QueryString["src"] ?? string.Empty).ToLowerInvariant();
        int id;

        if (!int.TryParse(context.Request.QueryString["id"], out id) || id <= 0)
        {
            WriteMissingImage(context, src);
            return;
        }

        try
        {
            HACK.WebForms.ImageResult result = null;

            if (src == "content")
                result = HACK.WebForms.HackRepository.GetContentImage(id);
            else if (src == "person")
                result = HACK.WebForms.HackRepository.GetPersonImage(id);

            if (result != null && result.Data != null && result.Data.Length > 0)
            {
                var mime = !string.IsNullOrEmpty(result.MimeType) ? result.MimeType : "image/jpeg";
                context.Response.ContentType = mime;
                context.Response.Cache.SetCacheability(HttpCacheability.Public);
                context.Response.Cache.SetMaxAge(TimeSpan.FromDays(7));
                context.Response.BinaryWrite(result.Data);
                return;
            }

            if (result != null && !string.IsNullOrEmpty(result.FallbackUrl))
            {
                Redirect(context, result.FallbackUrl);
                return;
            }
        }
        catch
        {
            // fall through to the missing-image behavior on any DB error
        }

        WriteMissingImage(context, src);
    }

    private static void WriteMissingImage(HttpContext context, string src)
    {
        if (src == "person")
        {
            context.Response.StatusCode = 200;
            context.Response.ContentType = "image/svg+xml";
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.Cache.SetMaxAge(TimeSpan.FromDays(7));
            context.Response.Write(PersonPlaceholderSvg());
            return;
        }

        context.Response.StatusCode = 404;
        context.Response.End();
    }

    private static string PersonPlaceholderSvg()
    {
        return @"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 256 256"" role=""img"" aria-label=""Person""><rect width=""256"" height=""256"" rx=""128"" fill=""#e5e7eb""/><circle cx=""128"" cy=""92"" r=""44"" fill=""#64748b""/><path fill=""#64748b"" d=""M48 222c8-45 41-74 80-74s72 29 80 74z""/></svg>";
    }

    private static void Redirect(HttpContext context, string url)
    {
        context.Response.StatusCode = 302;
        context.Response.AddHeader("Location", url);
        context.Response.End();
    }
}
