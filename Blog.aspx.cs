using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HACK.WebForms
{
    public partial class Blog : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            var posts = BlogRepository.GetPosts();
            PostsRepeater.DataSource = posts;
            PostsRepeater.DataBind();

            if (posts.Count > 0)
            {
                FeaturedTitle.Text = posts[0].Title;
                FeaturedSummary.Text = posts[0].Summary;
            }
        }

        private T GetMainContentControl<T>(string id) where T : Control
        {
            var contentPlaceHolder = Master.FindControl("MainContent") as ContentPlaceHolder;
            return contentPlaceHolder == null ? null : contentPlaceHolder.FindControl(id) as T;
        }

        private Repeater PostsRepeater
        {
            get { return GetMainContentControl<Repeater>("postsRepeater"); }
        }

        private Literal FeaturedTitle
        {
            get { return GetMainContentControl<Literal>("featuredTitle"); }
        }

        private Literal FeaturedSummary
        {
            get { return GetMainContentControl<Literal>("featuredSummary"); }
        }
    }
}
