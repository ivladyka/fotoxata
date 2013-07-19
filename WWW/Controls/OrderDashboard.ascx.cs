using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using MyGeneration.dOOdads;
using Telerik.Web.UI;
using VikkiSoft_BLL;

public partial class OrderDashboard : ListControlBase, Interfaces.IColouredGrid
{
    public OrderDashboard()
    {
        this.m_Name = "Замовлення";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString() + "," + ((int)UserTypeEnum.Photographer).ToString()
            + "," + ((int)UserTypeEnum.Employee).ToString();
        BackURL = "~/Office/Office.aspx";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(Delivery);
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        DeleteOldNotCompletedOrders();
    }

    protected override string[] GetPrimaryKeys()
    {
        return new string[] { "DeliveryID" };
    }

    public override void InitGrid()
    {
        base.InitGrid();
        this.editableGrid.GridMode = GridModes.Refresh;
        editableGrid.Width = 600;
        SetColumnSettings(Delivery.ColumnNames.Name1, true, "Доставка",
                0, HorizontalAlign.Center, "");
        SetColumnSettings(Delivery.ColumnNames.DeliveryID, false, Delivery.ColumnNames.DeliveryID,
                0, HorizontalAlign.Center, "");
        SetColumnSettings("NewOrder", true, "Нові",
                110, HorizontalAlign.Center, "");
        SetColumnSettings("CompletedWorkOrder", true, "Роздруковано",
                110, HorizontalAlign.Center, "");
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
                    int deliveryID = int.Parse(dataRowView["DeliveryID"].ToString());
                    e.Item.Cells[5].Text = GetImageTable(int.Parse(e.Item.Cells[5].Text), 1, deliveryID);
                    e.Item.Cells[6].Text = GetImageTable(int.Parse(e.Item.Cells[6].Text), 3, deliveryID);
                }
            }
        }
    }

    private string GetImageTable(int count, int orderStatusID, int deliveryID)
    {
        string imageName = "SmallYellow";
        if(count > 0)
        {
            imageName = "SmallRed";
        }
        string s = "<table border='0' style='border: none;' width='100%'><tr><td style='border: none;'>";
        if (count > 0)
        {
            s += "<a href='Office.aspx?content=OrderList&OrderStatusID="
                 + orderStatusID + "&DeliveryID=" + deliveryID + "'>";
        }
        s += "<img src='../NewImages/"
             + imageName + "1.gif' style='border-width:0px;'";
        if (count > 0)
        {
            s += " class='VIKKI_HandCursor' onmouseover=\"VIKKI_PuzzleOnMouseOver(event, '../NewImages/"
              + imageName + "2.gif' );\" onmouseout=\"VIKKI_PuzzleOnMouseOver(event, '../NewImages/"
              + imageName + "1.gif');\"";
        }
        s += "/>";
        if (count > 0)
        {
            s += "</a>";
        }
        s += "</td><td style='border: none;'>" + count + "</td></tr></table>";
        return s;
    }

    protected override DataTable GetDataSource()
    {
        Order o = new Order();
        o.LoadDashboard();
        return o.DefaultView.Table;
    }

    private void DeleteOldNotCompletedOrders()
    {
        Order o = new Order();
        o.Where.OrderStatusID.Operator = WhereParameter.Operand.IsNull;
        o.Where.DateCreated.Value = DateTime.Now.AddDays(-20);
        o.Where.DateCreated.Operator = WhereParameter.Operand.LessThan;
        if(o.Query.Load())
        {
            do
            {
                string targetFolder = Server.MapPath(Utils.OrderImagePath + "//" + o.OrderID + "//");
                if (Directory.Exists(targetFolder))
                {
                    Directory.Delete(targetFolder, true);
                }
            } while (o.MoveNext());
            o.DeleteAll();
            o.Save();
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
