using System;
using VikkiSoft_BLL;

public partial class DeliveryEdit : EditControlBase
{
    public DeliveryEdit()
    {
        this.m_Name = "Доставку";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
        BackURL = "";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(Delivery);
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        text_Name.Focus();
    }
}
