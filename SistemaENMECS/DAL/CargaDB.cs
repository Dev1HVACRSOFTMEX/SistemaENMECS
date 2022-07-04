using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using SistemaENMECS.BLL;

namespace SistemaENMECS.DAL
{
    public class CargaDB
    {
        private int dimExcelRow { get; set; } = 0;
        private int dimExcelCol { get; set; } = 0;
        private Excel.Range rango { get; set; } = null;
        private Excel.Workbook xlWorkBook { get; set; } = null;
        public string rutaArchivo { get; set; } = "";

        public void abreExcel(int hoja = 1)
        {
            Excel.Application xlApp;
            Excel.Worksheet xlWorkSheet;
            xlApp = new Excel.Application();
            rutaArchivo = rutaArchivo.Trim();
            xlWorkBook = xlApp.Workbooks.Open(rutaArchivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(hoja);

            Excel.Worksheet excelSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(hoja);
            rango = excelSheet.UsedRange;

            dimExcelRow = rango.Rows.Count;
            dimExcelCol = rango.Columns.Count;
        }

        public string CargaDireccion(string fileXLS, string tipo)
        {
            string err = "Falta indicar Archivo";

            if (rutaArchivo != "" || fileXLS != "")
            {
                err = "";
                rutaArchivo = rutaArchivo == "" ? fileXLS.ToString() : rutaArchivo;
                abreExcel();

                try
                {
                    _Directorio prv = new _Directorio();
                    _Contacto prvcon = new _Contacto();
                    int numCon = (dimExcelCol - 12) / 7;
                    for (int i = 3; i <= dimExcelRow; i++)
                    {
                        var var01 = (rango.Cells[i, 1] as Excel.Range).Value;
                        var var02 = (rango.Cells[i, 2] as Excel.Range).Value;
                        var var03 = (rango.Cells[i, 3] as Excel.Range).Value;
                        var var04 = (rango.Cells[i, 4] as Excel.Range).Value;
                        var var05 = (rango.Cells[i, 5] as Excel.Range).Value;
                        var var06 = (rango.Cells[i, 6] as Excel.Range).Value;
                        var var07 = (rango.Cells[i, 7] as Excel.Range).Value;
                        var var08 = (rango.Cells[i, 8] as Excel.Range).Value;
                        var var09 = (rango.Cells[i, 9] as Excel.Range).Value;
                        var var10 = (rango.Cells[i, 10] as Excel.Range).Value;
                        var var11 = (rango.Cells[i, 11] as Excel.Range).Value;
                        var var12 = (rango.Cells[i, 12] as Excel.Range).Value;
                        var var13 = (rango.Cells[i, 13] as Excel.Range).Value;
                        var var14 = (rango.Cells[i, 14] as Excel.Range).Value;
                        var var15 = (rango.Cells[i, 15] as Excel.Range).Value;
                        var var16 = (rango.Cells[i, 16] as Excel.Range).Value;
                        var var17 = (rango.Cells[i, 17] as Excel.Range).Value;
                        var var18 = (rango.Cells[i, 18] as Excel.Range).Value;
                        var var19 = (rango.Cells[i, 19] as Excel.Range).Value;
                        var var20 = (rango.Cells[i, 20] as Excel.Range).Value;
                        var var21 = (rango.Cells[i, 21] as Excel.Range).Value;
                        var var22 = (rango.Cells[i, 22] as Excel.Range).Value;
                        var var23 = (rango.Cells[i, 23] as Excel.Range).Value;
                        var var24 = (rango.Cells[i, 24] as Excel.Range).Value;
                        var var25 = (rango.Cells[i, 25] as Excel.Range).Value;
                        var var26 = (rango.Cells[i, 26] as Excel.Range).Value;
                        var var27 = (rango.Cells[i, 27] as Excel.Range).Value;
                        var var28 = (rango.Cells[i, 28] as Excel.Range).Value;
                        var var29 = (rango.Cells[i, 29] as Excel.Range).Value;
                        var var30 = (rango.Cells[i, 30] as Excel.Range).Value;

                        if (var01 == null)                          //DiNumero
                            prv.DiNumero = "";
                        else
                            prv.DiNumero = var01.ToString();
                        prv.DiTipo = tipo;                          //DiTipo
                        if (var02 == null)                          //DiTipo2
                            prv.DiTipo2 = "---";
                        else
                            prv.DiTipo2 = var02.ToString();
                        if (var03 == null)                          //DiNomCorto
                            prv.DiNomCorto = "";
                        else
                            prv.DiNomCorto = var03.ToString();
                        if (var04 == null)                          //DiNombreCom
                            prv.DiNombreCom = "---";
                        else
                            prv.DiNombreCom = var04.ToString();
                        if (var05 == null)                          //DIRazonSocial
                            prv.DiRazonSocial = "---";
                        else
                            prv.DiRazonSocial = var05.ToString();
                        if (var06 == null)                          //DiRFC
                            prv.DiRFC = "XXXX010101XXX";
                        else
                            prv.DiRFC = var06.ToString();
                        if (var07 == null)                          //DiTipoEmpresa
                            prv.DiTipoEmpresa = "---";
                        else
                            prv.DiTipoEmpresa = var07.ToString();
                        if (var08 == null)                          //DiCalle
                            prv.DiCalle = "";
                        else
                            prv.DiCalle = var08.ToString();
                        if (var09 == null)                          //DiNumInt
                            prv.DiNumInt = "";
                        else
                            prv.DiNumInt = var09.ToString();
                        if (var10 == null)                          //DiNumExt
                            prv.DiNumExt = "";
                        else
                            prv.DiNumExt = var10.ToString();
                        if (var11 == null)                          //DiColonia
                            prv.DiColonia = "";
                        else
                            prv.DiColonia = var11.ToString();
                        if (var12 == null)                          //DiCP
                            prv.DiCP = "";
                        else
                            prv.DiCP = var12.ToString();
                        if (var13 == null)                          //DiPoblacion
                            prv.DiPoblacion = "";
                        else
                            prv.DiPoblacion = var13.ToString();
                        if (var14 == null)                          //DiMunicipio
                            prv.DiMunicipio = "";
                        else
                            prv.DiMunicipio = var14.ToString();
                        if (var15 == null)                          //DiEstado
                            prv.DiEstado = "";
                        else
                            prv.DiEstado = var15.ToString();
                        if (var16 == null)                          //DiPais
                            prv.DiPais = "";
                        else
                            prv.DiPais = var16.ToString();
                        if (var17 == null)                          //DiNacional
                            prv.DiNacional = "";
                        else
                            prv.DiNacional = var17.ToString();
                        if (var18 == null)                          //DiClasif
                            prv.DiClasif = "ACT";
                        else
                            prv.DiClasif = var18.ToString();
                        if (var19 == null)                          //DiCCredito
                            prv.DiCCredito = "";
                        else
                            prv.DiCCredito = var19.ToString() == "Si" ? "S" : "N";
                        if (var20 == null)                          //DiDCredito
                            prv.DiDCredito = 0;
                        else
                            prv.DiDCredito = Convert.ToInt16(var20.ToString());
                        if (var21 == null)                          //DiLCredito
                            prv.DiLCredito = 0;
                        else
                            prv.DiLCredito = Convert.ToDouble(var21.ToString());
                        if (var22 == null)                          //DiDBBenef
                            prv.DiDBBenef = "";
                        else
                            prv.DiDBBenef = var22.ToString();
                        if (var23 == null)                          //DiDBBanco
                            prv.DiDBBanco = "";
                        else
                            prv.DiDBBanco = var23.ToString();
                        if (var24 == null)                          //DiDBSucursal
                            prv.DiDBSucursal = "";
                        else
                            prv.DiDBSucursal = var24.ToString();
                        if (var25 == null)                          //DiDBNumCta
                            prv.DiDBNumCta = "";
                        else
                            prv.DiDBNumCta = var25.ToString();
                        if (var26 == null)                          //DiDBCLABE
                            prv.DiDBCLABE = "";
                        else
                            prv.DiDBCLABE = var26.ToString();
                        if (var27 == null)                          //DiPaginaWeb
                            prv.DiPaginaWeb = "";
                        else
                            prv.DiPaginaWeb = var27.ToString();
                        prv.DiPjDesc = 0;
                        prv.DiRapido = "I";                         //DiRapido
                        prv.DiActivo = "A";                         //DiActivo

                        prv.guardar();
                        
                        prvcon.DiNumero = prv.DiNumero;
                        prvcon.CnNumero = 1;
                        prvcon.CnTipo = "EMP";
                        prvcon.CnNombre = "Empresa";
                        prvcon.CnAPaterno = "---";
                        prvcon.CnAMaterno = "";
                        if (var28 == null)                          //Correo
                            prvcon.CnCorreo = "";
                        else
                            prvcon.CnCorreo = var28.ToString();
                        if (var29 == null)                          //Telefono
                            prvcon.CnTelefono = "";
                        else
                            prvcon.CnTelefono = var29.ToString();
                        prvcon.CnPuesto = "General";
                        prvcon.CnGradoEst = "";
                        prvcon.CnAbrGraEst = "";
                        prvcon.CnCedula = "";
                        prvcon.CnNota = "";
                        prvcon.CnActivo = "A";
                        prvcon.guardar();

                        if (var30 != null)
                        {
                            prvcon.DiNumero = prv.DiNumero;
                            prvcon.CnNumero = 2;
                            prvcon.CnTipo = "EMP";
                            prvcon.CnNombre = "Empresa";
                            prvcon.CnAPaterno = "---";
                            prvcon.CnAMaterno = "";
                            prvcon.CnCorreo = "";
                            if (var30 == null)                          //Telefono
                                prvcon.CnTelefono = "";
                            else
                                prvcon.CnTelefono = var30;
                            prvcon.CnPuesto = "General";
                            prvcon.CnGradoEst = "";
                            prvcon.CnAbrGraEst = "";
                            prvcon.CnCedula = "";
                            prvcon.CnNota = "";
                            prvcon.CnActivo = "A";
                            prvcon.guardar();
                        }

                        int col = 30;
                        for (int y = 1; y <= numCon; y++)
                        {
                            var varC1 = (rango.Cells[i, col + 1] as Excel.Range).Value;
                            var varC2 = (rango.Cells[i, col + 2] as Excel.Range).Value;
                            var varC3 = (rango.Cells[i, col + 3] as Excel.Range).Value;
                            var varC4 = (rango.Cells[i, col + 4] as Excel.Range).Value;
                            var varC5 = (rango.Cells[i, col + 5] as Excel.Range).Value;
                            var varC6 = (rango.Cells[i, col + 6] as Excel.Range).Value;
                            var varC7 = (rango.Cells[i, col + 7] as Excel.Range).Value;

                            prvcon.DiNumero = prv.DiNumero;
                            prvcon.CnNumero = y + 2;
                            prvcon.CnTipo = "CON";
                            if (varC1 == null)                      //Nombre
                                prvcon.CnNombre = "";
                            else
                                prvcon.CnNombre = varC1.ToString();
                            if (varC2 == null)                      //A. Paterno
                                prvcon.CnAPaterno = "";
                            else
                                prvcon.CnAPaterno = varC2.ToString();
                            if (varC3 == null)                      //A. Materno
                                prvcon.CnAMaterno = "";
                            else
                                prvcon.CnAMaterno = varC3.ToString();
                            if (varC4 == null)                      //Correo
                                prvcon.CnCorreo = "";
                            else
                                prvcon.CnCorreo = varC4.ToString();
                            if (varC5 == null)                      //Telefono
                                prvcon.CnTelefono = "";
                            else
                                prvcon.CnTelefono = varC5.ToString();
                            if (varC6 == null)                      //Puesto
                                prvcon.CnPuesto = "";
                            else
                                prvcon.CnPuesto = varC6.ToString();
                            if (varC7 == null)                      //Nota
                                prvcon.CnNota = "";
                            else
                                prvcon.CnNota = varC7.ToString();
                            prvcon.CnGradoEst = "";
                            prvcon.CnAbrGraEst = "";
                            prvcon.CnCedula = "";
                            prvcon.CnActivo = "A";
                            prvcon.guardar();

                            col += 7;
                        }
                    }
                }
                catch (Exception ex)
                {
                    err = ex.Message;
                }
                finally
                {
                    xlWorkBook.Close();
                }

            }

            return err;
        }

        public string CargaProducto(string fileXLS)
        {
            string resultado = "";

            string err = "Falta indicar Archivo";

            if (rutaArchivo != "" || fileXLS != "")
            {
                err = "";
                rutaArchivo = rutaArchivo == "" ? fileXLS.ToString() : rutaArchivo;
                abreExcel();

                try
                {
                    _Articulo art = new _Articulo();
                    _Folio fol = new _Folio();
                    int folio = 0;
                    _PrecioLista prl = new _PrecioLista();
                    for (int i = 2; i <= dimExcelRow; i++)
                    {
                        var var01 = (rango.Cells[i, 1] as Excel.Range).Value;
                        var var02 = (rango.Cells[i, 2] as Excel.Range).Value;
                        var var03 = (rango.Cells[i, 3] as Excel.Range).Value;
                        var var04 = (rango.Cells[i, 4] as Excel.Range).Value;
                        var var05 = (rango.Cells[i, 5] as Excel.Range).Value;
                        var var06 = (rango.Cells[i, 6] as Excel.Range).Value;
                        var var07 = (rango.Cells[i, 7] as Excel.Range).Value;
                        var var08 = (rango.Cells[i, 8] as Excel.Range).Value;
                        var var09 = (rango.Cells[i, 9] as Excel.Range).Value;
                        var var10 = (rango.Cells[i, 10] as Excel.Range).Value;
                        var var11 = (rango.Cells[i, 11] as Excel.Range).Value;
                        var var12 = (rango.Cells[i, 12] as Excel.Range).Value;
                        var var13 = (rango.Cells[i, 13] as Excel.Range).Value;
                        var var14 = (rango.Cells[i, 14] as Excel.Range).Value;
                        var var15 = (rango.Cells[i, 15] as Excel.Range).Value;

                        art.ArIdent = "";                            //Identificador (Autonumerico)
                        folio = fol.consecutivo(tipoFolio.PRO);
                        art.ArIdent = tipoFolio.PRO.ToString() + folio.ToString().Trim().PadLeft(7, '0');
                        fol.FoFolio = folio;
                        fol.actualizar();
                        if (var01 == null)                          //Codigo
                            art.ArCodigo = "";
                        else
                            art.ArCodigo = var01.ToString();
                        if (var02 == null)                          //Codigo Comercial
                            art.ArCodCom = "";
                        else
                            art.ArCodCom = var02.ToString();
                        if (var03 == null)                          //Descripcion
                            art.ArDescripcion = "";
                        else
                            art.ArDescripcion = var03.ToString();
                        if (var06 == null)                          //Precio Publico
                            art.ArPrecioPub = 0;
                        else
                            art.ArPrecioPub = Convert.ToDouble(var06.ToString());
                        if (var07 == null)                          //Moneda
                            art.ArMoneda = "";
                        else
                            art.ArMoneda = var07.ToString();
                        if (var08 == null)                          //Unidad
                            art.ArUnidad = "";
                        else
                            art.ArUnidad = var08.ToString();
                        if (var09 == null)                          //Clasificacion
                            art.ArClasificacion = "";
                        else
                            art.ArClasificacion = var09.ToString();
                        if (var10 == null)                          //Categoria
                            art.ArCategoria = "";
                        else
                            art.ArCategoria = var10.ToString();
                        if (var11 == null)                          //Uso
                            art.ArUso = "";
                        else
                            art.ArUso = var11.ToString();
                        if (var12 == null)                          //Tipo
                            art.ArTipo = "";
                        else
                            art.ArTipo = var12.ToString();
                        if (var13 == null)                          //Modelo Comercial
                            art.ArModeloCom = "";
                        else
                            art.ArModeloCom = var13.ToString();
                        if (var14 == null)                          //Marca
                            art.ArMarca = "";
                        else
                            art.ArMarca = var14.ToString();
                        if (var15 == null)
                            art.ArGenerico = "";
                        else
                            art.ArGenerico = var15.ToString();      //Generico
                        //art.ArGenerico = "---";                     //Generico
                        art.ArActivo = "A";                         //Activo
                        art.ArAlto = "";                            //ArAlto
                        art.ArLargo = "";                           //ArLargo
                        art.ArAncho = "";                           //ArAncho
                        art.ArPeso = "";                            //ArPeso

                        art.guardar();

                        if (var05 != null && var06 != null)
                        {
                            prl.ArIdent = art.ArIdent;
                            prl.DiNumero = var05.ToString();
                            prl.PlPrecioLista = Convert.ToDouble(var06.ToString());
                            prl.PlMoneda = art.ArMoneda;
                            prl.PlCodPrv = "";
                            prl.PlPlazo = "";
                            prl.PlReferencia = "";
                            prl.PlObservacion = "";
                            prl.guardar();
                        }
                    }
                }
                catch (Exception ex)
                {
                    err = ex.Message;
                }
                finally
                {
                    xlWorkBook.Close();
                }

            }

            return resultado;
        }

        public string CargaServicio(string fileXLS)
        {
            string resultado = "";

            string err = "Falta indicar Archivo";

            if (rutaArchivo != "" || fileXLS != "")
            {
                err = "";
                rutaArchivo = rutaArchivo == "" ? fileXLS.ToString() : rutaArchivo;
                abreExcel();

                try
                {
                    _Articulo art = new _Articulo();
                    for (int i = 2; i <= dimExcelRow; i++)
                    {
                        var var01 = (rango.Cells[i, 1] as Excel.Range).Value;
                        var var02 = (rango.Cells[i, 2] as Excel.Range).Value;
                        var var03 = (rango.Cells[i, 3] as Excel.Range).Value;
                        var var04 = (rango.Cells[i, 4] as Excel.Range).Value;
                        var var05 = (rango.Cells[i, 5] as Excel.Range).Value;
                        var var06 = (rango.Cells[i, 6] as Excel.Range).Value;

                        art.ArIdent = "";                            //Identificador (Autonumerico)
                        if (var01 == null)                          //Codigo
                            art.ArCodigo = "";
                        else
                            art.ArCodigo = var01.ToString();
                        art.ArCodCom = "";                          //Codigo Comercial
                        if (var02 == null)                          //Descripcion
                            art.ArDescripcion = "";
                        else
                            art.ArDescripcion = var02.ToString();
                        if (var03 == null)                          //Precio Publico
                            art.ArPrecioPub = 0;
                        else
                            art.ArPrecioPub = Convert.ToDouble(var03.ToString());
                        if (var04 == null)                          //Moneda
                            art.ArMoneda = "";
                        else
                            art.ArMoneda = var04.ToString();
                        if (var05 == null)                          //Unidad
                            art.ArUnidad = "";
                        else
                            art.ArUnidad = var05.ToString();
                        art.ArClasificacion = "SER";                //Clasificación
                        if (var06 == null)                          //Categoria
                            art.ArCategoria = "";
                        else
                            art.ArCategoria = var06.ToString();
                        art.ArUso = "";                             //Uso
                        art.ArTipo = "";                            //Tipo
                        art.ArModeloCom = "";                       //Modelo Comercial
                        art.ArMarca = "";                           //Marca
                        art.ArGenerico = "---";                     //Generico
                        art.ArActivo = "A";                         //Activo

                        art.guardar();
                    }
                }
                catch (Exception ex)
                {
                    err = ex.Message;
                }
                finally
                {
                    xlWorkBook.Close();
                }

            }

            return resultado;
        }

        public string CargaNota(string fileXLS)
        {
            string resultado = "";

            string err = "Falta indicar Archivo";

            if (rutaArchivo != "" || fileXLS != "")
            {
                err = "";
                rutaArchivo = rutaArchivo == "" ? fileXLS.ToString() : rutaArchivo;
                abreExcel();

                try
                {
                    _Nota nota = new _Nota();
                    for (int i = 2; i <= dimExcelRow; i++)
                    {
                        var var01 = (rango.Cells[i, 1] as Excel.Range).Value;
                        var var02 = (rango.Cells[i, 3] as Excel.Range).Value;
                        var var03 = (rango.Cells[i, 4] as Excel.Range).Value;

                        nota.NoIdent = var01.ToString();
                        nota.NoTipo = var02.ToString();
                        nota.NoDescripcion = var03.ToString();
                        nota.EfIdent = "";

                        nota.guardar();
                    }
                }
                catch (Exception ex)
                {
                    err = ex.Message;
                }
                finally
                {
                    xlWorkBook.Close();
                }

            }

            return resultado;
        }

        public string CargaConcepto(string fileXLS)
        {
            string resultado = "";

            string err = "Falta indicar Archivo";

            if (rutaArchivo != "" || fileXLS != "")
            {
                err = "";
                rutaArchivo = rutaArchivo == "" ? fileXLS.ToString() : rutaArchivo;
                abreExcel();

                try
                {
                    _Concepto con = new _Concepto();
                    for (int i = 2; i <= dimExcelRow; i++)
                    {
                        var var01 = (rango.Cells[i, 1] as Excel.Range).Value;
                        var var02 = (rango.Cells[i, 2] as Excel.Range).Value;

                        con.CoNumero = Convert.ToInt16(var01.ToString());
                        con.CoDescripcion = var02.ToString();

                        con.guardar();
                    }
                }
                catch (Exception ex)
                {
                    err = ex.Message;
                }
                finally
                {
                    xlWorkBook.Close();
                }

            }

            return resultado;
        }
    }
}
