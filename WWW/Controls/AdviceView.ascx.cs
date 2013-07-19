using System;
using VikkiSoft_BLL;

public partial class AdviceView : EditControlBase
{
    public AdviceView()
    {
        this.m_Name = "";
        BackURL = "~/Default.aspx?content=AdviceTableList";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(Advice);
    }

    protected override void ReadDataFromEntity()
    {
        base.ReadDataFromEntity();
        Advice a = (Advice)this.EditableEntity;
        if (!a.IsColumnNull("Question" + Utils.LangPrefix))
        {
            this.m_Name = a.GetColumn("Question" + Utils.LangPrefix).ToString();
        }
        if (!a.IsColumnNull("Answer" + Utils.LangPrefix))
        {
            editor_Answer.Html = a.GetColumn("Answer" + Utils.LangPrefix).ToString();
        }
        hlBAckAdviceList.Text = Resources.Fotoxata.BackAdviceList + " >>";
    }
}
