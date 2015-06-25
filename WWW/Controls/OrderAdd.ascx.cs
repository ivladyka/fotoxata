using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyGeneration.dOOdads;
using Telerik.Web.UI;
using VikkiSoft_BLL;
using System.Web;
using Image=System.Web.UI.WebControls.Image;

public partial class OrderAdd : ControlBase
{

    public OrderAdd()
	{
        
	}

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        text_CellPhone.Focus();
        LoadLoggedUserCellPhone();
        PhotoAsyncUploadConfiguration config =
            auFile.CreateDefaultUploadConfiguration<PhotoAsyncUploadConfiguration>();
        Delivery d = new Delivery();
        if (d.LoadAll())
        {
            config.DeliveryID = d.DeliveryID;
        }
        PaperType pt = new PaperType();
        if (pt.LoadAll())
        {
            config.PaperTypeID = pt.PaperTypeID;
        }
        Merchandise m = new Merchandise();
        m.Where.CategoryID.Value = CategoryID;
        if (m.Query.Load())
        {
            config.MerchandiseID = m.MerchandiseID;
        }
        auFile.UploadConfiguration = config;

        auFile.TemporaryFolder = Utils.GaleryImagePath + "/RadUploadTemp";
        auFile.Localization.Select = Resources.Fotoxata.Select;
        auFile.Localization.Remove = Resources.Fotoxata.Remove;
        rntbCount.Value = 1;
        btnAddPhoto.Attributes["onclick"] = "return VIKKI_CheckUploadedFiles(false);";
        btnAddOrder.Attributes["onclick"] = "return VIKKI_CheckUploadedFiles(true);";
        btnAddPhoto.ImageUrl = "../NewImages/addphoto" + Utils.LangPrefix + ".gif";
        btnAddPhoto.Attributes["onmouseover"] = "VIKKI_PuzzleOnMouseOver(event, 'NewImages/addphoto1" + Utils.LangPrefix + ".gif' );";
        btnAddPhoto.Attributes["onmouseout"] = "VIKKI_PuzzleOnMouseOver(event, 'NewImages/addphoto" + Utils.LangPrefix + ".gif' );";
        btnAddOrder.ImageUrl = "../NewImages/Ordering" + Utils.LangPrefix + ".gif";
        btnAddOrder.Attributes["onmouseover"] = "VIKKI_PuzzleOnMouseOver(event, 'NewImages/Ordering1" + Utils.LangPrefix + ".gif' );";
        btnAddOrder.Attributes["onmouseout"] = "VIKKI_PuzzleOnMouseOver(event, 'NewImages/Ordering" + Utils.LangPrefix + ".gif' );";
        tdAddedPhoto.InnerHtml = Resources.Fotoxata.AddedPhotos + ":";
        tdPriceOnPrint.InnerHtml = "<br />&nbsp;&nbsp;" + Resources.Fotoxata.PriceOnPrint;
        LoadTitle();
    }

    private void LoadLoggedUserCellPhone()
    {
        if (Request.IsAuthenticated)
        {
            text_CellPhone.Text = LoggedUser.CellPhone;
        }
    }

    protected void btnAddOrder_Click(object sender, System.EventArgs e)
    {
        AddOrder(true);
    }

    private void AddOrder(bool preparePrint)
    {
        try
        {
            Order o = new Order();
            string userName = "";
            string cellPhone = text_CellPhone.Text.Trim();
            o.LoadByPrimaryKey(OrderID);
            if (preparePrint)
            {
                o.OrderStatusID = 1;
                VikkiSoft_BLL.User u = new User();
                u.Where.CellPhone.Value = text_CellPhone.Text.Trim();
                if (u.Query.Load())
                {
                    o.UserID = u.UserID;
                    o.SetColumnNull(Order.ColumnNames.CellPhone);
                    userName = u.s_LastName + " " + u.s_FirstName;
                    cellPhone = u.s_CellPhone;
                }
                else
                {
                    o.CellPhone = text_CellPhone.Text.Trim();
                    o.SetColumnNull(Order.ColumnNames.UserID);
                }
            }
            o.DeliveryID = int.Parse(ddlDelivery.SelectedValue);
            o.ClientNote = tbClientNote.Text;
            o.Save();

            Order o1 = new Order();
            o1.UpdateOrderPhotosAllUploaded(OrderID, (int)rntbCount.Value, chkBorder.Checked, int.Parse(paperTypeChoice.SelectedValue), int.Parse(photoFormatChoice.SelectedValue));

            Update(false);
            if (preparePrint)
            {
                MoveCreateFolders();
                SaveOrderInfo(userName, cellPhone);
                Utils.SendEmail("Додано нове замовлення.", "Додано нове замовлення. Номер замовлення - " + OrderID,
                    System.Configuration.ConfigurationManager.AppSettings["AddOrderEmail"].Trim());
                OrderID = 0;
                Response.Redirect("Default.aspx?content=OrderAdded&OrderID=" + OrderID);
                return;
            }
            rgdOrderPhoto.Rebind();
            SetEditMode(true);
        }
        catch (Exception ex)
        {
            Error e = new Error();
            e.AddNew();
            e.Date = DateTime.Now;
            e.StackTrace = ex.StackTrace;
            e.Name = ex.Message;
            e.Browser = System.Web.HttpContext.Current.Request.Browser.Browser;
            e.Description = ex.Message;
            e.Save();
        }
    }

    private void SaveOrderInfo(string userName, string cellPhone)
    {
        StreamWriter orderInfo = File.AppendText(Server.MapPath(Utils.PrintImagePath + "//" + OrderID + "//")
                + "OrderInfo.txt");
        Order o = new Order();
        if (o.LoadByPrimaryKey(OrderID))
        {
            WriteLog("Номер Замовлення: " + OrderID, orderInfo);
            WriteLog("Телефон: " + cellPhone, orderInfo);
            if (userName.TrimEnd().Length > 0)
            {
                WriteLog("Прізвище: " + userName, orderInfo);
            }
        }
        WriteLog("Примітки клієнта: " + tbClientNote.Text, orderInfo);
        WriteLog("Дата замовлення: " + o.DateCreated.ToString("dd.MM.yyyy"), orderInfo);
        WriteLog("Доставка: " + ddlDelivery.SelectedText, orderInfo);
        if(!o.IsColumnNull(Order.ColumnNames.PhotoCount))
        {
            WriteLog("Кількість фото: " + o.s_PhotoCount, orderInfo);
        }
        if (!o.IsColumnNull(Order.ColumnNames.Amount))
        {
            WriteLog("Ціна: " + o.Amount.ToString("N") + " грн.", orderInfo);
        }
        orderInfo.Close();
    }

    private void MoveCreateFolders()
    {
        string printFolder = Server.MapPath(Utils.PrintImagePath + "//" + OrderID);
        string orderFolder = Server.MapPath(Utils.OrderImagePath + "//" + OrderID);
        OrderPhoto op = new OrderPhoto();
        op.Where.OrderID.Value = OrderID;
        if(op.Query.Load())
        {
            do
            {
                    string folderName = printFolder + "//" + PhotoFormat(op.MerchandiseID);
                    if (op.PaperTypeID == 1)
                    {
                        folderName += "MAT";
                    }
                    else
                    {
                        folderName += "GL";
                    }
                    if (op.Border)
                    {
                        folderName += "_B";
                    }
                    if (!System.IO.Directory.Exists(folderName + "//"))
                    {
                        System.IO.Directory.CreateDirectory(folderName + "//");
                    }
                    string sourceFileName = Path.Combine(orderFolder, op.s_PhotoName);
                    string destFileName = op.s_PhotoName;
                    if (op.Count > 1)
                    {
                        string[] fileParts = op.s_PhotoName.Split('.');
                        if (fileParts.Length == 2)
                        {
                            destFileName = "(" + op.Count + ")" + fileParts[0] + "." + fileParts[1];
                        }
                    }
                    string desctFileName = Path.Combine(folderName, destFileName);
                    try
                    {
                        File.Move(sourceFileName, desctFileName);
                    }
                    catch
                    {
                        File.Copy(sourceFileName, desctFileName);
                    }
            } while (op.MoveNext());
        }
    }

    private string PhotoFormat(int merchandiseID)
    {
        Merchandise m = new Merchandise();
        if(m.LoadByPrimaryKey(merchandiseID))
        {
            return m.s_Name.Replace("см", "").Replace("cm", "");
        }
        return "";
    }

    private void rgdOrderPhoto_NeedDataSource(object source, Telerik.WebControls.GridNeedDataSourceEventArgs e)
    {
        this.rgdOrderPhoto.DataSource = LoadOrderPhoto();
    }

    private DataSet LoadOrderPhoto()
    {
        DataSet ds = new DataSet();
        OrderPhoto op = new OrderPhoto();
        op.LoadByOrderID(OrderID);
        op.DefaultView.Table.TableName = "OrderPhoto";
        if(op.DefaultView.Table.Rows.Count > 0)
        {
            rgdOrderPhoto.MasterTableView.ShowFooter = true;
        }
        else
        {
            rgdOrderPhoto.MasterTableView.ShowFooter = false;
        }
        ds.Tables.Add(op.DefaultView.Table);

        PaperType pt = new PaperType();
        if (pt.LoadAll())
        {
            pt.DefaultView.Table.TableName = "PaperType";
            ds.Tables.Add(pt.DefaultView.Table);
        }

        Merchandise m = new Merchandise();
        m.Where.CategoryID.Value = CategoryID;
        if (m.Query.Load())
        {
            m.DefaultView.Table.TableName = "PhotoFormat";
            ds.Tables.Add(m.DefaultView.Table);
        }
        return ds;
    }

    private void SetEditMode(bool setEditMode)
    {
        TableRowCollection rows = (rgdOrderPhoto.MasterTableView.Controls[0] as Table).Rows;
        foreach (Telerik.WebControls.GridItem row in rows)
        {
            row.Edit = setEditMode;
        }
        rgdOrderPhoto.Rebind();
    }

    private void Update(bool deleteChecked)
    {
        TableRowCollection rows = (rgdOrderPhoto.MasterTableView.Controls[0] as Table).Rows;
        foreach (Telerik.WebControls.GridItem item in rows)
        {
            if (item.Edit)
            {
                Telerik.WebControls.GridEditableItem editedItem = item as Telerik.WebControls.GridEditableItem;
                TextBox tb = (TextBox)editedItem["OrderPhotoID"].Controls[0];
                int orderPhotoID = int.Parse(tb.Text);
                CheckBox chkDeleteRow = (CheckBox)item.FindControl("chkDeleteRow");
                if (chkDeleteRow != null && chkDeleteRow.Checked && deleteChecked)
                {
                    DeleteItem(orderPhotoID);
                }
                else
                {
                    OrderPhoto op = new OrderPhoto();
                    if (op.LoadByPrimaryKey(orderPhotoID))
                    {
                        UpdateEntity(op, item);
                    }
                }
            }
        }
        //rgdOrderPhoto.Rebind();
    }

    private void UpdateEntity(SqlClientEntity entity, Telerik.WebControls.GridItem item)
    {
        try
        {
            Telerik.WebControls.GridEditableItem editedItem = item as Telerik.WebControls.GridEditableItem;
            //Update new values
            Hashtable newValues = new Hashtable();
            //The GridTableView will fill the values from all editable columns in the hash
            item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);
            foreach (DictionaryEntry entry in newValues)
            {
                string key = (string) entry.Key;
                if(key == "PhotoCount")
                {
                    key = "Count";
                }
                if (entry.Value == null)
                {
                    entity.SetColumnNull(key);
                }
                else
                {
                    entity.SetColumn(key, entry.Value);
                }
            }
            entity.Save();
        }
        catch
        {
        }
    }

    private void rgdOrderPhoto_ItemCommand(object source, Telerik.WebControls.GridCommandEventArgs e)
    {
        if (e.CommandName == "DeleteSelected")
        {
            Update(true);
            e.Item.OwnerTableView.Rebind();
            return;
        }
    }

    private void DeleteItem(int orderPhotoID)
    {
        OrderPhoto op = new OrderPhoto();
        if (op.LoadByPrimaryKey(orderPhotoID))
        {
            string orderFolder = Server.MapPath(Utils.OrderImagePath + "//" + OrderID);
            string extension = "";
            string photoName = op.PhotoName;
            if (photoName.LastIndexOf('.') != -1)
            {
                extension = photoName.Substring(photoName.LastIndexOf('.'),
                    (photoName.Length - photoName.LastIndexOf('.')));
                photoName = photoName.Substring(0, photoName.LastIndexOf('.'));
            }
            Utils.DeleteFile(orderFolder, op.PhotoName);
            Utils.DeleteFile(orderFolder, photoName + "_s" + extension);
            //Utils.DeleteFile(orderFolder, photoName + "_m" + extension);
            op.DeleteAll();
            op.Save();
        }
    }

    protected override void SetEventHandlers()
    {
        this.rgdOrderPhoto.NeedDataSource +=
            new Telerik.WebControls.GridNeedDataSourceEventHandler(this.rgdOrderPhoto_NeedDataSource);
        this.rgdOrderPhoto.ItemCommand +=
            new Telerik.WebControls.GridCommandEventHandler(this.rgdOrderPhoto_ItemCommand);
        //auFile.FileUploaded += new FileUploadedEventHandler(auFile_FileUploaded);
        /*MasterPageBase master = (MasterPageBase)Page.Master;
        if (master.RadScriptManager1 != null)
        {
            master.RadScriptManager1.AsyncPostBackError += new EventHandler<AsyncPostBackErrorEventArgs>(ScriptManager1_AsyncPostBackError);
        }*/

        base.SetEventHandlers();
    }

    protected override void OnInit(EventArgs e)
    {
        if (!Utils.IsPagePostBack(this))
        {
            rgdOrderPhoto.MasterTableView.SortExpressions.AddSortExpression("OrderPhotoID DESC");
        }
        this.rgdOrderPhoto.ClientSettings.ClientEvents.OnGridCreated = "GetOrderPhotoGridObject";
        base.OnInit(e);
    }

    public string GetUpdateCancelButtonStyle()
    {
        if (this.rgdOrderPhoto.EditIndexes.Count > 0)
        {
            return "";
        }
        return "VIKKI_HiddenButton";
    }

    public string GetAddDeleteButtonStyle()
    {
        if (this.rgdOrderPhoto.EditIndexes.Count > 0)
        {
            return "VIKKI_HiddenButton";
        }
        return "";
    }

    protected void rgdOrderPhoto_ItemDataBound(object sender, Telerik.WebControls.GridItemEventArgs e)
    {
        if (e.Item is Telerik.WebControls.GridHeaderItem)
        {
            CheckBox chkDeleteAll = (CheckBox)e.Item.FindControl("chkDeleteAll");
            if (chkDeleteAll != null)
            {
                chkDeleteAll.Attributes["onclick"] = "VIKKI_OrderPhotoCheckAllCheckboxes(event);";
            }
        }
        if (e.Item is Telerik.WebControls.GridDataItem)
        {
            DataRowView dataRowView = e.Item.DataItem as DataRowView;
            if (dataRowView != null)
            {
                //Load Image
                Image i = new Image();
                string orderImagePath = Utils.OrderImagePath + "//" + OrderID;
                string photoName = dataRowView["PhotoName"].ToString();
                string extension = "";
                if (photoName.LastIndexOf('.') != -1)
                {
                    extension = photoName.Substring(photoName.LastIndexOf('.'),
                        (photoName.Length - photoName.LastIndexOf('.')));
                    photoName = photoName.Substring(0, photoName.LastIndexOf('.'));
                }

                i.ImageUrl = Path.Combine(orderImagePath, photoName + "_s" + extension);
                /*i.Attributes["onclick"] = "return VIKKI_ShowImageViewWindow('0', '"
                    + photoName + "_m" + extension + "', '" + OrderID.ToString() + "');";
                i.CssClass = "VIKKI_HandCursor";*/
                i.ToolTip = dataRowView["ClientPhotoName"].ToString();
                e.Item.Cells[3].Text = "";
                e.Item.Cells[3].Controls.Add(i);
            }
        }
        if (e.Item is Telerik.WebControls.GridFooterItem)
        {
            if (OrderID > 0)
            {
                Order o = new Order();
                if (o.LoadByPrimaryKey(OrderID))
                {
                    if (!o.IsColumnNull(Order.ColumnNames.Amount))
                    {
                        e.Item.Cells[7].Text = o.Amount.ToString("0.00") + " " + Resources.Fotoxata.Grn;
                    }
                    if (!o.IsColumnNull(Order.ColumnNames.PhotoCount))
                    {
                        e.Item.Cells[4].Text = o.PhotoCount.ToString();
                    }
                }
            }
        }
    }

    private int CategoryID
    {
        get
        {
            if (Request.Params["CategoryID"] != null)
            {
                return int.Parse(Request.Params["CategoryID"]);
            }
            return 0;
        }
    }

    protected void rgdOrderPhoto_CreateColumnEditor(object sender, Telerik.WebControls.GridCreateColumnEditorEventArgs e)
    {
        switch (e.Column.UniqueName)
        {
            case "PaperTypeID":
            case "MerchandiseID":
                InLineEditComboBoxEditor comboEditor = new InLineEditComboBoxEditor();
                comboEditor.ComboID = e.Column.UniqueName;
                comboEditor.OnClientSelectedIndexChanged = "VIKKI_CalculateTotalAmounts";
                e.ColumnEditor = comboEditor;
                break;
            case "PhotoCount":
                InLineEditInputEditor numTextBox = new InLineEditInputEditor();
                numTextBox.OnClientValueChanged = "VIKKI_CalculateTotalAmounts";
                e.ColumnEditor = numTextBox;
                break;
        }
    }

    protected void btnAddPhoto_Click(object sender, EventArgs e)
    {
        AddOrder(false);
    }

    private void LoadTitle()
    {
        Category c = new Category();
        if (c.LoadByPrimaryKey(CategoryID))
        {
            string title = "";
            if (!c.IsColumnNull("Title" + Utils.LangPrefix))
            {
                title = c.GetColumn("Title" + Utils.LangPrefix).ToString();
            }
            if (title.Trim() == "")
            {
                title = c.GetColumn("Name" + Utils.LangPrefix).ToString();
            }
            this.m_Name = title;
        }
    }

    public string AtFirstUploadPhoto
    {
        get
        {
            return Resources.Fotoxata.AtFirstUploadPhoto;
        }
    }

    public string MobilePhoneRequire
    {
        get
        {
            return Resources.Fotoxata.MobilePhoneRequire;
        }
    }

    public string ImageFormatAlert
    {
        get
        {
            return Resources.Fotoxata.ImageFormatAlert;
        }
    }

    public string MaxImageSizeAlert
    {
        get
        {
            return Resources.Fotoxata.MaxImageSizeAlert;
        }
    }

    public string WaitCompleteUploadingAlert
    {
        get
        {
            return Resources.Fotoxata.WaitCompleteUploadingAlert;
        }
    }

    public string Total
    {
        get
        {
            return Resources.Fotoxata.Total;
        }
    }

    public string Grn
    {
        get
        {
            return Resources.Fotoxata.Grn;
        }
    }

    public string DeleteSelectedRow
    {
        get
        {
            return Resources.Fotoxata.DeleteSelectedRow;
        }
    }

    public string DeleteAlert
    {
        get
        {
            return Resources.Fotoxata.DeleteAlert;
        }
    }

    public string Refresh
    {
        get
        {
            return Resources.Fotoxata.Refresh;
        }
    }

    private void WriteLog(string message, StreamWriter log)
    {
        log.WriteLine(message);
        log.Flush();
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

    protected void btnRemovePhoto_Click(object sender, EventArgs e)
    {
        string clientPhotoName = hdClientPhotoNameRemove.Value;
        if(!string.IsNullOrEmpty(clientPhotoName) && OrderID > 0)
        {
            try
            {
                OrderPhoto op = new OrderPhoto();
                op.LoadByClientPhotoName(OrderID, clientPhotoName);
                string targetFolder = Server.MapPath(Utils.OrderImagePath + "//" + OrderID);
                string photoName = op.PhotoName;
                string extension = "";
                if (clientPhotoName.LastIndexOf('.') != -1)
                {
                    extension = clientPhotoName.Substring(clientPhotoName.LastIndexOf('.'),
                        (clientPhotoName.Length - clientPhotoName.LastIndexOf('.')));
                }
                photoName = photoName.TrimEnd(extension.ToCharArray());
                try
                {
                    Utils.DeleteFile(targetFolder, photoName + extension);
                    Utils.DeleteFile(targetFolder, photoName + "_s" + extension);
                }
                catch { }
                op.DeleteAll();
                op.Save();
            }
            catch { }
        }
    }

    protected void auFile_FileUploaded(object sender, FileUploadedEventArgs e)
    {
        PhotoAsyncUploadResult result = e.UploadResult as PhotoAsyncUploadResult;
        if (result.OrderID > 0)
        {
            /*if(((PhotoAsyncUploadConfiguration)auFile.UploadConfiguration).OrderID == 0)
            {
                ((PhotoAsyncUploadConfiguration)auFile.UploadConfiguration).OrderID = result.OrderID;
            }*/
        }
    }

    protected void ScriptManager1_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
    {
        string s = e.Exception.Message;
        //ScriptManager1.AsyncPostBackErrorMessage = e.Exception.Message;
    }
}
