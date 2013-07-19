using System;
using System.Web.UI.WebControls;
using VikkiSoft_BLL;


public partial class UserEdit : EditControlBase
{
    public UserEdit()
    {
        this.m_Name = "Користувача";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
        BackURL = "~/Office/Office.aspx?content=UserList";
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
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        text_FirstName.Focus();
        LoadUserTypeCBL();
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
                if (Utils.GetEntityValueInt(ut, "IsChecked") == 1)
                {
                    li.Selected = true;
                }
                cblUserType.Items.Add(li);
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
        if (choice_PhotoSalonID.SelectedText == "")
        {
            u.SetColumnNull(VikkiSoft_BLL.User.ColumnNames.PhotoSalonID);
        }
        
    }

    protected override void RedirectBackToList()
    {
        if (ReturnValue == "Save")
        {
            VikkiSoft_BLL.User u = (VikkiSoft_BLL.User) this.EditableEntity;
            int userID = u.UserID;
            foreach (ListItem it in cblUserType.Items)
            {
                try
                {
                    int userTypeID = int.Parse(it.Value);
                    bool isRole = it.Selected;
                    UserUserType uut = new UserUserType();
                    uut.Where.UserID.Value = userID;
                    uut.Where.UserTypeID.Value = userTypeID;
                    if (uut.Query.Load())
                    {
                        if (!isRole)
                        {
                            uut.DeleteAll();
                            uut.Save();
                        }
                    }
                    else
                    {
                        if (isRole)
                        {
                            uut.AddNew();
                            uut.UserID = userID;
                            uut.UserTypeID = userTypeID;
                            uut.Save();
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
        base.RedirectBackToList();
    }
}
