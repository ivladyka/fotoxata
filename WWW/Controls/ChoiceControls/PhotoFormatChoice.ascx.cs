﻿using Telerik.WebControls;
using VikkiSoft_BLL;
using MyGeneration.dOOdads;

public partial class PhotoFormatChoice : ChoiceControlBase
{
    protected override RadComboBox ddlList
    {
        get { return ddlPhotoFormat; }
    }

    protected override void InitDDL()
    {
        Merchandise m = new Merchandise();
        m.Where.CategoryID.Value = CategoryID;
        m.Query.AddOrderBy(VikkiSoft_BLL.Merchandise.ColumnNames.PriceFrom, WhereParameter.Dir.ASC);
        if (m.Query.Load())
        {
            do
            {
                RadComboBoxItem item = new RadComboBoxItem((!m.IsColumnNull("Name" + Utils.LangPrefix) ? m.GetColumn("Name" + Utils.LangPrefix).ToString() : ""),
                    m.MerchandiseID.ToString());
                this.ddlList.Items.Add(item);
            } while (m.MoveNext());
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
}
