<%@ WebHandler Language="C#" Class="PhotoUpload" %>

using System;
using System.Web;
using Telerik.Web.UI;
using VikkiSoft_BLL;
using System.IO;

public class PhotoUpload : AsyncUploadHandler, System.Web.SessionState.IRequiresSessionState
{
    protected override IAsyncUploadResult Process(UploadedFile file, HttpContext context, IAsyncUploadConfiguration configuration, string tempFileName)
    {
        PhotoAsyncUploadResult result = CreateDefaultUploadResult<PhotoAsyncUploadResult>(file);

        try
        {
            PhotoAsyncUploadConfiguration pauConfiguration = configuration as PhotoAsyncUploadConfiguration;
            int i = PhotoIndex;
            int orderID = OrderID;
            if (pauConfiguration != null)
            {
                if (OrderID == 0)
                {
                    Order o = new Order();
                    o.AddNew();
                    o.DateCreated = DateTime.Now;
                    o.DeliveryID = pauConfiguration.DeliveryID;
                    o.ClientNote = "";
                    o.Save();
                    pauConfiguration.OrderID = o.OrderID;
                    result.OrderID = o.OrderID;
                    OrderID = o.OrderID;
                    orderID = o.OrderID;
                    i = 1;
                }
            }
            string orderFolder = System.Web.HttpContext.Current.Server.MapPath(Utils.OrderImagePath + "//" + orderID);
            string printFolder = System.Web.HttpContext.Current.Server.MapPath(Utils.PrintImagePath + "//" + orderID);
            if (!System.IO.Directory.Exists(printFolder + "//"))
            {
                System.IO.Directory.CreateDirectory(printFolder + "//");
            }
            if (!System.IO.Directory.Exists(orderFolder + "//"))
            {
                System.IO.Directory.CreateDirectory(orderFolder + "//");
            }
            string newGUID = "photo" + i.ToString();
            string extension = file.GetExtension();
            string newFileName = newGUID + extension;
            string path = Path.Combine(orderFolder, newFileName);
            file.SaveAs(path, true);
            OrderPhoto op = new OrderPhoto();
            op.AddNew();
            op.ClientPhotoName = new FileInfo(file.FileName).Name;
            op.Count = 0;
            op.Border = false;
            int paperType = 1;
            int merchandiseID = 0;
            if (pauConfiguration != null)
            {
                paperType = pauConfiguration.PaperTypeID;
                merchandiseID = pauConfiguration.MerchandiseID;
            }
            else
            {
                Merchandise m = new Merchandise();
                m.Where.CategoryID.Value = 9;
                if (m.Query.Load())
                {
                    merchandiseID = m.MerchandiseID;
                }
            }
            op.PaperTypeID = paperType;
            op.MerchandiseID = merchandiseID;
            op.OrderID = orderID;
            op.PhotoName = newFileName;
            op.Save();
            try
            {
                System.IO.FileStream fs = System.IO.File.OpenRead(Path.Combine(orderFolder, newFileName));
                byte[] b = new byte[fs.Length];
                fs.Read(b, 0, b.Length);
                newFileName = newGUID + "_s" + extension;
                Utils.ResizeAndSaveJpgImage(b, 79, 120, Path.Combine(orderFolder, newFileName), true);
                fs.Close();
            }
            catch { }
            i++;
            PhotoIndex = i;
        }
        catch (Exception ex)
        {
            Utils.SaveError(ex);
        }
        
        return result;
    }
    
    private int OrderID
    {
        set
        {
            HttpCookie FOTOXATA_CURR_OrderIDCookie = new HttpCookie("FOTOXATA_CURR_OrderID", value.ToString());
            HttpContext.Current.Response.Cookies.Add(FOTOXATA_CURR_OrderIDCookie);
        }

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

    private int PhotoIndex
    {
        set
        {
            HttpCookie FOTOXATA_CURR_PhotoIndexCookie = new HttpCookie("FOTOXATA_CURR_PhotoIndex", value.ToString());
            HttpContext.Current.Response.Cookies.Add(FOTOXATA_CURR_PhotoIndexCookie);
        }

        get
        {
            int photoIndex = 1;
            if (HttpContext.Current.Request.Cookies["FOTOXATA_CURR_PhotoIndex"] != null)
            {
                int.TryParse(HttpContext.Current.Request.Cookies["FOTOXATA_CURR_PhotoIndex"].Value.ToString(), out photoIndex);
            }
            return photoIndex;
        }
    }
}