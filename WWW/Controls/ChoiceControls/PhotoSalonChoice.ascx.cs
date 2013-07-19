using MyGeneration.dOOdads;
using Telerik.WebControls;
using VikkiSoft_BLL;

public partial class PhotoSalonChoice : ChoiceControlBase
{
    protected override RadComboBox ddlList
    {
        get { return ddlPhotoSalon; }
    }

    protected override void InitDDL()
    {
        PhotoSalon ps = new PhotoSalon();
        ps.Query.AddOrderBy(PhotoSalon.ColumnNames.Address, WhereParameter.Dir.ASC);
        if (ps.Query.Load())
        {
            do
            {
                RadComboBoxItem item = new RadComboBoxItem(ps.Address,
                    ps.PhotoSalonID.ToString());
                this.ddlList.Items.Add(item);
            } while (ps.MoveNext());
        }
    }
}
