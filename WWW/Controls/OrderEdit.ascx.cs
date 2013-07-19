using System;
using System.Web.UI.WebControls;
using VikkiSoft_BLL;

public partial class OrderEdit : EditControlBase
{
    public OrderEdit()
    {
        this.m_Name = "Замовлення";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString() + "," + ((int)UserTypeEnum.Photographer).ToString()
            + "," + ((int)UserTypeEnum.Employee).ToString();
        BackURL = ""; 
    }
        protected override void WriteDataToEntity()
        {
            base.WriteDataToEntity();

            if (IsNew)
            {
                Order m = (Order)this.EditableEntity;
                
            }
        }

    protected override Type GetEditableEntityType()
    {
        return typeof(Order);
    }
        protected override void ReadDataFromEntity()
    {
        base.ReadDataFromEntity();
        Order a = (Order)this.EditableEntity;
        lblCellPhone.Text = a.s_CellPhone;
        lblClientNote.Text = a.s_ClientNote;
        if (!a.IsColumnNull("PhotoCount"))
        {
            lblPhotoCount.Text = a.PhotoCount.ToString();
        }
        if (!a.IsColumnNull("Amount"))
        {
            lblAmount.Text = a.Amount.ToString("N");
        }
        lblDateCreated.Text = a.DateCreated.ToString("dd/MM/yyyy");
        
      if(!a.IsColumnNull(Order.ColumnNames.UserID))
        {
            VikkiSoft_BLL.User u = new User();
            if(u.LoadByPrimaryKey(a.UserID))
            {
                lblCellPhone.Text = u.s_CellPhone;
                lblUserName.Text = u.s_LastName + " " + u.s_FirstName;
            }
       
    }
 
    }
}
