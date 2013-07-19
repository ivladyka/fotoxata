using VikkiSoft_BLL;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class AdviceTableList : ControlBase
{
    public AdviceTableList()
    {
        this.m_Name = Resources.Fotoxata.Advices.ToUpper(); ;
    }

    protected override void InitOnFirstLoading()
    {
        base.InitOnFirstLoading();
        LoadAdvices();
    }

    private void LoadAdvices()
    {
        Advice a = new Advice();
        if (a.LoadAll())
        {
            do
            {
                tblAdvice.Rows.Add(AddNewRow("<a class='titleNewslink' style='font-size:14pt' href='Default.aspx?content=AdviceView&AdviceID=" + a.AdviceID
                        + "'>" + (!a.IsColumnNull("Question" + Utils.LangPrefix) ? a.GetColumn("Question" + Utils.LangPrefix).ToString() : "") + "</a>", "titleQuestion", "30px", "bottom"));
                string answer = "";
                if (!a.IsColumnNull("Answer" + Utils.LangPrefix))
                {
                    answer = a.GetColumn("Answer" + Utils.LangPrefix).ToString();
                }
                if (answer.Length > 500)
                {
                    answer = answer.Substring(0, 499) + "<br/> <br/><a class='Adviceslink' href='Default.aspx?content=AdviceView&AdviceID=" + a.AdviceID
                        + "'>" + Resources.Fotoxata.More + " >></a>";
                }
                tblAdvice.Rows.Add(AddNewRow(answer, "Advicetext", "","")); 
            }
            while (a.MoveNext());
        }
    }

    private HtmlTableRow AddNewRow(string innerHTML, string style, string paddingtd, string valigntd)
    {
        HtmlTableRow row = new HtmlTableRow();
        HtmlTableCell cell = new HtmlTableCell();
        cell.VAlign = valigntd;
        cell.Style["padding-top"] = paddingtd;
        Label lbl = new Label();
        lbl.Text = innerHTML;
        if (style != "")
        {
            lbl.CssClass = style;
        }
        cell.Controls.Add(lbl);
        row.Cells.Add(cell);
        return row;
    }
}
