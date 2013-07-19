using System;
using System.Web;
using System.Web.Security;
using VikkiSoft_BLL;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            string s = Request.Params["ReturnUrl"];
            s = GetReturnUrl(s);
            Response.Redirect(s);
        }
        if (!Page.IsPostBack)
        {
            btnLogin.ImageUrl = "~/NewImages/entrance" + Utils.LangPrefix + ".gif";
            btnLogin.Attributes["onmouseover"] = "VIKKI_PuzzleOnMouseOver(event, 'NewImages/entrance1" + Utils.LangPrefix + ".gif' );";
            btnLogin.Attributes["onmouseout"] = "VIKKI_PuzzleOnMouseOver(event, 'NewImages/entrance" + Utils.LangPrefix + ".gif' );";
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (string.Empty != tbCellPhoneNumber.Text && string.Empty != tbPassword.Text)
        {
            VikkiSoft_BLL.User u = new User();
            u.Where.CellPhone.Value = tbCellPhoneNumber.Text;
            u.Where.Password.Value = Encrypt.EncryptRijndael(tbPassword.Text);
            u.Where.Active.Value = true;
            if (u.Query.Load())
            {
                HttpCookie authCookie = FormsAuthentication.GetAuthCookie(u.UserID.ToString(), chkKeepInSystem.Checked);
                Response.Cookies.Add(authCookie);

                string s = FormsAuthentication.GetRedirectUrl(u.UserID.ToString(), chkKeepInSystem.Checked);
                s = GetReturnUrl(s);

                string jscript = "<script language='javascript'>\n "
                    + "VIKKI_RedirectFromLoginPage('" + s
                    + "', '" + Encrypt.EncryptRijndael(u.UserID.ToString()) + "');\n"
                    + "</script>";
                if (!Page.IsStartupScriptRegistered("RedirectFromLoginPageScript"))
                {
                    Page.RegisterStartupScript("RedirectFromLoginPageScript", jscript);
                }
            }
            else
            {
                lbNotFound.Visible = true;
            }
        }
    }

    private string GetReturnUrl(string ReturnUrl)
    {
        if (ReturnUrl == null) ReturnUrl = "~/Default.aspx";
        return ReturnUrl;
    }

    public string LogInSystem
    {
        get
        {
            return Resources.Fotoxata.LogInSystem;
        }
    }

    public string MobilePhone
    {
        get
        {
            return Resources.Fotoxata.MobilePhone;
        }
    }

    protected override void InitializeCulture()
    {
        Utils.InitCulture();
        base.InitializeCulture();
    }

    public string Password
    {
        get
        {
            return Resources.Fotoxata.Password;
        }
    }

    public string StayLogged
    {
        get
        {
            return Resources.Fotoxata.StayLogged;
        }
    }
}
