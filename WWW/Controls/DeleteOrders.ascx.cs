using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using VikkiSoft_BLL;
using System.IO;

public partial class DeleteOrders : ControlBase
{
    public DeleteOrders()
	{
        this.m_Name = "Видалити замовлення";
        this.AllowUserTypes = ((int)UserTypeEnum.Admin).ToString();
	}

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Office/Office.aspx");
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        lblError.Text = "";
        int orderNumber;
        int.TryParse(tbOrderNumber.Text, out orderNumber);
        if (orderNumber == 0)
        {
            ShowError("Введіть правильний номер завмовлення.");
            return;
        }
        try
        {
            Order o = new Order();
            o.Where.OrderID.Operator = MyGeneration.dOOdads.WhereParameter.Operand.LessThanOrEqual;
            o.Where.OrderID.Value = orderNumber;
            if (o.Query.Load())
            {
                do
                {
                    string targetFolder = Server.MapPath(Utils.OrderImagePath + "//" + o.OrderID + "//");
                    if (Directory.Exists(targetFolder))
                    {
                        Directory.Delete(targetFolder, true);
                    }
                    targetFolder = Server.MapPath(Utils.PrintImagePath + "//" + o.OrderID + "//");
                    if (Directory.Exists(targetFolder))
                    {
                        Directory.Delete(targetFolder, true);
                    }
                }
                while (o.MoveNext());
                o.DeleteAll();
                o.Save();
            }
            lblError.Text = "Замовлення видалені успішно.";
            lblError.ForeColor = Color.Green;
            tblOrderDel.Visible = false;
        }
        catch(Exception ex)
        {
            ShowError(ex.Message);
        }
    }

    private void ShowError(string error)
    {
        lblError.Text = error;
        lblError.ForeColor = Color.Red;
    }
}