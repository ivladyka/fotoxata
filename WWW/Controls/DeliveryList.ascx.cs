using System;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VikkiSoft_BLL;

public partial class DeliveryList : ListControlBase, Interfaces.IColouredGrid
{
    public DeliveryList()
	{
		this.m_Name = "Доставка";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
        BackURL = "~/Office/Office.aspx";
	}

	protected override string GetEditableControlName()
	{
        return "DeliveryEdit";
	}

	protected override Type GetEditableEntityType()
	{
        return typeof(Delivery);
	}

	protected override string[] GetPrimaryKeys()
	{
        return new string[] { "DeliveryID" };
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        EditInModalWindow = true;
        ModaldialogHeight = 320;
        ModaldialogWidth = 490;
    }
	public override void InitGrid()
	{
		base.InitGrid ();
		this.editableGrid.GridMode = GridModes.Add | GridModes.Delete
			| GridModes.Edit | GridModes.Refresh;				
		editableGrid.Width = 700;
        SetColumnSettings(Delivery.ColumnNames.DeliveryID, false, Delivery.ColumnNames.DeliveryID,
				0, HorizontalAlign.Center, "");
        SetColumnSettings(Delivery.ColumnNames.Name, true, "Доставка",
           0, HorizontalAlign.Left, "");
        SetColumnSettings(Delivery.ColumnNames.Name_ru, false, "", 0, HorizontalAlign.Left, "");
        SetColumnSettings(Delivery.ColumnNames.Name_en, false, "", 0, HorizontalAlign.Left, "");
        SetColumnSettings(Delivery.ColumnNames.Active, true, "Діюча",
           40, HorizontalAlign.Center, "");
        SetColumnSettings(Delivery.ColumnNames.Name1, true, "Альтернативна Назва",
           0, HorizontalAlign.Left, "");
        SetColumnSettings(Delivery.ColumnNames.Name1_ru, false, "", 0, HorizontalAlign.Left, "");
        SetColumnSettings(Delivery.ColumnNames.Name1_en, false, "", 0, HorizontalAlign.Left, "");
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
