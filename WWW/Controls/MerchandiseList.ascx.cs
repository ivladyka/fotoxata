using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VikkiSoft_BLL;

public partial class MerchandiseList : ListControlBase, Interfaces.IColouredGrid
{
    public MerchandiseList()
    {
        this.m_Name = "Товари";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
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
        this.editableGrid.GridMode = GridModes.Add | GridModes.Edit | GridModes.Delete
            | GridModes.Refresh;
        editableGrid.AllowPaging = true;
        editableGrid.PageSize = 10;
        editableGrid.Width = 780;
        SetColumnSettings(Merchandise.ColumnNames.MerchandiseID, false, Merchandise.ColumnNames.MerchandiseID,
            0, HorizontalAlign.Center, "");
        SetColumnSettings(Merchandise.ColumnNames.CategoryID, false, Merchandise.ColumnNames.CategoryID,
            0, HorizontalAlign.Center, "");
        SetColumnSettings(Merchandise.ColumnNames.Name, true, "Назва",
           0, HorizontalAlign.Center, "");
        SetColumnSettings(Merchandise.ColumnNames.Name_ru, false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings(Merchandise.ColumnNames.Name_en, false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings(Merchandise.ColumnNames.PhotoName, true, "Зображення",
           0, HorizontalAlign.Center, "");
        SetColumnSettings(Merchandise.ColumnNames.DisplayOnPrice, true, "Показати на прайсі",
           40, HorizontalAlign.Center, "");
        SetColumnSettings(Merchandise.ColumnNames.PriceFrom, true, "Ціна, грн",
           90, HorizontalAlign.Center, "");
        SetColumnSettings(Merchandise.ColumnNames.PriceTo, false, Merchandise.ColumnNames.PriceTo,
          0, HorizontalAlign.Center, "");
        SetColumnSettings(Merchandise.ColumnNames.Description, true, "Опис",
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
                    Image i = new Image();
                    if (dataRowView["PhotoName"].ToString() != "")
                    {
                        i.ImageUrl = Path.Combine(Utils.GaleryImagePath,
                            dataRowView["PhotoName"].ToString().Substring(0, dataRowView["PhotoName"].ToString().Length - 4) + "_s.jpg");
                        i.Attributes["onclick"] = "return VIKKI_ShowImageViewWindow('0', '" + dataRowView["PhotoName"].ToString() + "', '0');";
                        i.CssClass = "VIKKI_HandCursor";
                    }
                    else
                    {
                        i.ImageUrl = Path.Combine(Utils.GaleryImagePath, "nophoto.jpg");
                    }
                    e.Item.Cells[7].Controls.Add(i);
                    HyperLink lnkEdit = e.Item.Cells[2].FindControl("lnkEdit") as HyperLink;
                    if (lnkEdit != null)
                    {
                        lnkEdit.NavigateUrl += "&CategoryID=" + CategoryID;
                    }

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

    protected override void OnEditableGridDelete(object sender, EditableGridDeleteEventArgs e)
    {
        base.OnEditableGridDelete(sender, e);
        GridEditableItem gei = e.DeletedItem;
        string targetFolder = Server.MapPath(Utils.GaleryImagePath);
        Utils.DeleteFile(targetFolder, gei["PhotoName"].Text);
        Utils.DeleteFile(targetFolder, gei["PhotoName"].Text.Substring(0, gei["PhotoName"].Text.Length-4) + "_s.jpg");
    }

    protected override DataTable GetDataSource()
    {
        Merchandise m = new Merchandise();
        m.LoadByCategoryID(CategoryID);
        return m.DefaultView.Table;
    }

    private int CategoryID
    {
        get
        {
            if(Request.Params["CategoryID"] != null)
            {
                return int.Parse(Request.Params["CategoryID"]);
            }
            return 0;
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
