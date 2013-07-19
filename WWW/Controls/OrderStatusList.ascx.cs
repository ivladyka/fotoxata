using System;
using System.Web.UI.WebControls;
using VikkiSoft_BLL;

public partial class OrderStatusList : ListControlBase, Interfaces.IColouredGrid
{
    public OrderStatusList()
	{
        this.m_Name = "Статус Замовлення";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
        BackURL = "~/Office/Office.aspx";
	}

	protected override string GetEditableControlName()
	{
        return "OrderStatusEdit";
	}

	protected override Type GetEditableEntityType()
	{
        return typeof(OrderStatus);
	}

	protected override string[] GetPrimaryKeys()
	{
        return new string[] { "OrderStatusID" };
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        EditInModalWindow = true;
        ModaldialogHeight = 200;
        ModaldialogWidth = 400;
    }

    public override void InitGrid()
	{
		base.InitGrid ();
		this.editableGrid.GridMode = GridModes.Add | GridModes.Delete
			| GridModes.Edit | GridModes.Refresh;				
		editableGrid.Width = 500;
        SetColumnSettings(OrderStatus.ColumnNames.OrderStatusID, false, OrderStatus.ColumnNames.OrderStatusID,
		   0, HorizontalAlign.Center, "");
        SetColumnSettings(OrderStatus.ColumnNames.Name, true, "Назва",
           0, HorizontalAlign.Left, "");
        SetColumnSettings(OrderStatus.ColumnNames.Active, true, "Діючий",
           40, HorizontalAlign.Center, "");
        SetColumnSettings(OrderStatus.ColumnNames.Name_ru, false, "", 0, HorizontalAlign.Left, "");
        SetColumnSettings(OrderStatus.ColumnNames.Name_en, false, "", 0, HorizontalAlign.Left, "");
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
