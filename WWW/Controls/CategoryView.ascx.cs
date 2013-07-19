using System;
using VikkiSoft_BLL;

public partial class CategoryView : EditControlBase
{
    public CategoryView()
    {
        this.m_Name = "";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(Category);
    }

    protected override void ReadDataFromEntity()
    {
        base.ReadDataFromEntity();
        Category c = (Category)this.EditableEntity;
        if (c.IsColumnNull("Title" + Utils.LangPrefix) || c.GetColumn("Title" + Utils.LangPrefix).ToString().Trim() == "")
        {
            this.m_Name = c.GetColumn("Name" + Utils.LangPrefix).ToString();
        }
        else
        {
            this.m_Name = c.GetColumn("Title" + Utils.LangPrefix).ToString();
        }
        if (!c.IsColumnNull("CategoryContent" + Utils.LangPrefix))
        {
            lblCategoryContent.Text = c.GetColumn("CategoryContent" + Utils.LangPrefix).ToString();
        }
    }
}
