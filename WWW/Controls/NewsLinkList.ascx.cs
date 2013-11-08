using System;
using System.Net.Mime;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MyGeneration.dOOdads;

public partial class NewsLinkList : ControlBase
{
    public NewsLinkList()
    {
        m_Name = Resources.Fotoxata.News.ToUpper();
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        LoadNewsLink();
    }


    private void LoadNewsLink()
    {
        VikkiSoft_BLL.News n = new VikkiSoft_BLL.News();
        n.Where.DateExpired.Value = DateTime.Now;
        n.Where.DateExpired.Operator = WhereParameter.Operand.GreaterThanOrEqual;
        n.Query.AddOrderBy(VikkiSoft_BLL.News.ColumnNames.DateNews, WhereParameter.Dir.DESC);
        if (n.Query.Load())
        {
            do
            {
                HtmlTableRow row = new HtmlTableRow();
                row.Cells.Add(AddNewCell("<a class='titleNewslink' href='Default.aspx?content=NewsView&NewsID=" + n.NewsID + "'>"
                    + (!n.IsColumnNull("Title" + Utils.LangPrefix) ? n.GetColumn("Title" + Utils.LangPrefix).ToString() : "" ) + "</a>", "titleQuestion", "30px", "bottom"));
                row.Cells.Add(AddNewCell(n.DateNews.ToString("dd.MM.yyyy"), "titleQuestion", "30px", "bottom"));
                tblNews.Rows.Add(row);
                string content = "";
                if (!n.IsColumnNull("NewsContent" + Utils.LangPrefix))
                {
                    content = n.GetColumn("NewsContent" + Utils.LangPrefix).ToString();
                }
                if (content.Length > 500)
                {
                    content = StringHtmlExtensions.TruncateHtml(content, 500, " ...") + "<br/> <br/><a class='titleQuestion' href='Default.aspx?content=NewsView&NewsID=" 
                        + n.NewsID + "'>" + Resources.Fotoxata.More + " >></a>";
                    /*content = content.Substring(0, 499) + "<br/> <br/><a class='titleQuestion' href='Default.aspx?content=NewsView&NewsID=" + n.NewsID
                        + "'>" + Resources.Fotoxata.More + " >></a>";*/
                }
                row = new HtmlTableRow();
                HtmlTableCell cell = AddNewCell(content, "", "0px", "bottom");
                cell.ColSpan = 2;
                row.Cells.Add(cell);
                tblNews.Rows.Add(row); 
            }
            while (n.MoveNext());
        }
        
    }

    private HtmlTableCell AddNewCell(string innerHTML, string style, string paddingtd, string valigntd)
    {
        HtmlTableCell cell = new HtmlTableCell();
        cell.VAlign = valigntd;
        cell.Style["padding-top"] = paddingtd;
        Label lbl = new Label();
        lbl.Text = innerHTML;
        if (style != "")
        {
            lbl.CssClass = style;
        }
        cell.Controls.Add(lbl);
        return cell;
    }
   }
