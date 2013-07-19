using System;
using System.Web.UI.HtmlControls;

public partial class Interesting : ControlBase
{
    public Interesting()
	{
        AddOnlyBrowserTitle = true;
        m_Name = "Цікаве";
	}

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        SetClientOnMouseEvents("vikki_top103", imgAnecdote);
        SetClientOnMouseEvents("vikki_top105", imgRidiculousphoto);
        SetClientOnMouseEvents("vikki_top107", imgTravel);
        SetClientOnMouseEvents("vikki_top108", imgCase);

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
