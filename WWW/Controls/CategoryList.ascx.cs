using System;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VikkiSoft_BLL;

public partial class CategoryList : ListControlBase, Interfaces.IColouredGrid
{
    public CategoryList()
    {
        this.m_Name = "КАТЕГОРІЇ";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
        BackURL = "~/Office/Office.aspx";
    }

    protected override string GetEditableControlName()
    {
        return "CategoryEdit";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(Category);
    }

    protected override string[] GetPrimaryKeys()
    {
        return new string[] { "CategoryID" };
    }

    public override void InitGrid()
    {
        base.InitGrid();
        this.editableGrid.GridMode = GridModes.Add | GridModes.Delete
            | GridModes.Edit | GridModes.Refresh;
        editableGrid.Width = 900;
        SetColumnSettings(Category.ColumnNames.Title, false, "Заголовок",
                0, HorizontalAlign.Center, "");
        SetColumnSettings(Category.ColumnNames.CategoryID, false, Category.ColumnNames.CategoryID,
           0, HorizontalAlign.Center, "");
        SetColumnSettings(Category.ColumnNames.CategoryContent, false, Category.ColumnNames.CategoryContent,
           0, HorizontalAlign.Center, "");
        SetColumnSettings(Category.ColumnNames.IsGallery, true, "Відображати в галереї",
           170, HorizontalAlign.Center, "");
        SetColumnSettings(Category.ColumnNames.PriceFrom, true, "Ціна, грн",
           100, HorizontalAlign.Center, "");
        SetColumnSettings(Category.ColumnNames.PriceTo, false, Category.ColumnNames.PriceTo,
          0, HorizontalAlign.Center, "");
        SetColumnSettings(Category.ColumnNames.DisplayOnPrice, true, "Показати на Прайсі",
           150, HorizontalAlign.Center, "");
        SetColumnSettings(Category.ColumnNames.Name, true, "Назва",
           0, HorizontalAlign.Center, "");
        SetColumnSettings(Category.ColumnNames.Name_ru, false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings(Category.ColumnNames.Name_en, false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings(Category.ColumnNames.Title_ru, false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings(Category.ColumnNames.Title_en, false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings(Category.ColumnNames.CategoryContent_ru, false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings(Category.ColumnNames.CategoryContent_en, false, "", 0, HorizontalAlign.Center, "");
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
                    decimal.TryParse(dataRowView[Category.ColumnNames.PriceTo].ToString(), out priceTo);
                    decimal.TryParse(dataRowView[Category.ColumnNames.PriceFrom].ToString(), out priceFrom);
                    e.Item.Cells[6].Text = "";
                    if (priceFrom > 0)
                    {
                        e.Item.Cells[6].Text = priceFrom.ToString("N");
                    }
                    if(priceTo > 0)
                    {
                        if(e.Item.Cells[6].Text != "")
                        {
                            e.Item.Cells[6].Text += " - ";
                        }
                        e.Item.Cells[6].Text += priceTo.ToString("F");
                    }
                }
            }
        }
    }

    protected override void OnEditableGridDelete(object sender, EditableGridDeleteEventArgs e)
    {
        GridEditableItem gei = e.DeletedItem;
        Gallery g = new Gallery();
        g.Where.CategoryID.Value = int.Parse(gei["CategoryID"].Text);
        if(g.Query.Load())
        {
            do
            {
                DeletePhotos(g.s_PhotoName);
            }
            while (g.MoveNext());
        }
        Merchandise m = new Merchandise();
        m.Where.CategoryID.Value = int.Parse(gei["CategoryID"].Text);
        if (m.Query.Load())
        {
            do
            {
                DeletePhotos(m.s_PhotoName);
            } while (m.MoveNext());
        }
        base.OnEditableGridDelete(sender, e);
    }

    private void DeletePhotos(string photoName)
    {
        string targetFolder = Server.MapPath(Utils.GaleryImagePath);
        if (photoName != "")
        {
            Utils.DeleteFile(targetFolder, photoName);
            Utils.DeleteFile(targetFolder, photoName.Substring(0, photoName.Length - 4) + "_s.jpg");
        }
    }

    #region IColouredGrid Members

    public Interfaces.GridColorSchemes GridColorScheme
    {
        get
        {
            return Interfaces.GridColorSchemes.Green;
        }
    }

    #endregion
}
