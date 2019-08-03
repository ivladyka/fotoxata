using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VikkiSoft_BLL;
using MyGeneration.dOOdads;

public partial class Controls_HomeSection : System.Web.UI.UserControl
{
    private int m_CategoryID = 0;
    private string m_PageLink = "";
    private string m_Title = "";
    protected string CrLf = new string(new char[] { (char)13, (char)10 });

    protected void Page_Load(object sender, EventArgs e)
    {
        hlTitle.NavigateUrl = PageLink;
        hlDetail.NavigateUrl = PageLink;
        hlDetail.Text = Resources.Fotoxata.More + " >>";
        hlTitle.Text = Title.ToUpper();
        if (CategoryID > 0)
        {
            LoadCategory();
        }
        else
        {
            if (PageLink.IndexOf("NewsLinkList") > -1)
            {
                LoadNews();
            }
            if (PageLink.IndexOf("AdviceTableList") > -1)
            {
                LoadAdvice();
            }
        }
    }

    private void LoadNews()
    {
        VikkiSoft_BLL.News n = new VikkiSoft_BLL.News();
        n.Where.DateExpired.Value = DateTime.Now;
        n.Where.DateExpired.Operator = WhereParameter.Operand.GreaterThanOrEqual;
        n.Query.AddOrderBy(VikkiSoft_BLL.News.ColumnNames.DateNews, WhereParameter.Dir.DESC);
        if (n.Query.Load())
        {
            string content = "";
            if (!n.IsColumnNull("Title" + Utils.LangPrefix))
            {
                content += n.GetColumn("Title" + Utils.LangPrefix).ToString();
            }
            if (!n.IsColumnNull("NewsContent" + Utils.LangPrefix))
            {
                content += "<br>" + System.Text.RegularExpressions.Regex.Replace(n.GetColumn("NewsContent" + Utils.LangPrefix).ToString(), "<[^>]*>", string.Empty);
            }
            if (content.Length > 170)
            {
                content = content.Substring(0, 169) + " ...";
            }
            lblContent.InnerHtml = content;
        }
    }

    private void LoadCategory()
    {
        Category cat = new Category();
        if (cat.LoadByPrimaryKey(CategoryID))
        {
            if (cat.IsColumnNull("Title" + Utils.LangPrefix) || cat.GetColumn("Title" + Utils.LangPrefix).ToString().Trim() == "")
            {
                hlTitle.Text = cat.GetColumn("Name" + Utils.LangPrefix).ToString();
            }
            else
            {
                hlTitle.Text = cat.GetColumn("Title" + Utils.LangPrefix).ToString();
            }
            if (!cat.IsColumnNull("CategoryContent" + Utils.LangPrefix))
            {
                string content = System.Text.RegularExpressions.Regex.Replace(cat.GetColumn("CategoryContent" + Utils.LangPrefix).ToString(), "<[^>]*>", string.Empty);
                if (content.Length > 100)
                {
                    content = content.Substring(0, 99) + " ...";
                }
                lblContent.InnerHtml = content;
            }
            
        }
    }

    public string PageLink
    {
        set
        {
            m_PageLink = value;
        }
        get
        {
            return m_PageLink;
        }
    }

    public string Title
    {
        set
        {
            m_Title = value;
        }
        get
        {
            return m_Title;
        }
    }

    public int CategoryID
    {
        set
        {
            m_CategoryID = value;
        }
        get
        {
            return m_CategoryID;
        }
    }

    private void LoadAdvice()
    {
        VikkiSoft_BLL.Advice adv = new VikkiSoft_BLL.Advice();
        adv.Query.AddOrderBy(VikkiSoft_BLL.Advice.ColumnNames.AdviceID, WhereParameter.Dir.DESC);
        if (adv.Query.Load())
        {
            string content = adv.GetColumn("Question" + Utils.LangPrefix).ToString();
            content += "<br>" + System.Text.RegularExpressions.Regex.Replace(adv.GetColumn("Answer" + Utils.LangPrefix).ToString(), "<[^>]*>", string.Empty);
            if (content.Length > 170)
            {
                content = content.Substring(0, 169) + " ...";
            }
            lblContent.InnerHtml = content;
        }
    }
}