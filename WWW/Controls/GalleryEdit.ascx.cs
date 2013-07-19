using System;
using System.IO;
using Telerik.Web.UI;
using VikkiSoft_BLL;

public partial class GalleryEdit : EditControlBase
{
    public GalleryEdit()
    {
        this.m_Name = "Фотографію";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
        BackURL = "";
    }
    protected override Type GetEditableEntityType()
    {
        return typeof(Gallery);
    }

    protected override void OnSave()
    {
        string targetFolder = Server.MapPath(Utils.GaleryImagePath);
        foreach (UploadedFile af in auFile.UploadedFiles)
        {
            string newGUID = Guid.NewGuid().ToString();
            string newFileName = newGUID + ".jpg";
            string path = Path.Combine(targetFolder, newFileName);
            af.SaveAs(path, true);
            Gallery g = new Gallery();
            g.AddNew();
            g.CategoryID = CategoryID;
            g.PhotoName = newFileName;
            g.Save();
            try
            {
                System.IO.FileStream fs = System.IO.File.OpenRead(Path.Combine(targetFolder, newFileName));
                byte[] b = new byte[fs.Length];
                fs.Read(b, 0, b.Length);
                newFileName = newGUID + "_s.jpg";
                Utils.ResizeAndSaveJpgImage(b, 2000, 100, Path.Combine(targetFolder, newFileName), false);
            }
            catch{}
        }
        Response.Redirect("Office.aspx?content=CategoryEdit&CategoryID=" + CategoryID);
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        btnUpdate.Attributes["onclick"] = "return VIKKI_CheckUploadedFiles();";
        auFile.TemporaryFolder = Utils.GaleryImagePath + "/RadUploadTemp";
    }

    private int CategoryID
    {
        get
        {
            if (Request.Params["CategoryID"] != null)
            {
                return int.Parse(Request.Params["CategoryID"]);
            }
            return 0;
        }
    }
}
