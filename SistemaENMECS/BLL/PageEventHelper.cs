using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace SistemaENMECS.BLL
{
    class PageEventHelper : PdfPageEventHelper
    {
        PdfContentByte cb;
        PdfTemplate template;

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            cb = writer.DirectContent;
            template = cb.CreateTemplate(50, 50);
        }

        public override void OnEndPage(PdfWriter writer, Document doc)
        {

            BaseColor grey = new BaseColor(128, 128, 128);
            string fnt = @"C:\Users\Desarrollador\AppData\Local\Microsoft\Windows\Fonts\JetBrainsMono-Regular.ttf";
            iTextSharp.text.Font font = FontFactory.GetFont(fnt, 9, iTextSharp.text.Font.NORMAL, grey);
            //tbl footer
            PdfPTable footerTbl = new PdfPTable(1);
            footerTbl.TotalWidth = doc.PageSize.Width;



            //numero de la page

            //Chunk myFooter = new Chunk("Página " + (doc.PageNumber), FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 8, grey));
            Chunk myFooter = new Chunk("Página " + (doc.PageNumber), font);
            PdfPCell footer = new PdfPCell(new Phrase(myFooter));
            footer.Border = iTextSharp.text.Rectangle.NO_BORDER;
            footer.HorizontalAlignment = Element.ALIGN_CENTER;
            footerTbl.AddCell(footer);


            //footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin + 80), writer.DirectContent);
            footerTbl.WriteSelectedRows(0, -1, 250, 30, writer.DirectContent);

            footerTbl = new PdfPTable(1);
            footerTbl.TotalWidth = doc.PageSize.Width;

            myFooter = new Chunk("BK Filtración \"RENOVANDO EL AIRE\"", font);
            footer = new PdfPCell(new Phrase(myFooter));
            footer.Border = iTextSharp.text.Rectangle.NO_BORDER;
            footer.HorizontalAlignment = Element.ALIGN_CENTER;
            footerTbl.AddCell(footer);


            //footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin + 80), writer.DirectContent);
            footerTbl.WriteSelectedRows(0, -1, -158, 30, writer.DirectContent);
        }




        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

        }
    }
}
