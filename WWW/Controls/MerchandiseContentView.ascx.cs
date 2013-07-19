using System.Web;
using VikkiSoft_BLL;

public partial class MerchandiseContentView : ControlBase
{
 

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
