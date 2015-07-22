using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net.Mail;
using MyGeneration.dOOdads;
using System.Web.UI.WebControls;
using VikkiSoft_BLL;
using System.Collections;
using System.Threading;
using System.Globalization;
using System.Web;

/// <summary>
/// Summary description for Utils
/// </summary>
public class Utils
{
    public static void ShowMessage(System.Web.UI.Control control, string message)
    {
        if (!control.Page.IsClientScriptBlockRegistered(control.ID + "_ERROR_MESSAGE"))
        {
            message = message.Replace("\r", "\\r");
            message = message.Replace("\n", "\\n");
            message = message.Replace("'", "\\'");
            message = message.Replace("\"", "\\");
            control.Page.RegisterClientScriptBlock(control.ID + "_ERROR_MESSAGE", "<script>alert(\"" + message + "\")</script>");
        }
    }

    public static bool IsPagePostBack(System.Web.UI.Page page)
    {
        if (page.IsPostBack)
            return true;

        return IsPageCallBack(page);
    }

    public static bool IsPageCallBack(System.Web.UI.Page page)
    {
        if (page.Request.Params["rcbID"] != null)
            return true;
        return false;
    }

    public static bool IsPagePostBack(System.Web.UI.UserControl control)
    {
        return IsPagePostBack(control.Page);
    }

    public static bool IsEmptyId(string id)
    {
        if (id == null || id == "")
            return true;
        return false;
    }

    public static bool IsValueNull(object value)
    {
        if (value == null || value == DBNull.Value)
            return true;
        return false;
    }

    public static bool GetEntityValueBool(SqlClientEntity entity, string columnName)
    {
        bool entityValueBoll = false;
        if (!entity.IsColumnNull(columnName))
        {
            try
            {
                entityValueBoll = Convert.ToBoolean(entity.GetColumn(columnName).ToString());
            }
            catch { }
        }
        return entityValueBoll;
    }

    public static int GetEntityValueInt(SqlClientEntity entity, string columnName)
    {
        int entityValueInt = 0;
        if (!entity.IsColumnNull(columnName))
        {
            try
            {
                entityValueInt = int.Parse(entity.GetColumn(columnName).ToString());
            }
            catch { }
        }
        return entityValueInt;
    }

    public static decimal GetEntityValueDecimal(SqlClientEntity entity, string columnName)
    {
        decimal entityValueDecimal = 0;
        if (!entity.IsColumnNull(columnName))
        {
            try
            {
                entityValueDecimal = Convert.ToDecimal(entity.GetColumn(columnName).ToString());
            }
            catch { }
        }
        return entityValueDecimal;
    }

    public static void ResizeAndSaveJpgImage(byte[] Content, int MaxWidth, int MaxHeigh, string pathSave,
        bool checkLandscape)
    {
        MemoryStream m = new MemoryStream();
        m.Write(Content, 0, Content.Length);
        Bitmap bmp = new Bitmap(m);
        if (checkLandscape && bmp.Width > bmp.Height)
        {
            int height = MaxWidth;
            MaxWidth = MaxHeigh;
            MaxHeigh = height;
        }
        float K = System.Math.Max((float)bmp.Width / MaxWidth, (float)bmp.Height / MaxHeigh);
        Rectangle oRectangle = new Rectangle(0, 0, (int)(bmp.Width / K), (int)(bmp.Height / K));

        System.Drawing.Image oThumbNail = new Bitmap(oRectangle.Width, oRectangle.Height, bmp.PixelFormat);
        Graphics oGraphic = Graphics.FromImage(oThumbNail);
        oGraphic.CompositingQuality = CompositingQuality.HighQuality;
        oGraphic.SmoothingMode = SmoothingMode.HighQuality;
        oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
        oGraphic.DrawImage(bmp, oRectangle);

        oThumbNail.Save(pathSave, System.Drawing.Imaging.ImageFormat.Jpeg);
    }

