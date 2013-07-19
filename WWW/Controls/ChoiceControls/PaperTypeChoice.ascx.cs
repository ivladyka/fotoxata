using Telerik.WebControls;
using VikkiSoft_BLL;

public partial class PaperTypeChoice : ChoiceControlBase
{
    protected override RadComboBox ddlList
    {
        get { return ddlPaperType; }
    }

    protected override void InitDDL()
    {
        PaperType pt = new PaperType();
        if (pt.LoadAll())
        {
            do
            {
                RadComboBoxItem item = new RadComboBoxItem((!pt.IsColumnNull("Name" + Utils.LangPrefix) ? pt.GetColumn("Name" + Utils.LangPrefix).ToString() : ""),
                    pt.PaperTypeID.ToString());
                this.ddlList.Items.Add(item);
            } while (pt.MoveNext());
        }
    }
}
