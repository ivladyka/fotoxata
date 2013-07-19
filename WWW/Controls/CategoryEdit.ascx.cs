using System;
using VikkiSoft_BLL;
using Telerik.Web.UI;

public partial class CategoryEdit : EditControlBase
{
    public CategoryEdit()
    {
        this.m_Name = "розділ";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
        BackURL = "";
    }
    protected override Type GetEditableEntityType()
    {
        return typeof(Category);
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        if(IsNew)
        {
            text_Name.Focus();
            /*rtsCategory.Tabs[1].Enabled = false;
            rtsCategory.Tabs[2].Enabled = false;*/
            rtsCategory.Visible = false;
        }
    }

    protected override void RedirectBackToList()
    {
        if (IsNew && ReturnValue == "Save")
        {
            Category c = (Category)this.EditableEntity;
            this.Response.Redirect("Office.aspx?content=CategoryEdit&CategoryID=" + c.CategoryID);
        }
        else
        {
            Response.Redirect("Office.aspx?content=CategoryList");
        }
    }

    protected void rtsCategory1_TabClick(object sender, RadTabStripEventArgs e)
    {
        switch (e.Tab.Text)
        {
            case "Категорія":
                pnlCategoryEdit.Visible = true;
                pnlGalleryList.Visible = false;
                pnlMerchandiseList.Visible = false;
                break;
            case "Фотографії":
                pnlCategoryEdit.Visible = false;
                pnlGalleryList.Visible = true;
                GalleryList.RebindGrid();
                pnlMerchandiseList.Visible = false;
                break;
            case "Товари":
                pnlCategoryEdit.Visible = false;
                pnlGalleryList.Visible = false;
                pnlMerchandiseList.Visible = true;
                merchandiseList.RebindGrid();
                break;
        }
    }
}
