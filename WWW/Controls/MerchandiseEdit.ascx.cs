using System;
using VikkiSoft_BLL;

public partial class MerchandiseEdit : EditControlBase
{
    public MerchandiseEdit()
    {
        this.m_Name = "Товар";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
        BackURL = "";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(Merchandise);
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        text_Name.Focus();
    }

    protected override void WriteDataToEntity()
    {
        base.WriteDataToEntity();
        if (IsNew)
        {
            Merchandise m = (Merchandise) this.EditableEntity;
            m.CategoryID = CategoryID;
        }
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

    protected override void RedirectBackToList()
    {
        if (upload_PhotoName.IsPhotoDeleted)
        {
            upload_PhotoName.DeletePhoto();
        }
        base.RedirectBackToList();
    }
}
