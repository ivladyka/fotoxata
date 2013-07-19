using System;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VikkiSoft_BLL;

public partial class PriceList : ListControlBase, Interfaces.IColouredGrid
{
    public PriceList()
    {
        
    }

    protected override string GetEditableControlName()
    {
        return "MerchandiseEdit";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(Merchandise);
    }

    protected override string[] GetPrimaryKeys()
    {
        return new string[] { "MerchandiseID" };
    }

    public override void InitGrid()
    {
        base.InitGrid();
        this.editableGrid.UrlToAdd += "&CategoryID=" + CategoryID;
        this.editableGrid.GridMode = GridModes.None;
        editableGrid.AllowPaging = false;
        editableGrid.Width = 600;
        SetColumnSettings(Merchandise.ColumnNames.MerchandiseID, false, Merchandise.ColumnNames.MerchandiseID,
            0, HorizontalAlign.Center, "");
        SetColumnSettings(Merchandise.ColumnNames.CategoryID, false, Merchandise.ColumnNames.CategoryID,
            0, HorizontalAlign.Center, "");
        SetColumnSettings(Merchandise.ColumnNames.Name, false, "Назва", 0, HorizontalAlign.Center, "");
        SetColumnSettings(Merchandise.ColumnNames.Name_ru, false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings(Merchandise.ColumnNames.Name_en, false, "", 0, HorizontalAlign.Center, "");
        if (IsServiceMode)
        {
            SetColumnSettings("Name" + Utils.LangPrefix, true, Resources.Fotoxata.ServiceName, 0, HorizontalAlign.Left, "");
        }
        else
        {
            SetColumnSettings("Name" + Utils.LangPrefix, true, Resources.Fotoxata.Format, 0, HorizontalAlign.Center, "");
        }
        SetColumnSettings(Merchandise.ColumnNames.PhotoName, false, "Зображення",
           0, HorizontalAlign.Center, "");
        SetColumnSettings(Merchandise.ColumnNames.DisplayOnPrice, false, "Показати на прайсі",
           0, HorizontalAlign.Center, "");
        SetColumnSettings(Merchandise.ColumnNames.PriceFrom, true, Resources.Fotoxata.Cost, 190, HorizontalAlign.Center, "");
        SetColumnSettings(Merchandise.ColumnNames.PriceTo, false, Merchandise.ColumnNames.PriceTo,
          0, HorizontalAlign.Center, "");
        SetColumnSettings(Merchandise.ColumnNames.Description, false, "Опис",
           0, HorizontalAlign.Left, "");
        SetColumnSettings(Merchandise.ColumnNames.Description_ru, false, "", 0, HorizontalAlign.Left, "");
        SetColumnSettings(Merchandise.ColumnNames.Description_en, false, "", 0, HorizontalAlign.Left, "");
    }

    protected override void OnEditableGridItemDataBound(object sender, GridItemEventArgs e)
    {
        base.OnEditableGridItemDataBound(sender, e);
        if (e.Item is GridDataItem)
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                DataRowView dataRowView = e.Item.DataItem as DataRowView;
                if (dataRowView != null)
                {
                    decimal priceTo;
                    decimal priceFrom;
                    decimal.TryParse(dataRowView[Merchandise.ColumnNames.PriceTo].ToString(), out priceTo);
                    decimal.TryParse(dataRowView[Merchandise.ColumnNames.PriceFrom].ToString(), out priceFrom);
                    e.Item.Cells[9].Text = "";
                    if (priceFrom > 0)
                    {
                        e.Item.Cells[9].Text = priceFrom.ToString("N");
                    }
                    if (priceTo > 0)
                    {
                        if (e.Item.Cells[9].Text != "")
                        {
                            e.Item.Cells[9].Text += " - ";
                        }
                        e.Item.Cells[9].Text += priceTo.ToString("F");
                    }
                }
            }
        }
    }

    protected override DataTable GetDataSource()
    {
        Merchandise m = new Merchandise();
        m.LoadByCategoryID(CategoryID);
        if (m.DefaultView.Table.Rows.Count == 0)
        {
            return null;
        }
        return m.DefaultView.Table;
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

    private bool IsServiceMode
    {
        get
        {
            if (Request.QueryString["content"] != null)
            {
                if(Request.QueryString["content"] == "MerchandiseContentViewLessImage")
                {
                    return true;
                }
            }
            return false;
        }
    }

    #region IColouredGrid Members

    public Interfaces.GridColorSchemes GridColorScheme
    {
        get
        {
            return Interfaces.GridColorSchemes.Blue;
        }
    }

    #endregion
}
