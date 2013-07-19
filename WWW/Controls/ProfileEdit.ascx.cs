using System;
using System.Web.UI.WebControls;
using VikkiSoft_BLL;

public partial class ProfileEdit : EditControlBase
{
    public ProfileEdit()
    {
        this.m_Name = "Користувача";
        BackURL = "~/Default.aspx";
    }

    protected override Type GetEditableEntityType()
    {
        return typeof(User);
    }

    protected override void ReadDataFromEntity()
    {
        base.ReadDataFromEntity();
        VikkiSoft_BLL.User u = (VikkiSoft_BLL.User)this.EditableEntity;
        this.text_Password.Text = Encrypt.DecryptRijndael(u.Password);
        this.tbPassword1.Text = Encrypt.DecryptRijndael(u.Password);
        if(UserSession.UserID != UserID && !IsNew)
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        text_FirstName.Focus();
        LoadUserTypeCBL();
        if (!IsNew || Utils.LangPrefix == "_en")
        {
            rowAffreement.Visible = false;
        }
    }

    private void LoadUserTypeCBL()
    {
        UserType ut = new UserType();
        if (ut.LoadByUserID(UserID))
        {
            do
            {
                ListItem li = new ListItem();
                li.Value = ut.UserTypeID.ToString();
                li.Text = ut.Name;

            } 
            while (ut.MoveNext());
        }
    }

    private int UserID
    {
        get
        {
            if(Request.Params["UserID"] != null)
            {
                return int.Parse(Request.Params["UserID"]);
            }
            return 0;
        }
    }

    protected override void WriteDataToEntity()
    {
        base.WriteDataToEntity();
        VikkiSoft_BLL.User u = (VikkiSoft_BLL.User)this.EditableEntity;
        u.Password = Encrypt.EncryptRijndael(text_Password.Text);
        if(IsNew)
        {
            u.Active = true;
        }
    }

    protected override void RedirectBackToList()
    {
        if(ReturnValue == "Save" && IsNew)
        {
            VikkiSoft_BLL.User u = (VikkiSoft_BLL.User)this.EditableEntity;
            UserUserType uut = new UserUserType();
            uut.AddNew();
            uut.UserID = u.UserID;
            uut.UserTypeID = 4;
            uut.Save();
        }
        Response.Redirect("~/Default.aspx");
    }

    public string FirstName
    {
        get
        {
            return Resources.Fotoxata.FirstName;
        }
    }

    public string Surname
    {
        get
        {
            return Resources.Fotoxata.Surname;
        }
    }

    public string Phone
    {
        get
        {
            return Resources.Fotoxata.Phone;
        }
    }

    public string Password
    {
        get
        {
            return Resources.Fotoxata.Password;
        }
    }

    public string PasswordConfirm
    {
        get
        {
            return Resources.Fotoxata.PasswordConfirm;
        }
    }

    public string Agreement
    {
        get
        {
            return Resources.Fotoxata.Agreement;
        }
    }
}