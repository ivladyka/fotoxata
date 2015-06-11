using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VikkiSoft_BLL;

public partial class OrderList : ListControlBase, Interfaces.IColouredGrid
{
    public OrderList()
    {
        this.m_Name = "Замовлення";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString() + "," + ((int)UserTypeEnum.Photographer).ToString()
            + "," + ((int)UserTypeEnum.Employee).ToString();
        BackURL = "~/Office/Office.aspx?content=OrderDashboard";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(Order);
    }


    protected override string GetEditableControlName()
    {
        return "OrderEdit";
    }
    protected override string[] GetPrimaryKeys()
    {
        return new string[] { "OrderID" };
    }

    public override void InitGrid()
    {
        base.InitGrid();
        this.editableGrid.GridMode = GridModes.Delete | GridModes.Edit | GridModes.Refresh;
        editableGrid.Width = 980;
        SetColumnSettings(Order.ColumnNames.OrderID, true, "Номер",
                0, HorizontalAlign.Center, "");
        SetColumnSettings(Order.ColumnNames.CellPhone, true, "Телефон", 0, HorizontalAlign.Center, "");
        SetColumnSettings("UserName", true, "Клієнт", 90, HorizontalAlign.Center, "");
        SetColumnSettings(Order.ColumnNames.ClientNote, true, "Примітка Клієнта", 0, HorizontalAlign.Left, "");
        SetColumnSettings(Order.ColumnNames.OfficeNote, true, "Примітка працівників фотосалону", 0, HorizontalAlign.Left, "");
        SetColumnSettings(Order.ColumnNames.PhotoCount, true, "Кількість фото", 60, HorizontalAlign.Center, "");
        SetColumnSettings(Order.ColumnNames.Amount, true, "Вартість, грн.", 60, HorizontalAlign.Center, "{0:f2}");
        SetColumnSettings(Order.ColumnNames.DateCreated, true, "Дата", 80, HorizontalAlign.Center, "{0:dd/MM/yyyy}");
    }

    protected override DataTable GetDataSource()
    {
        Order o = new Order();
        o.LoadByDeliveryIDAndOrderStatusID(DeliveryID, OrderStatusID);
        return o.DefaultView.Table;
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
                    int orderID = int.Parse(dataRowView["OrderID"].ToString());
                    string ftp = Utils.OrderFTPPath + "/" + orderID + "/";
                    e.Item.Cells[11].Text = "<a style='color:#a1a1a1' href='ftp://" + ftp + "' target='new'>" + ftp + "</a>";
                }
            }
        }
    }

    protected override void OnEditableGridDelete(object sender, EditableGridDeleteEventArgs e)
    {
        base.OnEditableGridDelete(sender, e);
        GridEditableItem gei = e.DeletedItem;
        string targetFolder = Server.MapPath(Utils.OrderImagePath + "//" + gei["OrderID"].Text + "//");
        if(Directory.Exists(targetFolder))
        {
            Directory.Delete(targetFolder, true);
        }
        targetFolder = Server.MapPath(Utils.PrintImagePath + "//" + gei["OrderID"].Text + "//");
        if (Directory.Exists(targetFolder))
        {
            Directory.Delete(targetFolder, true);
        }
    }

    private int DeliveryID
    {
        get
        {
            if (Request.Params["DeliveryID"] != null)
            {
                return int.Parse(Request.Params["DeliveryID"]);
            }
            return 0;
        }
    }

    private int OrderStatusID
    {
        get
        {
            if (Request.Params["OrderStatusID"] != null)
            {
                return int.Parse(Request.Params["OrderStatusID"]);
            }
            return 0;
        }
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        LoadTitle();
    }

    private void LoadTitle()
    {
        this.m_Name = "Замовлення";
        Delivery d = new Delivery();
        if (d.LoadByPrimaryKey(DeliveryID))
        {
            m_Name += " - " + d.s_Name1;
        }
        OrderStatus os = new OrderStatus();
        if(os.LoadByPrimaryKey(OrderStatusID))
        {
            m_Name += " (" + os.s_Name + ")";
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
