using System;
using VikkiSoft_BLL;

public partial class PhotoSalonView : EditControlBase
{
    public PhotoSalonView()
    {
        this.m_Name = "";
        BackURL = "~/Default.aspx?content=PhotoSalonLinkList";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(PhotoSalon);
    }

    protected override void ReadDataFromEntity()
    {
        base.ReadDataFromEntity();
        PhotoSalon a = (PhotoSalon)this.EditableEntity;
        this.m_Name = (!a.IsColumnNull("Address" + Utils.LangPrefix) ? a.GetColumn("Address" + Utils.LangPrefix).ToString() : "");
        lblPhones.Text = Resources.Fotoxata.Phone + ":" + FormatPhone(a.s_Phone1) + "<br/>" +  FormatPhone(a.s_Phone2) + "<br/>" +  FormatPhone(a.s_Phone3) + "</div>";
        if (!a.IsColumnNull("Description" + Utils.LangPrefix))
        {
            editor_Description.Html = a.GetColumn("Description" + Utils.LangPrefix).ToString();
        }
    }

    private string FormatPhone(string phone)
    {
        return phone.Replace("+38() ", "");

    }
}
