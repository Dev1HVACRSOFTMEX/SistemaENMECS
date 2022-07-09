using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SistemaENMECS.DAL;
using System.Diagnostics;

namespace SistemaENMECS.BLL
{
    public class Cotizacion
    {
        public Cotizacion()
        {

        }

        //Configuración Celda.
        public PdfPCell celdaTexto(string texto, BaseColor color, int alineacion)
        {
            Font _standardFont = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK);
            Paragraph txt = new Paragraph(texto, _standardFont);
            PdfPCell cell = new PdfPCell(txt);

            cell.BorderColor = color;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.HorizontalAlignment = alineacion;
            //cell.Padding = 20;

            return cell;
        }

        public void generaCotizacion(string DoIdent)
        {
            _Documento cot = new _Documento();
            _DocNota cotNot = new _DocNota();
            _DocConcepto cotCon = new _DocConcepto();
            _DocCPartida cotPar = new _DocCPartida();
            _Empresa emp = new _Empresa();
            _Proyecto pry = new _Proyecto();
            _Carpeta crp = new _Carpeta();

            //string[] tipo00 = new string[] { "DCONG", "DCVOF", "DCFPA", "DCCPA", "DCTRE", "DCNTR", "DCTEN", "DCNTE", "DCCNI", "DNTIM", "DCGAS", "DCLGA" };
            string[] tipo00 = new string[] { "DCCTM", "DCCVF", "DCCFP", "DCCCP", "DCCTE", "DCCPE", "DCCSE", "DCNIM" };
            string[] tipo01 = new string[] { "Tipo de Moneda:", "Vigencia de la Oferta:", "Forma de Pago:", "Condiciones de Pago:", "Términos de Entrega:", "Plazo de Entrega:", "Se Excluye:", "Notas Importantes" };

            string[] fin00 = new string[] { "SUM", "INS", "SUMIN", "SERV", "FAB", "MAN" };
            string[] fin01 = new string[] { "Suministro de", "Instalación de", "Suministro e instalación de", "Servicio de", "Fabricación de", "Maniobras de" };

            cot.DoIdent = DoIdent;
            cot.DoTipo = "";
            cot.DiNumero = "";
            cot.EmIdent = "";
            cot.DoEstatus = "";
            cot.FeIni = DateTime.Now;
            cot.FeFin = DateTime.Now;
            cot.DoUsuSeg = "";
            cot.DoVendedor = "";
            cot.consultaUno();

            cotNot.DoIdent = DoIdent;
            cotNot.DnNumero = 0;
            cotNot.NoIdent = "";
            cotNot.listado();

            cotCon.DoIdent = DoIdent;
            cotCon.CoNumero = 0;
            cotCon.listado();

            pry.PyNumero = cot.PyNumero;
            pry.PyNombre = "";
            pry.DiNombre = "";
            pry.consultaUno();

            emp.EmIdent = cot.EmIdent;
            emp.consultaUno();

            crp.GcIdent = emp.EmGrIdCot;
            crp.CrIdent = emp.EmCrIdCot;
            crp.CrNombre = "";
            crp.consultaUno();
            
            string pathPDF = usuarioCache.pathPry + pry.PyNomCarp;

            if (File.Exists(pathPDF))
            {
                pathPDF = pathPDF + "\\" + crp.CrNombre;
                if (!File.Exists(pathPDF))
                    Directory.CreateDirectory(pathPDF);
            }
            else
            {
                pathPDF = usuarioCache.pathCotDf;
                if (!File.Exists(pathPDF))
                    Directory.CreateDirectory(pathPDF);
            }

            string nombrePDF = cot.DoFolio.Trim() + ".pdf";
            string pathCompleto = pathPDF.Trim() + "\\" + nombrePDF.Trim();
            float ultP = 0;
            int size18 = 18, size15 = 15, size11 = 11, size10 = 10, size09 = 9, size08 = 8, size07 = 7, size06 = 6;
            FileStream fs = new FileStream(pathCompleto, FileMode.Create);
            Document doc = new Document(PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            writer.PageEvent = new PageEventHelper();
            PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, doc.PageSize.Height, 0.85f);
            doc.Open();

            doc.AddTitle("Cotizacion");
            doc.AddCreator("ENMECS Software");

            PdfContentByte cb = writer.DirectContent;
            
            int enc = 0;
            float posX = 0, posY = 780;                           //VERTICAL
            //float posX = 0, posY = 600;                             //HORIZONTAL
            float x1T = 0, x2T = 0, y1T = 0, y2T = 0, x1R = 0, x2R = 0, y1R = 0, y2R = 0, xRow = 0, xCon = 0, leading = 12;
            BaseColor Linea = new BaseColor(14, 138, 194);
            BaseColor LineaNeg = new BaseColor(0, 0, 0);
            BaseColor SinLinea = new BaseColor(255, 255, 255);
            BaseColor FondoConcepto = new BaseColor(235, 253, 255);
            BaseColor FondoAmarillo = new BaseColor(210, 210, 1);
            BaseColor FondoTitulo = new BaseColor(230 , 232, 216);
            BaseColor FondoDesc = new BaseColor(255, 222, 89);
            BaseColor FondoSubT = new BaseColor(201, 226, 101);
            BaseColor FondoBlanco = new BaseColor(255, 255, 255);
            BaseColor ColorGris = new BaseColor(155, 155, 155);
            BaseColor ColorAzul = new BaseColor(0, 32, 96);
            BaseColor ColorAzul01 = new BaseColor(14, 138, 194);

            BaseColor LineaGris = new BaseColor(127, 127, 127);
            BaseColor TituloGris = new BaseColor(89, 89, 89);
            BaseColor LetraGris = new BaseColor(128, 128, 128);
            BaseColor ColorNegrita = BaseColor.BLACK;

            ///////////////////////////////////////////////////Paragraph///////////////////////////////////////////////////
            //BaseFont BF = BaseFont.CreateFont(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Windows), "c:\\windows\\fonts\\calibri.ttf"), BaseFont.CP1252, false);
            //BaseFont BF = BaseFont.CreateFont(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Windows), "c:\\windows\\fonts\\arial.ttf"), BaseFont.CP1252, false);
            string fpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Windows);
            //string fnt = @"C:\Users\Desarrollador\AppData\Local\Microsoft\Windows\Fonts\Lato-Regular.ttf";//Path.Combine(fpath, @"Fonts\Lato-Regular.ttf");
            string fnt = @"C:\Users\Desarrollador\AppData\Local\Microsoft\Windows\Fonts\JetBrainsMono-Regular.ttf";
            BaseFont BF = BaseFont.CreateFont(fnt, BaseFont.CP1252, false);
            Paragraph P;
            ColumnText col;

            //cb.SetTextMatrix(posX + 30, posY - 67.5f);
            //cb.SetTextMatrix(posX + 95, posY - 67.5f);
            //cb.SetTextMatrix(posX + 95, posY - 82.5f);

            /*****************************************************************************************************************
             ****************************************************************************************************************/
            ///////////////////////////////////////////////////Encabezado///////////////////////////////////////////////////
            Rectangle rect = new Rectangle(posX + 30, posY - 127.5f, posX + 575, posY - 140.5f);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoTitulo;
            cb.Rectangle(rect);

