using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VikkiSoft_BLL;

public partial class OrderPhotoList : ListControlBase, Interfaces.IColouredGrid
{
    public OrderPhotoList()
    {
        this.m_Name = "Замовлення";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString() + "," + ((int)UserTypeEnum.Photographer).ToString()
            + "," + ((int)UserTypeEnum.Employee).ToString() + "," + ((int)UserTypeEnum.User).ToString();
        BackURL = "~/Office/Office.aspx?content=OrderDashboard";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(OrderPhoto);
    }

    protected override string[] GetPrimaryKeys()
    {
        return new string[] { "OrderPhotoID" };
    }

    public override void InitGrid()
    {
        base.InitGrid();
        if (LoggedUser.IsAdmin() || LoggedUser.IsEmployee() || LoggedUser.IsPhotographer())
        {
            this.editableGrid.GridMode = GridModes.Delete | GridModes.Refresh;
        }
        else
        {
            this.editableGrid.GridMode = GridModes.Refresh;
        }
        editableGrid.Width = 700;
        SetColumnSettings("OrderPhotoID", false, "",0, HorizontalAlign.Center, "");
        SetColumnSettings("ClientPhotoName", false, "Назва файлу", 0, HorizontalAlign.Center, "");
        SetColumnSettings("PhotoCount", true, Resources.Fotoxata.PhotoCount, 60, HorizontalAlign.Center, "");
        SetColumnSettings("Border", true, Resources.Fotoxata.Border, 80, HorizontalAlign.Center, "");
        SetColumnSettings("PaperTypeName", true, Resources.Fotoxata.Paper, 0, HorizontalAlign.Center, "");
        SetColumnSettings("MerchandiseName", true, Resources.Fotoxata.Size, 0, HorizontalAlign.Center, "");
        SetColumnSettings(VikkiSoft_BLL.OrderPhoto.ColumnNames.PhotoName, true, Resources.Fotoxata.Photo, 60, HorizontalAlign.Center, "");
        SetColumnSettings("PaperTypeID", false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings("MerchandiseID", false, "", 0, HorizontalAlign.Center, "");
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
                    e.Item.Cells[9].Controls.Add(GetImageControl(dataRowView[OrderPhoto.ColumnNames.PhotoName].ToString()));
                }
            }
        }
    }
 private Image GetImageControl(string photoName)
 {
     Image i = new Image();
     string orderImagePath = Utils.OrderImagePath + "//" + OrderID;
     string extension = "";
     if (photoName.LastIndexOf('.') != -1)
     {
         extension = photoName.Substring(photoName.LastIndexOf('.'),
             (photoName.Length - photoName.LastIndexOf('.')));
         photoName = photoName.Substring(0, photoName.LastIndexOf('.'));
     }

     i.ImageUrl = Path.Combine(orderImagePath, photoName + "_s" + extension);
     i.Attributes["onclick"] = "return VIKKI_ShowImageViewWindow('0', '"
         + photoName + "_m" + extension + "', '" + OrderID.ToString() + "');";
     i.CssClass = "VIKKI_HandCursor";

        return i;
    }
    protected override DataTable GetDataSource()
    {
        OrderPhoto op = new OrderPhoto();
        op.LoadByOrderID(OrderID);
        return op.DefaultView.Table;
    }
    protected override void OnEditableGridDelete(object sender, EditableGridDeleteEventArgs e)
    {
        base.OnEditableGridDelete(sender, e);
        GridEditableItem gei = e.DeletedItem;
        string targetFolder = Server.MapPath(Utils.OrderImagePath + "//" + OrderID);
        string extension = "";
        string photoName = gei["PhotoName"].Text;
        if (photoName.LastIndexOf('.') != -1)
        {
            extension = photoName.Substring(photoName.LastIndexOf('.'),
                (photoName.Length - photoName.LastIndexOf('.')));
            photoName = photoName.Substring(0, photoName.LastIndexOf('.'));
        }
        string folderName = targetFolder + "//" + PhotoFormat(int.Parse(gei["MerchandiseID"].Text));
        if (int.Parse(gei["PaperTypeID"].Text) == 1)
        {
            folderName += "MAT";
        }
        else
        {
            folderName += "GL";
        }
        if (((CheckBox)gei["Border"].Controls[0]).Checked)
        {
            folderName += "_B";
        }

        Utils.DeleteFile(folderName, gei["PhotoName"].Text);
        Utils.DeleteFile(targetFolder, photoName + "_s" + extension);
        Utils.DeleteFile(targetFolder, photoName + "_m" + extension);
    }

    private string PhotoFormat(int merchandiseID)
    {
        Merchandise m = new Merchandise();
        if (m.LoadByPrimaryKey(merchandiseID))
        {
            return m.s_Name.Replace("см", "");
        }
        return "";
    }

    private int OrderID
    {
        get
        {
            if (Request.Params["OrderID"] != null)
            {
                return int.Parse(Request.Params["OrderID"]);
            }
            return 0;
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