    public static string GaleryImagePath
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["GaleryImagePath"];
        }
    }

    public static void DeleteFile(string targetFolder, string fileName)
    {
        string filePath = Path.Combine(targetFolder, fileName);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    public static string OrderImagePath
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["OrderImagePath"];
        }
    }

    public static string OrderFTPPath
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["OrderFTPPath"];
        }
    }

    public static string FontPath
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["FontPath"];
        }
    }

    public static void SendEmail(string subject, string body, string toEmail)
    {
        try
        {
            int portNumber;
            int.TryParse(System.Configuration.ConfigurationManager.AppSettings["SMTPServerPort"],
                         out portNumber);
            SmtpClient client;
            if (portNumber > 0)
            {
                client = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["SMTPServer"], portNumber);
            }
            else
            {
                client = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["SMTPServer"]);
            }
            MailAddress from =
                new MailAddress(System.Configuration.ConfigurationManager.AppSettings["FromEmail"]);
            MailAddress to = new MailAddress(toEmail);
            // Specify the message content.
            MailMessage message = new MailMessage(from, to);
            message.Body = body;
            message.Subject = subject;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            if (System.Configuration.ConfigurationManager.AppSettings["EmailAccountPassword"].Trim() != "")
            {
                client.Credentials =
                    new System.Net.NetworkCredential(
                        System.Configuration.ConfigurationManager.AppSettings["FromEmail"],
                        System.Configuration.ConfigurationManager.AppSettings["EmailAccountPassword"]);
            }
            client.Send(message);
        }
        catch
        { }
    }

    public static void InitTopMenu(Menu menu)
    {
        Hashtable catTitles = new Hashtable();
        Category cat = new Category();
        if (cat.LoadTitle())
        {
            do
            {
                catTitles.Add(cat.CategoryID, cat.GetColumn("Title" + LangPrefix).ToString().ToUpper());
            } while (cat.MoveNext());
        }

        menu.Items.Clear();
        menu.Items.Add(AddMenuItem("~/Default.aspx?content=MerchandiseContentView", 70, catTitles));
        menu.Items.Add(AddMenuItem("~/Default.aspx?content=GalleryTableList", Resources.Fotoxata.Gallery.ToUpper()));
        menu.Items.Add(AddMenuItem("~/Default.aspx?content=TreeView", 75, catTitles));

        if (catTitles[76] != null)
        {
            MenuItem studioArtPhotos = AddMenuItem("~/Default.aspx?content=TreeView", 76, catTitles);
            AddMenuItem(studioArtPhotos.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 2, catTitles);
            AddMenuItem(studioArtPhotos.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 53, catTitles);
            AddMenuItem(studioArtPhotos.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 3, catTitles);
            AddMenuItem(studioArtPhotos.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 54, catTitles);
            AddMenuItem(studioArtPhotos.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 56, catTitles);
            AddMenuItem(studioArtPhotos.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 57, catTitles);
            AddMenuItem(studioArtPhotos.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 4, catTitles);
            AddMenuItem(studioArtPhotos.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 58, catTitles);
            AddMenuItem(studioArtPhotos.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 59, catTitles);
            menu.Items[2].ChildItems.Add(studioArtPhotos);
        }

        if (catTitles[77] != null)
        {
            MenuItem offsitePhotos = AddMenuItem("~/Default.aspx?content=TreeView", 77, catTitles);
            AddMenuItem(offsitePhotos.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 40, catTitles);
            AddMenuItem(offsitePhotos.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 41, catTitles);
            AddMenuItem(offsitePhotos.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 42, catTitles);
            AddMenuItem(offsitePhotos.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 43, catTitles);
            AddMenuItem(offsitePhotos.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 44, catTitles);
            AddMenuItem(offsitePhotos.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 45, catTitles);
            AddMenuItem(offsitePhotos.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 46, catTitles);
            menu.Items[2].ChildItems.Add(offsitePhotos);
        }

        if (catTitles[78] != null)
        {
            MenuItem digitalPrint = AddMenuItem("~/Default.aspx?content=TreeView", 78, catTitles);
            AddMenuItem(digitalPrint.ChildItems, "~/Default.aspx?content=MerchandiseContentView", 47, catTitles);
            AddMenuItem(digitalPrint.ChildItems, "~/Default.aspx?content=MerchandiseContentView", 48, catTitles);
            AddMenuItem(digitalPrint.ChildItems, "~/Default.aspx?content=OrderAdd", 9, catTitles);
            AddMenuItem(digitalPrint.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 50, catTitles);
            AddMenuItem(digitalPrint.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 51, catTitles);
            AddMenuItem(digitalPrint.ChildItems, "~/Default.aspx?content=GalleryPhotoView", 52, catTitles);
            menu.Items[2].ChildItems.Add(digitalPrint);
        }
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 11, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 65, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 72, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 83, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 27, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 38, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 37, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 33, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 26, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 1, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 10, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 36, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 29, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 34, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 5, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 28, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 35, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 39, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 60, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 61, catTitles);

        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 63, catTitles);
        AddMenuItem(menu.Items[2].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 64, catTitles);

        menu.Items.Add(AddMenuItem("~/Default.aspx?content=MerchandiseContentView", 6, catTitles));
        menu.Items.Add(AddMenuItem("~/Default.aspx?content=TreeView", 79, catTitles));
        AddMenuItem(menu.Items[4].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 73, catTitles);
        AddMenuItem(menu.Items[4].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 12, catTitles);
        AddMenuItem(menu.Items[4].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 13, catTitles);
        AddMenuItem(menu.Items[4].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 14, catTitles);
        AddMenuItem(menu.Items[4].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 15, catTitles);
        AddMenuItem(menu.Items[4].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 16, catTitles);
        AddMenuItem(menu.Items[4].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 17, catTitles);
        AddMenuItem(menu.Items[4].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 18, catTitles);
        AddMenuItem(menu.Items[4].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 19, catTitles);
        AddMenuItem(menu.Items[4].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 20, catTitles);
        AddMenuItem(menu.Items[4].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 21, catTitles);
        AddMenuItem(menu.Items[4].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 25, catTitles);
        AddMenuItem(menu.Items[4].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 22, catTitles);
        AddMenuItem(menu.Items[4].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 23, catTitles);
        AddMenuItem(menu.Items[4].ChildItems, "~/Default.aspx?content=GalleryPhotoView", 24, catTitles);

        menu.Items.Add(AddMenuItem("~/Default.aspx?content=NewsLinkList", Resources.Fotoxata.News.ToUpper()));
        menu.Items.Add(AddMenuItem("~/Default.aspx?pricePDF=true", Resources.Fotoxata.Price.ToUpper()));
        menu.Items.Add(AddMenuItem("~/Default.aspx?content=TreeView", 80, catTitles));
        menu.Items[7].ChildItems.Add(AddMenuItem("~/Default.aspx?content=AdviceTableList", Resources.Fotoxata.Advices.ToUpper()));
        AddMenuItem(menu.Items[7].ChildItems, "~/Default.aspx?content=MerchandiseContentView", 66, catTitles);
        AddMenuItem(menu.Items[7].ChildItems, "~/Default.aspx?content=MerchandiseContentView", 67, catTitles);
        AddMenuItem(menu.Items[7].ChildItems, "~/Default.aspx?content=MerchandiseContentView", 68, catTitles);
        AddMenuItem(menu.Items[7].ChildItems, "~/Default.aspx?content=MerchandiseContentView", 69, catTitles);

        menu.Items.Add(AddMenuItem("~/Default.aspx?content=PhotoSalonLinkList", Resources.Fotoxata.Contacts.ToUpper()));
    }

    private static void AddMenuItem(MenuItemCollection items, string url, int categotyID, Hashtable catTitles)
    {
        string title = "";
        if (catTitles[categotyID] != null)
        {
            title = catTitles[categotyID].ToString();
            items.Add(AddMenuItem(url + "&CategoryID=" + categotyID.ToString(), title, title));
        }
    }

    private static MenuItem AddMenuItem(string url, int categotyID, Hashtable catTitles)
    {
        string title = "";
        if (catTitles[categotyID] != null)
        {
            title = catTitles[categotyID].ToString();
        }
        return AddMenuItem(url + "&CategoryID=" + categotyID.ToString(), title, title);
    }

    private static MenuItem AddMenuItem(string url, string title)
    {
        return AddMenuItem(url, title, title);
    }

    private static MenuItem AddMenuItem(string url, string title, string description)
    {
        MenuItem item = new MenuItem();
        item.Text = description;
        item.ToolTip = title;
        item.NavigateUrl = url;
        return item;
    }

    public static string LangPrefix
    {
        get
        {
            string culture = "uk-UA";
            if (Thread.CurrentThread.CurrentCulture != null)
            {
                culture = Thread.CurrentThread.CurrentCulture.Name;
            }
            string prefCulture = "";
            switch (culture)
            {
                case "en-US":
                    prefCulture = "_en";
                    break;
                case "ru-RU":
                    prefCulture = "_ru";
                    break;
            }
            return prefCulture;
        }
    }

    public static void InitFooterMenu(Menu menu)
    {
        Hashtable catTitles = new Hashtable();
        Category cat = new Category();
        if (cat.LoadTitle())
        {
            do
            {
                catTitles.Add(cat.CategoryID, cat.GetColumn("Title" + LangPrefix).ToString().ToUpper());
            } while (cat.MoveNext());
        }

        menu.Items.Clear();
        menu.Items.Add(AddMenuItem("~/Default.aspx?content=MerchandiseContentView", 70, catTitles));
        menu.Items.Add(AddMenuItem("~/Default.aspx?content=GalleryTableList", Resources.Fotoxata.Gallery.ToUpper()));
        menu.Items.Add(AddMenuItem("~/Default.aspx?content=TreeView", 75, catTitles));
        menu.Items.Add(AddMenuItem("~/Default.aspx?content=MerchandiseContentView", 6, catTitles));
        menu.Items.Add(AddMenuItem("~/Default.aspx?content=TreeView", 79, catTitles));
        menu.Items.Add(AddMenuItem("~/Default.aspx?content=NewsLinkList", Resources.Fotoxata.News.ToUpper()));
        menu.Items.Add(AddMenuItem("~/Default.aspx?pricePDF=true", Resources.Fotoxata.Price.ToUpper()));
        menu.Items.Add(AddMenuItem("~/Default.aspx?content=TreeView", 80, catTitles));
        menu.Items.Add(AddMenuItem("~/Default.aspx?content=PhotoSalonLinkList", Resources.Fotoxata.Contacts.ToUpper()));
        menu.Items.Add(AddMenuItem("~/Default.aspx?content=MerchandiseContentView", 73, catTitles));
        menu.Items.Add(AddMenuItem("~/Default.aspx?content=SiteMapTree", Resources.Fotoxata.SiteMap.ToUpper()));
    }

    public static void InitCulture()
    {
        string culture = "uk-UA";
        if (HttpContext.Current.Request.Cookies["FOTOXATA_LV_UKR_LNG"] != null)
        {
            culture = HttpContext.Current.Request.Cookies["FOTOXATA_LV_UKR_LNG"].Value.ToString();
        }
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
    }

    public static string PrintImagePath
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["PrintImagePath"];
        }
    }

    public static bool LogError
    {
        get
        {
            bool logError = false;
            if (System.Configuration.ConfigurationManager.AppSettings["LogError"] != null)
            {
                logError = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["LogError"]);
            }
            return logError;
        }
    }

    public static void SaveError(Exception ex)
    {
        if (LogError)
        {
            Error e = new Error();
            e.AddNew();
            e.Date = DateTime.Now;
            e.StackTrace = ex.StackTrace;
            e.Name = ex.Message;
            e.Browser = System.Web.HttpContext.Current.Request.Browser.Browser;
            e.Description = ex.Message;
            e.OrderID = OrderID;
            e.Save();
        }
    }

    private static int OrderID
    {
        get
        {
            int orderID = 0;
            if (HttpContext.Current.Request.Cookies["FOTOXATA_CURR_OrderID"] != null)
            {
                int.TryParse(HttpContext.Current.Request.Cookies["FOTOXATA_CURR_OrderID"].Value.ToString(), out orderID);
            }
            return orderID;
        }
    }
}
