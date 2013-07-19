public partial class OrderAdded : ControlBase
{
    public OrderAdded()
	{
        this.m_Name = "";
	}

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        lbOrderAdded.Text += " - <span style='font-size: 16pt;'>" + OrderID + ".</span>";
    }

    private int OrderID
    {
        get
        {
            if (Request.QueryString["OrderID"] != null)
            {
                return int.Parse(Request.QueryString["OrderID"]);
            }
            return 0;
        }
    }
}
