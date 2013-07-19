using System;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VikkiSoft_BLL;

public partial class UserList : ListControlBase, Interfaces.IColouredGrid
{
    public UserList()
	{
		this.m_Name = "Користувачі";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
        BackURL = "~/Office/Office.aspx";
	}

	protected override string GetEditableControlName()
	{
        return "UserEdit";
	}

	protected override Type GetEditableEntityType()
	{
        return typeof(User);
	}

	protected override string[] GetPrimaryKeys()
	{
        return new string[] { "UserID" };
    }

	public override void InitGrid()
	{
		base.InitGrid ();
		this.editableGrid.GridMode = GridModes.Add | GridModes.Delete
			| GridModes.Edit | GridModes.Refresh;				
		editableGrid.Width = 800;
        SetColumnSettings(User.ColumnNames.UserID, false, User.ColumnNames.UserID,
				0, HorizontalAlign.Center, "");
        SetColumnSettings("CellPhone", true, "Телефон",
           0, HorizontalAlign.Center, "");
        SetColumnSettings("FirstName", true, "Ім`я",
           0, HorizontalAlign.Center, "");
        SetColumnSettings("LastName", true, "Прізвище",
           0, HorizontalAlign.Center, "");
        SetColumnSettings("Password", false, "Пароль",
           0, HorizontalAlign.Center, "");
        SetColumnSettings("EMailAddress", true, "E-mail",
           0, HorizontalAlign.Center, "");
        SetColumnSettings("UserTypeList", true, "Ролі",
           0, HorizontalAlign.Center, "");
        SetColumnSettings("PhotoSalonAddress", true, "Фотосалон",
           0, HorizontalAlign.Center, "");
        SetColumnSettings(User.ColumnNames.Active, true, "Активний",
           30, HorizontalAlign.Center, "");
	}

    protected override DataTable GetDataSource()
    {
        VikkiSoft_BLL.User u = new VikkiSoft_BLL.User();
        u.LoadWithPhotoSalonAddress();
        return u.DefaultView.Table;
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
