using Telerik.WebControls;
using VikkiSoft_BLL;

public partial class OrderStatusChoice : ChoiceControlBase
{
    protected override RadComboBox ddlList
    {
        get { return ddlOrderStatus; }
    }

    protected override void InitDDL()
    {
        OrderStatus d = new OrderStatus();
        if (d.LoadAll())
        {
            do
            {
                RadComboBoxItem item = new RadComboBoxItem(d.Name,
                    d.OrderStatusID.ToString());
                this.ddlList.Items.Add(item);
            } while (d.MoveNext());
        }
    }
}