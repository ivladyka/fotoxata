using System.Web.UI.HtmlControls;

public partial class OfficeMenu : ControlBase
{
    public OfficeMenu()
	{
        this.m_Name = "ON-LINE - Фотохата";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString() + "," + ((int)UserTypeEnum.Photographer).ToString()
            + "," + ((int)UserTypeEnum.Employee).ToString();
	}
    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();

        bool isAdmin = LoggedUser.IsAdmin();
        if (isAdmin)
        {
            liOrderStatus.Visible = true;
            liUsers.Visible = true;
            liPhotoSalon.Visible = true;
            liCategory.Visible = true;
            liAdvice.Visible = true;
            liDelivery.Visible = true;
            liNews.Visible = true;
            liDeleteOrders.Visible = true;
        }
    }

    private void SetClientOnMouseEvents(string imageName, HtmlImage img)
    {
        string defaultPrefix = "";
        if (Request.Url.PathAndQuery.IndexOf("/Office/") != -1)
        {
            defaultPrefix = "../";
        }
        img.Attributes["onmouseover"] = "VIKKI_PuzzleOnMouseOver(event, '" + defaultPrefix
            + "Images/" + imageName + "2.png');";
        img.Attributes["onmouseout"] = "VIKKI_PuzzleOnMouseOver(event, '" + defaultPrefix
            + "Images/" + imageName + "1.png');";
    }
}