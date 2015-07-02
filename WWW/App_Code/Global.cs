using System;
using System.Collections.Generic;
using System.Web;
using VikkiSoft_BLL;

namespace VikkiSoft.Ekran
{
    public class Global : System.Web.HttpApplication
    {
        void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Utils.SaveError(ex);
            Server.ClearError();
        }
    }
}