using System;
using System.Drawing;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using VikkiSoft_BLL;
using Font=iTextSharp.text.Font;
using System.Web;
using System.Web.UI.WebControls;

public partial class _Default : ProjectPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!Page.IsPostBack && IsPDF)
        {
            ExportPricePDF();
        }
    }

    private bool IsPDF
    {
        get
        {
            if (Request.QueryString["pricePDF"] != null)
            {
                return Convert.ToBoolean(Request.QueryString["pricePDF"]);
            }
            return false;
        }
    }

    private void ExportPricePDF()
    {
        Response.AddHeader("Content-Disposition", "attachment; filename=Price.pdf");
        Response.ContentType = "application/pdf";

        MemoryStream m = new MemoryStream();
        Document document = new Document(PageSize.A4, 15, 15, 50, 34);

        VIKKI_WorkListPDFEvents wlPDFevents = new VIKKI_WorkListPDFEvents(Server.MapPath("~//Images//logo.png"),
            Server.MapPath(Utils.FontPath) + "//arial.ttf");

        PdfWriter pdfWriter = PdfWriter.GetInstance(document, m);
        pdfWriter.CloseStream = false;
        pdfWriter.PageEvent = wlPDFevents;
        document.Open();

        BaseFont bf = BaseFont.CreateFont(Server.MapPath(Utils.FontPath) + "//arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        Paragraph title = new Paragraph(Resources.Fotoxata.PriceList, new Font(bf, 20, Font.UNDERLINE));
        title.Alignment = Element.ALIGN_CENTER;
        document.Add(title);
        document.Add(new Paragraph(" "));

        float[] widths1 = { 5f, 1f};
        PdfPTable table = new PdfPTable(widths1);
        table.WidthPercentage = 100;

        //Add Table header
        AddPDFCell(Resources.Fotoxata.ServiceName, table, 12, bf, BaseColor.WHITE, BaseColor.BLACK, 0, Element.ALIGN_CENTER, 3);
        AddPDFCell(Resources.Fotoxata.Price + ", " + Resources.Fotoxata.Grn, table, 12, bf, BaseColor.WHITE, BaseColor.BLACK, 0, Element.ALIGN_CENTER, 3);

        BaseColor grayBackground = new BaseColor(244, 244, 244);
        BaseColor grayDarkBackground = new BaseColor(220, 220, 220);
        Category cat = new Category();
        if (cat.LoadPrice())
        {
            do
            {
                BaseColor bc = grayBackground;
                byte fontSize = 10;
                if(cat.GetColumn("MerchandiseID").ToString() == "0")
                {
                    bc = grayDarkBackground;
                    fontSize = 11;
                }
                AddPDFCell((!cat.IsColumnNull("Name" + Utils.LangPrefix) ? cat.GetColumn("Name" + Utils.LangPrefix).ToString() : "" ), table, fontSize, bf, BaseColor.BLACK, bc, 0, Element.ALIGN_LEFT, 3);   
                string priceRange = "";
                decimal priceTo = 0;
                decimal priceFrom = 0;
                if(!cat.IsColumnNull(Category.ColumnNames.PriceTo))
                {
                    priceTo = cat.PriceTo;
                }
                if(!cat.IsColumnNull(Category.ColumnNames.PriceFrom))
                {
                    priceFrom = cat.PriceFrom;
                }
                if (priceFrom > 0)
                {
                    priceRange = priceFrom.ToString("N");
                }
                if (priceTo > 0)
                {
                    if (priceRange != "")
                    {
                        priceRange += " - ";
                    }
                    priceRange += priceTo.ToString("F");
                }
                AddPDFCell(priceRange, table, fontSize, bf, BaseColor.BLACK, bc, 0, Element.ALIGN_CENTER, 3);
            } while (cat.MoveNext());
        }
        table.HeaderRows = 1;
        document.Add(table);

        document.Close();
        Response.OutputStream.Write(m.GetBuffer(), 0, m.GetBuffer().Length);
        Response.OutputStream.Flush();
        Response.OutputStream.Close();
        m.Close();

    }

    private void AddPDFCell(string text, PdfPTable table, byte fontSize, BaseFont bf, BaseColor color, BaseColor bgColor,
            int colspan, int hAlign, float paddingBottom)
    {
        PdfPCell pdfpCell = new PdfPCell(new Phrase(text, new Font(bf, fontSize, Font.NORMAL, color)));
        pdfpCell.HorizontalAlignment = hAlign;
        pdfpCell.PaddingBottom = paddingBottom;
        pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
        pdfpCell.BackgroundColor = bgColor;
        pdfpCell.BorderColor = new BaseColor(80, 80, 80);
        if (colspan > 0)
        {
            pdfpCell.Colspan = colspan;
        }
        table.AddCell(pdfpCell);
    }
}

class VIKKI_WorkListPDFEvents : PdfPageEventHelper
{
    protected PdfTemplate total;
    protected BaseFont arialFont;
    protected string m_LogoPath = "";
    protected string m_FontPath = "";
    protected iTextSharp.text.Image logo;

    public VIKKI_WorkListPDFEvents(string logoPath, string fontPath)
    {
        m_LogoPath = logoPath;
        m_FontPath = fontPath;
    }

    public override void OnOpenDocument(PdfWriter writer, Document document)
    {
        logo = iTextSharp.text.Image.GetInstance(m_LogoPath);
        logo.Alignment = Element.ALIGN_TOP;
        if (logo.Height > 40)
        {
            logo.ScalePercent(40 / logo.Height * 100);
        }
        logo.SetAbsolutePosition(document.LeftMargin + 10,
            document.Top + document.TopMargin - logo.ScaledHeight - 10);

        PdfContentByte cb = writer.DirectContent;
        total = cb.CreateTemplate(50, 50);
        try
        {
            arialFont = BaseFont.CreateFont(m_FontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        }
        catch { }
    }
    public override void OnEndPage(PdfWriter writer, Document document)
    {
        PdfContentByte cb = writer.DirectContent;

        int pageN = writer.PageNumber;
        String text = Resources.Fotoxata.Page + " " + pageN + " " + Resources.Fotoxata.From + " ";
        float len = arialFont.GetWidthPoint(text, 8);
        cb.BeginText();
        cb.SetFontAndSize(arialFont, 8);
        cb.SetTextMatrix((document.Right - document.Left) / 2 + document.LeftMargin - 20, 15);
        cb.ShowText(text);
        cb.EndText();
        cb.AddTemplate(total, (document.Right - document.Left) / 2 + document.LeftMargin + len - 20, 15);
        cb.BeginText();
        cb.SetFontAndSize(arialFont, 8);
        cb.SetTextMatrix(10, 820);
        cb.EndText();

        if (logo != null)
        {
            cb.AddImage(logo);
        }
        ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT, new Phrase(DateTime.Now.ToShortDateString(), new Font(arialFont, 14)),
            document.Right - document.Left + document.LeftMargin, document.Top + 20, 0);
    }
    public override void OnCloseDocument(PdfWriter writer, Document document)
    {
        total.BeginText();
        total.SetFontAndSize(arialFont, 8);
        total.ShowText((writer.PageNumber - 1).ToString());
        total.EndText();
    }
}

