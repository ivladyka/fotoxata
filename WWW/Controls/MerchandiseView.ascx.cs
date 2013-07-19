using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using VikkiSoft_BLL;

public partial class MerchandiseView : ControlBase
{
    public MerchandiseView()
    {
        
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
                LoadTitle();
        LoadMerchandise();

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
                    (!m.IsColumnNull("Description" + Utils.LangPrefix) ? m.GetColumn("Description" + Utils.LangPrefix).ToString() : ""), prices));
            }
            while (m.MoveNext());
        }
        else
        {
            this.Visible = false;
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
        HtmlTable t = new HtmlTable();
        t.Style["width"] = "100%";
        HtmlTableRow row = new HtmlTableRow();
        HtmlTableCell cell1 = new HtmlTableCell();
        cell1.Width = "50%";
        Image i = new Image();
        Literal l = new Literal();
        if (photoName == "")
        {
            i.ImageUrl = Path.Combine(Utils.GaleryImagePath, "nophoto.jpg");
            i.ImageAlign = ImageAlign.Middle;
            i.CssClass = "ThNoImageStyle";
            l.Text = "";
        }
        else
        {
            i.ImageUrl = Path.Combine(Utils.GaleryImagePath, photoName.Substring(0, photoName.Length - 4) + "_s.jpg");
            i.Attributes["onclick"] = "return VIKKI_ShowImageViewWindow('0', '" + photoName + "', '0');";
            i.CssClass = "GaleryThImageStyle";
            l.Text = "<br/><br/><span class='FasilityStyle'>" + name + "</span><br/><br/><span class='FasilitytextStyle'>" + description + "</span><br><br/><span class='FasilityStyleprice'>" + prices + "</span><br>";
        }
        cell1.Controls.Add(i);
        cell1.Controls.Add(l);
        row.Cells.Add(cell1);
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
