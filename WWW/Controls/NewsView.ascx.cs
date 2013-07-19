using System;
using System.Web.UI.HtmlControls;

public partial class NewsView : EditControlBase
{
    public NewsView()
    {
        BackURL = "~/Default.aspx?content=NewsLinkList";
        AddOnlyBrowserTitle = true;
        m_Name = "Новина";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(VikkiSoft_BLL.News);
    }

    protected override void ReadDataFromEntity()
    {
        base.ReadDataFromEntity();
        VikkiSoft_BLL.News n = (VikkiSoft_BLL.News)this.EditableEntity;
        this.m_Name = "";
        if (!n.IsColumnNull("Title" + Utils.LangPrefix))
        {
            lbTitle.Text = "<span class='pageName'>" + n.GetColumn("Title" + Utils.LangPrefix).ToString() + "</span>";
        }
        if (!n.IsColumnNull("NewsContent" + Utils.LangPrefix))
        {
            editor_NewsContent.Html = n.GetColumn("NewsContent" + Utils.LangPrefix).ToString();
        }
        lblDate.Text = n.DateNews.ToString("dd/MM/yyyy");

        HtmlTableRow trSiteMap = (HtmlTableRow)Page.Master.FindControl("trSiteMap");
        if (trSiteMap != null)
        {
            trSiteMap.Visible = false;
        }
        hlBackNewsList.Text = Resources.Fotoxata.BackNewsList + " >>";
    }

 
}
