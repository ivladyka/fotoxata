using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VikkiSoft_BLL;

public partial class OrderUserList : ListControlBase, Interfaces.IColouredGrid
{
   public OrderUserList()
    {
        this.m_Name = "Замовлення";
        this.AllowUserTypes = ((int)UserTypeEnum.User).ToString();
        BackURL = "~/Office/Office.aspx?content=OrderDashboard";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(Order);
    }


    protected override string GetEditableControlName()
    {
        return "OrderUserView";
    }
    protected override string[] GetPrimaryKeys()
    {
        return new string[] { "OrderID" };
    }

    public override void InitGrid()
    {
        base.InitGrid();
        this.editableGrid.GridMode = GridModes.Delete | GridModes.Edit | GridModes.Refresh;
        editableGrid.Width = 970;
        SetColumnSettings(Order.ColumnNames.OrderID, false, Order.ColumnNames.OrderID,
                0, HorizontalAlign.Center, "");
        SetColumnSettings(Order.ColumnNames.CellPhone, true, "Телефон", 0, HorizontalAlign.Center, "");
        SetColumnSettings("OrderStatus", false, "", 00, HorizontalAlign.Center, "");
        SetColumnSettings("OrderStatus_ru", false, "", 00, HorizontalAlign.Center, "");
        SetColumnSettings("OrderStatus_en", false, "", 00, HorizontalAlign.Center, "");
        SetColumnSettings("OrderStatus" + Utils.LangPrefix, true, Resources.Fotoxata.OrderStatus, 90, HorizontalAlign.Center, "");
        SetColumnSettings("UserName", true, "Клієнт", 90, HorizontalAlign.Center, "");
        SetColumnSettings(Order.ColumnNames.ClientNote, true, Resources.Fotoxata.ClientNote, 0, HorizontalAlign.Left, "");
        SetColumnSettings(Order.ColumnNames.OfficeNote, true, Resources.Fotoxata.PhotoNotice, 0, HorizontalAlign.Left, "");
        SetColumnSettings(Order.ColumnNames.PhotoCount, true, Resources.Fotoxata.PhotoCount, 60, HorizontalAlign.Center, "");
        SetColumnSettings(Order.ColumnNames.Amount, true, Resources.Fotoxata.Cost, 60, HorizontalAlign.Center, "{0:f2}");
        SetColumnSettings(Order.ColumnNames.DateCreated, true, Resources.Fotoxata.Date, 80, HorizontalAlign.Center, "{0:dd/MM/yyyy}");
    }

    protected override DataTable GetDataSource()
    { 
        Order o = new Order();
        o.LoadByUserID(UserSession.UserID);
        return o.DefaultView.Table;
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
        this.m_Name = Resources.Fotoxata.Order;
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

