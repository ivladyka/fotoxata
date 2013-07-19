using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using VikkiSoft_BLL;

public partial class TreeView : ControlBase
{
    public TreeView()
    {
        this.m_Name = "";
    }
    private void SetClientOnMouseEvents(string imageName, HtmlImage img)
    {
        string defaultPrefix = "";
        if (Request.Url.PathAndQuery.IndexOf("/Office/") != -1)
        {
            defaultPrefix = "../";
        }

    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
           LoadTitle();
    }

    private void LoadTitle()
    {
        Category c = new Category();
        if (c.LoadByPrimaryKey(CategoryID))
        {
            string title = "";
            if (!c.IsColumnNull("Title" + Utils.LangPrefix))
            {
                title = c.GetColumn("Title" + Utils.LangPrefix).ToString();
            }
            if (title.Trim() == "")
            {
                title = c.GetColumn("Name" + Utils.LangPrefix).ToString();
            }
            this.m_Name = title;
        }
    }

    private int CategoryID
    {
        get
        {
            if (HttpContext.Current.Request.QueryString["CategoryID"] != null)
            {
                return int.Parse(HttpContext.Current.Request.QueryString["CategoryID"]);
            }
            return 0;
        }
    } 
}