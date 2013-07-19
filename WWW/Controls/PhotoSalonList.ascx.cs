using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VikkiSoft_BLL;

public partial class PhotoSalonList : ListControlBase, Interfaces.IColouredGrid
{
    public PhotoSalonList()
    {
        this.m_Name = "Фотосалони";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
        BackURL = "~/Office/Office.aspx";
    }

    protected override string GetEditableControlName()
    {
        return "PhotoSalonEdit";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(PhotoSalon);
    }

    protected override string[] GetPrimaryKeys()
    {
        return new string[] { "PhotoSalonID" };
    }


    public override void InitGrid()
    {
        base.InitGrid();
        this.editableGrid.GridMode = GridModes.Add | GridModes.Delete
            | GridModes.Edit | GridModes.Refresh;
        editableGrid.Width = 900;
        SetColumnSettings(PhotoSalon.ColumnNames.PhotoSalonID, false, PhotoSalon.ColumnNames.PhotoSalonID,
                0, HorizontalAlign.Center, "");
        SetColumnSettings("Address", true, "Адреса ", 0, HorizontalAlign.Center, "");
        SetColumnSettings("Address_ru", false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings("Address_en", false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings("Phone1", true, "Телефон ",
           0, HorizontalAlign.Center, "");
        SetColumnSettings("Phone2", true, "Телефон ",
           0, HorizontalAlign.Center, "");
        SetColumnSettings("Phone3", true, "Телефон ",
           0, HorizontalAlign.Center, "");
        SetColumnSettings(PhotoSalon.ColumnNames.Description, false, PhotoSalon.ColumnNames.Description,
           0, HorizontalAlign.Center, "");
        SetColumnSettings(PhotoSalon.ColumnNames.Description_ru, false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings(PhotoSalon.ColumnNames.Description_en, false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings(PhotoSalon.ColumnNames.Active, true, "Діючий ",
           100, HorizontalAlign.Center, "");
        SetColumnSettings(PhotoSalon.ColumnNames.ButtonImage, false, PhotoSalon.ColumnNames.ButtonImage,
           0, HorizontalAlign.Center, "");
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
