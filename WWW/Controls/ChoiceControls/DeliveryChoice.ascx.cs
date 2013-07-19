using Telerik.WebControls;
using VikkiSoft_BLL;

public partial class DeliveryChoice : ChoiceControlBase
{
    protected override RadComboBox ddlList
    {
        get { return ddlDelivery; }
    }

    protected override void InitDDL()
    {
        Delivery d = new Delivery();
        if (d.LoadAll())
        {
            do
            {
                RadComboBoxItem item = new RadComboBoxItem((!d.IsColumnNull("Name" + Utils.LangPrefix) ? d.GetColumn("Name" + Utils.LangPrefix).ToString() : ""),
                    d.DeliveryID.ToString());
                this.ddlList.Items.Add(item);
            } while (d.MoveNext());
        }
    }
}
