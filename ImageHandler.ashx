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
            Redirect(context, Placeholder());
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
            // fall through to placeholder on any DB error
        }

        Redirect(context, Placeholder());
    }

    private static string Placeholder()
    {
        return "https://ui-avatars.com/api/?name=HACK&background=0f766e&color=fff&bold=true&size=256";
    }

    private static void Redirect(HttpContext context, string url)
    {
        context.Response.StatusCode = 302;
        context.Response.AddHeader("Location", url);
        context.Response.End();
    }
}
