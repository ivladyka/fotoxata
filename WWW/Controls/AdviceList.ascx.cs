using System;
using System.Data;
using System.IO;
using Telerik.Web.UI;
using System.Web.UI.WebControls;
using VikkiSoft_BLL;

public partial class AdviceList : ListControlBase, Interfaces.IColouredGrid
{
    public AdviceList()
	{
		this.m_Name = "Фото-поради";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
        BackURL = "~/Office/Office.aspx";
	}

	protected override string GetEditableControlName()
	{
        return "AdviceEdit";
	}

	protected override Type GetEditableEntityType()
	{
        return typeof(Advice);
	}

	protected override string[] GetPrimaryKeys()
	{
        return new string[] { "AdviceID" };
    }

	public override void InitGrid()
	{
		base.InitGrid ();
		this.editableGrid.GridMode = GridModes.Add | GridModes.Delete
			| GridModes.Edit | GridModes.Refresh;				
		editableGrid.Width = 800;
        SetColumnSettings(Advice.ColumnNames.AdviceID, false, Advice.ColumnNames.AdviceID,
				0, HorizontalAlign.Center, "");
        SetColumnSettings(Advice.ColumnNames.Question, true, "Запитання",
           0, HorizontalAlign.Center, "");
        SetColumnSettings(Advice.ColumnNames.Question_ru, false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings(Advice.ColumnNames.Question_en, false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings(Advice.ColumnNames.Answer, false, Advice.ColumnNames.Answer,
           0, HorizontalAlign.Center, "");
        SetColumnSettings(Advice.ColumnNames.Answer_ru, false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings(Advice.ColumnNames.Answer_en, false, "", 0, HorizontalAlign.Center, "");
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
