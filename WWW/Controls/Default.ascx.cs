using System.Web.UI.HtmlControls;
using VikkiSoft_BLL;
using System.Web.UI.WebControls;
using System.IO;

public partial class Default : ControlBase
{
    public Default()
    {
        BackURL = "";
        AddOnlyBrowserTitle = true;
        m_Name = "Фотохата";
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        LoadGallery();
    }

    private void LoadGallery()
    {
        Gallery g = new Gallery();
        g.Where.CategoryID.Value = 81;
        if (g.Query.Load())
        {
            HtmlTableRow row = new HtmlTableRow();
            do
            {
                Image i = new Image();
                i.ImageUrl = Path.Combine(Utils.GaleryImagePath, g.PhotoName);
                gallery.Controls.Add(i);
            }
            while (g.MoveNext());
        }
    }
}
