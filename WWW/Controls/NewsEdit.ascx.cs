using System;

public partial class NewsEdit : EditControlBase
{
    public NewsEdit()
    {
        this.m_Name = "новину";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(VikkiSoft_BLL.News);
    }

    protected override void InitOnFirstLoading()
    {
        if (IsNew)
        {
            date_DateNews.SelectedDate = DateTime.Now;
            date_DateExpired.SelectedDate = DateTime.Now.AddMonths(1);
        }
        base.InitOnFirstLoading();
        text_Title.Focus();
    }
}
