

using System.Web.UI.HtmlControls;
using VikkiSoft_BLL;

public partial class ScheduleList : ControlBase
{
    public ScheduleList()
    {
        this.m_Name = "Планування";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString() + "," + ((int)UserTypeEnum.Photographer).ToString()
            + "," + ((int)UserTypeEnum.Employee).ToString();
        BackURL = "~/Office/Office.aspx";
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        LoadScheduleLink();
    }

    private void LoadScheduleLink()
    {
        VikkiSoft_BLL.User u = new User();
        if (u.LoadPhotographer())
        {
            do
            {
                string photographerName = "";
                if (!u.IsColumnNull(User.ColumnNames.FirstName))
                {
                    photographerName = u.s_FirstName;
                }
                if (!u.IsColumnNull(User.ColumnNames.LastName))
                {
                    if (photographerName != "")
                    {
                        photographerName += " ";
                    }
                    photographerName += u.s_LastName;
                }
                if (photographerName == "")
                {
                    photographerName = u.s_CellPhone;
                }
                AddNewsRow(photographerName, u.UserID);
            }
            while (u.MoveNext());
        }
    }

    private void AddNewsRow(string title, int userID)
    {
        HtmlTableRow row = new HtmlTableRow();
        HtmlTableCell cell = new HtmlTableCell();
        cell.VAlign = "top";
        cell.InnerHtml = "<a style='font-size:11pt' href='Office.aspx?content=Schedule&uid=" + userID + "' class='VIKKI_ScheduleLink'>"
            + title + "</a>";

        row.Cells.Add(cell);
        tblScheduleLink.Rows.Add(row);
    }
}
