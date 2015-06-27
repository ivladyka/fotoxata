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
            Error err = new Error();
            err.AddNew();
            err.Date = DateTime.Now;
            err.StackTrace = ex.StackTrace;
            err.Name = ex.Message;
            err.Browser = System.Web.HttpContext.Current.Request.Browser.Browser;
            err.Description = ex.Message;
            err.Save();

            Server.ClearError();
        }
    }
}