using System;
using System.Drawing;
using System.Net.Mail;
using VikkiSoft_BLL;

public partial class ForgotPassword : ControlBase
{
    public ForgotPassword()
	{
		
	}

    override protected void SetEventHandlers()
    {
        this.m_Name = Resources.Fotoxata.ForgotPassword;
        base.SetEventHandlers();
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        btnSendPassword.ImageUrl = "../NewImages/send" + Utils.LangPrefix + ".gif";
        btnSendPassword.Attributes["onmouseover"] = "VIKKI_PuzzleOnMouseOver(event, 'NewImages/send1" + Utils.LangPrefix + ".gif' );";
        btnSendPassword.Attributes["onmouseout"] = "VIKKI_PuzzleOnMouseOver(event, 'NewImages/send" + Utils.LangPrefix + ".gif' );";
    }

    protected void btnSendPassword_Click(object sender, EventArgs e)
    {
        if (string.Empty != tbCellPhoneNumber.Text)
        {
            lbNotFound.Visible = true;
            User u = new User();
            u.Where.CellPhone.Value = tbCellPhoneNumber.Text;
            u.Where.Active.Value = true;
            if (u.Query.Load())
            {
                if(!u.IsColumnNull(User.ColumnNames.EMailAddress))
                {
                    if(u.EMailAddress.Trim() != "")
                    {
                        try
                        {
                            //Send E-mail
                            Utils.SendEmail(Resources.Fotoxata.PasswordEmailSubj, Resources.Fotoxata.YourPassword + ": " + Encrypt.DecryptRijndael(u.Password),
                                u.EMailAddress.Trim());
                            Response.Redirect("Default.aspx?content=ForgotPassworded");
   }
                        catch (Exception ex)
                        {
                            ShowMessage(ex.Message, Color.Red);
                        }
                    }
                }
                return;
            }
            ShowMessage(Resources.Fotoxata.ForgotPasswordAlert, Color.Red);
        }
    }

    private void ShowMessage(string message, Color color)
    {
        lbNotFound.Text = message;
        lbNotFound.ForeColor = color;
    }

    public string ForgotPasswordMessage
    {
        get
        {
            return Resources.Fotoxata.ForgotPasswordMessage;
        }
    }

    public string MobilePhone
    {
        get
        {
            return Resources.Fotoxata.MobilePhone;
        }
    }
}
