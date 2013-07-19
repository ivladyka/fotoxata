using System;
using VikkiSoft_BLL;


public partial class OrderStatusEdit : EditControlBase
{
    public OrderStatusEdit()
    {
        this.m_Name = "Статус Замовлення";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
        BackURL = "";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(OrderStatus);
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        text_Name.Focus();
    }
}
