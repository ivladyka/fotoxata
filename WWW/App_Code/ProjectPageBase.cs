using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;
using System.Web;

/// <summary>
/// Summary description for ProjectPageBase
/// </summary>

public class ProjectPageBase : System.Web.UI.Page
{
    protected string contentControlName = "";
    private bool m_AddOnlyBrowserTitle = false;
    protected UserControl userControl;
    //protected System.Web.UI.WebControls.PlaceHolder PlaceHolder1;
    protected ArrayList _headerTags = new ArrayList();

    public string ContentControlName
    {
        get
        {
            if (this.contentControlName != "")
                return this.contentControlName;

            string ret = this.Request.Params["content"];

            if (ret == null || ret == "")
            {
                if(Request.Url.PathAndQuery.IndexOf("Office.aspx") != -1)
                {
                    if (LoggedUser.IsAdmin() || LoggedUser.IsEmployee() || LoggedUser.IsPhotographer())
                    {
                        ret = "OfficeMenu";
                    }
                    else
                    {
                        ret = "OrderUserList";
                    }
                }
                else
                {
                    ret = "Default";
                }
            }
            return ret;
        }
        set
        {
            this.contentControlName = value;
        }
    }

    public string PageTitle
    {
        set
        {
            Page.Title = Resources.Fotoxata.PageTitle + (value.Trim().Length > 0 && value != "Фотохата" ? " - " + value : "");
            if (!AddOnlyBrowserTitle)
            {
                MasterPageBase dmp = (MasterPageBase) Page.Master;
                if (dmp != null)
                {
                    dmp.PageName = value;
                }
            }
        }
        get
        {
            return Page.Title;
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        userControl = (System.Web.UI.UserControl)Page.LoadControl("~/Controls/" + ContentControlName + ".ascx");
        userControl.ID = ContentControlName + "ID";

        HtmlForm form = (HtmlForm)Page.Master.FindControl("form1");
        if (form != null)
        {
            ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)form.FindControl("cphWithoutScroll");
            if (contentPlaceHolder != null)
            {
                if (userControl is ControlBase)
                {
                    MasterPageBase dmp = (MasterPageBase)Page.Master;
                /*    if (dmp != null)
                    {
                        dmp.BackButtonURL = ((ControlBase) userControl).BackURL;
                    }*/
                    AddOnlyBrowserTitle = ((ControlBase) userControl).AddOnlyBrowserTitle;
                }
                contentPlaceHolder.Controls.Add(userControl);
            }
        }

        if (userControl is Interfaces.INamedControl)
        {
            this.PageTitle = (userControl as Interfaces.INamedControl).Name;
        }
        /*if (userControl is Interfaces.IColouredGrid)
        {
            AddStyleSheet("~/RadControls/Grid/ColorSchemes/" + (userControl as Interfaces.IColouredGrid).GridColorScheme.ToString() + "/Styles.css");
        }
        else
        {
            AddStyleSheet("~/RadControls/Grid/ColorSchemes/Yellow/Styles.css");   
        }*/
        
    }

    private void AddStyleSheet(string cssFileName)
    {
        Page.Header.Controls.Add(new LiteralControl("<link href=\""
            + cssFileName + "\" type=\"text/css\" rel=\"stylesheet\" />"));
    }

    public void AddKeywords(string keywords)
    {
        Page.Header.Controls.Add(new LiteralControl("<meta name=\"keywords\" content=\"" + keywords + "\" />"));
    }

    public bool AddOnlyBrowserTitle
    {
        get
        {
            return m_AddOnlyBrowserTitle;
        }
        set
        {
            m_AddOnlyBrowserTitle = value;
        }
    }

    protected override void InitializeCulture()
    {
        Utils.InitCulture();
        base.InitializeCulture();
    }
}
