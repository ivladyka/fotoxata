using System;
using VikkiSoft_BLL;


public partial class PhotoSalonEdit : EditControlBase
{
    public PhotoSalonEdit()
    {
        this.m_Name = "Фотосалон";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
        BackURL = "~/Office/Office.aspx?content=PhotoSalonList";
    }
    protected override Type GetEditableEntityType()
    {
        return typeof(PhotoSalon);
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        text_Address.Focus();
    }
    protected override void RedirectBackToList()
    {
        if (upload_ButtonImage.IsPhotoDeleted)
        {
            upload_ButtonImage.DeletePhoto();
        }
        base.RedirectBackToList();
    }
}