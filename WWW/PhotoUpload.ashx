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
            int i = 1;
            int orderID = OrderID;
            if (pauConfiguration != null)
            {
                if (orderID == 0)
                {
                    Order o = new Order();
                    o.AddNew();
                    o.DateCreated = DateTime.Now;
                    o.DeliveryID = pauConfiguration.DeliveryID;
                    o.ClientNote = "";
                    o.OrderGuid = OrderGuid;
                    o.PhotoCount = 1;
                    o.Save();
                    pauConfiguration.OrderID = o.OrderID;
                    result.OrderID = o.OrderID;
                    orderID = o.OrderID;
                }
                else
                {
                    i = PhotoIndex;
                    PhotoIndex = i;
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
            string uploadTempFolder = System.Web.HttpContext.Current.Server.MapPath(Utils.GaleryImagePath + "/RadUploadTemp");
            Utils.DeleteFile(uploadTempFolder, tempFileName);
        }
        catch (Exception ex)
        {
            Utils.SaveError(ex);
        }
        
        return result;
    }
    
    private int OrderID
    {
        get
        {
            int orderID = 0;
            if (OrderGuid != Guid.Empty)
            {
                Order o = new Order();
                if(o.LoadByOrderGuid(OrderGuid))
                {
                    orderID = o.OrderID;
                }
            }
            return orderID;
        }
    }

    private Guid OrderGuid
    {
        get
        {
            Guid OrderGuid = Guid.Empty;
            if (HttpContext.Current.Request.Cookies["FOTOXATA_CURR_OrderGuid"] != null)
            {
                OrderGuid = new Guid(HttpContext.Current.Request.Cookies["FOTOXATA_CURR_OrderGuid"].Value.ToString());
            }
            return OrderGuid;
        }
    }

    private int PhotoIndex
    {
        get
        {
            Order o = new Order();
            if (o.LoadByPrimaryKey(OrderID))
            {
                return o.PhotoCount + 1;
            }
            return 1;
        }
        set
        {
            Order o = new Order();
            o.IncreasePhotoCount(OrderID);
        }
    }
}