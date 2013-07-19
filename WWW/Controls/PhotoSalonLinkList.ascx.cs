using System.Web.UI.HtmlControls;

public partial class PhotoSalonLinkList : ControlBase
{
    public PhotoSalonLinkList()
    {
        
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        LoadPhotoSalonLink();
        m_Name = Resources.Fotoxata.Contacts;
    }

    private void LoadPhotoSalonLink()
    {
        const int countCells = 2;
        HtmlTableRow row = new HtmlTableRow();
        VikkiSoft_BLL.PhotoSalon ps = new VikkiSoft_BLL.PhotoSalon();
        if (ps.Query.Load())
        {
            do
            {
                if (row.Cells.Count >= countCells)
                {
                    tblPhotoSalons.Rows.Add(row);
                    row = new HtmlTableRow();
                }

                row.Cells.Add(AddTableCell("<a class='titleNewslink' href='Default.aspx?content=PhotoSalonView&PhotoSalonID="
                    + ps.PhotoSalonID + "'><img class='GaleryThImageStyle' src='Images/WEBSite/" + ps.s_ButtonImage + "'><br><br>"
                    + (!ps.IsColumnNull("Address" + Utils.LangPrefix) ? ps.GetColumn("Address" + Utils.LangPrefix).ToString() : "") +
                    "</a><br><br>"));
            }
            while (ps.MoveNext());
        }
        for (int i = row.Cells.Count; i < countCells; i++)
        {
            row.Cells.Add(AddTableCell("&nbsp;"));
        }
        tblPhotoSalons.Rows.Add(row);

    }

    private static HtmlTableCell AddTableCell(string innerHtml)
    {
        HtmlTableCell cell = new HtmlTableCell();
        cell.InnerHtml = innerHtml;
        cell.Align = "center";
        cell.VAlign = "top";
        return cell;
    }
   }

