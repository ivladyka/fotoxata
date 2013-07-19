using System;
using VikkiSoft_BLL;

public partial class AdviceEdit : EditControlBase
{
    public AdviceEdit()
    {
        this.m_Name = "Пораду";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
        BackURL = "";
    }
    protected override Type GetEditableEntityType()
    {
        return typeof(Advice);
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        text_Question.Focus();
    }

    protected override void RedirectBackToList()
    {

        base.RedirectBackToList();
    }
}
