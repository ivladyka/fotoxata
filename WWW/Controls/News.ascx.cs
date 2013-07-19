using System;
using System.Web.UI.HtmlControls;
using MyGeneration.dOOdads;

public partial class News : ControlBase
{
    public News()
    {
        
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        LoadNews();
    }

    private void LoadNews()
    {
        int index = 0;
        VikkiSoft_BLL.News n = new VikkiSoft_BLL.News();
        n.Where.DateExpired.Value = DateTime.Now;
        n.Where.DateExpired.Operator = WhereParameter.Operand.GreaterThan;
        n.Query.AddOrderBy(VikkiSoft_BLL.News.ColumnNames.DateNews, WhereParameter.Dir.DESC);
        if (n.Query.Load())
        {
            do
            {
                HtmlTableRow row = new HtmlTableRow();
                row.Cells.Add(AddNewsCell(n.DateNews, n.s_Title, n.s_NewsContent, n.NewsID));
                tblNews.Rows.Add(row);
                index++;
                if(index > 2)
                {
                    break;
                }
            }
            while (n.MoveNext());

            HtmlTableRow rowLast = new HtmlTableRow();
            HtmlTableCell cell = new HtmlTableCell();
            cell.Attributes["class"] = "news2";
            rowLast.Cells.Add(cell);
            tblNews.Rows.Add(rowLast);
        }
        else
        {
            tblNews.Visible = false;
        }
    }

    private HtmlTableCell AddNewsCell(DateTime date, string title, string content, int newsID)
    {
        HtmlTableCell cell = new HtmlTableCell();
        cell.Attributes["class"] = "news1";
        cell.VAlign = "top";
        cell.InnerHtml = "<h6>" + date.ToString("dd/MM/yyyy") + "</h6>";
        if (title != "")
        {
            cell.InnerHtml += "<b>" + title + "</b>";
        }
        if(content.Length > 60)
        {
            cell.InnerHtml += "<br/>" + content.Substring(0, 59) + "...<br/>";
            cell.InnerHtml += "<h6 style='text-align:right;'><a class='VIKKI_NewMoreLink' href='Default.aspx?content=NewsView&NewsID=" + newsID
                + "'>більше...</a></h6>";
        }
        else
        {
            cell.InnerHtml += "<br/>" + content;
        }
        return cell;
    }

}
