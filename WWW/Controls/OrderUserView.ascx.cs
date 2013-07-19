using System;
using System.Web.UI.WebControls;
using VikkiSoft_BLL;


public partial class OrderUserView : EditControlBase
{
    public OrderUserView()
    {
        this.m_Name = "";
        this.AllowUserTypes = ((int)UserTypeEnum.User).ToString();
        BackURL = "~/Office/Office.aspx";
        
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
        this.m_Name = Resources.Fotoxata.OrderView;
            Order a = (Order)this.EditableEntity;
        lblClientNote.Text = a.s_ClientNote;
        lblPhotoCount.Text = a.PhotoCount.ToString();
        lblOfficeNote.Text = a.s_OfficeNote;
        lblAmount.Text = a.Amount.ToString("N");
        lblDateCreated.Text = a.DateCreated.ToString("dd/MM/yyyy");
        if(!LoggedUser.IsAdmin() && !LoggedUser.IsEmployee() && !LoggedUser.IsPhotographer())
        {
            if(UserSession.UserID != a.UserID)
            {
                Response.Redirect("~/Default.aspx");
            }
          
        }
        
      if(!a.IsColumnNull(Order.ColumnNames.UserID))
        {
            VikkiSoft_BLL.User u = new User();
            if(u.LoadByPrimaryKey(a.UserID))
            {
                lblCellPhone.Text = u.s_CellPhone;
                lblUserName.Text = u.s_LastName + " " + u.s_FirstName;
            }
    }
      if (!a.IsColumnNull(Order.ColumnNames.OrderStatusID))
      {
          VikkiSoft_BLL.OrderStatus o = new OrderStatus();
          if (o.LoadByPrimaryKey(a.OrderStatusID))
          {
              if (!o.IsColumnNull("Name" + Utils.LangPrefix))
              {
                  lblOrderStatus.Text = o.GetColumn("Name" + Utils.LangPrefix).ToString();
              }
          }
      }
    }

        public string Phone
        {
            get
            {
                return Resources.Fotoxata.Phone;
            }
        }

        public string Surname
        {
            get
            {
                return Resources.Fotoxata.Surname;
            }
        }

        public string ClientNote
        {
            get
            {
                return Resources.Fotoxata.ClientNote;
            }
        }

        public string OrderDate
        {
            get
            {
                return Resources.Fotoxata.OrderDate;
            }
        }

        public string PhotoCount
        {
            get
            {
                return Resources.Fotoxata.PhotoCount;
            }
        }

        public string Cost
        {
            get
            {
                return Resources.Fotoxata.Cost;
            }
        }

        public string OrderStatus
        {
            get
            {
                return Resources.Fotoxata.OrderStatus;
            }
        }

        public string Grn
        {
            get
            {
                return Resources.Fotoxata.Grn;
            }
        }

        public string PhotoNotice
        {
            get
            {
                return Resources.Fotoxata.PhotoNotice;
            }
        }
}
