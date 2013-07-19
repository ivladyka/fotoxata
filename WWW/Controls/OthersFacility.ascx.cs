using System.Web.UI.HtmlControls;

public partial class OthersFacility : ControlBase
{
    public OthersFacility()
	{
        AddOnlyBrowserTitle = true;
        m_Name = "Інші послуги";
        BackURL = "Default.aspx";
	}
    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        SetClientOnMouseEvents("vikki_top70", imgLamination);
        SetClientOnMouseEvents("vikki_top71", imgPrintText);
        SetClientOnMouseEvents("vikki_top72", imgInteryer);
        SetClientOnMouseEvents("vikki_top73", imgXerox);
        SetClientOnMouseEvents("vikki_top74", imgСartridge);
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