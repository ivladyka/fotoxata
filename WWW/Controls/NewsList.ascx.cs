using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VikkiSoft_BLL;

public partial class NewsList : ListControlBase, Interfaces.IColouredGrid
{
    public NewsList()
    {
        this.m_Name = "Новини";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
        BackURL = "~/Office/Office.aspx";
    }

    protected override string GetEditableControlName()
    {
        return "NewsEdit";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(VikkiSoft_BLL.News);
    }

    protected override string[] GetPrimaryKeys()
    {
        return new string[] { "NewsID" };
    }

    public override void InitGrid()
    {
        base.InitGrid();
        this.editableGrid.GridMode = GridModes.Add | GridModes.Delete
            | GridModes.Edit | GridModes.Refresh;
        editableGrid.AllowPaging = true;
        editableGrid.PageSize = 10;
        editableGrid.Width = 780;
        SetColumnSettings(VikkiSoft_BLL.News.ColumnNames.NewsID, false, VikkiSoft_BLL.News.ColumnNames.NewsID,
       0, HorizontalAlign.Center, "");
        SetColumnSettings(VikkiSoft_BLL.News.ColumnNames.Title, true, "Заголовок",
       0, HorizontalAlign.Center, "");
        SetColumnSettings(VikkiSoft_BLL.News.ColumnNames.Title_ru, false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings(VikkiSoft_BLL.News.ColumnNames.Title_en, false, "", 0, HorizontalAlign.Center, "");
        SetColumnSettings(VikkiSoft_BLL.News.ColumnNames.DateNews, true, "Дата",
          150, HorizontalAlign.Left, "{0:dd.MM.yyyy}");
        SetColumnSettings(VikkiSoft_BLL.News.ColumnNames.DateExpired, true, "Дата закінчення",
           150, HorizontalAlign.Left, "{0:dd.MM.yyyy}");
        SetColumnSettings(VikkiSoft_BLL.News.ColumnNames.NewsContent, false, "Новина",
           0, HorizontalAlign.Left, "");
        SetColumnSettings(VikkiSoft_BLL.News.ColumnNames.NewsContent_ru, false, "", 0, HorizontalAlign.Left, "");
        SetColumnSettings(VikkiSoft_BLL.News.ColumnNames.NewsContent_en, false, "", 0, HorizontalAlign.Left, "");
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
