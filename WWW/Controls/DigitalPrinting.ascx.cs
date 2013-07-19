using System.Web.UI.HtmlControls;

public partial class DigitalPrinting : ControlBase
{
    public DigitalPrinting()
	{
        AddOnlyBrowserTitle = true;
        m_Name = "Цифровий фотодрук";
        BackURL = "Default.aspx?content=PhotoFacility";
	}
    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
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