            col = new ColumnText(cb);
            P = new Paragraph();
            Chunk txtCom = new Chunk("COTIZACIÓN", new Font(BF, size10, Font.BOLD, ColorAzul));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + 30, posY - 126f, posX + 575, posY - 140.5f, leading, Element.ALIGN_CENTER);
            col.Go();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            //y1R = 147.5f;
            //y1T = 150.5f;
            //y2T = y2R = 172.5f;

            y2R = 144.5f;

            int numC = 1;
            foreach (DOCCONCEPTO itemCon in cotCon.listDoC)
            {
                xRow = numC == 1 ? 0 : 13;
                numC++;

                x1T = x1R = 30;
                x2T = x2R = 575;

                y1R = y2R;
                y2R = y1R + 13;

                y1T = y1R - 2;
                y2T = y1T + 15;         //22

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = FondoConcepto;
                cb.Rectangle(rect);
                
                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk(itemCon.CoDescripcion, new Font(BF, size10, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, leading, Element.ALIGN_CENTER);
                col.Go();

                //////////////////////////////////////////////////////////////////////////////////////////////////////////

                generaTitulos(cb, ref x1R, ref x2R, ref y1R, ref y2R, ref x1T, ref x2T, ref y1T, ref y2T, rect, posX, posY, xRow, ref enc);
                    
                //////////////////////////////////////////////////////////////////////////////////////////////////////////

                cotPar.DoIdent = DoIdent;
                cotPar.CoNumero = itemCon.CoNumero;
                cotPar.DpNumero = 0;
                cotPar.listado();

                int numP = 1;
                xRow = 12;
                foreach (DOCCPARTIDA itemPar in cotPar.listDCP)
                {
                    int idxF = -1;
                    string fin = "";
                    if (itemPar.DpTratamiento != null && itemPar.DpTratamiento != "")
                    {
                        foreach (string f in fin00)
                        {
                            idxF++;
                            if (f == itemPar.DpTratamiento)
                                fin = fin01[idxF];
                        }
                    }
                    string clv = itemPar.ArIdent;
                    List<string> lclv = divideTextoCorto(clv, 7);
                    string Desc;
                    if (fin != "")
                        Desc = fin.Trim() + " " + itemPar.DpDescripcion.Substring(0,1).ToLower() + itemPar.DpDescripcion.Substring(1).Trim();
                    else
                        Desc = itemPar.DpDescripcion.Trim();
                    List<string> lDesc = divideTextoCorto(Desc, 55);
                    int lin = lDesc.Count > lclv.Count ? lDesc.Count : lclv.Count;
                    
                    y1T = y2R - 4;
                    y2T = y2R + (xRow * lin) - 4;
                    y1R = y2R;
                    y2R = y2R + (xRow * lin);

                    /////////////////////////////////////////////////NÚMERO/////////////////////////////////////////////////
                    
                    if (y2T >= 750)
                    {
                        generaEncabezadoCot(cot, cb);

                        doc.NewPage();
                        enc = 0;

                        //rect = new Rectangle(posX + 30, posY - 120.5f, posX + 575, posY - 145.5f);
                        rect = new Rectangle(posX + 30, posY - 127.5f, posX + 575, posY - 140.5f);
                        rect.Border = Rectangle.BOX;
                        rect.BorderWidth = 0.5f;
                        rect.BorderColor = Linea;
                        rect.BackgroundColor = FondoTitulo;
                        cb.Rectangle(rect);

                        col = new ColumnText(cb);
                        P = new Paragraph();
                        txtCom = new Chunk("COTIZACIÓN", new Font(BF, size10, Font.BOLD, ColorAzul));
                        P.Add(txtCom);
                        //col.SetSimpleColumn(P, posX + 30, posY - 123.5f, posX + 575, posY - 148.5f, 15, Element.ALIGN_CENTER);
                        col.SetSimpleColumn(P, posX + 30, posY - 126f, posX + 575, posY - 140.5f, leading, Element.ALIGN_CENTER);
                        col.Go();

                        y2R = 144.5f;           //147.5f;

                        x1T = x1R = 30;
                        x2T = x2R = 575;

                        y1R = y2R;
                        y2R = y1R + 13;         //25

                        y1T = y1R - 2;          //+3
                        y2T = y1T + 15;         //22

                        rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                        rect.Border = Rectangle.BOX;
                        rect.BorderWidth = 0.5f;
                        rect.BorderColor = Linea;
                        rect.BackgroundColor = FondoConcepto;
                        cb.Rectangle(rect);

                        col = new ColumnText(cb);
                        P = new Paragraph();
                        txtCom = new Chunk(itemCon.CoDescripcion, new Font(BF, size10, Font.BOLD, BaseColor.BLACK));
                        P.Add(txtCom);
                        col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, leading, Element.ALIGN_CENTER);
                        col.Go();

                        //////////////////////////////////////////////////////////////////////////////////////////////////////////

                        xRow = 0;
                        generaTitulos(cb, ref x1R, ref x2R, ref y1R, ref y2R, ref x1T, ref x2T, ref y1T, ref y2T, rect, posX, posY, xRow, ref enc);
                        xRow = 12;

                        //////////////////////////////////////////////////////////////////////////////////////////////////////////

                        y1T = y2R - 4;
                        y2T = y2R + (xRow * lin) - 4;
                        y1R = y2R;
                        y2R = y2R + (xRow * lin);
                    }

                    x1T = x1R = 30;
                    x2T = x2R = 58;

                    rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                    rect.Border = Rectangle.BOX;
                    rect.BorderWidth = 0.5f;
                    rect.BorderColor = Linea;
                    rect.BackgroundColor = FondoBlanco;
                    cb.Rectangle(rect);

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk(numP.ToString(), new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, leading, Element.ALIGN_CENTER);
                    col.Go();

                    /////////////////////////////////////////////////CLAVE/////////////////////////////////////////////////
                    x1T = x1R = 58;
                    x2T = x2R = 100;

                    rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                    rect.Border = Rectangle.BOX;
                    rect.BorderWidth = 0.5f;
                    rect.BorderColor = Linea;
                    rect.BackgroundColor = FondoBlanco;
                    cb.Rectangle(rect);

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk(itemPar.ArIdent, new Font(BF, size08, Font.NORMAL, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T + 3, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_CENTER);
                    col.Go();

                    /////////////////////////////////////////////////DESCRIPCIÓN/////////////////////////////////////////////////
                    x1T = x1R = 100;
                    x2T = x2R = 382;

                    rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                    rect.Border = Rectangle.BOX;
                    rect.BorderWidth = 0.5f;
                    rect.BorderColor = Linea;
                    rect.BackgroundColor = FondoBlanco;
                    cb.Rectangle(rect);

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk(Desc, new Font(BF, size08, Font.NORMAL, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T + 3, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();

                    /////////////////////////////////////////////////U. MEDIDA/////////////////////////////////////////////////
                    x1T = x1R = 382;
                    x2T = x2R = 415;

                    rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                    rect.Border = Rectangle.BOX;
                    rect.BorderWidth = 0.5f;
                    rect.BorderColor = Linea;
                    rect.BackgroundColor = FondoBlanco;
                    cb.Rectangle(rect);

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk(itemPar.DpUnidad.Trim(), new Font(BF, size08, Font.NORMAL, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, leading, Element.ALIGN_CENTER);
                    col.Go();

                    /////////////////////////////////////////////////CANTIDAD/////////////////////////////////////////////////
                    x1T = x1R = 415;
                    x2T = x2R = 448;

                    rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                    rect.Border = Rectangle.BOX;
                    rect.BorderWidth = 0.5f;
                    rect.BorderColor = Linea;
                    rect.BackgroundColor = FondoBlanco;
                    cb.Rectangle(rect);

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk(itemPar.DpCantidad.ToString(), new Font(BF, size08, Font.NORMAL, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_RIGHT);
                    col.Go();

                    /////////////////////////////////////////////////PRECIO UNITARIO/////////////////////////////////////////////////
                    x1T = x1R = 448;
                    x2T = x2R = 511;

                    rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                    rect.Border = Rectangle.BOX;
                    rect.BorderWidth = 0.5f;
                    rect.BorderColor = Linea;
                    rect.BackgroundColor = FondoBlanco;
                    cb.Rectangle(rect);

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk("$ " + itemPar.ArPrecioPub.ToString("N2").Trim(), new Font(BF, size08, Font.NORMAL, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_RIGHT);
                    col.Go();

                    /////////////////////////////////////////////////IMPORTE/////////////////////////////////////////////////
                    x1T = x1R = 511;
                    x2T = x2R = 575;

                    rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                    rect.Border = Rectangle.BOX;
                    rect.BorderWidth = 0.5f;
                    rect.BorderColor = Linea;
                    rect.BackgroundColor = FondoBlanco;
                    cb.Rectangle(rect);

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk("$ " + itemPar.DpImporte.ToString("N2").Trim(), new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_RIGHT);
                    col.Go();

                    numP++;
                }
            }
            /*****************************************************************************************************************
                ****************************************************************************************************************/
            /////////////////////////////////////////////////SUBTOTAL/////////////////////////////////////////////////
            
            y1T = y2R - 4;
            y2T = y2R + xRow - 4;
            y1R = y2R;
            y2R = y2R + xRow;

            x1T = x1R = 448;    //415
            x2T = x2R = 511;    //495

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("SUBTOTAL", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_RIGHT);
            col.Go();

            x1T = x1R = 511;    //495
            x2T = x2R = 575;    //575

            rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("$ 6,250.00", new Font(BF, size08, Font.BOLD, ColorAzul));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_RIGHT);
            col.Go();

            /////////////////////////////////////////////////DESCUENTO/////////////////////////////////////////////////
            if (cot.DoDesc > 0)
            {
                y1T = y2R - 4;
                y2T = y2R + xRow - 4;
                y1R = y2R;
                y2R = y2R + xRow;

                x1T = x1R = 448;    //415
                x2T = x2R = 511;    //495

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = SinLinea;
                rect.BackgroundColor = FondoDesc;
                cb.Rectangle(rect);

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk("Desc. 0.0%", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_RIGHT);
                col.Go();

                x1T = x1R = 511;    //495
                x2T = x2R = 575;    //575

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = FondoDesc;
                cb.Rectangle(rect);

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk("$ 0.00", new Font(BF, size08, Font.BOLD, ColorAzul));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_RIGHT);
                col.Go();

                /////////////////////////////////////////////////SUBTOTAL/////////////////////////////////////////////////

                y1T = y2R - 4;
                y2T = y2R + xRow - 4;
                y1R = y2R;
                y2R = y2R + xRow;

                x1T = x1R = 448;    //415
                x2T = x2R = 511;    //495

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = SinLinea;
                rect.BackgroundColor = FondoSubT;
                cb.Rectangle(rect);

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk("SUBTOTAL", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_RIGHT);
                col.Go();

                x1T = x1R = 511;    //495
                x2T = x2R = 575;    //575

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = FondoSubT;
                cb.Rectangle(rect);

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk("$ 6,250.00", new Font(BF, size08, Font.BOLD, ColorAzul));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_RIGHT);
                col.Go();
            }
            /////////////////////////////////////////////////IVA/////////////////////////////////////////////////
            y1T = y2R - 4;
            y2T = y2R + xRow - 4;
            y1R = y2R;
            y2R = y2R + xRow;

            x1T = x1R = 448;    //415
            x2T = x2R = 511;    //495

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("I.V.A. 16%", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_RIGHT);
            col.Go();

            x1T = x1R = 511;    //495
            x2T = x2R = 575;    //575

            rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("$ 1,000.00", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_RIGHT);
            col.Go();

            /////////////////////////////////////////////////TOTAL/////////////////////////////////////////////////
            y1T = y2R - 4;
            y2T = y2R + xRow - 4;
            y1R = y2R;
            y2R = y2R + xRow;

            x1T = x1R = 448;    //415
            x2T = x2R = 511;    //495

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("TOTAL", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_RIGHT);
            col.Go();

            x1T = x1R = 511;    //495
            x2T = x2R = 575;    //575

            rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("$ 7,250.00", new Font(BF, size08, Font.BOLD, ColorAzul));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_RIGHT);
            col.Go();
            /////////////////////////////////////////////////CONDICIONES GRALS./////////////////////////////////////////////////
            xRow = 12;
            y2R += 6;

            /*cotNot.DoIdent = DoIdent;
            cotNot.DnNumero = 0;
            cotNot.DnTipo = tipo00[0];
            cotNot.NoIdent = "";
            cotNot.listado();
            if (cotNot.listDoN != null && cotNot.listDoN.Count > 0)
            {*/

            
            /*foreach (DOCNOTA item in cotNot.listDoN)
            {
                y1T = y2R - 4;
                y2T = y2R + xRow - 4;
                y1R = y2R;
                y2R = y2R + xRow;

                /*y1R = y2R;
                y2R = y2R + xRow;
                y1T = y2T;
                y2T = y2T + xRow;*//*

                cc++;

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk("I." + cc.ToString().Trim() + " " + item.DnDescripcion, new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                col.Go();
            }*/

            string descNota = "", prefNota = "";
            float banNota = 0;
            int cc = 0;

            for (int j = 0; j < tipo00.Count(); j++)
            {
                
                if (tipo00[j] != "DCNIM" && banNota == 0)
                {
                    cc = 0;
                    banNota = 1;

                    y1T = y2R - 4;
                    y2T = y2R + xRow - 2;
                    y1R = y2R;
                    y2R = y2R + xRow;
                    
                    x1T = x1R = 30;
                    x2T = x2R = 575;

                    rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                    rect.Border = Rectangle.BOX;
                    rect.BorderWidth = 0.5f;
                    rect.BorderColor = Linea;
                    rect.BackgroundColor = FondoConcepto;
                    cb.Rectangle(rect);

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk("I. CONDICIONES COMERCIALES", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T - 2, posX + x2T - 3, posY - y2T - 2, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();

                    prefNota = "I.";
                }
                else if (tipo00[j] == "DCNIM")
                {
                    cc = 0;

                    y1T = y2R - 4;
                    y2T = y2R + xRow - 2;
                    y1R = y2R;
                    y2R = y2R + xRow;

                    /*y1R = y2R;
                    y2R = y2R + xRow;
                    y1T = y2T;
                    y2T = y2T + xRow;*/

                    x1T = x1R = 30;
                    x2T = x2R = 575;

                    rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                    rect.Border = Rectangle.BOX;
                    rect.BorderWidth = 0.5f;
                    rect.BorderColor = Linea;
                    rect.BackgroundColor = FondoConcepto;
                    cb.Rectangle(rect);

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk("II. NOTAS IMPORTANTES", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T - 2, posX + x2T - 3, posY - y2T - 2, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();

                    prefNota = "II.";
                }
                cotNot.DoIdent = DoIdent;
                cotNot.DnNumero = 0;
                cotNot.DnTipo = tipo00[j];
                cotNot.NoIdent = "";
                cotNot.listado();

                
                
                foreach (DOCNOTA itemNot in cotNot.listDoN)
                {
                    //103        Largo del primer renglon CONDICIONES COMERCIALES
                    //128       Largo de NOTAS IMPORTANTES
                    if (itemNot.DnActivo == "A")
                    {
                        cc++;
                        if (tipo00[j] != "DCNIM")
                            descNota = prefNota.Trim() + cc.ToString().Trim() + " " + tipo01[j];
                        else
                            descNota = prefNota.Trim() + cc.ToString().Trim();

                        string notaDoc01 = descNota.Trim() + " " + itemNot.DnDescripcion.Trim();
                        List<string> lDesc = divideTextoCorto(notaDoc01, 100);
                        int lin = lDesc.Count;

                        y1T = y2R - 4;
                        y2T = y2R + xRow - 4;
                        y1R = y2R;
                        y2R = y2R + xRow;
                        
                        col = new ColumnText(cb);
                        P = new Paragraph();
                        txtCom = new Chunk(descNota.Trim(), new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
                        P.Add(txtCom);
                        col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                        col.Go();

                        int k = 1;
                        string N = "";
                        foreach (string itemDesc in lDesc)
                        {
                            if (k == 1)
                            {
                                N = N.PadLeft(descNota.Length + 1, ' ') + itemDesc.Substring(descNota.Length + 1).Trim();
                                col = new ColumnText(cb);
                                P = new Paragraph();
                                txtCom = new Chunk(N, new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
                                P.Add(txtCom);
                                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, lin > 1 ? Element.ALIGN_JUSTIFIED_ALL : Element.ALIGN_JUSTIFIED);
                                col.Go();
                            }
                            else
                            {
                                y1T = y2R - 4;
                                y2T = y2R + xRow - 4;
                                y1R = y2R;
                                y2R = y2R + xRow;

                                N = itemDesc.Trim();
                                col = new ColumnText(cb);
                                P = new Paragraph();
                                txtCom = new Chunk(N, new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
                                P.Add(txtCom);
                                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, k < lin ? Element.ALIGN_JUSTIFIED_ALL : Element.ALIGN_JUSTIFIED);
                                col.Go();
                            }
                            k++;
                        }
                    }
                }
            }
            /*y1T = y2R - 4;
            y2T = y2R + xRow - 4;
            y1R = y2R;
            y2R = y2R + xRow;

            cc++;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("I." + cc.ToString().Trim() + " Vigencia de la Oferta:", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Esta cotización el válida por un periodo máximo de 30 días naturales a partir de la fecha indicada. Nos reservamos el derecho de recotizar nuestros precios.", new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T + 97, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            y1T = y2R - 4;
            y2T = y2R + xRow - 4;
            y1R = y2R;
            y2R = y2R + xRow;

            cc++;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("I." + cc.ToString().Trim() + " Forma de Pago:", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Transferencia Electrónica.", new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T + 75, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            y1T = y2R - 4;
            y2T = y2R + xRow - 4;
            y1R = y2R;
            y2R = y2R + xRow;

            cc++;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("I." + cc.ToString().Trim() + " Condiciones de Pago:", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("100%", new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T + 97, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            y1T = y2R - 4;
            y2T = y2R + xRow - 4;
            y1R = y2R;
            y2R = y2R + xRow;

            cc++;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("I." + cc.ToString().Trim() + " Terminos de entrega:", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Conforme al <Cliente> <Ciudad>,<Estado>.", new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T + 97, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            y1T = y2R - 4;
            y2T = y2R + xRow - 4;
            y1R = y2R;
            y2R = y2R + xRow;

            cc++;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("I." + cc.ToString().Trim() + " Plazo de Entrega:", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Inmediato, salvo previa venta.", new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T + 82, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            y1T = y2R - 4;
            y2T = y2R + xRow - 4;
            y1R = y2R;
            y2R = y2R + xRow;

            cc++;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("I." + cc.ToString().Trim() + " Se Excluye:", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Cualquier otro concepto no mencionado en esta Cotización.", new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T + 58, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();
            //}*/
            
            
            /*
            cotNot.DoIdent = DoIdent;
            cotNot.DnNumero = 0;
            cotNot.DnTipo = "DCNIM";
            cotNot.NoIdent = "";
            cotNot.listado();
            if (cotNot.listDoN != null && cotNot.listDoN.Count > 0)
            {
                foreach (DOCNOTA item in cotNot.listDoN)
                {
                    y1T = y2R - 4;
                    y2T = y2R + xRow - 4;
                    y1R = y2R;
                    y2R = y2R + xRow;

                    cc02++;

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk("I." + cc02.ToString().Trim() + " ", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk(item.DnDescripcion.Trim(), new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T + 12, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();
                }
            }*/
                /*
                cotNot.DoIdent = DoIdent;
                cotNot.DnNumero = 0;
                cotNot.DnTipo = tipo00[1];
                cotNot.NoIdent = "";
                cotNot.listado();
                if (cotNot.listDoN != null && cotNot.listDoN.Count > 0)
                {
                    y1T = y2R - 4;
                    y2T = y2R + xRow - 4;
                    y1R = y2R;
                    y2R = y2R + xRow;

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk("Vigencia de la oferta", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();

                    foreach (DOCNOTA item in cotNot.listDoN)
                    {
                        y1T = y2R - 4;
                        y2T = y2R + xRow - 4;
                        y1R = y2R;
                        y2R = y2R + xRow;

                        col = new ColumnText(cb);
                        P = new Paragraph();
                        txtCom = new Chunk(item.DnDescripcion, new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
                        P.Add(txtCom);
                        col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                        col.Go();
                    }
                }

                cotNot.DoIdent = DoIdent;
                cotNot.DnNumero = 0;
                cotNot.DnTipo = tipo00[2];
                cotNot.NoIdent = "";
                cotNot.listado();
                if (cotNot.listDoN != null && cotNot.listDoN.Count > 0)
                {
                    y1T = y2R - 4;
                    y2T = y2R + xRow - 4;
                    y1R = y2R;
                    y2R = y2R + xRow;

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk("Forma de Pago: ", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();

                    x1T = x1R = 100;
                    x2T = x2R = 575;

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk(cotNot.listDoN[0].DnDescripcion, new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();
                }
                x1T = x1R = 30;
                x2T = x2R = 575;

                cotNot.DoIdent = DoIdent;
                cotNot.DnNumero = 0;
                cotNot.DnTipo = tipo00[3];
                cotNot.NoIdent = "";
                cotNot.listado();
                if (cotNot.listDoN != null && cotNot.listDoN.Count > 0)
                {
                    y1T = y2R - 4;
                    y2T = y2R + xRow - 4;
                    y1R = y2R;
                    y2R = y2R + xRow;

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk("Condiciones de Pago: ", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();

                    x1T = x1R = 122;
                    x2T = x2R = 575;

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk(cotNot.listDoN[0].DnDescripcion, new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();
                }
                x1T = x1R = 30;
                x2T = x2R = 575;

                cotNot.DoIdent = DoIdent;
                cotNot.DnNumero = 0;
                cotNot.DnTipo = tipo00[4];
                cotNot.NoIdent = "";
                cotNot.listado();
                if (cotNot.listDoN != null && cotNot.listDoN.Count > 0)
                {
                    y1T = y2R - 4;
                    y2T = y2R + xRow - 4;
                    y1R = y2R;
                    y2R = y2R + xRow;

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk("Tiempo de Respuesta: ", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();

                    x1T = x1R = 125;
                    x2T = x2R = 575;

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk(cotNot.listDoN[0].DnDescripcion, new Font(BF, size09, Font.BOLD, ColorAzul));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();
                }
                x1T = x1R = 30;
                x2T = x2R = 575;

                cotNot.DoIdent = DoIdent;
                cotNot.DnNumero = 0;
                cotNot.DnTipo = tipo00[5];
                cotNot.NoIdent = "";
                cotNot.listado();
                if (cotNot.listDoN != null && cotNot.listDoN.Count > 0)
                {
                    foreach (DOCNOTA item in cotNot.listDoN)
                    {
                        y1T = y2R - 4;
                        y2T = y2R + xRow - 4;
                        y1R = y2R;
                        y2R = y2R + xRow;

                        col = new ColumnText(cb);
                        P = new Paragraph();
                        txtCom = new Chunk(item.DnDescripcion, new Font(BF, size09, Font.NORMAL, ColorAzul));
                        P.Add(txtCom);
                        col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                        col.Go();
                    }
                }
                x1T = x1R = 30;
                x2T = x2R = 575;

                cotNot.DoIdent = DoIdent;
                cotNot.DnNumero = 0;
                cotNot.DnTipo = tipo00[6];
                cotNot.NoIdent = "";
                cotNot.listado();
                if (cotNot.listDoN != null && cotNot.listDoN.Count > 0)
                {
                    y1T = y2R - 4;
                    y2T = y2R + xRow - 4;
                    y1R = y2R;
                    y2R = y2R + xRow;

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk("Tiempo de Entrega(#LAB): ", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();

                    x1T = x1R = 135;
                    x2T = x2R = 575;

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk(cotNot.listDoN[0].DnDescripcion, new Font(BF, size09, Font.BOLD, ColorAzul));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();
                }
                x1T = x1R = 30;
                x2T = x2R = 575;

                cotNot.DoIdent = DoIdent;
                cotNot.DnNumero = 0;
                cotNot.DnTipo = tipo00[7];
                cotNot.NoIdent = "";
                cotNot.listado();
                if (cotNot.listDoN != null && cotNot.listDoN.Count > 0)
                {
                    foreach (DOCNOTA item in cotNot.listDoN)
                    {
                        y1T = y2R - 4;
                        y2T = y2R + xRow - 4;
                        y1R = y2R;
                        y2R = y2R + xRow;

                        col = new ColumnText(cb);
                        P = new Paragraph();
                        txtCom = new Chunk(item.DnDescripcion, new Font(BF, size09, Font.NORMAL, ColorAzul));
                        P.Add(txtCom);
                        col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                        col.Go();
                    }
                }

                cotNot.DoIdent = DoIdent;
                cotNot.DnNumero = 0;
                cotNot.DnTipo = tipo00[8];
                cotNot.NoIdent = "";
                cotNot.listado();
                if (cotNot.listDoN != null && cotNot.listDoN.Count > 0)
                {
                    y1T = y2R - 4;
                    y2T = y2R + xRow - 4;
                    y1R = y2R;
                    y2R = y2R + xRow;

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk("Cláusulas y Notas adicionales:", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();

                    foreach (DOCNOTA item in cotNot.listDoN)
                    {
                        y1T = y2R - 4;
                        y2T = y2R + xRow - 4;
                        y1R = y2R;
                        y2R = y2R + xRow;

                        col = new ColumnText(cb);
                        P = new Paragraph();
                        txtCom = new Chunk(item.DnDescripcion, new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
                        P.Add(txtCom);
                        col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                        col.Go();
                    }
                }

                cotNot.DoIdent = DoIdent;
                cotNot.DnNumero = 0;
                cotNot.DnTipo = tipo00[9];
                cotNot.NoIdent = "";
                cotNot.listado();
                if (cotNot.listDoN != null && cotNot.listDoN.Count > 0)
                {
                    y1T = y2R - 4;
                    y2T = y2R + xRow - 4;
                    y1R = y2R;
                    y2R = y2R + xRow;

                    x1T = x1R = 30;
                    x2T = x2R = 575;

                    rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                    rect.Border = Rectangle.BOX;
                    rect.BorderWidth = 0.5f;
                    rect.BorderColor = Linea;
                    rect.BackgroundColor = FondoConcepto;
                    cb.Rectangle(rect);

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk("II. NOTAS IMPORTANTES", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();

                    foreach (DOCNOTA item in cotNot.listDoN)
                    {
                        y1T = y2R - 4;
                        y2T = y2R + xRow - 4;
                        y1R = y2R;
                        y2R = y2R + xRow;

                        col = new ColumnText(cb);
                        P = new Paragraph();
                        txtCom = new Chunk(item.DnDescripcion, new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
                        P.Add(txtCom);
                        col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                        col.Go();
                    }
                }

                cotNot.DoIdent = DoIdent;
                cotNot.DnNumero = 0;
                cotNot.DnTipo = tipo00[10];
                cotNot.NoIdent = "";
                cotNot.listado();
                if (cotNot.listDoN != null && cotNot.listDoN.Count > 0)
                {
                    y1T = y2R - 4;
                    y2T = y2R + xRow - 4;
                    y1R = y2R;
                    y2R = y2R + xRow;

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk("Garantía de Servicio:", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();

                    foreach (DOCNOTA item in cotNot.listDoN)
                    {
                        y1T = y2R - 4;
                        y2T = y2R + xRow - 4;
                        y1R = y2R;
                        y2R = y2R + xRow;

                        col = new ColumnText(cb);
                        P = new Paragraph();
                        txtCom = new Chunk(item.DnDescripcion, new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
                        P.Add(txtCom);
                        col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                        col.Go();
                    }
                }

                cotNot.DoIdent = DoIdent;
                cotNot.DnNumero = 0;
                cotNot.DnTipo = tipo00[11];
                cotNot.NoIdent = "";
                cotNot.listado();
                if (cotNot.listDoN != null && cotNot.listDoN.Count > 0)
                {
                    y1T = y2R - 4;
                    y2T = y2R + xRow - 4;
                    y1R = y2R;
                    y2R = y2R + xRow;

                    col = new ColumnText(cb);
                    P = new Paragraph();
                    txtCom = new Chunk("Cláusulas de Garantía no válida más relevantes:", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
                    P.Add(txtCom);
                    col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                    col.Go();

                    foreach (DOCNOTA item in cotNot.listDoN)
                    {
                        y1T = y2R - 4;
                        y2T = y2R + xRow - 4;
                        y1R = y2R;
                        y2R = y2R + xRow;

                        col = new ColumnText(cb);
                        P = new Paragraph();
                        txtCom = new Chunk(item.DnDescripcion, new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
                        P.Add(txtCom);
                        col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
                        col.Go();
                    }
                }*/

                //string infTec = "La información técnica-comercial mostrada en esta cotización es responsabilidad y propiedad de #NombreEmp; por lo que será otorgada confirmada y certificada al cliente usuario final una vez que una orden de compra ampare dicho material. Solicitamos de la manera más atenta no utilizar esta información técnica para solicitar cotizaciones a nuestra competencia para evitar así una competencia desleal.";
                string infTec = "La información técnica y/o comercial mostrada en esta cotización es de carácter con fidencial y propiedad de BKfiltración; por lo que será otorgada,confirmada y certificada al cliente-usuario final una vez que una orden de compra ampare dicho equipo, producto(s) o mercancia(s); solicitamos de la manera más atenta y respetuosa no utilizar esta información de base o punto de partida para pedir cotizaciones a otros proveedores y evitar así una competencia desleal.";
            List<string> lInfTec = divideTextoCorto(infTec, 120);
            int c = lInfTec.Count;

            y1R = y2R + (xRow * 2);
            y2R = y2R + (xRow * 2) + (xRow * c);
            y1T = y2T + (xRow * 2);
            y2T = y2T + (xRow * 2) + (xRow * c);

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(infTec, new Font(BF, size09, Font.BOLD, ColorAzul));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            y1R = y2R + (xRow * 2);
            y2R = y2R + (xRow * 2) + xRow;
            y1T = y2T + (xRow * 2);
            y2T = y2T + (xRow * 2) + xRow;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("A T E N T A M E N T E", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            y1T = y2R - 4;
            y2T = y2R + xRow - 4;
            y1R = y2R;
            y2R = y2R + xRow;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("\"RENOVANDO EL AIRE\"", new Font(BF, size09, Font.BOLD, ColorAzul01));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            y1T = y2R + (xRow * 1) - 4;
            y2T = y2R + (xRow * 1) - 4;
            y1R = y2R + (xRow * 1);
            y2R = y2R + (xRow * 1);

            /*y1R = y2R;
            y2R = y2R + xRow;
            y1T = y2T;
            y2T = y2T + xRow;*/

            rect = new Rectangle(posX + x1R, posY - y1R, posX + 120, posY - y1R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = LineaNeg;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);

            y1T = y2R - 2;
            y2T = y2R + xRow - 2;
            y1R = y2R;
            y2R = y2R + xRow;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("#Realizador", new Font(BF, size09, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            y1T = y2R - 4;
            y2T = y2R + xRow - 4;
            y1R = y2R;
            y2R = y2R + xRow;
            
            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Asesor Comercial BK", new Font(BF, size09, Font.BOLD, ColorAzul01));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            y1T = y2R - 4;
            y2T = y2R + xRow - 4;
            y1R = y2R;
            y2R = y2R + xRow;
            
            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("BK Filtración - VENDEDOR", new Font(BF, size09, Font.BOLD, ColorAzul01));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            y1T = y2R - 4;
            y2T = y2R + xRow - 4;
            y1R = y2R;
            y2R = y2R + xRow;

            /*y1R = y2R;
            y2R = y2R + xRow;
            y1T = y2T;
            y2T = y2T + xRow;*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("#GradoEstudio", new Font(BF, size09, Font.BOLD, ColorAzul01));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            y1T = y2R - 4;
            y2T = y2R + xRow - 4;
            y1R = y2R;
            y2R = y2R + xRow;
            
            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Técnico Certificado por la *NAFA", new Font(BF, size09, Font.BOLD, ColorAzul01));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            y1T = y2R - 4;
            y2T = y2R + xRow - 4;
            y1R = y2R;
            y2R = y2R + xRow;
            
            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("ventas@bkfiltracion.com.mx", new Font(BF, size09, Font.BOLD, ColorAzul01));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            y1T = y2R + (xRow * 2) - 4;
            y2T = y2R + xRow - 4;
            y1R = y2R + (xRow * 2);
            y2R = y2R + xRow;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("*NAFA: Asociación Nacional de Filtración de Aire, Virginia, EU", new Font(BF, size09, Font.ITALIC, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, leading, Element.ALIGN_JUSTIFIED);
            col.Go();

            x1T = x1R = 515;
            x2T = x2R = 575;

            y1R = 750;
            y2R = 765;
            y1T = 750;
            y2T = 765;

            /*col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Página 1 de 1", new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T - 3, posY - y2T, 15, Element.ALIGN_JUSTIFIED);
            col.Go();*/
            /*****************************************************************************************************************
             ****************************************************************************************************************/
            ///////////////////////////////////////////////////Encabezado///////////////////////////////////////////////////
            generaEncabezadoCot(cot, cb);
            
            doc.NewPage();

            termsCond(cot, doc, cb);

            PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, writer);
            
            writer.SetOpenAction(action);
            doc.Close();

            Process.Start(pathCompleto);
        }

        public void generaEncabezadoCot(_Documento cot, PdfContentByte cb)
        {
            _Empresa empresa = new _Empresa();
            empresa.EmIdent = cot.EmIdent;
            empresa.consultaUno();

            _Directorio directorio = new _Directorio();
            directorio.DiNumero = empresa.DiNumero;
            directorio.DiTipo = "";
            directorio.DiRFC = "";
            directorio.DiNombreCom = "";
            directorio.consultaUno();

            _Contacto contacto = new _Contacto();
            contacto.DiNumero = empresa.DiNumero;
            contacto.CnNumero = 1;
            contacto.CnTipo = "EMP";
            contacto.consultaUno();

            _Directorio cliente = new _Directorio();
            cliente.DiNumero = cot.DiNumero;
            cliente.DiTipo = "";
            cliente.DiRFC = "";
            cliente.DiNombreCom = "";
            cliente.consultaUno();

            _Contacto dirigido = new _Contacto();
            dirigido.DiNumero = cot.DiNumero;
            dirigido.CnNumero = cot.CnNumero01;
            dirigido.CnTipo = "CLI";
            dirigido.consultaUno();

            _Proyecto proyecto = new _Proyecto();
            proyecto.PyNumero = cot.PyNumero;
            proyecto.PyNombre = "";
            proyecto.DiNombre = "";
            proyecto.consultaUno();

            _Usuario usuario = new _Usuario();
            usuario.DiNumero = "";
            usuario.CnNumero = 0;
            usuario.UsUsuario = cot.DoUsuSeg;
            usuario.consultaUno();

            _Contacto vendedor = new _Contacto();
            vendedor.DiNumero = usuario.DiNumero;
            vendedor.CnNumero = usuario.CnNumero;
            vendedor.CnTipo = "";
            vendedor.consultaUno();

            /*****************************************************************************************************************
             ****************************************************************************************************************/
            float posX = 0, posY = 780;
            int size13 = 13, size10 = 10, size09 = 9, size08 = 8, size07 = 7;
            BaseColor ColorAzul01 = new BaseColor(14, 138, 194);
            BaseColor ColorAzul02 = new BaseColor(5, 73, 116);
            BaseColor Linea = new BaseColor(14, 138, 194);
            BaseColor sinLinea = new BaseColor(255, 255, 255);
            BaseColor FondoLin = new BaseColor(14, 138, 194);
            BaseColor FondoV = new BaseColor(230, 232, 216);

            //BaseFont f_cn = BaseFont.CreateFont(@"C:\Users\Desarrollador\AppData\Local\Microsoft\Windows\Fonts\Lato-Regular.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //string fnt = @"C:\Users\Desarrollador\AppData\Local\Microsoft\Windows\Fonts\Lato-Regular.ttf";//Path.Combine(fpath, @"Fonts\Lato-Regular.ttf");
            string fnt = @"C:\Users\Desarrollador\AppData\Local\Microsoft\Windows\Fonts\JetBrainsMono-Regular.ttf";
            BaseFont f_cn = BaseFont.CreateFont(fnt, BaseFont.CP1252, false);

            Rectangle line01 = new Rectangle(posX + 30, posY - 20.5f, posX + 575, posY - 21f);
            line01.Border = Rectangle.BOX;
            line01.BorderWidth = 1f;
            line01.BorderColor = Linea;
            line01.BackgroundColor = FondoLin;
            cb.Rectangle(line01);

            Rectangle line02 = new Rectangle(posX + 30, posY - 85.5f, posX + 575, posY - 86f);
            line02.Border = Rectangle.BOX;
            line02.BorderWidth = 0.5f;
            line02.BorderColor = Linea;
            line02.BackgroundColor = FondoLin;
            cb.Rectangle(line02);

            Rectangle line03 = new Rectangle(posX + 30, posY - 122.5f, posX + 575, posY - 123f);
            line03.Border = Rectangle.BOX;
            line03.BorderWidth = 0.5f;
            line03.BorderColor = Linea;
            line03.BackgroundColor = FondoLin;
            cb.Rectangle(line03);
            
            Rectangle rect01 = new Rectangle(posX + 30, posY - 71.5f, posX + 575, posY - 83.5f);
            rect01.Border = Rectangle.BOX;
            rect01.BorderWidth = 0.5f;
            rect01.BorderColor = sinLinea;
            rect01.BackgroundColor = FondoV;
            cb.Rectangle(rect01);

            iTextSharp.text.Image logo01 = Image.GetInstance("HechoMexico.png");
            logo01.SetAbsolutePosition(175, 721.5f);
            logo01.ScalePercent(36f);
            cb.AddImage(logo01);

            iTextSharp.text.Image logo02 = Image.GetInstance("logo_bk.png");
            logo02.SetAbsolutePosition(270f, 726f);
            logo02.ScalePercent(36f);
            cb.AddImage(logo02);

            ColumnText col = new ColumnText(cb);
            Paragraph P = new Paragraph();
            Chunk txtCom = new Chunk(directorio.DiNombreCom, new Font(f_cn, size13, Font.BOLD, ColorAzul01));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + 30, posY - 21.5f, posX + 200, posY - 33.5f, 12, Element.ALIGN_JUSTIFIED);
            col.Go();

            /*cb.SetFontAndSize(f_cn, size13);
            cb.SetColorFill(ColorAzul01);
            cb.SetTextMatrix(posX + 30, posY - 33.5f);
            cb.ShowText(directorio.DiNombreCom);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Fabricante de Sistemas de", new Font(f_cn, size09, Font.ITALIC, ColorAzul01));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + 450, posY - 28.5f, posX + 575, posY - 40.5f, 12, Element.ALIGN_JUSTIFIED);
            col.Go();

            /*cb.SetFontAndSize(f_cn, size10);
            cb.SetColorFill(ColorAzul01);
            cb.SetTextMatrix(posX + 450, posY - 40.5f);
            cb.ShowText("Fabricante de Sistemas de");*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Filtración Mecánica", new Font(f_cn, size09, Font.ITALIC, ColorAzul01));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + 465, posY - 41.5f, posX + 575, posY - 53.5f, 12, Element.ALIGN_JUSTIFIED);
            col.Go();

            /*cb.SetFontAndSize(f_cn, size10);
            cb.SetColorFill(ColorAzul01);
            cb.SetTextMatrix(posX + 465, posY - 53.5f);
            cb.ShowText("Filtración Mecánica");*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(empresa.EmLeyenda02.Trim(), new Font(f_cn, size07, Font.NORMAL, ColorAzul01));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + 30, posY - 68.5f, posX + 575, posY - 80.5f, 12, Element.ALIGN_CENTER);
            col.Go();

            /*cb.SetFontAndSize(f_cn, size08);
            cb.SetColorFill(ColorAzul01);
            cb.SetTextMatrix(posX + 30, posY - 80.5f);
            cb.ShowText(empresa.EmLeyenda02.Trim());*/

            cb.BeginText();
            ///////////////////////////////////////////////////Encabezado///////////////////////////////////////////////////
            cb.SetFontAndSize(f_cn, size09);
            cb.SetColorFill(ColorAzul02);
            cb.SetTextMatrix(posX + 30, posY - 45.5f);
            cb.ShowText(directorio.DiEstado.Trim() +", " + directorio.DiPais.Trim());

            cb.SetFontAndSize(f_cn, size09);
            cb.SetColorFill(ColorAzul02);
            cb.SetTextMatrix(posX + 30, posY - 56.5f);
            cb.ShowText("Tel. +52 " + contacto.CnTelefono.Trim());

            cb.SetFontAndSize(f_cn, size09);
            cb.SetColorFill(ColorAzul02);
            cb.SetTextMatrix(posX + 30, posY - 67.5f);
            cb.ShowText(directorio.DiPaginaWeb.Trim());
            
            cb.SetFontAndSize(f_cn, size09);
            cb.SetColorFill(ColorAzul02);
            cb.SetTextMatrix(posX + 43, posY - 98.5f);
            cb.ShowText("ATENCIÓN A ");

            if (dirigido.CnNombre != null)
            {
                cb.SetFontAndSize(f_cn, size09);
                cb.SetColorFill(ColorAzul02);
                cb.SetTextMatrix(posX + 105, posY - 98.5f);
                cb.ShowText(dirigido.CnNombre.Trim() + " " + dirigido.CnAPaterno.Trim() + " " + dirigido.CnAMaterno.Trim());
            }

            cb.SetFontAndSize(f_cn, size09);
            cb.SetColorFill(ColorAzul02);
            cb.SetTextMatrix(posX + 65, posY - 109.5f);
            cb.ShowText("C.C.P.");

            cb.SetFontAndSize(f_cn, size09);
            cb.SetColorFill(ColorAzul02);
            cb.SetTextMatrix(posX + 105, posY - 109.5f);
            cb.ShowText("C.C.P.");

            cb.SetFontAndSize(f_cn, size09);
            cb.SetColorFill(ColorAzul02);
            cb.SetTextMatrix(posX + 60, posY - 120.5f);
            cb.ShowText("CLIENTE");

            cb.SetFontAndSize(f_cn, size09);
            cb.SetColorFill(ColorAzul02);
            cb.SetTextMatrix(posX + 105, posY - 120.5f);
            cb.ShowText(cliente.DiRazonSocial.Trim());

            cb.SetFontAndSize(f_cn, size09);
            cb.SetColorFill(ColorAzul02);
            cb.SetTextMatrix(posX + 475, posY - 98.5f);
            cb.ShowText("FECHA");

            cb.SetFontAndSize(f_cn, size09);
            cb.SetColorFill(ColorAzul02);
            cb.SetTextMatrix(posX + 510, posY - 98.5f);
            cb.ShowText(cot.DoFecha.Day.ToString().PadLeft(2,'0') + "/" + cot.DoFecha.Month.ToString().PadLeft(2, '0') + "/" + cot.DoFecha.Year.ToString());

            cb.SetFontAndSize(f_cn, size09);
            cb.SetColorFill(ColorAzul02);
            cb.SetTextMatrix(posX + 475, posY - 109.5f);
            cb.ShowText("FOLIO");

            cb.SetFontAndSize(f_cn, size09);
            cb.SetColorFill(ColorAzul02);
            cb.SetTextMatrix(posX + 510, posY - 109.5f);
            cb.ShowText(cot.DoFolio.Trim());

            cb.SetFontAndSize(f_cn, size09);
            cb.SetColorFill(ColorAzul02);
            cb.SetTextMatrix(posX + 465, posY - 120.5f);
            cb.ShowText("VERSIÓN");

            cb.SetFontAndSize(f_cn, size09);
            cb.SetColorFill(ColorAzul02);
            cb.SetTextMatrix(posX + 510, posY - 120.5f);
            cb.ShowText(cot.DoVersion.ToString().Trim() + cot.DoVersionL.Trim());

            /*cb.SetFontAndSize(f_cn, size18);
            cb.SetColorFill(BaseColor.BLACK);
            cb.SetTextMatrix(posX + 250, posY - 138.5f);
            cb.ShowText("COTIZACIÓN");*/

            cb.EndText();
        }

        public void generaTitulos(PdfContentByte cb, ref float x1R, ref float x2R, ref float y1R, ref float y2R, ref float x1T, ref float x2T, ref float y1T, ref float y2T, Rectangle rect, float posX, float posY, float xRow, ref int enc)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            //BaseFont BF = BaseFont.CreateFont(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Windows), "c:\\windows\\fonts\\arial.ttf"), BaseFont.CP1252, false);
            string fpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Windows);
            //string fnt = @"C:\Users\Desarrollador\AppData\Local\Microsoft\Windows\Fonts\Lato-Regular.ttf";//Path.Combine(fpath, @"Fonts\Lato-Regular.ttf");
            string fnt = @"C:\Users\Desarrollador\AppData\Local\Microsoft\Windows\Fonts\JetBrainsMono-Regular.ttf";
            BaseFont BF = BaseFont.CreateFont(fnt, BaseFont.CP1252, false);
            Paragraph P;
            ColumnText col;
            Chunk txtCom;
            BaseColor Linea = new BaseColor(14, 138, 194);
            BaseColor FondoBlanco = new BaseColor(255, 255, 255);
            int size08 = 08;

            if (enc == 0)
            {
                y1R = 157.5f + xRow;        //172.5f
                y2R = 172.5f + xRow;        //192.5f
                y1T = 153.5f + xRow;        //170.5f
                y2T = 168.5f + xRow;        //190.5f

                x1T = x1R = 30;
                x2T = x2R = 58;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = FondoBlanco;
                cb.Rectangle(rect);

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk("ITEM", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
                col.Go();

                x1T = x1R = 58;
                x2T = x2R = 100;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = FondoBlanco;
                cb.Rectangle(rect);

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk("CLAVE", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
                col.Go();

                x1T = x1R = 100;
                x2T = x2R = 382;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = FondoBlanco;
                cb.Rectangle(rect);

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk("DESCRIPCIÓN", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
                col.Go();

                x1T = x1R = 382;
                x2T = x2R = 415;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = FondoBlanco;
                cb.Rectangle(rect);

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk("UNIDAD", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
                col.Go();

                x1T = x1R = 415;
                x2T = x2R = 448;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = FondoBlanco;
                cb.Rectangle(rect);

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk("CANT.", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
                col.Go();

                x1T = x1R = 448;
                x2T = x2R = 511;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = FondoBlanco;
                cb.Rectangle(rect);

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk("PRECIO UNIT.", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
                col.Go();

                x1T = x1R = 511;
                x2T = x2R = 575;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = FondoBlanco;
                cb.Rectangle(rect);

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk("IMPORTE", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
                col.Go();

                enc = 1;
            }
        }

        public List<string> divideTextoCorto(string texto, int largo)
        {
            List<string> lineas = new List<string>();

            string[] espacio = texto.Trim().Split(' ');
            string val1 = "", val2 = "";
            int i = 1;
            if (texto.Length < largo)
            {
                lineas.Add(texto);
                //lineas.Add(" ");
            }
            else
            {
                foreach (string item2 in espacio)
                {
                    val1 += item2.Trim() + " ";
                    val2 = val1.Trim() + " " + (i == espacio.Count() ? "" : espacio[i]);
                    i++;
                    if (val2.Length > largo)
                    {
                        lineas.Add(val1.Trim());
                        val1 = "";
                    }
                }
                if (val2.Trim().Length > 0)
                    lineas.Add(val2);
            }

            return lineas;
        }

        public void generaBateo()
        {
            _Bateo bateo = new _Bateo();
            string nombrePDF = "Bateo" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".pdf";
            float ultP = 0;
            int size18 = 18, size15 = 15, size11 = 11, size10 = 10, size09 = 9, size08 = 8, size07 = 7, size06 = 6;
            FileStream fs = new FileStream(nombrePDF, FileMode.Create);
            Document doc = new Document(PageSize.LETTER.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, doc.PageSize.Height, 0.85f);
            doc.Open();

            bateo.generaBateo();

            doc.AddTitle("Cotizacion");
            doc.AddCreator("ENMECS Software");

            PdfContentByte cb = writer.DirectContent;

            //float posX = 0, posY = 780;                           //VERTICAL
            float posX = 0, posY = 600;                             //HORIZONTAL
            float x1T = 0, x2T = 0, y1T = 0, y2T = 0, x1R = 0, x2R = 0, y1R = 0, y2R = 0, xRow = 0;
            BaseColor Linea = new BaseColor(0, 0, 0);
            BaseColor FondoCrema = new BaseColor(253, 233, 217);
            BaseColor FondoAmarillo = new BaseColor(210, 210, 1);
            BaseColor FondoAzul = new BaseColor(218, 238, 243);
            BaseColor FondoBlanco = new BaseColor(255, 255, 255);
            BaseColor ColorGris = new BaseColor(155, 155, 155);
            BaseColor ColorAzul = new BaseColor(0, 32, 96);

            BaseColor LineaGris = new BaseColor(127, 127, 127);
            BaseColor TituloGris = new BaseColor(89, 89, 89);
            BaseColor LetraGris = new BaseColor(128, 128, 128);
            BaseColor ColorNegrita = BaseColor.BLACK;

            ///////////////////////////////////////////////////Paragraph///////////////////////////////////////////////////
            BaseFont BF = BaseFont.CreateFont(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Windows), "c:\\windows\\fonts\\arial.ttf"), BaseFont.CP1252, false);
            Paragraph P;
            ColumnText col;

            /*****************************************************************************************************************
             ****************************************************************************************************************/
            ///////////////////////////////////////////////////Encabezado///////////////////////////////////////////////////
            x1R = 30;
            y1R = 5.5f;
            x2R = 575;
            y2R = 20.5f;

            col = new ColumnText(cb);
            P = new Paragraph();
            Chunk txtCom = new Chunk("Enmecs Sales Report", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1R, posY - (y1R + 3), posX + x2R, posY - (y2R + 3), 15, Element.ALIGN_LEFT);
            col.Go();

            x1R = 30;
            y1R = 0.5f;
            x2R = 760;
            y2R = 15.5f;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("®Copyright ENMECS. All Rights Reserved", new Font(BF, size08, Font.BOLD, new BaseColor(169, 169, 169)));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1R, posY - (y1R + 3), posX + x2R, posY - (y2R + 3), 15, Element.ALIGN_RIGHT);
            col.Go();

            x1R = 500;
            y1R = 10.5f;
            x2R = 680;
            y2R = 25.5f;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Fecha:", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1R, posY - (y1R + 3), posX + x2R, posY - (y2R + 3), 15, Element.ALIGN_RIGHT);
            col.Go();

            x1R = 690;
            y1R = 10.5f;
            x2R = 760;
            y2R = 25.5f;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Mar, 08/12/2020", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1R, posY - (y1R + 3), posX + x2R, posY - (y2R + 3), 15, Element.ALIGN_LEFT);
            col.Go();

            x1R = 500;
            y1R = 20.5f;
            x2R = 680;
            y2R = 35.5f;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("TDC (D.O.F.):", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1R, posY - (y1R + 3), posX + x2R, posY - (y2R + 3), 15, Element.ALIGN_RIGHT);
            col.Go();

            x1R = 690;
            y1R = 20.5f;
            x2R = 760;
            y2R = 35.5f;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("$ 21.8692", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1R, posY - (y1R + 3), posX + x2R, posY - (y2R + 3), 15, Element.ALIGN_LEFT);
            col.Go();

            x1R = 30;
            y1R = 25.5f;
            x2R = 575;
            y2R = 40.5f;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("REPORTE DE OPORTUNIDADES DE VENTA", new Font(BF, size11, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1R, posY - (y1R + 3), posX + x2R, posY - (y2R + 3), 15, Element.ALIGN_LEFT);
            col.Go();

            /***************************************************************************************************************
             ****************************************** TABLA 01 ***********************************************************
             **************************************************************************************************************/

            x1T = x1R = 30;
            y1R = 50.5f;
            y1T = y1R - 5;
            x2T = x2R = 80;
            y2T = y2R = 75.5f;
            
            Rectangle rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = BaseColor.WHITE;
            cb.Rectangle(rect);
            
            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Folio", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
            col.Go();

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Proyecto", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - (y1T + 8), posX + x2T, posY - (y2T + 8), 15, Element.ALIGN_CENTER);
            col.Go();

            x1R = 80;
            y1R = 50.5f;
            x2R = 195;
            y2R = 75.5f;

            rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = BaseColor.WHITE;
            cb.Rectangle(rect);

            x1T = 80;
            y1T = 50.5f;
            x2T = 195;
            y2T = 75.5f;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Nombre corto del Proyecto", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
            col.Go();

            x1R = 195;
            y1R = 50.5f;
            x2R = 255;
            y2R = 75.5f;

            rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = BaseColor.WHITE;
            cb.Rectangle(rect);

            x1T = 195;
            y1T = 50.5f;
            x2T = 255;
            y2T = 75.5f;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Vendedor", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
            col.Go();

            x1R = 255;
            y1R = 50.5f;
            x2R = 320;
            y2R = 75.5f;

            rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = BaseColor.WHITE;
            cb.Rectangle(rect);

            x1T = 255;
            y1T = 45.5f;
            x2T = 320;
            y2T = 75.5f;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Importe", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
            col.Go();

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("antes de I.V.A.", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - (y1T + 8), posX + x2T, posY - (y2T + 8), 15, Element.ALIGN_CENTER);
            col.Go();

            x1R = 320;
            y1R = 50.5f;
            x2R = 385;
            y2R = 75.5f;

            rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = BaseColor.WHITE;
            cb.Rectangle(rect);

            x1T = 320;
            y1T = 45.5f;
            x2T = 385;
            y2T = 75.5f;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Importe", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
            col.Go();

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("antes de I.V.A.", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - (y1T + 8), posX + x2T, posY - (y2T + 8), 15, Element.ALIGN_CENTER);
            col.Go();

            x1R = 385;
            y1R = 50.5f;
            x2R = 435;
            y2R = 75.5f;

            rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = BaseColor.WHITE;
            cb.Rectangle(rect);

            x1T = 385;
            y1T = 45.5f;
            x2T = 435;
            y2T = 75.5f;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Fecha", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
            col.Go();

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Cotización", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - (y1T + 8), posX + x2T, posY - (y2T + 8), 15, Element.ALIGN_CENTER);
            col.Go();

            x1R = 435;
            y1R = 50.5f;
            x2R = 485;
            y2R = 75.5f;

            rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = BaseColor.WHITE;
            cb.Rectangle(rect);

            x1T = 435;
            y1T = 45.5f;
            x2T = 485;
            y2T = 75.5f;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Versión", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
            col.Go();

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Cotización", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - (y1T + 8), posX + x2T, posY - (y2T + 8), 15, Element.ALIGN_CENTER);
            col.Go();

            x1R = 485;
            y1R = 50.5f;
            x2R = 550;
            y2R = 75.5f;

            rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = BaseColor.WHITE;
            cb.Rectangle(rect);

            x1T = 485;
            y1T = 50.5f;
            x2T = 550;
            y2T = 75.5f;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Oportunidad", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
            col.Go();

            x1R = 550;
            y1R = 50.5f;
            x2R = 620;
            y2R = 75.5f;

            rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = BaseColor.WHITE;
            cb.Rectangle(rect);

            x1T = 550;
            y1T = 50.5f;
            x2T = 620;
            y2T = 75.5f;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Interés", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
            col.Go();

            x1R = 620;
            y1R = 50.5f;
            x2R = 690;
            y2R = 75.5f;

            rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = BaseColor.WHITE;
            cb.Rectangle(rect);

            x1T = 620;
            y1T = 45.5f;
            x2T = 690;
            y2T = 75.5f;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Plan de", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
            col.Go();

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Acción", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - (y1T + 8), posX + x2T, posY - (y2T + 8), 15, Element.ALIGN_CENTER);
            col.Go();

            x1R = 690;
            y1R = 50.5f;
            x2R = 760;
            y2R = 75.5f;

            rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = BaseColor.WHITE;
            cb.Rectangle(rect);

            x1T = 690;
            y1T = 50.5f;
            x2T = 760;
            y2T = 75.5f;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Norte Inmediato", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
            col.Go();

            /***************************************************************************************************************
             ****************************************** TABLA 01 RENGLON***********************************************************
             **************************************************************************************************************/
             
            float row = 40;

            y1R = y2R;
            y2R = y1R + row;

            y1T = y2T;
            y2T = y1T + row;

            foreach (BATEO item in bateo.bateo)
            {
                x1R = 30;
                x2R = 80;
                x1T = 30;
                x2T = 80;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = BaseColor.WHITE;
                cb.Rectangle(rect);
                
                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk(item.DoFolio.Trim(), new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
                col.Go();

                x1R = 80;
                //y1R = 75.5f;
                x2R = 195;
                //y2R = 100.5f;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = BaseColor.WHITE;
                cb.Rectangle(rect);

                x1T = 80;
                //y1T = 75.5f;
                x2T = 195;
                //y2T = 100.5f;

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk(item.PyNombre.Trim(), new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_JUSTIFIED);
                col.Go();

                x1R = 195;
                //y1R = 75.5f;
                x2R = 255;
                //y2R = 100.5f;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = BaseColor.WHITE;
                cb.Rectangle(rect);

                x1T = 195;
                //y1T = 75.5f;
                x2T = 255;
                //y2T = 100.5f;

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk(item.DoUsuSeg, new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
                col.Go();

                x1R = 255;
                //y1R = 75.5f;
                x2R = 320;
                //y2R = 100.5f;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = BaseColor.WHITE;
                cb.Rectangle(rect);

                x1T = 255;
                //y1T = 75.5f;
                x2T = 320;
                //y2T = 100.5f;

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk("$ " + item.ImporteMOE.ToString("N2").Trim() + " USD", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_RIGHT);
                col.Go();

                x1R = 320;
                //y1R = 75.5f;
                x2R = 385;
                //y2R = 100.5f;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = BaseColor.WHITE;
                cb.Rectangle(rect);

                x1T = 320;
                //y1T = 75.5f;
                x2T = 385;
                //y2T = 100.5f;

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk("$ " + item.ImporteMXN.ToString("N2").Trim() + " MN", new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_RIGHT);
                col.Go();

                x1R = 385;
                //y1R = 75.5f;
                x2R = 435;
                //y2R = 100.5f;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = BaseColor.WHITE;
                cb.Rectangle(rect);

                x1T = 385;
                //y1T = 75.5f;
                x2T = 435;
                //y2T = 100.5f;

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk(item.DoFecha.Day.ToString().PadLeft(2, '0') + "/" + item.DoFecha.Month.ToString().PadLeft(2, '0') + "/" + item.DoFecha.Year.ToString(), new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
                col.Go();

                x1R = 435;
                //y1R = 75.5f;
                x2R = 485;
                //y2R = 100.5f;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = BaseColor.WHITE;
                cb.Rectangle(rect);

                x1T = 435;
                //y1T = 75.5f;
                x2T = 485;
                //y2T = 100.5f;

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk(item.DoVersionL.Trim() + item.DoVersion.ToString().Trim(), new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
                col.Go();

                x1R = 485;
                //y1R = 75.5f;
                x2R = 550;
                //y2R = 100.5f;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = BaseColor.WHITE;
                cb.Rectangle(rect);

                x1T = 485;
                //y1T = 75.5f;
                x2T = 550;
                //y2T = 100.5f;

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk(item.CvOportunidad, new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
                col.Go();

                x1R = 550;
                //y1R = 75.5f;
                x2R = 620;
                //y2R = 100.5f;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = BaseColor.WHITE;
                cb.Rectangle(rect);

                x1T = 550;
                //y1T = 75.5f;
                x2T = 620;
                //y2T = 100.5f;

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk(item.Interes, new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
                col.Go();

                x1R = 620;
                //y1R = 75.5f;
                x2R = 690;
                //y2R = 100.5f;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = BaseColor.WHITE;
                cb.Rectangle(rect);

                x1T = 620;
                //y1T = 75.5f;
                x2T = 690;
                //y2T = 100.5f;

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk(item.PlanAccion, new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
                col.Go();

                x1R = 690;
                //y1R = 75.5f;
                x2R = 760;
                //y2R = 100.5f;

                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = BaseColor.WHITE;
                cb.Rectangle(rect);

                x1T = 690;
                //y1T = 75.5f;
                x2T = 760;
                //y2T = 100.5f;

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk(item.Norte, new Font(BF, size08, Font.BOLD, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_CENTER);
                col.Go();
                //////////////////////////////////////////////////////////////////////////////////////////////////////////

                x1R = 30;
                y1R = y2R;
                x2R = 575;
                y2R = y2R + row;

                y1T = y2T;
                y2T = y2T + row;
            }

            /*****************************************************************************************************************
             ****************************************************************************************************************/

            doc.NewPage();
            PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, writer);
            writer.SetOpenAction(action);
            doc.Close();
        }

        public void termsCond(_Documento cot, Document doc, PdfContentByte cb)
        {
            int sizeTit = 10, sizeTex = 8;
            //FileStream fs = new FileStream(nombrePDF, FileMode.Create);
            //Document doc = new Document(PageSize.LETTER);
            //PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            //PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, doc.PageSize.Height, 0.85f);
            //doc.Open();

            //doc.AddTitle("Cotizacion");
            //doc.AddCreator("ENMECS Software");

            //PdfContentByte cb = writer.DirectContent;

            int enc = 0;
            float posX = 0, posY = 780;                           //VERTICAL
            //float posX = 0, posY = 600;                             //HORIZONTAL
            float x1T = 0, x2T = 0, y1T = 0, y2T = 0, x1R = 0, x2R = 0, y1R = 0, y2R = 0, xRow = 0;
            List<string> linTex;
            int lineas;
            BaseColor Linea = new BaseColor(0, 0, 0);
            BaseColor FondoAzul = new BaseColor(218, 238, 243);
            BaseColor FondoBlanco = new BaseColor(255, 255, 255);
            BaseColor ColorAzul = new BaseColor(0, 32, 96);
            BaseColor ColorPieAzul = new BaseColor(218, 238, 243);

            BaseColor LineaGris = new BaseColor(127, 127, 127);
            BaseColor TituloGris = new BaseColor(89, 89, 89);
            BaseColor LetraGris = new BaseColor(128, 128, 128);
            BaseColor ColorNegrita = BaseColor.BLACK;

            ///////////////////////////////////////////////////Paragraph///////////////////////////////////////////////////
            //BaseFont BF = BaseFont.CreateFont(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Windows), "c:\\windows\\fonts\\calibri.ttf"), BaseFont.CP1252, false);
            string fpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Windows);
            //string fnt = @"C:\Users\Desarrollador\AppData\Local\Microsoft\Windows\Fonts\Lato-Regular.ttf";//Path.Combine(fpath, @"Fonts\Lato-Regular.ttf");
            string fnt = @"C:\Users\Desarrollador\AppData\Local\Microsoft\Windows\Fonts\JetBrainsMono-Regular.ttf";
            BaseFont BF = BaseFont.CreateFont(fnt, BaseFont.CP1252, false);
            Paragraph P;
            ColumnText col;

            //cb.SetTextMatrix(posX + 30, posY - 67.5f);
            //cb.SetTextMatrix(posX + 95, posY - 67.5f);
            //cb.SetTextMatrix(posX + 95, posY - 82.5f);

            generaEncabezadoCot(cot, cb);

            /*****************************************************************************************************************
             ****************************************************************************************************************/
            ///////////////////////////////////////////////////Encabezado///////////////////////////////////////////////////
            Rectangle rect = new Rectangle(posX + 30, posY - 127.5f, posX + 575, posY - 140.5f);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoAzul;
            cb.Rectangle(rect);

            col = new ColumnText(cb);
            P = new Paragraph();
            Chunk txtCom = new Chunk("III. TÉRMINOS Y CONDICIONES DE VENTA", new Font(BF, sizeTit, Font.BOLD, ColorAzul));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + 30, posY - 126f, posX + 575, posY - 140.5f, 15, Element.ALIGN_CENTER);
            col.Go();
            
            string[] texto = {
            "     Este documento contiene los Términos y Condiciones de Venta que regirán en la cotización con número de Folio ___________________ que ofrece el \"VENDEDOR\" al \"COMPRADOR\".",
            "La presentación de documentos adicionales de compra por el \"COMPRADOR\" y la firma de esta cotización por parte del \"COMPRADOR\" le permite que el \"VENDEDOR\" comience con la ejecución de esta cotización y ordenar la producción de equipo(s), producto(s) o mercancía(s), se considera como una aceptación de esta cotización y se considerará un contrato. Cualquiera de estos eventos se considerará como la fecha efectiva del contrato y la fecha de terminación será cuando los siguientes eventos se completen: el \"COMPRADOR\" complete todos los pagos y los fondos se aclaren en las cuentas bancarias del \"VENDEDOR\" y; el \"VENDEDOR\" entregue todo. Cualquier compra adicional requerirá la negociación de una cotización separada e independiente. Cualquier otro término y/ o condición(es) diferente(s) contenido(s) en tal(es)documento(s) adicional(es) presentado(s) por el \"COMPRADOR\" aun cuando dicho(s) término(s) altere(n) materialmente esta Cotización, es o son rechazados por \"vendedor\" y no forman parte de este contrato entre el \"COMPRADOR\" y el \"VENDEDOR\", a menos que el \"VENDEDOR\" lo acuerde expresamente por escrito.",
            "III.1 ACEPTACIÓN DE CONTRATO: Los términos y condiciones de venta establecidos en este documento de cotización, todos los dibujos, especificaciones, descripciones y otros documentos adjuntos e incorporados aquí como referencia constituyen el acuerdo completo entre el \"VENDEDOR\" y el \"COMPRADOR\"; la aceptación por parte del \"VENDEDOR\" de este pedido está expresamente condicionada con el consentimiento del \"COMPRADOR\" a los términos del acuerdo completo. Los términos y condiciones de la propuesta del \"VENDEDOR\" y el reconocimiento prevalecerán sobre los términos diferentes o de conflicto que se presenten en el pedido del \"COMPRADOR\", a menos que:",
            "          III.1.1 El \"COMPRADOR\" notifique al \"VENDEDOR\" por escrito sus objeciones dentro de los tres (3) días posteriores a la recepción del reconocimiento del \"VENDEDOR\".",
            "          III.1.2 El \"VENDEDOR\" acepte por escrito las objeciones del \"COMPRADOR\"; el hecho de que el \"VENDEDOR\" no se oponga a ninguna disposición en conflicto con el presente documento, ya sea contenida en la orden de compra del \"COMPRADOR\" o de otra manera, no se interpretará como una renuncia a las disposiciones del presente documento ni como una aceptación de las mismas. La propuesta del \"VENDEDOR\" es solo preliminar a menos que se confirme lo contrario. Si alguno de los términos y condiciones de la propuesta del \"VENDEDOR\" entra en conflicto  con estas condiciones generales de venta, prevalecerán los contenidos en la propuesta de Cotización.",
            "III.2 INSTALACIÓN: Si el \"VENDEDOR\" acordó instalar el equipo, producto(s) o mercancia(s), el \"VENDEDOR\"  garantiza que dicha instalación se realizará de manera profesional y conforme a una cotización enviada por correo electrónico a el \"COMPRADOR\"; el cuál deberá pagar todos los costos de dicha instalación, incluido el costo de cualquier modificación al equipo, producto(s) o mercancia(a) del \"COMPRADOR\" que sean necesarios para colocar o acomodar el equipo, producto(s) o mercancia(s) del \"VENDEDOR\".",
            "III.3 ENVÍOS: Todos los envíos son conforme al Incoterm ExWorks (EXW) en San Pedro Cholula, Puebla; los costos de flete son responsabilidad del \"COMPRADOR\". El equipo, producto(s) o mercancia(s) puede ser enviado por un flete directo o por las empresas de paquetería indicados por el \"COMPRADOR\" de acuerdo a la zona que corresponda; la responsabilidad del \"VENDEDOR\" termina al momento en que el equipo, producto(s) o mercancia(s) sea entregada a el transportista o a el \"COMPRADOR\"; por lo que el \"VENDEDOR\" no se hace responsable por los daños ocasionados en el equipo, producto(s) o mercancia(s) después de haber sido entregada.",
            "III.4 COBRANZA: Todo equipo, producto(s) o mercancia(s) solicitados y facturados serán liquidados conforme se indica en las condiciones de pago del apartado I numeral 4. No se surtirán nuevas órdenes de compra hasta no haber pagado al 100% la factura por el equipo, producto(s) o mercancia(s) anteriormente adquirida.",
            "III.5 PEDIDOS ESPECIALES: Todos los equipos de fabricación especial o que no son de línea y que sean solicitados por el \"COMPRADOR\" según su diseño, están sujetos a los términos y condiciones detallados en la cotización expedida por BK Filtración requiriendo como mínimo un 50% (cincuenta por ciento) de anticipo o más según el costo del equipo, producto(s) o mercancia indicado en el apartado I numeral 4.",
            "III.6 GARANTÍAS: El \"VENDEDOR\" garantiza que el equipo, producto(s) o mercancias(a) vendidos se ajustan  a los dibujos y  especificaciones aplicables aceptados por escrito por el \"VENDEDOR\" y estarán libres de cualquier defecto en el material y la mano de obra que se haga evidente en el uso normal, y que el \"COMPRADOR\" notifique por escrito al Vendedor dentro  de un  período de 12 meses desde la fecha de envío. Si, dentro de ese período, el \"VENDEDOR\" recibe del \"COMPRADOR\" una notificación por escrito de cualquier supuesto defecto o incumplimiento de cualquier producto y si, a criterio exclusivo del \"VENDEDOR\", el producto no cumple o se encuentra defectuoso en material o mano de obra, entonces el \"COMPRADOR\" deberá, a solicitud del \"VENDEDOR\", devolver la pieza, producto(s) o mercancia(s), con un Incoterm Delivery Duty Paid (DDP); es decir, pagado hasta el punto de envío designado por el \"COMPRADOR\", y el \"VENDEDOR\", a su discreción y gastos, reparará o reemplazará la parte, producto(s) o mercancia(s) defectuoso(s). El desmontaje y reinstalación de piezas defectuosas o no conformes se realiza a expensas del \"COMPRADOR\". La garantía para la entrega de piezas de repuesto o el reemplazo de piezas no conformes vence cuando caduca la garantía del equipo original la cuál es de 12 meses. Cualquier reembolso del precio de compra será sin intereses. La única responsabilidad del \"VENDEDOR\", y el remedio exclusivo del \"COMPRADOR\" a continuación se limitará a dicha reparación o reemplazo. NO HAY OTRAS GARANTÍAS, EXPRESAS, ESTATUTARIAS O IMPLÍCITAS, INCLUIDAS, PERO SIN LIMITARSE A, CUALQUIER GARANTÍA DECOMERCIABILIDAD, CALIDAD O IDONEIDAD PARA UN PROPÓSITO PARTICULAR, NI NINGUNA AFIRMACIÓN DE HECHO O REPRESENTACIÓN QUE SE EXTENDE MÁS ALLÁ DE LA DESCRIPCIÓN PRESENTADA EN ESTE DOCUMENTO DE COTIZACIÓN.",
            "Las garantías del \"VENDEDOR\" no cubren, y el \"VENDEDOR\" no ofrece ninguna garantía con respecto a:",
            "          6.1 Fallas no informadas al \"VENDEDOR\" dentro del período de garantía especificado anteriormente.",
            "          6.2 Falla o daño debido a una aplicación incorrecta, abuso, instalación mecánica, eléctrica y/o neumática incorrecta o condiciones anormales de temperatura, suciedad o materia corrosiva o en caso de desastres naturales.",
            "          6.3 Fallas debidas al funcionamiento inadecuado, ya sea intencional o no, por encima de las capacidades de flujo de aire, caída de presión o velocidad de operación para lo que fue diseñado el equipo o producto.",
            "          6.4 Equipo(s), producto(s) o mercancia(s) que hayan sido alterados de cualquier forma por alguien que no sea un representante autorizado del \"VENDEDOR\".",
            "          6.5 Equipo(s), producto(s) o mercancia(s) dañados en el envío o de otro modo sin culpa del \"VENDEDOR\".",
            "          6.6 Gastos incurridos por el \"COMPRADOR\" en un intento de reparar o reelaborar cualquier supuesto producto, pieza o mercancia defectuosa.",
            "          6.7 Defectos en el material y la mano de obra atribuibles a los planos y especificaciones proporcionados por el \"COMPRADOR\".",
            "III.7 LÍMITE DE RESPONSABILIDAD: La responsabilidad exclusiva del \"VENDEDOR\" y el remedio único y exclusivo del \"COMPRADOR\" con respecto a cualquier  incumplimiento de la garantía o garantía bajo este acuerdo se limitarán a la reparación o reemplazo del precio de compra a la  única opción del \"VENDEDOR\". La responsabilidad total del \"VENDEDOR\" y cualquier responsabilidad por cualquier reclamo, daños de cualquier naturaleza, pérdidas, responsabilidades de los costos de los esfuerzos correctivos, incluidos, entre otros, los relacionados con cualquier garantía o garantía que surja o esté relacionada con el cumplimiento de este acuerdo o los productos, no excederán el precio de compra. EN NINGÚN CASO EL \"VENDEDOR\" SERÁ RESPONSABLE DE CUALQUIER DAÑO ESPECIAL, INDIRECTO, INCIDENTAL O CONSECUENTE DE CUALQUIER PERSONAJE; INCLUYENDO PERO SIN LIMITARSE A, PÉRDIDA DE USO DE INSTALACIONES PRODUCTIVAS O EQUIPO, PÉRDIDAS DE GANANCIAS, DAÑO A LA PROPIEDAD, GASTOS INCURRIDOS EN CONFIANZA EN EL RENDIMIENTO DEL \"VENDEDOR\" AQUÍ, O PÉRDIDA DE PRODUCCIÓN, SUFRIDO POR EL \"COMPRADOR\" O CUALQUIER TERCERO. El \"VENDEDOR\" renuncia a toda responsabilidad por todos y cada uno de los costos, reclamos, demandas, cargos, gastos u otros daños, ya sean directos o indirectos, incidentes a todos los daños a la propiedad  que surjan de cualquier causa de acción basada en responsabilidad estricta. El \"COMPRADOR\" no podrá contratar por su cuenta o mediante un tercero, ningún trabajador de nuestra empresa durante el plazo de vigencia de esta cotización, ni durante un (1) año siguiente después de su venta.",
            "III.8 MODIFICACIÓN, RECISIÓN Y RENUNCIA: Este contrato no puede modificarse ni rescindirse, ni ninguna de sus disposiciones quedará exenta a menos que dichas modificaciones, rescisión o renuncia sean por escrito y estén firmadas por un empleado autorizado del \"VENDEDOR\" en su oficina.",
            "III.9 CANCELACIÓN: El \"VENDEDOR\" y el \"COMPRADOR\" reconocen que debido a la singularidad de equipo(s), producto(s) o mercancia(s) ordenados o solicitados, el cálculo de los daños, incluidos, entre otros, el costo de oportunidad perdida del \"VENDEDOR\", que resultaría de la cancelación o suspensión del contrato sería difícil. Por lo tanto, si el \"COMPRADOR\" cancela cualquier pedido al: (a) comunicar verbalmente dicha cancelación, (b) no cumplir con los términos de pago del Acuerdo, (c) la morosidad continua en el pago de saldos vencidos o después del aviso de morosidad por escrito del \"VENDEDOR\", o ( d) solicitar en una o más ocasiones que el \"VENDEDOR\" suspenda la ejecución del contrato del \"VENDEDOR\" una vez que el  \"VENDEDOR\" haya comenzado a cumplir el  contrato, incluidos, entre otros, el diseño, las especificaciones, la fabricación, la fabricación, el montaje, la adquisición, el envío, la entrega, la instalación o puesta en marcha, durante más de treinta (30) días en total de todas las suspensiones solicitadas [(a), (b), (c) y (d) colectivamente y cada una individualmente constituye un \"Evento de cancelación\"], luego Además de los montos adeudados por el \"COMPRADOR\" de conformidad con este Acuerdo.",
            "III.10 MISCELÁNEOS: El \"VENDEDOR\" se reserva el derecho de proporcionar sustitutos para materiales que no pueden obtenerse razonablemente debido a restricciones, establecidas voluntaria o obligatoriamente por  o  en  conexión  con  cualquier  autoridad  o  programa  gubernamental.  El  \"VENDEDOR\"  puede,  durante  cualquier  período  de escasez debido a causas ajenas al control del \"VENDEDOR\" o de sus proveedores, prorratear su suministro de productos entre todos sus Compradores de tal manera que se considere equitativo a juicio exclusivo del \"VENDEDOR\". El \"VENDEDOR\" no incurrirá en ninguna responsabilidad ante el \"COMPRADOR\" debido a cualquier prorrateo generado. Ningún pedido se considerará aceptado por el \"VENDEDOR\" hasta que sea aceptado por escrito por un empleado autorizado del \"VENDEDOR\" en su oficina. Los derechos y deberes de las partes y la construcción y efecto de todas las disposiciones del presente se regirán e interpretarán de acuerdo con la ley del Estado aplicable de acuerdo a la Ley  Mercantil  Vigente  en  el  país de transacción, excepto que se disponga lo contrario en el presente. Cualquier acción que surja de esta venta y contrato solo puede presentarse en un tribunal estatal o federal en el País de transacción donde se recibe la orden de compra, y el \"COMPRADOR\" acepta la jurisdicción de dichos tribunales con respecto a dicha acción. Si el Vendedor no insiste en una o más instancias sobre el cumplimiento de cualquiera de los términos y condiciones de este contrato o si el \"VENDEDOR\" no ejerce ninguno de sus derechos en virtud del presente, no se interpretará como una renuncia a dicho término, condición, o justo en el presente y no afectará el derecho del \"VENDEDOR\" a insistir en el cumplimiento estricto y el cumplimiento con respecto a cualquier parte no ejecutada de este contrato o el cumplimiento futuro de estos términos y condiciones.",
            "III.11 POLÍTICA DE PRECIOS: El precio de venta aquí cotizado, no incluye el arranque de equipo(s), producto(s) o mercancía(s) ordenados o solicitados, válido sólo por treinta (30) días después de la fecha de la cotización a menos que se acuerde lo contrario por escrito en la cotización. Todos los precios están sujetos a aumento con previo aviso por varias razones, tales como aumentos de los precios en dólares o aumentos en los costos de mano de obra o materiales. No se aceptarán reclamaciones de ninguna clase por el precio una vez firmado este documento. Los precios se basan en el horario hábil normal (Lunes a Viernes de 9:00 AM-6:00 PM). Las horas por tiempo extra y en días Sábados serán facturadas a razón de 1½ x la tarifa horaria; Domingo, 2x la tarifa horaria; Feriado, 3x la tarifa horaria. El \"COMPRADOR\" voluntariamente renuncia a toda acción legal, de cualquier tipo o naturaleza, que pueda surgir en relación al precio una vez firme este Contrato.",
            "III.12 RECLAMACIONES: No se considerarán reclamaciones por escasez o errores en la orden a menos que se hagan por escrito al \"VENDEDOR\" dentro de los tres (3) días siguientes a la recepción de la cotización aceptada.",
            "III.13 DEVOLUCIONES: Los equipo(s), producto(s) o mercancía(s), no se podrán devolver a menos que el \"COMPRADOR\" obtenga el permiso previo por escrito del \"VENDEDOR\". La devolución, una vez aprobada, estará sujeta a gastos de manipulación y transporte. Los equipo(s), producto(s) o mercancía(s) autorizados para devolución deberán ser enviados pre-pagados a la ubicación designada por la autorización.",
            "III.14 CONFIDENCIALIDAD: El \"COMPRADOR\" reconoce que la INFORMACIÓN CONFIDENCIAL otorgada por el \"VENDEDOR\", tal como los clientes, los precios, y secretos de comercio relacionados, así como los nombres comerciales relativos a los equipo(s), producto(s) o mercancía(s), vendidos, (\"Información Confidencial\"), son propiedad de la Empresa. El \"COMPRADOR\" también se compromete a no revelar la Información Confidencial sin el consentimiento por escrito del \"VENDEDOR\", así como a utilizar y mostrar sólo en la manera autorizada por el \"VENDEDOR\" por escrito, y a no utilizarlas como parte de su nombre corporativo o comercial, o de ninguna manera que pudiera sugerir que el \"COMPRADOR\" se asocia con la Empresa como socio, o que no haya sido autorizado por la Empresa. El Comprador no usará ninguna de las marcas como parte de un sitio web o nombre de dominio de Internet o dirección, y no hará enlace alguno a la página web de la Empresa, salvo en conformidad con las políticas vigentes en ese momento para tal uso y previa autorización por escrito de la Empresa. Tras la rescisión de este Contrato, todo uso previamente autorizado por la Empresa de las marcas será rescindido. Además, cada parte puede divulgar de manera confidencial a la otra parte planes técnicos y planos de propiedad (\"Información Técnica\") relacionados con un proyecto particular relacionado con los equipo(s), producto(s) o mercancía(s), objeto de este contrato; cada parte acuerda que dicha Información Técnica seguirá siendo propiedad de la \"PARTE REVELADORA\", y que la \"PARTE RECEPTORA\" no divulgará dicha Información Técnica sin el consentimiento de la parte reveladora.",
            "III.15 CASO FORTUITO O FUERZA MAYOR: El \"COMPRADOR\" y el \"VENDEDOR\" convienen en que no existirá responsabilidad para esta última en cuanto al incumplimiento en la entrega de los equipo(s), producto(s) o mercancía(s), cuando dicho incumplimiento se origine por causas imputables a un caso fortuito o de fuerza mayor, situación que deberá ser notificada por escrito a la otra parte al presentarse dicha causa de fuerza mayor o caso fortuito, y en cuyo caso, según la magnitud de la fuerza mayor o caso fortuito, se suspenderán parcial o totalmente los efectos de este contrato, según se acuerden por escrito.",
            "III.16 NO RESPONSABILIDAD POR DAÑOS Y PERJUICIOS: El \"VENDEDOR\" no será responsable por daños y perjuicios compensatorios, indirectos, consecuentes, generales, especiales, ejemplares o punitivos; pérdidas, costos gastos u otros honorarlos de abogados; gastos de fabricación adicionales; el costo de la cobertura del seguro; pérdida de ganancias o de la buena fama; costos y gastos incurridos por el \"COMPRADOR\" en la defensa de cualquier reclamación; daños y perjuicios como resultado del transporte, recibo, inspección, custodia, adquisición, venta, reventa o manejo de productos del \"VENDEDOR\" por cualquier motivo.",
            "III.17 INCUMPLIMIENTO POR PARTE DEL COMPRADOR: Además de los demás derechos reservados para el \"VENDEDOR\", en virtud de estos términos y condiciones de venta, en caso de que el \"COMPRADOR\" se volviera insolvente o de que fuere entablada cualquier petición de insolvencia por o contra el \"COMPRADOR\" o si el \"COMPRADOR\" entablare una petición de cesión a beneficio de sus acreedores, o en caso de que se nombrare un síndico, agente fiscal u otro funcionario oficial para encargarse de los asuntos del \"COMPRADOR\" o el \"COMPRADOR\" efectuare transferencias dolosas o pagos preferentes, o si el \"COMPRADOR\" se negare a aceptar mercancías o si de otra manera violare sus obligaciones ante el \"VENDEDOR\"  o repudiare cualquier contrato con el \"VENDEDOR\"  o en caso de que el \"VENDEDOR\" a su exclusiva discreción tuviere duda y considerare que la condición financiera del \"COMPRADOR\" hubiere sufrido menoscabo o no justificare la continuación de la producción o embarque bajos los términos aquí acordados, el \"VENDEDOR\" se reserva el derecho de cancelar el pedido o de negarse a continuar la producción y/o entrega hasta que recibiere el pago íntegro por anticipado o una garantía y seguridad satisfactoria de que se efectuare el pago a su vencimiento. En el caso de la falta de pago por cualquier entrega efectuada, ya sea parcial o de otro tipo, el \"VENDEDOR\" podrá suspender las entregas futuras adecuadas hasta que se recibiere el pago íntegro, o podrá terminar el contrato sin necesidad de orden judicial previa. No obstante, sin perjuicio de las acciones del \"VENDEDOR\", el \"COMPRADOR\" se hará responsable de todos los costos y gastos incurridos por el \"VENDEDOR\" derivados del incumplimiento del \"COMPRADOR\", incluyendo todos los cargos de cancelación, costos de tribunal y honorarios de abogados.",
            "III.18 NO CESIÓN POR EL COMPRADOR: El \"COMPRADOR\" no tendrá el derecho de ceder o de transferir de cualquier forma el presente contrato o cualquier derecho u obligación que se derive del mismo, por las cesiones que se realicen con el consentimiento previo y por escrito del \"VENDEDOR\".",
            "III.19 CORRECCION DE ERRORES: El \"VENDEDOR\" tendrá el derecho de corregir cualquier error evidente dactilográfico o tipográfico contenido en el presente documento o en cualquiera de los documentos relacionados con la transacción de las partes.",
            "III.20 ENCABEZADOS Y PIE DE PÁGINA: Los encabezados y pie de página que se insertan en este documento son únicamente para comodidad de referencia y no podrán considerarse en la interpretación del presente Contrato."};

            y2R = 140.5f;        //85.5f;       //147.5f

            x1T = x1R = 30;
            x2T = x2R = 575;

            xRow = 12;

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        0        //////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[0], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 2)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 2)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[0], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(" " + cot.DoIdent, new Font(BF, sizeTex, Font.BOLD, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);

            col.SetSimpleColumn(P, posX + x1T, posY - y1T - 11, posX + x2T, posY - y2T - 11, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        1        //////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[1], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 11)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 11)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[1], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        2        //////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[2], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 6)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 6)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[2], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        3        //////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[3], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 2)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 2)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[3], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        4        //////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[4], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 6)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 6)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[4], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        5        //////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[5], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 5)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 5)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[5], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        6        //////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[6], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 6)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 6)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[6], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        7        //////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[7], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 3)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 3)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[7], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        8        //////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*y1T = 750;
            y2T = (y1T + (xRow * 1)) + 12;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("              BK Filtración \"RENOVANDO EL AIRE\"", new Font(BF, sizePie, Font.NORMAL, BaseColor.BLUE));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_LEFT);
            col.Go();

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Página 1 de 4", new Font(BF, sizePie, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_RIGHT);
            col.Go();*/

            doc.NewPage();

            generaEncabezadoCot(cot, cb);

            y2R = 127.5f;

            x1T = x1R = 30;
            x2T = x2R = 575;

            //y1R = y2R;
            //y2R = y1R + 25;

            y1T = y1R + 3;
            y2T = y1T + 22;

            /*linTex = divideTextoCorto(texto[8], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 4)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 4)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[8], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        9        //////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[9], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 17)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 17)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[9], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        10        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[10], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 1)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 1)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[10], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        11        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[11], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 1)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 1)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[11], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        12        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[12], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 3)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 3)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[12], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        13        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[13], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 2)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 2)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[13], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        14        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[14], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 2)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 2)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[14], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        15        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[15], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 1)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 1)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[15], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        16        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[16], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 2)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 2)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[16], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        17        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[17], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 2)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 2)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[17], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        18        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*y1T = 750;
            y2T = (y1T + (xRow * 1)) + 12;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("              BK Filtración \"RENOVANDO EL AIRE\"", new Font(BF, sizePie, Font.NORMAL, BaseColor.BLUE));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_LEFT);
            col.Go();

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Página 1 de 4", new Font(BF, sizePie, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_RIGHT);
            col.Go();*/

            doc.NewPage();

            generaEncabezadoCot(cot, cb);

            y2R = 127.5f;

            x1T = x1R = 30;
            x2T = x2R = 575;

            //y1R = y2R;
            //y2R = y1R + 25;

            y1T = y1R + 3;
            y2T = y1T + 22;

            /*linTex = divideTextoCorto(texto[18], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 15)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 15)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[18], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        19        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[19], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 3)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 3)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[19], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        20        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[20], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 12)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 12)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[20], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        21        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[21], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 18)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 18)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[21], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        22        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*y1T = 750;
            y2T = (y1T + (xRow * 1)) + 12;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("              BK Filtración \"RENOVANDO EL AIRE\"", new Font(BF, sizePie, Font.NORMAL, BaseColor.BLUE));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_LEFT);
            col.Go();

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Página 1 de 4", new Font(BF, sizePie, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_RIGHT);
            col.Go();*/

            doc.NewPage();

            generaEncabezadoCot(cot, cb);

            y2R = 127.5f;

            x1T = x1R = 30;
            x2T = x2R = 575;

            //y1R = y2R;
            //y2R = y1R + 25;

            y1T = y1R + 3;
            y2T = y1T + 22;

            /*linTex = divideTextoCorto(texto[22], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 9)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 9)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[22], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        23        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[23], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 2)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 2)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[23], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        24        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[24], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 4)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 4)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[24], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        25        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[25], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 14)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 14)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[25], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        26        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[26], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 6)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 6)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[26], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        27        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[27], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 6)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 6)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[27], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        28        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*y1T = 750;
            y2T = (y1T + (xRow * 1)) + 12;

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("              BK Filtración \"RENOVANDO EL AIRE\"", new Font(BF, sizePie, Font.NORMAL, BaseColor.BLUE));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_LEFT);
            col.Go();

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk("Página 1 de 4", new Font(BF, sizePie, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_RIGHT);
            col.Go();*/

            doc.NewPage();

            generaEncabezadoCot(cot, cb);

            y2R = 127.5f;

            x1T = x1R = 30;
            x2T = x2R = 575;

            //y1R = y2R;
            //y2R = y1R + 25;

            y1T = y1R + 3;
            y2T = y1T + 22;

            /*linTex = divideTextoCorto(texto[28], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 17)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 17)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[28], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        29        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[29], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 3)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 3)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[29], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        30        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[30], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 3)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 3)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[30], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////        31        /////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*linTex = divideTextoCorto(texto[31], 113);
            lineas = linTex.Count;

            y1T = y2R;
            y2T = (y2R + (xRow * lineas)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * lineas)) + 12;*/

            y1T = y2R;
            y2T = (y2R + (xRow * 2)) + 12;
            y1R = y2R;
            y2R = (y2R + (xRow * 2)) + 12;

            /*rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
            rect.Border = Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = Linea;
            rect.BackgroundColor = FondoBlanco;
            cb.Rectangle(rect);*/

            col = new ColumnText(cb);
            P = new Paragraph();
            txtCom = new Chunk(texto[31], new Font(BF, sizeTex, Font.NORMAL, BaseColor.BLACK));
            txtCom.setLineHeight(11.5f);
            P.Add(txtCom);
            col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 11.5f, Element.ALIGN_JUSTIFIED);
            col.Go();

            /*foreach (string item in texto)
            {
                xRow = 15;
                string Desc = item.Trim();
                List<string> lDesc = divideTextoCorto(Desc, 129);
                int lin = lDesc.Count;

                y1T = y2R - 4;
                y2T = y2R + (xRow * lin) - 4;
                y1R = y2R;
                y2R = y2R + (xRow * lin);

                if (y2T >= 750)
                {
                    doc.NewPage();

                    y2R = 0.5f;

                    x1T = x1R = 30;
                    x2T = x2R = 575;

                    y1R = y2R;
                    y2R = y1R + 25;

                    y1T = y1R + 3;
                    y2T = y1T + 22;

                    y1T = y2R - 4;
                    y2T = y2R + (xRow * lin) - 4;
                    y1R = y2R;
                    y2R = y2R + (xRow * lin);
                }
                rect = new Rectangle(posX + x1R, posY - y1R, posX + x2R, posY - y2R);
                rect.Border = Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = Linea;
                rect.BackgroundColor = FondoBlanco;
                cb.Rectangle(rect);

                col = new ColumnText(cb);
                P = new Paragraph();
                txtCom = new Chunk(item.Trim(), new Font(BF, size09, Font.NORMAL, BaseColor.BLACK));
                P.Add(txtCom);
                col.SetSimpleColumn(P, posX + x1T, posY - y1T, posX + x2T, posY - y2T, 15, Element.ALIGN_JUSTIFIED);
                col.Go();
            }*/
            
            doc.NewPage();
            //PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, writer);
            //writer.SetOpenAction(action);
            doc.Close();
        }
    }
}
