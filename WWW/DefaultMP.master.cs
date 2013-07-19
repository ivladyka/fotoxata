using System;
using System.Web.UI.HtmlControls;
using System.Threading;

public partial class DefaultMP : MasterPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string culture = "uk-UA";
        if (Thread.CurrentThread.CurrentCulture != null)
        {
            culture = Thread.CurrentThread.CurrentCulture.Name;
        }
        switch (culture)
        {
            case "en-US":
                hlEnglishLang.CssClass = "VS_LangActive";
                break;
            case "ru-RU":
                hlRussianLang.CssClass = "VS_LangActive";
                break;
            case "uk-UA":
                hlUkrainianLang.CssClass = "VS_LangActive";
                break;
        }
       if (!Request.IsAuthenticated)
        {   
            hlOfficeRegistration.Visible = true; 
            hlOfficeRegistration.NavigateUrl = "~/Default.aspx?content=ProfileEdit&IsNew=true";
        } 
        if (Request.IsAuthenticated && !LoggedUser.IsAdmin() && !LoggedUser.IsEmployee() && !LoggedUser.IsPhotographer())
        {
            hlOfficeProfile.Visible = true;
            hlOfficeProfile.NavigateUrl = "~/Office/Office.aspx?content=ProfileEdit&UserID=" + UserSession.UserID;
        }
        if (!Request.IsAuthenticated)
        {
            hpLogIn.Visible = true;
            hpLogOut.Visible = false;
       }
        else
        {
            hpLogOut.Visible = true;
            hpLogIn.Visible = false;
        }
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                hlOfficeOnline.Visible = true;
            }
        }
    }

    protected void lbConfiguration_Click(object sender, EventArgs e)
    {
        Response.Redirect("Configuration.aspx");
    }

    protected void lbSchedule_Click(object sender, EventArgs e)
    {
        Response.Redirect("Schedule.aspx?content=ScheduleView");
    }

    public string Copyright
    {
        get
        {
            return Resources.Fotoxata.Copyright;
        }
    }

    public string MetaDescription
    {
        get
        {
            return "<meta name='description' content=\"" + Resources.Fotoxata.MetaDescription + "\" />";
        }
    }

    public string MetaKeywords
    {
        get
        {
            return "<meta name='keywords' content=\"" + Resources.Fotoxata.MetaKeywords + "\" />";
        }
    }

    protected void hlLanguage_Click(object sender, System.EventArgs e)
    {
        Response.Redirect(Request.Url.ToString());
    }
}
