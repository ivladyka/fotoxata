using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VikkiSoft_BLL;

public partial class GalleryList : ListControlBase, Interfaces.IColouredGrid
{
    public GalleryList()
    {
        this.m_Name = "Фотографії";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
    }

    protected override string GetEditableControlName()
    {
        return "GalleryEdit";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(Gallery);
    }

    protected override string[] GetPrimaryKeys()
    {
        return new string[] { "GalleryID" };
    }

    public override void InitGrid()
    {
        base.InitGrid();
        this.editableGrid.UrlToAdd += "&CategoryID=" + CategoryID;
        this.editableGrid.GridMode = GridModes.Add | GridModes.Delete
            | GridModes.Refresh;
        editableGrid.Width = 780;
        editableGrid.AllowSorting = false;
        SetColumnSettings(Gallery.ColumnNames.GalleryID, false, Gallery.ColumnNames.GalleryID,
            0, HorizontalAlign.Center, "");
        SetColumnSettings(Gallery.ColumnNames.CategoryID, false, Gallery.ColumnNames.CategoryID,
            0, HorizontalAlign.Center, "");
        SetColumnSettings(Gallery.ColumnNames.PhotoName, true, "Фотографії",
           0, HorizontalAlign.Center, "");
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
                    i.ImageUrl = Path.Combine(Utils.GaleryImagePath, 
                        dataRowView["PhotoName"].ToString().Substring(0, dataRowView["PhotoName"].ToString().Length-4) + "_s.jpg");
                    i.Attributes["onclick"] = "return VIKKI_ShowImageViewWindow('" + CategoryID
                        + "', '" + dataRowView["PhotoName"].ToString() + "', '0');";
                    i.CssClass = "VIKKI_HandCursor";
                    e.Item.Cells[5].Controls.Add(i);
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
        Gallery g = new Gallery();
        g.LoadByCategoryID(CategoryID);
        return g.DefaultView.Table;
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

    protected override void OnEditableGridRowsDragDrop(object sender, GridDragDropEventArgs e)
    {
        base.OnEditableGridRowsDragDrop(sender, e);
        if (e.DestDataItem != null)
        {
            int galleryIDDest = 0;
            int.TryParse(e.DestDataItem["GalleryID"].Text, out galleryIDDest);
            if (galleryIDDest > 0)
            {
                foreach (GridDataItem item in e.DraggedItems)
                {
                    try
                    {
                        int galleryIDDrag = int.Parse(item["GalleryID"].Text);
                        Gallery g = new Gallery();
                        g.Move(CategoryID, galleryIDDrag, galleryIDDest);
                        galleryIDDest = galleryIDDrag;
                    }
                    catch { }
                }
            }
        }
        this.RebindGrid();
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
