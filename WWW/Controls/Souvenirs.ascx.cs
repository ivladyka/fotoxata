using System;
using System.Web.UI.HtmlControls;

public partial class Souvenirs: ControlBase
{
    public Souvenirs()
	{
        AddOnlyBrowserTitle = true;
        m_Name = "Сувеніри";
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
