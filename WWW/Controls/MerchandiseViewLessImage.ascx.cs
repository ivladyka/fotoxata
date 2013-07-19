using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using VikkiSoft_BLL;

public partial class MerchandiseViewLessImage : ControlBase
{
    public MerchandiseViewLessImage()
    {
        
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        LoadMerchandise();
        LoadTitle();
    }

    private void LoadMerchandise()
    {
        const int countCells = 2;
        HtmlTableRow row = new HtmlTableRow();
        Merchandise m = new Merchandise();
        m.Where.CategoryID.Value = CategoryID;
        if (m.Query.Load())
        {
            do
            {
                if (row.Cells.Count >= countCells)
                {
                    tblGallery.Rows.Add(row);
                    row = new HtmlTableRow();
                }
                string prices = "";
                if (m.PriceFrom > 0)
                {
                    prices = m.PriceFrom.ToString("N");
                }
                if (m.PriceTo > 0)
                {
                    if (prices != "")
                    {
                        prices += " - ";
                    }
                    prices += m.PriceTo.ToString("F");
                }
                prices += " грн.";
                row.Cells.Add(AddMerchandiseCell(m.s_PhotoName, 
                    (!m.IsColumnNull("Name" + Utils.LangPrefix) ? m.GetColumn("Name" + Utils.LangPrefix).ToString() : ""),
                    (!m.IsColumnNull("Description" + Utils.LangPrefix) ? m.GetColumn("Description" + Utils.LangPrefix).ToString() : "")
                    , prices));
            }
            while (m.MoveNext());
        }
        for (int i = row.Cells.Count; i < countCells; i++)
        {
            row.Cells.Add(AddTableCell("&nbsp;"));
        }
        tblGallery.Rows.Add(row);
    }

    private HtmlTableCell AddMerchandiseCell(string photoName, string name, string description, string prices)
    {
        HtmlTableCell cell = new HtmlTableCell();
        cell.Align = "left";
        HtmlTable t = new HtmlTable();
        t.Style["width"] = "100%";
        HtmlTableRow row = new HtmlTableRow();
        HtmlTableCell cell1 = new HtmlTableCell();
        cell1.Width = "200px";
        row.Cells.Add(cell1);
        row.Cells.Add(AddTableCell("<b style='color: #ff7500; font-size:10pt;'>" + name + "</b><br><br>" + description + "<br><br><b><i style='color: #d60d04; font-size:12pt;'>" + prices + "</i></b>"));
        t.Rows.Add(row);
        cell.Controls.Add(t);
        return cell;
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
            if (Request.Params["CategoryID"] != null)
            {
                return int.Parse(Request.Params["CategoryID"]);
            }
            return 0;
        }
    }

    private static HtmlTableCell AddTableCell(string innerHtml)
    {
        HtmlTableCell cell = new HtmlTableCell();
        cell.InnerHtml = innerHtml;
        cell.Align = "left";
        cell.VAlign = "top";
        return cell;
    }
}
