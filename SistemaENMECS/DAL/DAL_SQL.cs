using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SistemaENMECS.BLL;

namespace SistemaENMECS.DAL
{
    public class DAL_SQL
    {
        //private string connectionString = "Data Source=SISTEMAS-PC;Initial Catalog = crmInterno; User ID=sa;Password=3nm3c5";
        //private string connectionString = "Data Source=VENTAS\\SQLEXPRESS;Initial Catalog = crmInterno; User ID=sa;Password=3nm3c5";
        private string connectionString = "Data Source=DESKTOP-926DOLQ\\SQLEXPRESS;Initial Catalog = crmInterno; User ID=sa;Password=3nm3c5";
        //private string connectionString = "Data Source=DESKTOP-VA8PNGH\\SQLEXPRESS;Initial Catalog = crmInterno; User ID=sa;Password=3nm3c5";
        
        public string error { get; set; }

        public void setDireccion (DIRECTORIO direccion)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setDireccion";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiNumero", direccion.DiNumero);
                    cmd.Parameters.AddWithValue("@DiTipo", direccion.DiTipo);
                    cmd.Parameters.AddWithValue("@DiTipo2", direccion.DiTipo2);
                    cmd.Parameters.AddWithValue("@DiRFC", direccion.DiRFC);
                    cmd.Parameters.AddWithValue("@DiRazonSocial", direccion.DiRazonSocial);
                    cmd.Parameters.AddWithValue("@DiTipoEmpresa", direccion.DiTipoEmpresa);
                    cmd.Parameters.AddWithValue("@DiNombreCom", direccion.DiNombreCom);
                    cmd.Parameters.AddWithValue("@DiCalle", direccion.DiCalle);
                    cmd.Parameters.AddWithValue("@DiNumExt", direccion.DiNumExt);
                    cmd.Parameters.AddWithValue("@DiNumInt", direccion.DiNumInt);
                    cmd.Parameters.AddWithValue("@DiColonia", direccion.DiColonia);
                    cmd.Parameters.AddWithValue("@DiCP", direccion.DiCP);
                    cmd.Parameters.AddWithValue("@DiPoblacion", direccion.DiPoblacion);
                    cmd.Parameters.AddWithValue("@DiMunicipio", direccion.DiMunicipio);
                    cmd.Parameters.AddWithValue("@DiEstado", direccion.DiEstado);
                    cmd.Parameters.AddWithValue("@DiPais", direccion.DiPais);
                    cmd.Parameters.AddWithValue("@DiNacional", direccion.DiNacional);
                    cmd.Parameters.AddWithValue("@DiPaginaWeb", direccion.DiPaginaWeb);
                    cmd.Parameters.AddWithValue("@DiNomCorto", direccion.DiNomCorto);
                    cmd.Parameters.AddWithValue("@DiClasif", direccion.DiClasif);
                    cmd.Parameters.AddWithValue("@DiRapido", direccion.DiRapido);
                    cmd.Parameters.AddWithValue("@DiCCredito", direccion.DiCCredito);
                    cmd.Parameters.AddWithValue("@DiDCredito", direccion.DiDCredito);
                    cmd.Parameters.AddWithValue("@DiLCredito", direccion.DiLCredito);
                    cmd.Parameters.AddWithValue("@DiDBBenef", direccion.DiDBBenef);
                    cmd.Parameters.AddWithValue("@DiDBBanco", direccion.DiDBBanco);
                    cmd.Parameters.AddWithValue("@DiDBSucursal", direccion.DiDBSucursal);
                    cmd.Parameters.AddWithValue("@DiDBNumCta", direccion.DiDBNumCta);
                    cmd.Parameters.AddWithValue("@DiDBCLABE", direccion.DiDBCLABE);
                    cmd.Parameters.AddWithValue("@DiPjDesc", direccion.DiPjDesc);
                    cmd.Parameters.AddWithValue("@DiActivo", direccion.DiActivo);
                    cmd.Parameters.AddWithValue("@DiAudUsuCre", direccion.DiAudUsuCre);
                    cmd.Parameters.AddWithValue("@DiAudFeCre", direccion.DiAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updDireccion(DIRECTORIO direccion, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updDireccion";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DiNumero", direccion.DiNumero);
                        cmd.Parameters.AddWithValue("@DiTipo", direccion.DiTipo);
                        cmd.Parameters.AddWithValue("@DiTipo2", direccion.DiTipo2);
                        cmd.Parameters.AddWithValue("@DiRFC", direccion.DiRFC);
                        cmd.Parameters.AddWithValue("@DiRazonSocial", direccion.DiRazonSocial);
                        cmd.Parameters.AddWithValue("@DiTipoEmpresa", direccion.DiTipoEmpresa);
                        cmd.Parameters.AddWithValue("@DiNombreCom", direccion.DiNombreCom);
                        cmd.Parameters.AddWithValue("@DiCalle", direccion.DiCalle);
                        cmd.Parameters.AddWithValue("@DiNumExt", direccion.DiNumExt);
                        cmd.Parameters.AddWithValue("@DiNumInt", direccion.DiNumInt);
                        cmd.Parameters.AddWithValue("@DiColonia", direccion.DiColonia);
                        cmd.Parameters.AddWithValue("@DiCP", direccion.DiCP);
                        cmd.Parameters.AddWithValue("@DiPoblacion", direccion.DiPoblacion);
                        cmd.Parameters.AddWithValue("@DiMunicipio", direccion.DiMunicipio);
                        cmd.Parameters.AddWithValue("@DiEstado", direccion.DiEstado);
                        cmd.Parameters.AddWithValue("@DiPais", direccion.DiPais);
                        cmd.Parameters.AddWithValue("@DiNacional", direccion.DiNacional);
                        cmd.Parameters.AddWithValue("@DiPaginaWeb", direccion.DiPaginaWeb);
                        cmd.Parameters.AddWithValue("@DiNomCorto", direccion.DiNomCorto);
                        cmd.Parameters.AddWithValue("@DiClasif", direccion.DiClasif);
                        cmd.Parameters.AddWithValue("@DiRapido", direccion.DiRapido);
                        cmd.Parameters.AddWithValue("@DiCCredito", direccion.DiCCredito);
                        cmd.Parameters.AddWithValue("@DiDCredito", direccion.DiDCredito);
                        cmd.Parameters.AddWithValue("@DiLCredito", direccion.DiLCredito);
                        cmd.Parameters.AddWithValue("@DiDBBenef", direccion.DiDBBenef);
                        cmd.Parameters.AddWithValue("@DiDBBanco", direccion.DiDBBanco);
                        cmd.Parameters.AddWithValue("@DiDBSucursal", direccion.DiDBSucursal);
                        cmd.Parameters.AddWithValue("@DiDBNumCta", direccion.DiDBNumCta);
                        cmd.Parameters.AddWithValue("@DiDBCLABE", direccion.DiDBCLABE);
                        cmd.Parameters.AddWithValue("@DiPjDesc", direccion.DiPjDesc);
                        cmd.Parameters.AddWithValue("@DiActivo", direccion.DiActivo);
                        cmd.Parameters.AddWithValue("@DiAudUsuMod", direccion.DiAudUsuMod);
                        cmd.Parameters.AddWithValue("@DiAudFeMod", direccion.DiAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delDireccion";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DiNumero", direccion.DiNumero);
                        cmd.Parameters.AddWithValue("@DiActivo", direccion.DiActivo);
                        cmd.Parameters.AddWithValue("@DiAudUsuEl", direccion.DiAudUsuEl);
                        cmd.Parameters.AddWithValue("@DiAudFeEl", direccion.DiAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public DIRECTORIO getDireccion (DIRECTORIO direccion)
        {
            DIRECTORIO item = new DIRECTORIO();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getDireccion";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiNumero", direccion.DiNumero);
                    cmd.Parameters.AddWithValue("@DiTipo", direccion.DiTipo);
                    cmd.Parameters.AddWithValue("@DiRFC", direccion.DiRFC);
                    cmd.Parameters.AddWithValue("@DiNombre", direccion.DiNombreCom);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if(ds.Tables[0].Rows.Count == 1)
                    {
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.DiTipo = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.DiTipo2 = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.DiRFC = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.DiRazonSocial = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.DiTipoEmpresa = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.DiNombreCom = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.DiCalle = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.DiNumExt = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.DiNumInt = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.DiColonia = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.DiCP = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.DiPoblacion = Convert.ToString(ds.Tables[0].Rows[i][12]);
                        item.DiMunicipio = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.DiEstado = Convert.ToString(ds.Tables[0].Rows[i][14]);
                        item.DiPais = Convert.ToString(ds.Tables[0].Rows[i][15]);
                        item.DiNacional = Convert.ToString(ds.Tables[0].Rows[i][16]);
                        item.DiPaginaWeb = Convert.ToString(ds.Tables[0].Rows[i][17]);
                        item.DiNomCorto = Convert.ToString(ds.Tables[0].Rows[i][18]);
                        item.DiClasif = Convert.ToString(ds.Tables[0].Rows[i][19]);
                        item.DiRapido = Convert.ToString(ds.Tables[0].Rows[i][20]);
                        item.DiCCredito = Convert.ToString(ds.Tables[0].Rows[i][21]);
                        item.DiDCredito = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][22]));
                        item.DiLCredito = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][23]));
                        item.DiDBBenef = Convert.ToString(ds.Tables[0].Rows[i][24]);
                        item.DiDBBanco = Convert.ToString(ds.Tables[0].Rows[i][25]);
                        item.DiDBSucursal = Convert.ToString(ds.Tables[0].Rows[i][26]);
                        item.DiDBNumCta = Convert.ToString(ds.Tables[0].Rows[i][27]);
                        item.DiDBCLABE = Convert.ToString(ds.Tables[0].Rows[i][28]);
                        item.DiPjDesc = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i][29]));
                        item.DiActivo = Convert.ToString(ds.Tables[0].Rows[i][30]);
                        item.DiAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][31]);
                        item.DiAudFeCre = ds.Tables[0].Rows[i][32].ToString() == "" ? item.DiAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][32]);
                        item.DiAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][33]);
                        item.DiAudFeMod = ds.Tables[0].Rows[i][34].ToString() == "" ? item.DiAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][34]);
                        item.DiAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][35]);
                        item.DiAudFeEl = ds.Tables[0].Rows[i][36].ToString() == "" ? item.DiAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][36]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<DIRECTORIO> getDirecciones(DIRECTORIO direccion)
        {
            DIRECTORIO item = new DIRECTORIO();
            List<DIRECTORIO> lista = new List<DIRECTORIO>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getDireccion";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiNumero", direccion.DiNumero);
                    cmd.Parameters.AddWithValue("@DiTipo", direccion.DiTipo);
                    cmd.Parameters.AddWithValue("@DiRFC", direccion.DiRFC);
                    cmd.Parameters.AddWithValue("@DiNombre", direccion.DiNombreCom);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.DiTipo = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.DiTipo2 = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.DiRFC = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.DiRazonSocial = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.DiTipoEmpresa = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.DiNombreCom = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.DiCalle = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.DiNumExt = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.DiNumInt = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.DiColonia = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.DiCP = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.DiPoblacion = Convert.ToString(ds.Tables[0].Rows[i][12]);
                        item.DiMunicipio = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.DiEstado = Convert.ToString(ds.Tables[0].Rows[i][14]);
                        item.DiPais = Convert.ToString(ds.Tables[0].Rows[i][15]);
                        item.DiNacional = Convert.ToString(ds.Tables[0].Rows[i][16]);
                        item.DiPaginaWeb = Convert.ToString(ds.Tables[0].Rows[i][17]);
                        item.DiNomCorto = Convert.ToString(ds.Tables[0].Rows[i][18]);
                        item.DiClasif = Convert.ToString(ds.Tables[0].Rows[i][19]);
                        item.DiRapido = Convert.ToString(ds.Tables[0].Rows[i][20]);
                        item.DiCCredito = Convert.ToString(ds.Tables[0].Rows[i][21]);
                        item.DiDCredito = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][22]));
                        item.DiLCredito = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][23]));
                        item.DiDBBenef = Convert.ToString(ds.Tables[0].Rows[i][24]);
                        item.DiDBBanco = Convert.ToString(ds.Tables[0].Rows[i][25]);
                        item.DiDBSucursal = Convert.ToString(ds.Tables[0].Rows[i][26]);
                        item.DiDBNumCta = Convert.ToString(ds.Tables[0].Rows[i][27]);
                        item.DiDBCLABE = Convert.ToString(ds.Tables[0].Rows[i][28]);
                        item.DiPjDesc = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i][29]));
                        item.DiActivo = Convert.ToString(ds.Tables[0].Rows[i][30]);
                        item.DiAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][31]);
                        item.DiAudFeCre = ds.Tables[0].Rows[i][32].ToString() == "" ? item.DiAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][32]);
                        item.DiAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][33]);
                        item.DiAudFeMod = ds.Tables[0].Rows[i][34].ToString() == "" ? item.DiAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][34]);
                        item.DiAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][35]);
                        item.DiAudFeEl = ds.Tables[0].Rows[i][36].ToString() == "" ? item.DiAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][36]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public List<ARTICULOCLIENTES> getDocCPartidaCLI(ARTICULOCLIENTES articulo)
        {
            ARTICULOCLIENTES item = new ARTICULOCLIENTES();
            List<ARTICULOCLIENTES> lista = new List<ARTICULOCLIENTES>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getDireccion";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArIdent", articulo.ArIdent);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.ArIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.DiNombreCom = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.DiNomCorto = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.DoFolio = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setContacto (CONTACTO contacto)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setContacto";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiNumero", contacto.DiNumero);
                    cmd.Parameters.AddWithValue("@CnNumero", contacto.CnNumero.ToString());
                    cmd.Parameters.AddWithValue("@CnTipo", contacto.CnTipo);
                    cmd.Parameters.AddWithValue("@CnNombre", contacto.CnNombre);
                    cmd.Parameters.AddWithValue("@CnAPaterno", contacto.CnAPaterno);
                    cmd.Parameters.AddWithValue("@CnAMaterno", contacto.CnAMaterno);
                    cmd.Parameters.AddWithValue("@CnCorreo", contacto.CnCorreo);
                    cmd.Parameters.AddWithValue("@CnTelefono", contacto.CnTelefono);
                    cmd.Parameters.AddWithValue("@CnPuesto", contacto.CnPuesto);
                    cmd.Parameters.AddWithValue("@CnGradoEst", contacto.CnGradoEst);
                    cmd.Parameters.AddWithValue("@CnAbrGraEst", contacto.CnAbrGraEst);
                    cmd.Parameters.AddWithValue("@CnCedula", contacto.CnCedula);
                    cmd.Parameters.AddWithValue("@CnNota", contacto.CnNota);
                    cmd.Parameters.AddWithValue("@CnActivo", contacto.CnActivo);
                    cmd.Parameters.AddWithValue("@CnAudUsuCre", contacto.CnAudUsuCre);
                    cmd.Parameters.AddWithValue("@CnAudFeCre", contacto.CnAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updContacto (CONTACTO contacto, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updContacto";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DiNumero", contacto.DiNumero);
                        cmd.Parameters.AddWithValue("@CnNumero", contacto.CnNumero.ToString());
                        cmd.Parameters.AddWithValue("@CnTipo", contacto.CnTipo);
                        cmd.Parameters.AddWithValue("@CnNombre", contacto.CnNombre);
                        cmd.Parameters.AddWithValue("@CnAPaterno", contacto.CnAPaterno);
                        cmd.Parameters.AddWithValue("@CnAMaterno", contacto.CnAMaterno);
                        cmd.Parameters.AddWithValue("@CnCorreo", contacto.CnCorreo);
                        cmd.Parameters.AddWithValue("@CnTelefono", contacto.CnTelefono);
                        cmd.Parameters.AddWithValue("@CnPuesto", contacto.CnPuesto);
                        cmd.Parameters.AddWithValue("@CnGradoEst", contacto.CnGradoEst);
                        cmd.Parameters.AddWithValue("@CnAbrGraEst", contacto.CnAbrGraEst);
                        cmd.Parameters.AddWithValue("@CnCedula", contacto.CnCedula);
                        cmd.Parameters.AddWithValue("@CnNota", contacto.CnNota);
                        cmd.Parameters.AddWithValue("@CnActivo", contacto.CnActivo);
                        cmd.Parameters.AddWithValue("@CnAudUsuMod", contacto.CnAudUsuMod);
                        cmd.Parameters.AddWithValue("@CnAudFeMod", contacto.CnAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delContacto";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DiNumero", contacto.DiNumero);
                        cmd.Parameters.AddWithValue("@CnNumero", contacto.CnNumero.ToString());
                        cmd.Parameters.AddWithValue("@CnActivo", contacto.CnActivo);
                        cmd.Parameters.AddWithValue("@CnAudUsuEl", contacto.CnAudUsuEl);
                        cmd.Parameters.AddWithValue("@CnAudFeEl", contacto.CnAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public CONTACTO getContacto (CONTACTO contacto)
        {
            CONTACTO item = new CONTACTO();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getContacto";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiNumero", contacto.DiNumero);
                    cmd.Parameters.AddWithValue("@CnNumero", contacto.CnNumero);
                    cmd.Parameters.AddWithValue("@CnTipo", contacto.CnTipo);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CnNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.CnTipo = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.CnNombre = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.CnAPaterno = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.CnAMaterno = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.CnCorreo = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.CnTelefono = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.CnPuesto = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.CnGradoEst = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.CnAbrGraEst = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.CnCedula = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.CnNota = Convert.ToString(ds.Tables[0].Rows[i][12]);
                        item.CnActivo = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.CnAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][14]);
                        item.CnAudFeCre = ds.Tables[0].Rows[i][15].ToString() == "" ? item.CnAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][15]);
                        item.CnAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][16]);
                        item.CnAudFeMod = ds.Tables[0].Rows[i][17].ToString() == "" ? item.CnAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][17]);
                        item.CnAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][18]);
                        item.CnAudFeEl = ds.Tables[0].Rows[i][19].ToString() == "" ? item.CnAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][19]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<CONTACTO> getContactos(CONTACTO contacto)
        {
            CONTACTO item = new CONTACTO();
            List<CONTACTO> lista = new List<CONTACTO>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getContacto";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiNumero", contacto.DiNumero);
                    cmd.Parameters.AddWithValue("@CnNumero", contacto.CnNumero);
                    cmd.Parameters.AddWithValue("@CnTipo", contacto.CnTipo);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CnNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.CnTipo = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.CnNombre = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.CnAPaterno = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.CnAMaterno = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.CnCorreo = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.CnTelefono = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.CnPuesto = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.CnGradoEst = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.CnAbrGraEst = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.CnCedula = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.CnNota = Convert.ToString(ds.Tables[0].Rows[i][12]);
                        item.CnActivo = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.CnAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][14]);
                        item.CnAudFeCre = ds.Tables[0].Rows[i][15].ToString() == "" ? item.CnAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][15]);
                        item.CnAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][16]);
                        item.CnAudFeMod = ds.Tables[0].Rows[i][17].ToString() == "" ? item.CnAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][17]);
                        item.CnAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][18]);
                        item.CnAudFeEl = ds.Tables[0].Rows[i][19].ToString() == "" ? item.CnAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][19]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setUsuario(USUARIO usuario)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setUsuario";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiNumero", usuario.DiNumero);
                    cmd.Parameters.AddWithValue("@CnNumero", usuario.CnNumero);
                    cmd.Parameters.AddWithValue("@UsNombre", usuario.UsNombre);
                    cmd.Parameters.AddWithValue("@UsUsuario", usuario.UsUsuario);
                    cmd.Parameters.AddWithValue("@UsPassword", usuario.UsPassword);
                    cmd.Parameters.AddWithValue("@UsPerfil", usuario.UsPerfil);
                    cmd.Parameters.AddWithValue("@UsActivo", usuario.UsActivo);
                    cmd.Parameters.AddWithValue("@UsAudUsuCre", usuario.UsAudUsuCre);
                    cmd.Parameters.AddWithValue("@UsAudFeCre", usuario.UsAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updUsuario(USUARIO usuario, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updUsuario";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DiNumero", usuario.DiNumero);
                        cmd.Parameters.AddWithValue("@CnNumero", usuario.CnNumero);
                        cmd.Parameters.AddWithValue("@UsNombre", usuario.UsNombre);
                        cmd.Parameters.AddWithValue("@UsUsuario", usuario.UsUsuario);
                        cmd.Parameters.AddWithValue("@UsPassword", usuario.UsPassword);
                        cmd.Parameters.AddWithValue("@UsPerfil", usuario.UsPerfil);
                        cmd.Parameters.AddWithValue("@UsActivo", usuario.UsActivo);
                        cmd.Parameters.AddWithValue("@UsAudUsuMod", usuario.UsAudUsuMod);
                        cmd.Parameters.AddWithValue("@UsAudFeMod", usuario.UsAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delUsuario";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DiNumero", usuario.DiNumero);
                        cmd.Parameters.AddWithValue("@CnNumero", usuario.CnNumero);
                        cmd.Parameters.AddWithValue("@UsActivo", usuario.UsActivo);
                        cmd.Parameters.AddWithValue("@UsAudUsuEl", usuario.UsAudUsuEl);
                        cmd.Parameters.AddWithValue("@UsAudFeEl", usuario.UsAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public USUARIO getUsuario(USUARIO usuario)
        {
            USUARIO item = new USUARIO();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getUsuario";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiNumero", usuario.DiNumero);
                    cmd.Parameters.AddWithValue("@CnNumero", usuario.CnNumero.ToString());
                    cmd.Parameters.AddWithValue("@UsUsuario", usuario.UsUsuario.Trim());
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CnNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.UsNombre = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.UsUsuario = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.UsPassword = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.UsPerfil = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.UsActivo = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.UsAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.UsAudFeCre = ds.Tables[0].Rows[i][8].ToString() == "" ? item.UsAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][8]);
                        item.UsAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.UsAudFeMod = ds.Tables[0].Rows[i][10].ToString() == "" ? item.UsAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][10]);
                        item.UsAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.UsAudFeEl = ds.Tables[0].Rows[i][12].ToString() == "" ? item.UsAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<USUARIO> getUsuarios(USUARIO usuario)
        {
            USUARIO item = new USUARIO();
            List<USUARIO> lista = new List<USUARIO>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getUsuario";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiNumero", usuario.DiNumero);
                    cmd.Parameters.AddWithValue("@CnNumero", usuario.CnNumero.ToString());
                    cmd.Parameters.AddWithValue("@UsUsuario", usuario.UsUsuario.Trim());
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CnNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.UsNombre = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.UsUsuario = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.UsPassword = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.UsPerfil = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.UsActivo = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.UsAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.UsAudFeCre = ds.Tables[0].Rows[i][8].ToString() == "" ? item.UsAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][8]);
                        item.UsAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.UsAudFeMod = ds.Tables[0].Rows[i][10].ToString() == "" ? item.UsAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][10]);
                        item.UsAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.UsAudFeEl = ds.Tables[0].Rows[i][12].ToString() == "" ? item.UsAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setProyecto(PROYECTO proyecto)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setProyecto";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PyNumero", proyecto.PyNumero);
                    cmd.Parameters.AddWithValue("@PyFolio", proyecto.PyFolio);
                    cmd.Parameters.AddWithValue("@PyNombre", proyecto.PyNombre);
                    cmd.Parameters.AddWithValue("@PyNomCorA", proyecto.PyNomCorA);
                    cmd.Parameters.AddWithValue("@PyNomCarp", proyecto.PyNomCarp);
                    cmd.Parameters.AddWithValue("@PyObjetivo", proyecto.PyObjetivo);
                    cmd.Parameters.AddWithValue("@PyTipoSis", proyecto.PyTipoSis);
                    cmd.Parameters.AddWithValue("@PyEstado", proyecto.PyEstado);
                    cmd.Parameters.AddWithValue("@PyMaster", proyecto.PyMaster);
                    cmd.Parameters.AddWithValue("@DiNumero", proyecto.DiNumero);
                    cmd.Parameters.AddWithValue("@EmIdent", proyecto.EmIdent);
                    cmd.Parameters.AddWithValue("@PyEstatus", proyecto.PyEstatus);
                    cmd.Parameters.AddWithValue("@PyClasif", proyecto.PyClasif);
                    cmd.Parameters.AddWithValue("@PyActivo", proyecto.PyActivo);
                    cmd.Parameters.AddWithValue("@PyAudUsuCre", proyecto.PyAudUsuCre);
                    cmd.Parameters.AddWithValue("@PyAudFeCre", proyecto.PyAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updProyecto(PROYECTO proyecto, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updProyecto";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PyNumero", proyecto.PyNumero);
                        cmd.Parameters.AddWithValue("@PyFolio", proyecto.PyFolio);
                        cmd.Parameters.AddWithValue("@PyNombre", proyecto.PyNombre);
                        cmd.Parameters.AddWithValue("@PyNomCorA", proyecto.PyNomCorA);
                        cmd.Parameters.AddWithValue("@PyNomCarp", proyecto.PyNomCarp);
                        cmd.Parameters.AddWithValue("@PyObjetivo", proyecto.PyObjetivo);
                        cmd.Parameters.AddWithValue("@PyTipoSis", proyecto.PyTipoSis);
                        cmd.Parameters.AddWithValue("@PyEstado", proyecto.PyEstado);
                        cmd.Parameters.AddWithValue("@PyMaster", proyecto.PyMaster);
                        cmd.Parameters.AddWithValue("@DiNumero", proyecto.DiNumero);
                        cmd.Parameters.AddWithValue("@EmIdent", proyecto.EmIdent);
                        cmd.Parameters.AddWithValue("@PyEstatus", proyecto.PyEstatus);
                        cmd.Parameters.AddWithValue("@PyClasif", proyecto.PyClasif);
                        cmd.Parameters.AddWithValue("@PyActivo", proyecto.PyActivo);
                        cmd.Parameters.AddWithValue("@PyAudUsuMod", proyecto.PyAudUsuMod);
                        cmd.Parameters.AddWithValue("@PyAudFeMod", proyecto.PyAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delProyecto";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PyNumero", proyecto.PyNumero);
                        cmd.Parameters.AddWithValue("@PyActivo", proyecto.PyActivo);
                        cmd.Parameters.AddWithValue("@PyAudUsuEl", proyecto.PyAudUsuEl);
                        cmd.Parameters.AddWithValue("@PyAudFeEl", proyecto.PyAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void viaProyecto(PROYECTO proyecto)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    string comandoSQL = "sp_viaProyecto";
                    cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PyNumero", proyecto.PyNumero);
                    cmd.Parameters.AddWithValue("@PyCambio", proyecto.PyCambio);
                    cmd.Parameters.AddWithValue("@PyUsuCam", proyecto.PyUsuCam);
                    cmd.Parameters.AddWithValue("@PyFeCam", proyecto.PyFeCam);
                    cmd.Parameters.AddWithValue("@PyEstatus", proyecto.PyEstatus);
                    cmd.Parameters.AddWithValue("@PyActivo", proyecto.PyActivo);
                    cmd.Parameters.AddWithValue("@PyAudUsuMod", proyecto.PyAudUsuMod);
                    cmd.Parameters.AddWithValue("@PyAudFeMod", proyecto.PyAudFeMod);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public PROYECTO getProyecto(PROYECTO proyecto)
        {
            PROYECTO item = new PROYECTO();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getProyecto";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PyNumero", proyecto.PyNumero);
                    cmd.Parameters.AddWithValue("@PyNombre", proyecto.PyNombre);
                    cmd.Parameters.AddWithValue("@DiNombre", proyecto.DiNombre);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.PyNumero = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.PyFolio = Convert.ToInt32(ds.Tables[0].Rows[i][1]);
                        item.PyNombre = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.PyNomCorA = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.PyNomCarp = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.PyObjetivo = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.PyTipoSis = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.PyEstado = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.PyMaster = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.DiNombre = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.EmIdent = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.PyCambio = Convert.ToString(ds.Tables[0].Rows[i][12]);
                        item.PyUsuCam = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.PyFeCam = ds.Tables[0].Rows[i][14].ToString() == "" ? item.PyFeCam : Convert.ToDateTime(ds.Tables[0].Rows[i][14]);
                        item.PyEstatus = Convert.ToString(ds.Tables[0].Rows[i][15]);
                        item.PyClasif = Convert.ToString(ds.Tables[0].Rows[i][16]);
                        item.PyActivo = Convert.ToString(ds.Tables[0].Rows[i][17]);
                        item.PyAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][18]);
                        item.PyAudFeCre = ds.Tables[0].Rows[i][19].ToString() == "" ? item.PyAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][19]);
                        item.PyAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][20]);
                        item.PyAudFeMod = ds.Tables[0].Rows[i][21].ToString() == "" ? item.PyAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][21]);
                        item.PyAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][22]);
                        item.PyAudFeEl = ds.Tables[0].Rows[i][23].ToString() == "" ? item.PyAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][23]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<PROYECTO> getProyectos(PROYECTO proyecto)
        {
            PROYECTO item = new PROYECTO();
            List<PROYECTO> lista = new List<PROYECTO>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getProyecto";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PyNumero", proyecto.PyNumero);
                    cmd.Parameters.AddWithValue("@PyNombre", proyecto.PyNombre);
                    cmd.Parameters.AddWithValue("@DiNombre", proyecto.DiNombre);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.PyNumero = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.PyFolio = Convert.ToInt32(ds.Tables[0].Rows[i][1]);
                        item.PyNombre = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.PyNomCorA = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.PyNomCarp = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.PyObjetivo = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.PyTipoSis = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.PyEstado = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.PyMaster = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.DiNombre = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.EmIdent = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.PyCambio = Convert.ToString(ds.Tables[0].Rows[i][12]);
                        item.PyUsuCam = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.PyFeCam = ds.Tables[0].Rows[i][14].ToString() == "" ? item.PyFeCam : Convert.ToDateTime(ds.Tables[0].Rows[i][14]);
                        item.PyEstatus = Convert.ToString(ds.Tables[0].Rows[i][15]);
                        item.PyClasif = Convert.ToString(ds.Tables[0].Rows[i][16]);
                        item.PyActivo = Convert.ToString(ds.Tables[0].Rows[i][17]);
                        item.PyAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][18]);
                        item.PyAudFeCre = ds.Tables[0].Rows[i][19].ToString() == "" ? item.PyAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][19]);
                        item.PyAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][20]);
                        item.PyAudFeMod = ds.Tables[0].Rows[i][21].ToString() == "" ? item.PyAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][21]);
                        item.PyAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][22]);
                        item.PyAudFeEl = ds.Tables[0].Rows[i][23].ToString() == "" ? item.PyAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][23]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setArticulo(ARTICULO articulo)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setArticulo";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArIdent", articulo.ArIdent);
                    cmd.Parameters.AddWithValue("@ArCodigo", articulo.ArCodigo);
                    cmd.Parameters.AddWithValue("@ArCodCom", articulo.ArCodCom);
                    cmd.Parameters.AddWithValue("@ArDescripcion", articulo.ArDescripcion);
                    cmd.Parameters.AddWithValue("@ArCosto", articulo.ArCosto);
                    cmd.Parameters.AddWithValue("@ArPrecioPub", articulo.ArPrecioPub);
                    cmd.Parameters.AddWithValue("@ArMoneda", articulo.ArMoneda);
                    cmd.Parameters.AddWithValue("@ArUnidad", articulo.ArUnidad);
                    cmd.Parameters.AddWithValue("@ArClasificacion", articulo.ArClasificacion);
                    cmd.Parameters.AddWithValue("@ArCategoria", articulo.ArCategoria);
                    cmd.Parameters.AddWithValue("@ArUso", articulo.ArUso);
                    cmd.Parameters.AddWithValue("@ArTipo", articulo.ArTipo);
                    cmd.Parameters.AddWithValue("@ArModeloCom", articulo.ArModeloCom);
                    cmd.Parameters.AddWithValue("@ArMarca", articulo.ArMarca);
                    cmd.Parameters.AddWithValue("@ArGenerico", articulo.ArGenerico);
                    cmd.Parameters.AddWithValue("@ArAlto", articulo.ArAlto);
                    cmd.Parameters.AddWithValue("@ArLargo", articulo.ArLargo);
                    cmd.Parameters.AddWithValue("@ArAncho", articulo.ArAncho);
                    cmd.Parameters.AddWithValue("@ArPeso", articulo.ArPeso);
                    cmd.Parameters.AddWithValue("@ArActivo", articulo.ArActivo);
                    cmd.Parameters.AddWithValue("@ArAudUsuCre", articulo.ArAudUsuCre);
                    cmd.Parameters.AddWithValue("@ArAudFeCre", articulo.ArAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updArticulo(ARTICULO articulo, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updArticulo";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ArIdent", articulo.ArIdent);
                        cmd.Parameters.AddWithValue("@ArCodigo", articulo.ArCodigo);
                        cmd.Parameters.AddWithValue("@ArCodCom", articulo.ArCodCom);
                        cmd.Parameters.AddWithValue("@ArDescripcion", articulo.ArDescripcion);
                        cmd.Parameters.AddWithValue("@ArCosto", articulo.ArCosto);
                        cmd.Parameters.AddWithValue("@ArPrecioPub", articulo.ArPrecioPub);
                        cmd.Parameters.AddWithValue("@ArMoneda", articulo.ArMoneda);
                        cmd.Parameters.AddWithValue("@ArUnidad", articulo.ArUnidad);
                        cmd.Parameters.AddWithValue("@ArClasificacion", articulo.ArClasificacion);
                        cmd.Parameters.AddWithValue("@ArCategoria", articulo.ArCategoria);
                        cmd.Parameters.AddWithValue("@ArUso", articulo.ArUso);
                        cmd.Parameters.AddWithValue("@ArTipo", articulo.ArTipo);
                        cmd.Parameters.AddWithValue("@ArModeloCom", articulo.ArModeloCom);
                        cmd.Parameters.AddWithValue("@ArMarca", articulo.ArMarca);
                        cmd.Parameters.AddWithValue("@ArGenerico", articulo.ArGenerico);
                        cmd.Parameters.AddWithValue("@ArAlto", articulo.ArAlto);
                        cmd.Parameters.AddWithValue("@ArLargo", articulo.ArLargo);
                        cmd.Parameters.AddWithValue("@ArAncho", articulo.ArAncho);
                        cmd.Parameters.AddWithValue("@ArPeso", articulo.ArPeso);
                        cmd.Parameters.AddWithValue("@ArActivo", articulo.ArActivo);
                        cmd.Parameters.AddWithValue("@ArAudUsuMod", articulo.ArAudUsuMod);
                        cmd.Parameters.AddWithValue("@ArAudFeMod", articulo.ArAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delArticulo";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ArIdent", articulo.ArIdent);
                        cmd.Parameters.AddWithValue("@ArActivo", articulo.ArActivo);
                        cmd.Parameters.AddWithValue("@ArAudUsuEl", articulo.ArAudUsuEl);
                        cmd.Parameters.AddWithValue("@ArAudFeEl", articulo.ArAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public ARTICULO getArticulo(ARTICULO articulo)
        {
            ARTICULO item = new ARTICULO();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getArticulo";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArIdent", articulo.ArIdent);
                    cmd.Parameters.AddWithValue("@ArCodigo", articulo.ArCodigo);
                    cmd.Parameters.AddWithValue("@ArDescripcion", articulo.ArDescripcion);
                    cmd.Parameters.AddWithValue("@ArClasificacion", articulo.ArClasificacion);
                    cmd.Parameters.AddWithValue("@ArModeloCom", articulo.ArModeloCom);
                    cmd.Parameters.AddWithValue("@ArMarca", articulo.ArMarca);

                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.ArIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.ArCodigo = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.ArCodCom = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.ArDescripcion = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.ArCosto = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][4]));
                        item.ArPrecioPub = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][5]));
                        item.ArMoneda = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.ArUnidad = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.ArClasificacion = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.ArCategoria = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.ArUso = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.ArTipo = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.ArModeloCom = Convert.ToString(ds.Tables[0].Rows[i][12]);
                        item.ArMarca = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.ArGenerico = Convert.ToString(ds.Tables[0].Rows[i][14]);
                        item.ArAlto = Convert.ToString(ds.Tables[0].Rows[i][15]);
                        item.ArLargo = Convert.ToString(ds.Tables[0].Rows[i][16]);
                        item.ArAncho = Convert.ToString(ds.Tables[0].Rows[i][17]);
                        item.ArPeso = Convert.ToString(ds.Tables[0].Rows[i][18]);
                        item.ArActivo = Convert.ToString(ds.Tables[0].Rows[i][19]);
                        item.ArAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][20]);
                        item.ArAudFeCre = ds.Tables[0].Rows[i][21].ToString() == "" ? item.ArAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][21]);
                        item.ArAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][22]);
                        item.ArAudFeMod = ds.Tables[0].Rows[i][23].ToString() == "" ? item.ArAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][23]);
                        item.ArAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][24]);
                        item.ArAudFeEl = ds.Tables[0].Rows[i][25].ToString() == "" ? item.ArAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][25]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<ARTICULO> getArticulos(ARTICULO articulo)
        {
            ARTICULO item = new ARTICULO();
            List<ARTICULO> lista = new List<ARTICULO>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getArticulo";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArIdent", articulo.ArIdent);
                    cmd.Parameters.AddWithValue("@ArCodigo", articulo.ArCodigo);
                    cmd.Parameters.AddWithValue("@ArDescripcion", articulo.ArDescripcion);
                    cmd.Parameters.AddWithValue("@ArClasificacion", articulo.ArClasificacion);
                    cmd.Parameters.AddWithValue("@ArModeloCom", articulo.ArModeloCom);
                    cmd.Parameters.AddWithValue("@ArMarca", articulo.ArMarca);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.ArIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.ArCodigo = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.ArCodCom = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.ArDescripcion = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.ArCosto = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][4]));
                        item.ArPrecioPub = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][5]));
                        item.ArMoneda = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.ArUnidad = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.ArClasificacion = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.ArCategoria = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.ArUso = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.ArTipo = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.ArModeloCom = Convert.ToString(ds.Tables[0].Rows[i][12]);
                        item.ArMarca = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.ArGenerico = Convert.ToString(ds.Tables[0].Rows[i][14]);
                        item.ArAlto = Convert.ToString(ds.Tables[0].Rows[i][15]);
                        item.ArLargo = Convert.ToString(ds.Tables[0].Rows[i][16]);
                        item.ArAncho = Convert.ToString(ds.Tables[0].Rows[i][17]);
                        item.ArPeso = Convert.ToString(ds.Tables[0].Rows[i][18]);
                        item.ArActivo = Convert.ToString(ds.Tables[0].Rows[i][19]);
                        item.ArAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][20]);
                        item.ArAudFeCre = ds.Tables[0].Rows[i][21].ToString() == "" ? item.ArAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][21]);
                        item.ArAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][22]);
                        item.ArAudFeMod = ds.Tables[0].Rows[i][23].ToString() == "" ? item.ArAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][23]);
                        item.ArAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][24]);
                        item.ArAudFeEl = ds.Tables[0].Rows[i][25].ToString() == "" ? item.ArAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][25]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setConfiguracion(CONFIGURACION configuracion)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setConfiguracion";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CgIdent", configuracion.CgIdent);
                    cmd.Parameters.AddWithValue("@CgImpuesto", configuracion.CgImpuesto);
                    cmd.Parameters.AddWithValue("@CgPjImpuesto", configuracion.CgPjImpuesto);
                    cmd.Parameters.AddWithValue("@CgMoneda", configuracion.CgMoneda);
                    cmd.Parameters.AddWithValue("@CgGcIdent", configuracion.CgGcIdent);
                    cmd.Parameters.AddWithValue("@CgCrIdent", configuracion.CgCrIdent);
                    cmd.Parameters.AddWithValue("@CgPathPry", configuracion.CgPathPry);
                    cmd.Parameters.AddWithValue("@CgPathCot", configuracion.CgPathCot);
                    cmd.Parameters.AddWithValue("@CgNoTipo", configuracion.CgNoTipo);
                    cmd.Parameters.AddWithValue("@CgDfArt", configuracion.CgDfArt);
                    cmd.Parameters.AddWithValue("@CgDfCli", configuracion.CgDfCli);
                    cmd.Parameters.AddWithValue("@CgDfPrv", configuracion.CgDfPrv);
                    cmd.Parameters.AddWithValue("@CgDfEmp", configuracion.CgDfEmp);
                    cmd.Parameters.AddWithValue("@CgDfPry", configuracion.CgDfPry);
                    cmd.Parameters.AddWithValue("@CgActivo", configuracion.CgActivo);
                    cmd.Parameters.AddWithValue("@CgAudUsuCre", configuracion.CgAudUsuCre);
                    cmd.Parameters.AddWithValue("@CgAudFeCre", configuracion.CgAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updConfiguracion(CONFIGURACION configuracion, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updConfiguracion";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CgIdent", configuracion.CgIdent);
                        cmd.Parameters.AddWithValue("@CgImpuesto", configuracion.CgImpuesto);
                        cmd.Parameters.AddWithValue("@CgPjImpuesto", configuracion.CgPjImpuesto);
                        cmd.Parameters.AddWithValue("@CgMoneda", configuracion.CgMoneda);
                        cmd.Parameters.AddWithValue("@CgGcIdent", configuracion.CgGcIdent);
                        cmd.Parameters.AddWithValue("@CgCrIdent", configuracion.CgCrIdent);
                        cmd.Parameters.AddWithValue("@CgPathPry", configuracion.CgPathPry);
                        cmd.Parameters.AddWithValue("@CgPathCot", configuracion.CgPathCot);
                        cmd.Parameters.AddWithValue("@CgNoTipo", configuracion.CgNoTipo);
                        cmd.Parameters.AddWithValue("@CgDfArt", configuracion.CgDfArt);
                        cmd.Parameters.AddWithValue("@CgDfCli", configuracion.CgDfCli);
                        cmd.Parameters.AddWithValue("@CgDfPrv", configuracion.CgDfPrv);
                        cmd.Parameters.AddWithValue("@CgDfEmp", configuracion.CgDfEmp);
                        cmd.Parameters.AddWithValue("@CgDfPry", configuracion.CgDfPry);
                        cmd.Parameters.AddWithValue("@CgActivo", configuracion.CgActivo);
                        cmd.Parameters.AddWithValue("@CgAudUsuMod", configuracion.CgAudUsuMod);
                        cmd.Parameters.AddWithValue("@CgAudFeMod", configuracion.CgAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delConfiguracion";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CgIdent", configuracion.CgIdent);
                        cmd.Parameters.AddWithValue("@CgActivo", configuracion.CgActivo);
                        cmd.Parameters.AddWithValue("@CgAudUsuEl", configuracion.CgAudUsuEl);
                        cmd.Parameters.AddWithValue("@CgAudFeEl", configuracion.CgAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public CONFIGURACION getConfiguracion(CONFIGURACION configuracion)
        {
            CONFIGURACION item = new CONFIGURACION();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getConfiguracion";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CgIdent", configuracion.CgIdent);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.CgIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CgImpuesto = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.CgPjImpuesto = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][2]));
                        item.CgMoneda = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.CgGcIdent = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.CgCrIdent = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.CgPathPry = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.CgPathCot = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.CgNoTipo = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.CgDfArt = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.CgDfCli = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.CgDfPrv = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.CgDfEmp = Convert.ToString(ds.Tables[0].Rows[i][12]);
                        item.CgDfPry = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.CgActivo = Convert.ToString(ds.Tables[0].Rows[i][14]);
                        item.CgAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][15]);
                        item.CgAudFeCre = ds.Tables[0].Rows[i][16].ToString() == "" ? item.CgAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][16]);
                        item.CgAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][17]);
                        item.CgAudFeMod = ds.Tables[0].Rows[i][18].ToString() == "" ? item.CgAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][18]);
                        item.CgAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][19]);
                        item.CgAudFeEl = ds.Tables[0].Rows[i][20].ToString() == "" ? item.CgAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][20]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public void setFolio(FOLIO folio)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setFolio";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FoIdent", folio.FoIdent);
                    cmd.Parameters.AddWithValue("@FoTipo", folio.FoTipo);
                    cmd.Parameters.AddWithValue("@FoDescrip", folio.FoDescrip);
                    cmd.Parameters.AddWithValue("@FoFolio", folio.FoFolio);
                    cmd.Parameters.AddWithValue("@FoPath", folio.FoPath);
                    cmd.Parameters.AddWithValue("@FoActivo", folio.FoActivo);
                    cmd.Parameters.AddWithValue("@FoAudUsuCre", folio.FoAudUsuCre);
                    cmd.Parameters.AddWithValue("@FoAudFeCre", folio.FoAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updFolio(FOLIO folio, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updFolio";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FoIdent", folio.FoIdent);
                        cmd.Parameters.AddWithValue("@FoTipo", folio.FoTipo);
                        cmd.Parameters.AddWithValue("@FoDescrip", folio.FoDescrip);
                        cmd.Parameters.AddWithValue("@FoFolio", folio.FoFolio);
                        cmd.Parameters.AddWithValue("@FoPath", folio.FoPath);
                        cmd.Parameters.AddWithValue("@FoActivo", folio.FoActivo);
                        cmd.Parameters.AddWithValue("@FoAudUsuMod", folio.FoAudUsuMod);
                        cmd.Parameters.AddWithValue("@FoAudFeMod", folio.FoAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delFolio";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FoIdent", folio.FoIdent);
                        cmd.Parameters.AddWithValue("@FoActivo", folio.FoActivo);
                        cmd.Parameters.AddWithValue("@FoAudUsuEl", folio.FoAudUsuEl);
                        cmd.Parameters.AddWithValue("@FoAudFeEl", folio.FoAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public FOLIO getFolio(FOLIO folio)
        {
            FOLIO item = new FOLIO();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getFolio";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FoIdent", folio.FoIdent);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.FoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.FoTipo = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.FoDescrip = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.FoFolio = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i][3]));
                        item.FoPath = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.FoActivo = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.FoAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.FoAudFeCre = ds.Tables[0].Rows[i][7].ToString() == "" ? item.FoAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][7]);
                        item.FoAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.FoAudFeMod = ds.Tables[0].Rows[i][9].ToString() == "" ? item.FoAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][9]);
                        item.FoAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.FoAudFeEl = ds.Tables[0].Rows[i][11].ToString() == "" ? item.FoAudFeEl: Convert.ToDateTime(ds.Tables[0].Rows[i][11]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<FOLIO> getFolios(FOLIO folio)
        {
            FOLIO item = new FOLIO();
            List<FOLIO> lista = new List<FOLIO>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getFolio";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FoIdent", folio.FoIdent);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.FoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.FoTipo = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.FoDescrip = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.FoFolio = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i][3]));
                        item.FoPath = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.FoActivo = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.FoAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.FoAudFeCre = ds.Tables[0].Rows[i][7].ToString() == "" ? item.FoAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][7]);
                        item.FoAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.FoAudFeMod = ds.Tables[0].Rows[i][9].ToString() == "" ? item.FoAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][9]);
                        item.FoAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.FoAudFeEl = ds.Tables[0].Rows[i][11].ToString() == "" ? item.FoAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][11]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setTipoCambio(TIPOCAMBIO tipoCambio)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setTipoCambio";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TcIdent", tipoCambio.TcIdent);
                    cmd.Parameters.AddWithValue("@TcFecha", tipoCambio.TcFecha);
                    cmd.Parameters.AddWithValue("@TcImporte", tipoCambio.TcImporte);
                    cmd.Parameters.AddWithValue("@TcMonedaOri", tipoCambio.TcMonedaOri);
                    cmd.Parameters.AddWithValue("@TcAudUsuCre", tipoCambio.TcAudUsuCre);
                    cmd.Parameters.AddWithValue("@TcAudFeCre", tipoCambio.TcAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updTipoCambio(TIPOCAMBIO tipoCambio)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_updTipoCambio";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TcIdent", tipoCambio.TcIdent);
                    cmd.Parameters.AddWithValue("@TcFecha", tipoCambio.TcFecha);
                    cmd.Parameters.AddWithValue("@TcImporte", tipoCambio.TcImporte);
                    cmd.Parameters.AddWithValue("@TcMonedaOri", tipoCambio.TcMonedaOri);
                    cmd.Parameters.AddWithValue("@TcAudUsuMod", tipoCambio.TcAudUsuMod);
                    cmd.Parameters.AddWithValue("@TcAudFeMod", tipoCambio.TcAudFeMod);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public TIPOCAMBIO getTipoCambio(TIPOCAMBIO tipoCambio)
        {
            TIPOCAMBIO item = new TIPOCAMBIO();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getTipoCambio";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TcIdent", tipoCambio.TcIdent);
                    cmd.Parameters.AddWithValue("@FeIni", tipoCambio.FeIni);
                    cmd.Parameters.AddWithValue("@FeFin", tipoCambio.FeFin);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.TcIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.TcFecha = ds.Tables[0].Rows[i][1].ToString() == "" ? item.TcFecha : Convert.ToDateTime(ds.Tables[0].Rows[i][1]);
                        item.TcImporte = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][2]));
                        item.TcMonedaOri = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.TcAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.TcAudFeCre = ds.Tables[0].Rows[i][5].ToString() == "" ? item.TcAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][5]);
                        item.TcAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.TcAudFeMod = ds.Tables[0].Rows[i][7].ToString() == "" ? item.TcAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][7]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<TIPOCAMBIO> getTiposCambios(TIPOCAMBIO tipoCambio)
        {
            TIPOCAMBIO item = new TIPOCAMBIO();
            List<TIPOCAMBIO> lista = new List<TIPOCAMBIO>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getTipoCambio";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TcIdent", tipoCambio.TcIdent);
                    cmd.Parameters.AddWithValue("@FeIni", tipoCambio.FeIni);
                    cmd.Parameters.AddWithValue("@FeFin", tipoCambio.FeFin);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.TcIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.TcFecha = ds.Tables[0].Rows[i][1].ToString() == "" ? item.TcFecha : Convert.ToDateTime(ds.Tables[0].Rows[i][1]);
                        item.TcImporte = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][2]));
                        item.TcMonedaOri = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.TcAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.TcAudFeCre = ds.Tables[0].Rows[i][5].ToString() == "" ? item.TcAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][5]);
                        item.TcAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.TcAudFeMod = ds.Tables[0].Rows[i][7].ToString() == "" ? item.TcAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][7]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setNota(NOTA nota)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setNota";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NoIdent", nota.NoIdent);
                    cmd.Parameters.AddWithValue("@NoTipo", nota.NoTipo);
                    cmd.Parameters.AddWithValue("@NoDescripcion", nota.NoDescripcion);
                    cmd.Parameters.AddWithValue("@EfIdent", nota.EfIdent);
                    cmd.Parameters.AddWithValue("@NoActivo", nota.NoActivo);
                    cmd.Parameters.AddWithValue("@NoAudUsuCre", nota.NoAudUsuCre);
                    cmd.Parameters.AddWithValue("@NoAudFeCre", nota.NoAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updNota(NOTA nota, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updNota";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NoIdent", nota.NoIdent);
                        cmd.Parameters.AddWithValue("@NoTipo", nota.NoTipo);
                        cmd.Parameters.AddWithValue("@NoDescripcion", nota.NoDescripcion);
                        cmd.Parameters.AddWithValue("@EfIdent", nota.EfIdent);
                        cmd.Parameters.AddWithValue("@NoActivo", nota.NoActivo);
                        cmd.Parameters.AddWithValue("@NoAudUsuMod", nota.NoAudUsuMod);
                        cmd.Parameters.AddWithValue("@NoAudFeMod", nota.NoAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delNota";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NoIdent", nota.NoIdent);
                        cmd.Parameters.AddWithValue("@NoActivo", nota.NoActivo);
                        cmd.Parameters.AddWithValue("@NoAudUsuEl", nota.NoAudUsuEl);
                        cmd.Parameters.AddWithValue("@NoAudFeEl", nota.NoAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public NOTA getNota(NOTA nota)
        {
            NOTA item = new NOTA();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getNota";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NoIdent", nota.NoIdent);
                    cmd.Parameters.AddWithValue("@NoTipo", nota.NoTipo);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.NoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.NoTipo = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.NoDescripcion = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.EfIdent = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.NoActivo = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.NoAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.NoAudFeCre = ds.Tables[0].Rows[i][6].ToString() == "" ? item.NoAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][6]);
                        item.NoAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.NoAudFeMod = ds.Tables[0].Rows[i][8].ToString() == "" ? item.NoAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][8]);
                        item.NoAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.NoAudFeEl = ds.Tables[0].Rows[i][10].ToString() == "" ? item.NoAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][10]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<NOTA> getNotas(NOTA nota)
        {
            NOTA item = new NOTA();
            List<NOTA> lista = new List<NOTA>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getNota";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NoIdent", nota.NoIdent);
                    cmd.Parameters.AddWithValue("@NoTipo", nota.NoTipo);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.NoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.NoTipo = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.NoDescripcion = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.EfIdent = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.NoActivo = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.NoAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.NoAudFeCre = ds.Tables[0].Rows[i][6].ToString() == "" ? item.NoAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][6]);
                        item.NoAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.NoAudFeMod = ds.Tables[0].Rows[i][8].ToString() == "" ? item.NoAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][8]);
                        item.NoAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.NoAudFeEl = ds.Tables[0].Rows[i][10].ToString() == "" ? item.NoAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][10]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setEfecto(EFECTO efecto)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setEfecto";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EfIdent", efecto.EfIdent);
                    cmd.Parameters.AddWithValue("@EfTipo", efecto.EfTipo);
                    cmd.Parameters.AddWithValue("@EfDescripcion", efecto.EfDescripcion);
                    cmd.Parameters.AddWithValue("@EfUnidad", efecto.EfUnidad);
                    cmd.Parameters.AddWithValue("@EfValor01", efecto.EfValor01);
                    cmd.Parameters.AddWithValue("@EfValor02", efecto.EfValor02);
                    cmd.Parameters.AddWithValue("@EfValor03", efecto.EfValor03);
                    cmd.Parameters.AddWithValue("@EfValor04", efecto.EfValor04);
                    cmd.Parameters.AddWithValue("@EfValor05", efecto.EfValor05);
                    cmd.Parameters.AddWithValue("@EfFecha01", efecto.EfFecha01);
                    cmd.Parameters.AddWithValue("@EfFecha02", efecto.EfFecha02);
                    cmd.Parameters.AddWithValue("@EfFecha03", efecto.EfFecha03);
                    cmd.Parameters.AddWithValue("@EfFecha04", efecto.EfFecha04);
                    cmd.Parameters.AddWithValue("@EfFecha05", efecto.EfFecha05);
                    cmd.Parameters.AddWithValue("@EfCodigo01", efecto.EfCodigo01);
                    cmd.Parameters.AddWithValue("@EfCodigo02", efecto.EfCodigo02);
                    cmd.Parameters.AddWithValue("@EfCodigo03", efecto.EfCodigo03);
                    cmd.Parameters.AddWithValue("@EfCodigo04", efecto.EfCodigo04);
                    cmd.Parameters.AddWithValue("@EfCodigo05", efecto.EfCodigo05);
                    cmd.Parameters.AddWithValue("@EfActivo", efecto.EfActivo);
                    cmd.Parameters.AddWithValue("@EfAudUsuCre", efecto.EfAudUsuCre);
                    cmd.Parameters.AddWithValue("@EfAudFeCre", efecto.EfAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updEfecto(EFECTO efecto, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updEfecto";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EfIdent", efecto.EfIdent);
                        cmd.Parameters.AddWithValue("@EfTipo", efecto.EfTipo);
                        cmd.Parameters.AddWithValue("@EfDescripcion", efecto.EfDescripcion);
                        cmd.Parameters.AddWithValue("@EfUnidad", efecto.EfUnidad);
                        cmd.Parameters.AddWithValue("@EfValor01", efecto.EfValor01);
                        cmd.Parameters.AddWithValue("@EfValor02", efecto.EfValor02);
                        cmd.Parameters.AddWithValue("@EfValor03", efecto.EfValor03);
                        cmd.Parameters.AddWithValue("@EfValor04", efecto.EfValor04);
                        cmd.Parameters.AddWithValue("@EfValor05", efecto.EfValor05);
                        cmd.Parameters.AddWithValue("@EfFecha01", efecto.EfFecha01);
                        cmd.Parameters.AddWithValue("@EfFecha02", efecto.EfFecha02);
                        cmd.Parameters.AddWithValue("@EfFecha03", efecto.EfFecha03);
                        cmd.Parameters.AddWithValue("@EfFecha04", efecto.EfFecha04);
                        cmd.Parameters.AddWithValue("@EfFecha05", efecto.EfFecha05);
                        cmd.Parameters.AddWithValue("@EfCodigo01", efecto.EfCodigo01);
                        cmd.Parameters.AddWithValue("@EfCodigo02", efecto.EfCodigo02);
                        cmd.Parameters.AddWithValue("@EfCodigo03", efecto.EfCodigo03);
                        cmd.Parameters.AddWithValue("@EfCodigo04", efecto.EfCodigo04);
                        cmd.Parameters.AddWithValue("@EfCodigo05", efecto.EfCodigo05);
                        cmd.Parameters.AddWithValue("@EfActivo", efecto.EfActivo);
                        cmd.Parameters.AddWithValue("@EfAudUsuMod", efecto.EfAudUsuMod);
                        cmd.Parameters.AddWithValue("@EfAudFeMod", efecto.EfAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delEfecto";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EfIdent", efecto.EfIdent);
                        cmd.Parameters.AddWithValue("@EfActivo", efecto.EfActivo);
                        cmd.Parameters.AddWithValue("@EfAudUsuEl", efecto.EfAudUsuEl);
                        cmd.Parameters.AddWithValue("@EfAudFeEl", efecto.EfAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public EFECTO getEfecto(EFECTO efecto)
        {
            EFECTO item = new EFECTO();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getEfecto";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EfIdent", efecto.EfIdent);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.EfIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.EfTipo = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.EfDescripcion = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.EfUnidad = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.EfValor01 = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][4]));
                        item.EfValor02 = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][5]));
                        item.EfValor03 = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][6]));
                        item.EfValor04 = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][7]));
                        item.EfValor05 = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][8]));
                        item.EfFecha01 = ds.Tables[0].Rows[i][9].ToString() == "" ? item.EfFecha01 : Convert.ToDateTime(ds.Tables[0].Rows[i][9]);
                        item.EfFecha02 = ds.Tables[0].Rows[i][10].ToString() == "" ? item.EfFecha02 : Convert.ToDateTime(ds.Tables[0].Rows[i][10]);
                        item.EfFecha03 = ds.Tables[0].Rows[i][11].ToString() == "" ? item.EfFecha03 : Convert.ToDateTime(ds.Tables[0].Rows[i][11]);
                        item.EfFecha04 = ds.Tables[0].Rows[i][12].ToString() == "" ? item.EfFecha04 : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                        item.EfFecha05 = ds.Tables[0].Rows[i][13].ToString() == "" ? item.EfFecha05 : Convert.ToDateTime(ds.Tables[0].Rows[i][13]);
                        item.EfCodigo01 = Convert.ToString(ds.Tables[0].Rows[i][14]);
                        item.EfCodigo02 = Convert.ToString(ds.Tables[0].Rows[i][15]);
                        item.EfCodigo03 = Convert.ToString(ds.Tables[0].Rows[i][16]);
                        item.EfCodigo04 = Convert.ToString(ds.Tables[0].Rows[i][17]);
                        item.EfCodigo05 = Convert.ToString(ds.Tables[0].Rows[i][18]);
                        item.EfActivo = Convert.ToString(ds.Tables[0].Rows[i][19]);
                        item.EfAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][20]);
                        item.EfAudFeCre = ds.Tables[0].Rows[i][21].ToString() == "" ? item.EfAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][21]);
                        item.EfAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][22]);
                        item.EfAudFeMod = ds.Tables[0].Rows[i][23].ToString() == "" ? item.EfAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][23]);
                        item.EfAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][24]);
                        item.EfAudFeEl = ds.Tables[0].Rows[i][25].ToString() == "" ? item.EfAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][25]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<EFECTO> getEfectos(EFECTO efecto)
        {
            EFECTO item = new EFECTO();
            List<EFECTO> lista = new List<EFECTO>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getEfecto";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EfIdent", efecto.EfIdent);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.EfIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.EfTipo = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.EfDescripcion = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.EfUnidad = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.EfValor01 = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][4]));
                        item.EfValor02 = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][5]));
                        item.EfValor03 = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][6]));
                        item.EfValor04 = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][7]));
                        item.EfValor05 = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][8]));
                        item.EfFecha01 = ds.Tables[0].Rows[i][9].ToString() == "" ? item.EfFecha01 : Convert.ToDateTime(ds.Tables[0].Rows[i][9]);
                        item.EfFecha02 = ds.Tables[0].Rows[i][10].ToString() == "" ? item.EfFecha02 : Convert.ToDateTime(ds.Tables[0].Rows[i][10]);
                        item.EfFecha03 = ds.Tables[0].Rows[i][11].ToString() == "" ? item.EfFecha03: Convert.ToDateTime(ds.Tables[0].Rows[i][11]);
                        item.EfFecha04 = ds.Tables[0].Rows[i][12].ToString() == "" ? item.EfFecha04 : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                        item.EfFecha05 = ds.Tables[0].Rows[i][13].ToString() == "" ? item.EfFecha05 : Convert.ToDateTime(ds.Tables[0].Rows[i][13]);
                        item.EfCodigo01 = Convert.ToString(ds.Tables[0].Rows[i][14]);
                        item.EfCodigo02 = Convert.ToString(ds.Tables[0].Rows[i][15]);
                        item.EfCodigo03 = Convert.ToString(ds.Tables[0].Rows[i][16]);
                        item.EfCodigo04 = Convert.ToString(ds.Tables[0].Rows[i][17]);
                        item.EfCodigo05 = Convert.ToString(ds.Tables[0].Rows[i][18]);
                        item.EfActivo = Convert.ToString(ds.Tables[0].Rows[i][19]);
                        item.EfAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][20]);
                        item.EfAudFeCre = ds.Tables[0].Rows[i][21].ToString() == "" ? item.EfAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][21]);
                        item.EfAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][22]);
                        item.EfAudFeMod = ds.Tables[0].Rows[i][23].ToString() == "" ? item.EfAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][23]);
                        item.EfAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][24]);
                        item.EfAudFeEl = ds.Tables[0].Rows[i][25].ToString() == "" ? item.EfAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][25]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setEmpresa(EMPRESA empresa)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setEmpresa";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmIdent", empresa.EmIdent);
                    cmd.Parameters.AddWithValue("@EmLogotipo", empresa.EmLogotipo);
                    cmd.Parameters.AddWithValue("@EmLeyenda01", empresa.EmLeyenda01);
                    cmd.Parameters.AddWithValue("@EmLeyenda02", empresa.EmLeyenda02);
                    cmd.Parameters.AddWithValue("@EmLeyenda03", empresa.EmLeyenda03);
                    cmd.Parameters.AddWithValue("@EmLeyenda04", empresa.EmLeyenda04);
                    cmd.Parameters.AddWithValue("@EmLeyenda05", empresa.EmLeyenda05);
                    cmd.Parameters.AddWithValue("@DiNumero", empresa.DiNumero);
                    cmd.Parameters.AddWithValue("@EmPrefijo", empresa.EmPrefijo);
                    cmd.Parameters.AddWithValue("@EmPrefijoPry", empresa.EmPrefijoPry);
                    cmd.Parameters.AddWithValue("@EmGrIdent", empresa.EmGrIdent);
                    cmd.Parameters.AddWithValue("@EmGrIdCot", empresa.EmGrIdCot);
                    cmd.Parameters.AddWithValue("@EmActivo", empresa.EmActivo);
                    cmd.Parameters.AddWithValue("@EmAudUsuCre", empresa.EmAudUsuCre);
                    cmd.Parameters.AddWithValue("@EmAudFeCre", empresa.EmAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updEmpresa(EMPRESA empresa, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updEmpresa";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmIdent", empresa.EmIdent);
                        cmd.Parameters.AddWithValue("@EmLogotipo", empresa.EmLogotipo);
                        cmd.Parameters.AddWithValue("@EmLeyenda01", empresa.EmLeyenda01);
                        cmd.Parameters.AddWithValue("@EmLeyenda02", empresa.EmLeyenda02);
                        cmd.Parameters.AddWithValue("@EmLeyenda03", empresa.EmLeyenda03);
                        cmd.Parameters.AddWithValue("@EmLeyenda04", empresa.EmLeyenda04);
                        cmd.Parameters.AddWithValue("@EmLeyenda05", empresa.EmLeyenda05);
                        cmd.Parameters.AddWithValue("@DiNumero", empresa.DiNumero);
                        cmd.Parameters.AddWithValue("@EmPrefijo", empresa.EmPrefijo);
                        cmd.Parameters.AddWithValue("@EmPrefijoPry", empresa.EmPrefijoPry);
                        cmd.Parameters.AddWithValue("@EmGrIdent", empresa.EmGrIdent);
                        cmd.Parameters.AddWithValue("@EmGrIdCot", empresa.EmGrIdCot);
                        cmd.Parameters.AddWithValue("@EmActivo", empresa.EmActivo);
                        cmd.Parameters.AddWithValue("@EmAudUsuMod", empresa.EmAudUsuMod);
                        cmd.Parameters.AddWithValue("@EmAudFeMod", empresa.EmAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delEmpresa";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmIdent", empresa.EmIdent);
                        cmd.Parameters.AddWithValue("@EmActivo", empresa.EmActivo);
                        cmd.Parameters.AddWithValue("@EmAudUsuEl", empresa.EmAudUsuEl);
                        cmd.Parameters.AddWithValue("@EmAudFeEl", empresa.EmAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public EMPRESA getEmpresa(EMPRESA empresa)
        {
            EMPRESA item = new EMPRESA();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getEmpresa";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmIdent", empresa.EmIdent);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.EmIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.EmLogotipo = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.EmLeyenda01 = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.EmLeyenda02 = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.EmLeyenda03 = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.EmLeyenda04 = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.EmLeyenda05 = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.DiNomCorto = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.EmPrefijo = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.EmPrefijoPry = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.EmGrIdent = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.EmGrIdCot = Convert.ToString(ds.Tables[0].Rows[i][12]);
                        item.EmActivo = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.EmAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][14]);
                        item.EmAudFeCre = ds.Tables[0].Rows[i][15].ToString() == "" ? item.EmAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][15]);
                        item.EmAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][16]);
                        item.EmAudFeMod = ds.Tables[0].Rows[i][17].ToString() == "" ? item.EmAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][17]);
                        item.EmAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][18]);
                        item.EmAudFeEl = ds.Tables[0].Rows[i][19].ToString() == "" ? item.EmAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][19]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<EMPRESA> getEmpresas(EMPRESA empresa)
        {
            EMPRESA item = new EMPRESA();
            List<EMPRESA> lista = new List<EMPRESA>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getEmpresa";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmIdent", empresa.EmIdent);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.EmIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.EmLogotipo = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.EmLeyenda01 = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.EmLeyenda02 = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.EmLeyenda03 = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.EmLeyenda04 = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.EmLeyenda05 = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.DiNomCorto = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.EmPrefijo = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.EmPrefijoPry = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.EmGrIdent = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.EmGrIdCot = Convert.ToString(ds.Tables[0].Rows[i][12]);
                        item.EmActivo = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.EmAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][14]);
                        item.EmAudFeCre = ds.Tables[0].Rows[i][15].ToString() == "" ? item.EmAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][15]);
                        item.EmAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][16]);
                        item.EmAudFeMod = ds.Tables[0].Rows[i][17].ToString() == "" ? item.EmAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][17]);
                        item.EmAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][18]);
                        item.EmAudFeEl = ds.Tables[0].Rows[i][19].ToString() == "" ? item.EmAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][19]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setDocumento(DOCUMENTO documento)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setDocumento";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", documento.DoIdent);
                    cmd.Parameters.AddWithValue("@DoTipo", documento.DoTipo);
                    cmd.Parameters.AddWithValue("@DoFolio", documento.DoFolio);
                    cmd.Parameters.AddWithValue("@DoVersion", documento.DoVersion);
                    cmd.Parameters.AddWithValue("@DoVersionL", documento.DoVersionL);
                    cmd.Parameters.AddWithValue("@DoFecha", documento.DoFecha);
                    cmd.Parameters.AddWithValue("@PyNumero", documento.PyNumero);
                    cmd.Parameters.AddWithValue("@EmIdent", documento.EmIdent);
                    cmd.Parameters.AddWithValue("@DiNumero", documento.DiNumero);
                    cmd.Parameters.AddWithValue("@CnNumero01", documento.CnNumero01);
                    cmd.Parameters.AddWithValue("@CnNumero02", documento.CnNumero02);
                    cmd.Parameters.AddWithValue("@CnNumero03", documento.CnNumero03);
                    cmd.Parameters.AddWithValue("@CnNumero04", documento.CnNumero04);
                    cmd.Parameters.AddWithValue("@CnNumero05", documento.CnNumero05);
                    cmd.Parameters.AddWithValue("@DoSubTotalMoE", documento.DoSubTotalMoE);
                    cmd.Parameters.AddWithValue("@DoTotalMoE", documento.DoTotalMoE);
                    cmd.Parameters.AddWithValue("@DoMonEx", documento.DoMonEx);
                    cmd.Parameters.AddWithValue("@DoSubTotal", documento.DoSubTotal);
                    cmd.Parameters.AddWithValue("@DoDesc", documento.DoDesc);
                    cmd.Parameters.AddWithValue("@DoPjDesc", documento.DoPjDesc);
                    cmd.Parameters.AddWithValue("@DoTipoDesc", documento.DoTipoDesc);
                    cmd.Parameters.AddWithValue("@DoSubTDesc", documento.DoSubTDesc);
                    cmd.Parameters.AddWithValue("@DoImpuesto", documento.DoImpuesto);
                    cmd.Parameters.AddWithValue("@DoImpImp", documento.DoImpImp);
                    cmd.Parameters.AddWithValue("@DoTotal", documento.DoTotal);
                    cmd.Parameters.AddWithValue("@DoMoneda", documento.DoMoneda);
                    cmd.Parameters.AddWithValue("@DoNombre", documento.DoNombre);
                    cmd.Parameters.AddWithValue("@DoPath", documento.DoPath);
                    cmd.Parameters.AddWithValue("@DoFechaIni", documento.DoFechaIni);
                    cmd.Parameters.AddWithValue("@DoFechaFin", documento.DoFechaFin);
                    cmd.Parameters.AddWithValue("@DoEstatus", documento.DoEstatus);
                    cmd.Parameters.AddWithValue("@DoAvance", documento.DoAvance);
                    cmd.Parameters.AddWithValue("@DoUsuSeg", documento.DoUsuSeg);
                    cmd.Parameters.AddWithValue("@DoTiCambio", documento.DoTiCambio);
                    cmd.Parameters.AddWithValue("@DoReferencia", documento.DoReferencia);
                    cmd.Parameters.AddWithValue("@DoDescripcion", documento.DoDescripcion);
                    cmd.Parameters.AddWithValue("@DoDocRef", documento.DoDocRef);
                    cmd.Parameters.AddWithValue("@DoVendedor", documento.DoVendedor);
                    cmd.Parameters.AddWithValue("@DoGrupo", documento.DoGrupo);
                    cmd.Parameters.AddWithValue("@DoGrupoOrden", documento.DoGrupoOrden);
                    cmd.Parameters.AddWithValue("@DoActivo", documento.DoActivo);
                    cmd.Parameters.AddWithValue("@DoAudUsuCre", documento.DoAudUsuCre);
                    cmd.Parameters.AddWithValue("@DoAudFeCre", documento.DoAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updDocumento(DOCUMENTO documento, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updDocumento";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoIdent", documento.DoIdent);
                        cmd.Parameters.AddWithValue("@DoTipo", documento.DoTipo);
                        cmd.Parameters.AddWithValue("@DoFolio", documento.DoFolio);
                        cmd.Parameters.AddWithValue("@DoVersion", documento.DoVersion);
                        cmd.Parameters.AddWithValue("@DoVersionL", documento.DoVersionL);
                        cmd.Parameters.AddWithValue("@DoFecha", documento.DoFecha);
                        cmd.Parameters.AddWithValue("@PyNumero", documento.PyNumero);
                        cmd.Parameters.AddWithValue("@EmIdent", documento.EmIdent);
                        cmd.Parameters.AddWithValue("@DiNumero", documento.DiNumero);
                        cmd.Parameters.AddWithValue("@CnNumero01", documento.CnNumero01);
                        cmd.Parameters.AddWithValue("@CnNumero02", documento.CnNumero02);
                        cmd.Parameters.AddWithValue("@CnNumero03", documento.CnNumero03);
                        cmd.Parameters.AddWithValue("@CnNumero04", documento.CnNumero04);
                        cmd.Parameters.AddWithValue("@CnNumero05", documento.CnNumero05);
                        cmd.Parameters.AddWithValue("@DoSubTotalMoE", documento.DoSubTotalMoE);
                        cmd.Parameters.AddWithValue("@DoTotalMoE", documento.DoTotalMoE);
                        cmd.Parameters.AddWithValue("@DoMonEx", documento.DoMonEx);
                        cmd.Parameters.AddWithValue("@DoSubTotal", documento.DoSubTotal);
                        cmd.Parameters.AddWithValue("@DoDesc", documento.DoDesc);
                        cmd.Parameters.AddWithValue("@DoPjDesc", documento.DoPjDesc);
                        cmd.Parameters.AddWithValue("@DoTipoDesc", documento.DoTipoDesc);
                        cmd.Parameters.AddWithValue("@DoSubTDesc", documento.DoSubTDesc);
                        cmd.Parameters.AddWithValue("@DoImpuesto", documento.DoImpuesto);
                        cmd.Parameters.AddWithValue("@DoImpImp", documento.DoImpImp);
                        cmd.Parameters.AddWithValue("@DoTotal", documento.DoTotal);
                        cmd.Parameters.AddWithValue("@DoMoneda", documento.DoMoneda);
                        cmd.Parameters.AddWithValue("@DoNombre", documento.DoNombre);
                        cmd.Parameters.AddWithValue("@DoPath", documento.DoPath);
                        cmd.Parameters.AddWithValue("@DoFechaIni", documento.DoFechaIni);
                        cmd.Parameters.AddWithValue("@DoFechaFin", documento.DoFechaFin);
                        cmd.Parameters.AddWithValue("@DoEstatus", documento.DoEstatus);
                        cmd.Parameters.AddWithValue("@DoAvance", documento.DoAvance);
                        cmd.Parameters.AddWithValue("@DoUsuSeg", documento.DoUsuSeg);
                        cmd.Parameters.AddWithValue("@DoTiCambio", documento.DoTiCambio);
                        cmd.Parameters.AddWithValue("@DoReferencia", documento.DoReferencia);
                        cmd.Parameters.AddWithValue("@DoDescripcion", documento.DoDescripcion);
                        cmd.Parameters.AddWithValue("@DoDocRef", documento.DoDocRef);
                        cmd.Parameters.AddWithValue("@DoVendedor", documento.DoVendedor);
                        cmd.Parameters.AddWithValue("@DoGrupo", documento.DoGrupo);
                        cmd.Parameters.AddWithValue("@DoGrupoOrden", documento.DoGrupoOrden);
                        cmd.Parameters.AddWithValue("@DoActivo", documento.DoActivo);
                        cmd.Parameters.AddWithValue("@DoAudUsuCre", documento.DoAudUsuCre);
                        cmd.Parameters.AddWithValue("@DoAudFeCre", documento.DoAudFeCre);
                    }
                    else
                    {
                        string comandoSQL = "sp_delDocumento";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoIdent", documento.DoIdent);
                        cmd.Parameters.AddWithValue("@DoActivo", documento.DoActivo);
                        cmd.Parameters.AddWithValue("@DoAudUsuEl", documento.DoAudUsuEl);
                        cmd.Parameters.AddWithValue("@DoAudFeEl", documento.DoAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public DOCUMENTO getDocumento(DOCUMENTO documento)
        {
            DOCUMENTO item = new DOCUMENTO();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getDocumento";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", documento.DoIdent);
                    cmd.Parameters.AddWithValue("@DoFolio", documento.DoFolio);
                    cmd.Parameters.AddWithValue("@DoTipo", documento.DoTipo);
                    cmd.Parameters.AddWithValue("@DiNumero", documento.DiNumero);
                    cmd.Parameters.AddWithValue("@DiNomCorto", documento.DiNomCorto);
                    cmd.Parameters.AddWithValue("@EmIdent", documento.EmIdent);
                    cmd.Parameters.AddWithValue("@DoEstatus", documento.DoEstatus);
                    cmd.Parameters.AddWithValue("@FeIni", documento.FeIni);
                    cmd.Parameters.AddWithValue("@FeFin", documento.FeFin);
                    cmd.Parameters.AddWithValue("@PyNumero", documento.PyNumero);
                    cmd.Parameters.AddWithValue("@PyNombre", documento.PyNombre);
                    cmd.Parameters.AddWithValue("@DoUsuSeg", documento.DoUsuSeg);
                    cmd.Parameters.AddWithValue("@DoVendedor", documento.DoVendedor);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.DoTipo = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.DoFolio = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[i][2]));
                        item.DoVersion = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][3]));
                        item.DoVersionL = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.DoFecha = ds.Tables[0].Rows[i][5].ToString() == "" ? item.DoFecha : Convert.ToDateTime(ds.Tables[0].Rows[i][5]);
                        item.PyNumero = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[i][6]));
                        item.PyNombre = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[i][7]));
                        item.EmIdent = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.DiNomCorto = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[i][10]));
                        item.CnNumero01 = Convert.ToInt16(ds.Tables[0].Rows[i][11]);
                        item.CnNumero02 = Convert.ToInt16(ds.Tables[0].Rows[i][12]);
                        item.CnNumero03 = Convert.ToInt16(ds.Tables[0].Rows[i][13]);
                        item.CnNumero04 = Convert.ToInt16(ds.Tables[0].Rows[i][14]);
                        item.CnNumero05 = Convert.ToInt16(ds.Tables[0].Rows[i][15]);
                        item.DoSubTotalMoE = Convert.ToDouble(ds.Tables[0].Rows[i][16]);
                        item.DoTotalMoE = Convert.ToDouble(ds.Tables[0].Rows[i][17]);
                        item.DoMonEx = Convert.ToString(ds.Tables[0].Rows[i][18]);
                        item.DoSubTotal = Convert.ToDouble(ds.Tables[0].Rows[i][19]);
                        item.DoDesc = Convert.ToDouble(ds.Tables[0].Rows[i][20]);
                        item.DoPjDesc = Convert.ToDouble(ds.Tables[0].Rows[i][21]);
                        item.DoTipoDesc = Convert.ToString(ds.Tables[0].Rows[i][22]);
                        item.DoSubTDesc = Convert.ToDouble(ds.Tables[0].Rows[i][23]);
                        item.DoImpuesto = Convert.ToInt16(ds.Tables[0].Rows[i][24]);
                        item.DoImpImp = Convert.ToDouble(ds.Tables[0].Rows[i][25]);
                        item.DoTotal = Convert.ToDouble(ds.Tables[0].Rows[i][26]);
                        item.DoMoneda = Convert.ToString(ds.Tables[0].Rows[i][27]);
                        item.DoNombre = Convert.ToString(ds.Tables[0].Rows[i][28]);
                        item.DoPath = Convert.ToString(ds.Tables[0].Rows[i][29]);
                        item.DoFechaIni = ds.Tables[0].Rows[i][30].ToString() == "" ? item.DoFechaIni : Convert.ToDateTime(ds.Tables[0].Rows[i][30]);
                        item.DoFechaFin = ds.Tables[0].Rows[i][31].ToString() == "" ? item.DoFechaFin : Convert.ToDateTime(ds.Tables[0].Rows[i][31]);
                        item.DoEstatus = Convert.ToString(ds.Tables[0].Rows[i][32]);
                        item.DoAvance = Convert.ToInt16(ds.Tables[0].Rows[i][33]);
                        item.DoUsuSeg = Convert.ToString(ds.Tables[0].Rows[i][34]);
                        item.DoTiCambio = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][35]));
                        item.DoReferencia = Convert.ToString(ds.Tables[0].Rows[i][36]);
                        item.DoDescripcion = Convert.ToString(ds.Tables[0].Rows[i][37]);
                        item.DoDocRef = Convert.ToString(ds.Tables[0].Rows[i][38]);
                        item.DoVendedor = Convert.ToString(ds.Tables[0].Rows[i][39]);
                        item.DoGrupo = Convert.ToString(ds.Tables[0].Rows[i][40]);
                        item.DoGrupoOrden = Convert.ToInt16(ds.Tables[0].Rows[i][41]);
                        item.DoActivo = Convert.ToString(ds.Tables[0].Rows[i][42]);
                        item.DoAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][43]);
                        item.DoAudFeCre = ds.Tables[0].Rows[i][44].ToString() == "" ? item.DoAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][44]);
                        item.DoAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][45]);
                        item.DoAudFeMod = ds.Tables[0].Rows[i][46].ToString() == "" ? item.DoAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][46]);
                        item.DoAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][47]);
                        item.DoAudFeEl = ds.Tables[0].Rows[i][48].ToString() == "" ? item.DoAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][48]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<DOCUMENTO> getDocumentos(DOCUMENTO documento)
        {
            DOCUMENTO item = new DOCUMENTO();
            List<DOCUMENTO> lista = new List<DOCUMENTO>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getDocumento";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", documento.DoIdent);
                    cmd.Parameters.AddWithValue("@DoFolio", documento.DoFolio);
                    cmd.Parameters.AddWithValue("@DoTipo", documento.DoTipo);
                    cmd.Parameters.AddWithValue("@DiNumero", documento.DiNumero);
                    cmd.Parameters.AddWithValue("@DiNomCorto", documento.DiNomCorto);
                    cmd.Parameters.AddWithValue("@EmIdent", documento.EmIdent);
                    cmd.Parameters.AddWithValue("@DoEstatus", documento.DoEstatus);
                    cmd.Parameters.AddWithValue("@FeIni", documento.FeIni);
                    cmd.Parameters.AddWithValue("@FeFin", documento.FeFin);
                    cmd.Parameters.AddWithValue("@PyNumero", documento.PyNumero);
                    cmd.Parameters.AddWithValue("@PyNombre", documento.PyNombre);
                    cmd.Parameters.AddWithValue("@DoUsuSeg", documento.DoUsuSeg);
                    cmd.Parameters.AddWithValue("@DoVendedor", documento.DoVendedor);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.DoTipo = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.DoFolio = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[i][2]));
                        item.DoVersion = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][3]));
                        item.DoVersionL = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.DoFecha = ds.Tables[0].Rows[i][5].ToString() == "" ? item.DoFecha : Convert.ToDateTime(ds.Tables[0].Rows[i][5]);
                        item.PyNumero = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[i][6]));
                        item.PyNombre = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[i][7]));
                        item.EmIdent = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.DiNomCorto = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[i][10]));
                        item.CnNumero01 = Convert.ToInt16(ds.Tables[0].Rows[i][11]);
                        item.CnNumero02 = Convert.ToInt16(ds.Tables[0].Rows[i][12]);
                        item.CnNumero03 = Convert.ToInt16(ds.Tables[0].Rows[i][13]);
                        item.CnNumero04 = Convert.ToInt16(ds.Tables[0].Rows[i][14]);
                        item.CnNumero05 = Convert.ToInt16(ds.Tables[0].Rows[i][15]);
                        item.DoSubTotalMoE = Convert.ToDouble(ds.Tables[0].Rows[i][16]);
                        item.DoTotalMoE = Convert.ToDouble(ds.Tables[0].Rows[i][17]);
                        item.DoMonEx = Convert.ToString(ds.Tables[0].Rows[i][18]);
                        item.DoSubTotal = Convert.ToDouble(ds.Tables[0].Rows[i][19]);
                        item.DoDesc = Convert.ToDouble(ds.Tables[0].Rows[i][20]);
                        item.DoPjDesc = Convert.ToDouble(ds.Tables[0].Rows[i][21]);
                        item.DoTipoDesc = Convert.ToString(ds.Tables[0].Rows[i][22]);
                        item.DoSubTDesc = Convert.ToDouble(ds.Tables[0].Rows[i][23]);
                        item.DoImpuesto = Convert.ToInt16(ds.Tables[0].Rows[i][24]);
                        item.DoImpImp = Convert.ToDouble(ds.Tables[0].Rows[i][25]);
                        item.DoTotal = Convert.ToDouble(ds.Tables[0].Rows[i][26]);
                        item.DoMoneda = Convert.ToString(ds.Tables[0].Rows[i][27]);
                        item.DoNombre = Convert.ToString(ds.Tables[0].Rows[i][28]);
                        item.DoPath = Convert.ToString(ds.Tables[0].Rows[i][29]);
                        item.DoFechaIni = ds.Tables[0].Rows[i][30].ToString() == "" ? item.DoFechaIni : Convert.ToDateTime(ds.Tables[0].Rows[i][30]);
                        item.DoFechaFin = ds.Tables[0].Rows[i][31].ToString() == "" ? item.DoFechaFin : Convert.ToDateTime(ds.Tables[0].Rows[i][31]);
                        item.DoEstatus = Convert.ToString(ds.Tables[0].Rows[i][32]);
                        item.DoAvance = Convert.ToInt16(ds.Tables[0].Rows[i][33]);
                        item.DoUsuSeg = Convert.ToString(ds.Tables[0].Rows[i][34]);
                        item.DoTiCambio = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][35]));
                        item.DoReferencia = Convert.ToString(ds.Tables[0].Rows[i][36]);
                        item.DoDescripcion = Convert.ToString(ds.Tables[0].Rows[i][37]);
                        item.DoDocRef = Convert.ToString(ds.Tables[0].Rows[i][38]);
                        item.DoVendedor = Convert.ToString(ds.Tables[0].Rows[i][39]);
                        item.DoGrupo = Convert.ToString(ds.Tables[0].Rows[i][40]);
                        item.DoGrupoOrden = Convert.ToInt16(ds.Tables[0].Rows[i][41]);
                        item.DoActivo = Convert.ToString(ds.Tables[0].Rows[i][42]);
                        item.DoAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][43]);
                        item.DoAudFeCre = ds.Tables[0].Rows[i][44].ToString() == "" ? item.DoAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][44]);
                        item.DoAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][45]);
                        item.DoAudFeMod = ds.Tables[0].Rows[i][46].ToString() == "" ? item.DoAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][46]);
                        item.DoAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][47]);
                        item.DoAudFeEl = ds.Tables[0].Rows[i][48].ToString() == "" ? item.DoAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][48]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public string getVerDocumento(string PyNumero)
        {
            string DoVersionL = "";
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                string comandoSQL = "sp_getVerDocumento";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PyNumero", PyNumero);
                cmd.Parameters.AddWithValue("@DoVersionL", "");
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i = 0;
                if (ds.Tables[0].Rows.Count == 1)
                {
                    DoVersionL = Convert.ToString(ds.Tables[0].Rows[i][0]);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return DoVersionL;
        }

        public int getVerDocumento(string PyNumero, string DoVersionL)
        {
            int DoVersion = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                string comandoSQL = "sp_getVerDocumento";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PyNumero", PyNumero);
                cmd.Parameters.AddWithValue("@DoVersionL", DoVersionL);
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i = 0;
                if (ds.Tables[0].Rows.Count == 1)
                {
                    DoVersion = Convert.ToInt16(ds.Tables[0].Rows[i][0]);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return DoVersion;
        }

        public void setDocNota(DOCNOTA docNota)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setDocNota";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", docNota.DoIdent);
                    cmd.Parameters.AddWithValue("@DnNumero", docNota.DnNumero);
                    cmd.Parameters.AddWithValue("@DnDescripcion", docNota.DnDescripcion);
                    cmd.Parameters.AddWithValue("@DnTipo", docNota.DnTipo);
                    cmd.Parameters.AddWithValue("@DnOrden", docNota.DnOrden);
                    cmd.Parameters.AddWithValue("@NoIdent", docNota.NoIdent);
                    cmd.Parameters.AddWithValue("@DnActivo", docNota.DnActivo);
                    cmd.Parameters.AddWithValue("@DnAudUsuCre", docNota.DnAudUsuCre);
                    cmd.Parameters.AddWithValue("@DnAudFeCre", docNota.DnAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updDocNota(DOCNOTA docNota, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updDocNota";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoIdent", docNota.DoIdent);
                        cmd.Parameters.AddWithValue("@DnNumero", docNota.DnNumero);
                        cmd.Parameters.AddWithValue("@DnDescripcion", docNota.DnDescripcion);
                        cmd.Parameters.AddWithValue("@DnTipo", docNota.DnTipo);
                        cmd.Parameters.AddWithValue("@DnOrden", docNota.DnOrden);
                        cmd.Parameters.AddWithValue("@NoIdent", docNota.NoIdent);
                        cmd.Parameters.AddWithValue("@DnActivo", docNota.DnActivo);
                        cmd.Parameters.AddWithValue("@DnAudUsuMod", docNota.DnAudUsuMod);
                        cmd.Parameters.AddWithValue("@DnAudFeMod", docNota.DnAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delDocNota";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoIdent", docNota.DoIdent);
                        cmd.Parameters.AddWithValue("@DnNumero", docNota.DnNumero);
                        cmd.Parameters.AddWithValue("@DnActivo", docNota.DnActivo);
                        cmd.Parameters.AddWithValue("@DnAudUsuEl", docNota.DnAudUsuEl);
                        cmd.Parameters.AddWithValue("@DnAudFeEl", docNota.DnAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public DOCNOTA getDocNota(DOCNOTA docNota)
        {
            DOCNOTA item = new DOCNOTA();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getDocNota";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", docNota.DoIdent);
                    cmd.Parameters.AddWithValue("@DnNumero", docNota.DnNumero);
                    cmd.Parameters.AddWithValue("@DnTipo", docNota.DnTipo);
                    cmd.Parameters.AddWithValue("@NoIdent", docNota.NoIdent);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.DnNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.DnDescripcion = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.DnTipo = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.DnOrden = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][4]));
                        item.NoIdent = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.DnActivo = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.DnAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.DnAudFeCre = ds.Tables[0].Rows[i][8].ToString() == "" ? item.DnAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][8]);
                        item.DnAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.DnAudFeMod = ds.Tables[0].Rows[i][10].ToString() == "" ? item.DnAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][10]);
                        item.DnAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.DnAudFeEl = ds.Tables[0].Rows[i][12].ToString() == "" ? item.DnAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<DOCNOTA> getDocNotas(DOCNOTA docNota)
        {
            DOCNOTA item = new DOCNOTA();
            List<DOCNOTA> lista = new List<DOCNOTA>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getDocNota";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", docNota.DoIdent);
                    cmd.Parameters.AddWithValue("@DnNumero", docNota.DnNumero);
                    cmd.Parameters.AddWithValue("@DnTipo", docNota.DnTipo);
                    cmd.Parameters.AddWithValue("@NoIdent", docNota.NoIdent);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.DnNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.DnDescripcion = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.DnTipo = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.DnOrden = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][4]));
                        item.NoIdent = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.DnActivo = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.DnAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.DnAudFeCre = ds.Tables[0].Rows[i][8].ToString() == "" ? item.DnAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][8]);
                        item.DnAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.DnAudFeMod = ds.Tables[0].Rows[i][10].ToString() == "" ? item.DnAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][10]);
                        item.DnAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.DnAudFeEl = ds.Tables[0].Rows[i][12].ToString() == "" ? item.DnAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setDocConcepto(DOCCONCEPTO docConcepto)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setDocConcepto";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", docConcepto.DoIdent);
                    cmd.Parameters.AddWithValue("@CoNumero", docConcepto.CoNumero);
                    cmd.Parameters.AddWithValue("@DcDescripcion", docConcepto.DcDescripcion);
                    cmd.Parameters.AddWithValue("@DcPjDesc", docConcepto.DcPjDesc);
                    cmd.Parameters.AddWithValue("@DcImpDesc", docConcepto.DcImpDesc);
                    cmd.Parameters.AddWithValue("@DcSubtotal", docConcepto.DcSubtotal);
                    cmd.Parameters.AddWithValue("@DcTotal", docConcepto.DcTotal);
                    cmd.Parameters.AddWithValue("@DcMoneda", docConcepto.DcMoneda);
                    cmd.Parameters.AddWithValue("@DcEstatus", docConcepto.DcEstatus);
                    cmd.Parameters.AddWithValue("@DcAvance", docConcepto.DcAvance);
                    cmd.Parameters.AddWithValue("@DcReferencia", docConcepto.DcReferencia);
                    cmd.Parameters.AddWithValue("@DcOrden", docConcepto.DcOrden);
                    cmd.Parameters.AddWithValue("@DcActivo", docConcepto.DcActivo);
                    cmd.Parameters.AddWithValue("@DcAudUsuCre", docConcepto.DcAudUsuCre);
                    cmd.Parameters.AddWithValue("@DcAudFeCre", docConcepto.DcAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updDocConcepto(DOCCONCEPTO docConcepto, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updDocConcepto";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoIdent", docConcepto.DoIdent);
                        cmd.Parameters.AddWithValue("@CoNumero", docConcepto.CoNumero);
                        cmd.Parameters.AddWithValue("@DcDescripcion", docConcepto.DcDescripcion);
                        cmd.Parameters.AddWithValue("@DcPjDesc", docConcepto.DcPjDesc);
                        cmd.Parameters.AddWithValue("@DcImpDesc", docConcepto.DcImpDesc);
                        cmd.Parameters.AddWithValue("@DcSubtotal", docConcepto.DcSubtotal);
                        cmd.Parameters.AddWithValue("@DcTotal", docConcepto.DcTotal);
                        cmd.Parameters.AddWithValue("@DcMoneda", docConcepto.DcMoneda);
                        cmd.Parameters.AddWithValue("@DcEstatus", docConcepto.DcEstatus);
                        cmd.Parameters.AddWithValue("@DcAvance", docConcepto.DcAvance);
                        cmd.Parameters.AddWithValue("@DcReferencia", docConcepto.DcReferencia);
                        cmd.Parameters.AddWithValue("@DcOrden", docConcepto.DcOrden);
                        cmd.Parameters.AddWithValue("@DcActivo", docConcepto.DcActivo);
                        cmd.Parameters.AddWithValue("@DcAudUsuMod", docConcepto.DcAudUsuMod);
                        cmd.Parameters.AddWithValue("@DcAudFeMod", docConcepto.DcAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delDocConcepto";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoIdent", docConcepto.DoIdent);
                        cmd.Parameters.AddWithValue("@CoNumero", docConcepto.CoNumero);
                        cmd.Parameters.AddWithValue("@DcActivo", docConcepto.DcActivo);
                        cmd.Parameters.AddWithValue("@DcAudUsuEl", docConcepto.DcAudUsuEl);
                        cmd.Parameters.AddWithValue("@DcAudFeEl", docConcepto.DcAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public DOCCONCEPTO getDocConcepto(DOCCONCEPTO docConcepto)
        {
            DOCCONCEPTO item = new DOCCONCEPTO();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getDocConcepto";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", docConcepto.DoIdent);
                    cmd.Parameters.AddWithValue("@CoNumero", docConcepto.CoNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CoNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.CoDescripcion = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.DcDescripcion = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.DcPjDesc = Convert.ToDouble(ds.Tables[0].Rows[i][4]);
                        item.DcImpDesc = Convert.ToDouble(ds.Tables[0].Rows[i][5]);
                        item.DcSubtotal = Convert.ToDouble(ds.Tables[0].Rows[i][6]);
                        item.DcTotal = Convert.ToDouble(ds.Tables[0].Rows[i][7]);
                        item.DcMoneda = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.DcEstatus = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.DcAvance = Convert.ToInt16(ds.Tables[0].Rows[i][10]);
                        item.DcReferencia = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.DcFeInicio = ds.Tables[0].Rows[i][12].ToString() == "" ? item.DcFeInicio : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                        item.DcFeTermino = ds.Tables[0].Rows[i][13].ToString() == "" ? item.DcFeTermino : Convert.ToDateTime(ds.Tables[0].Rows[i][13]);
                        item.DcFeCancel = ds.Tables[0].Rows[i][14].ToString() == "" ? item.DcFeCancel : Convert.ToDateTime(ds.Tables[0].Rows[i][14]);
                        item.DcOrden = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][15]));
                        item.DcActivo = Convert.ToString(ds.Tables[0].Rows[i][16]);
                        item.DcAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][17]);
                        item.DcAudFeCre = ds.Tables[0].Rows[i][18].ToString() == "" ? item.DcAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][18]);
                        item.DcAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][19]);
                        item.DcAudFeMod = ds.Tables[0].Rows[i][20].ToString() == "" ? item.DcAudFeMod :Convert.ToDateTime(ds.Tables[0].Rows[i][20]);
                        item.DcAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][21]);
                        item.DcAudFeEl = ds.Tables[0].Rows[i][22].ToString() == "" ? item.DcAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][22]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<DOCCONCEPTO> getDocConceptos(DOCCONCEPTO docConcepto)
        {
            DOCCONCEPTO item = new DOCCONCEPTO();
            List<DOCCONCEPTO> lista = new List<DOCCONCEPTO>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getDocConcepto";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", docConcepto.DoIdent);
                    cmd.Parameters.AddWithValue("@CoNumero", docConcepto.CoNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CoNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.CoDescripcion = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.DcDescripcion = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.DcPjDesc = Convert.ToDouble(ds.Tables[0].Rows[i][4]);
                        item.DcImpDesc = Convert.ToDouble(ds.Tables[0].Rows[i][5]);
                        item.DcSubtotal = Convert.ToDouble(ds.Tables[0].Rows[i][6]);
                        item.DcTotal = Convert.ToDouble(ds.Tables[0].Rows[i][7]);
                        item.DcMoneda = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.DcEstatus = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.DcAvance = Convert.ToInt16(ds.Tables[0].Rows[i][10]);
                        item.DcReferencia = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.DcFeInicio = ds.Tables[0].Rows[i][12].ToString() == "" ? item.DcFeInicio : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                        item.DcFeTermino = ds.Tables[0].Rows[i][13].ToString() == "" ? item.DcFeTermino : Convert.ToDateTime(ds.Tables[0].Rows[i][13]);
                        item.DcFeCancel = ds.Tables[0].Rows[i][14].ToString() == "" ? item.DcFeCancel : Convert.ToDateTime(ds.Tables[0].Rows[i][14]);
                        item.DcOrden = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][15]));
                        item.DcActivo = Convert.ToString(ds.Tables[0].Rows[i][16]);
                        item.DcAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][17]);
                        item.DcAudFeCre = ds.Tables[0].Rows[i][18].ToString() == "" ? item.DcAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][18]);
                        item.DcAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][19]);
                        item.DcAudFeMod = ds.Tables[0].Rows[i][20].ToString() == "" ? item.DcAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][20]);
                        item.DcAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][21]);
                        item.DcAudFeEl = ds.Tables[0].Rows[i][22].ToString() == "" ? item.DcAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][22]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setConcepto(CONCEPTO concepto)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setConcepto";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CoNumero", concepto.CoNumero);
                    cmd.Parameters.AddWithValue("@CoDescripcion", concepto.CoDescripcion);
                    cmd.Parameters.AddWithValue("@CoActivo", concepto.CoActivo);
                    cmd.Parameters.AddWithValue("@CoAudUsuCre", concepto.CoAudUsuCre);
                    cmd.Parameters.AddWithValue("@CoAudFeCre", concepto.CoAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updConcepto(CONCEPTO concepto, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updConcepto";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CoNumero", concepto.CoNumero);
                        cmd.Parameters.AddWithValue("@CoDescripcion", concepto.CoDescripcion);
                        cmd.Parameters.AddWithValue("@CoActivo", concepto.CoActivo);
                        cmd.Parameters.AddWithValue("@CoAudUsuMod", concepto.CoAudUsuMod);
                        cmd.Parameters.AddWithValue("@CoAudFeMod", concepto.CoAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delConcepto";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoIdent", concepto.CoNumero);
                        cmd.Parameters.AddWithValue("@CoActivo", concepto.CoActivo);
                        cmd.Parameters.AddWithValue("@CoAudUsuEl", concepto.CoAudUsuEl);
                        cmd.Parameters.AddWithValue("@CoAudFeEl", concepto.CoAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public CONCEPTO getConcepto(CONCEPTO concepto)
        {
            CONCEPTO item = new CONCEPTO();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getConcepto";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CoNumero", concepto.CoNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.CoNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][0]));
                        item.CoDescripcion = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.CoActivo = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.CoAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.CoAudFeCre = ds.Tables[0].Rows[i][4].ToString() == "" ? item.CoAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][4]);
                        item.CoAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.CoAudFeMod = ds.Tables[0].Rows[i][6].ToString() == "" ? item.CoAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][6]);
                        item.CoAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.CoAudFeEl = ds.Tables[0].Rows[i][8].ToString() == "" ? item.CoAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][8]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<CONCEPTO> getConceptos(CONCEPTO concepto)
        {
            CONCEPTO item = new CONCEPTO();
            List<CONCEPTO> lista = new List<CONCEPTO>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getConcepto";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CoNumero", concepto.CoNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.CoNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][0]));
                        item.CoDescripcion = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.CoActivo = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.CoAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.CoAudFeCre = ds.Tables[0].Rows[i][4].ToString() == "" ? item.CoAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][4]);
                        item.CoAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.CoAudFeMod = ds.Tables[0].Rows[i][6].ToString() == "" ? item.CoAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][6]);
                        item.CoAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.CoAudFeEl = ds.Tables[0].Rows[i][8].ToString() == "" ? item.CoAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][8]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setDocCPartida(DOCCPARTIDA docCPartida)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setDocCPartida";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", docCPartida.DoIdent);
                    cmd.Parameters.AddWithValue("@CoNumero", docCPartida.CoNumero);
                    cmd.Parameters.AddWithValue("@DpNumero", docCPartida.DpNumero);
                    cmd.Parameters.AddWithValue("@ArIdent", docCPartida.ArIdent);
                    cmd.Parameters.AddWithValue("@DiNumero", docCPartida.DiNumero);
                    cmd.Parameters.AddWithValue("@DpDescripcion", docCPartida.DpDescripcion);
                    cmd.Parameters.AddWithValue("@DpCantidad", docCPartida.DpCantidad);
                    cmd.Parameters.AddWithValue("@DpUnidad", docCPartida.DpUnidad);
                    cmd.Parameters.AddWithValue("@DpCosto", docCPartida.DpCosto);
                    cmd.Parameters.AddWithValue("@DpPjCosto", docCPartida.DpPjCosto);
                    cmd.Parameters.AddWithValue("@DpPrecio", docCPartida.DpPrecio);
                    cmd.Parameters.AddWithValue("@DpSubtotal", docCPartida.DpSubtotal);
                    cmd.Parameters.AddWithValue("@DpPjDesc", docCPartida.DpPjDesc);
                    cmd.Parameters.AddWithValue("@DpImpDesc", docCPartida.DpImpDesc);
                    cmd.Parameters.AddWithValue("@DpImporteMoE", docCPartida.DpImporteMoE);
                    cmd.Parameters.AddWithValue("@DpMonEx", docCPartida.DpMonEx);
                    cmd.Parameters.AddWithValue("@DpImporte", docCPartida.DpImporte);
                    cmd.Parameters.AddWithValue("@DpTratamiento", docCPartida.DpTratamiento);
                    cmd.Parameters.AddWithValue("@DpEstatus", docCPartida.DpEstatus);
                    cmd.Parameters.AddWithValue("@DpAvance", docCPartida.DpAvance);
                    cmd.Parameters.AddWithValue("@DpReferencia", docCPartida.DpReferencia);
                    cmd.Parameters.AddWithValue("@DpFabricado", docCPartida.DpFabricado);
                    cmd.Parameters.AddWithValue("@DpOrden", docCPartida.DpOrden);
                    cmd.Parameters.AddWithValue("@DpActivo", docCPartida.DpActivo);
                    cmd.Parameters.AddWithValue("@DpAudUsuCre", docCPartida.DpAudUsuCre);
                    cmd.Parameters.AddWithValue("@DpAudFeCre", docCPartida.DpAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updDocCPartida(DOCCPARTIDA docCPartida, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updDocCPartida";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoIdent", docCPartida.DoIdent);
                        cmd.Parameters.AddWithValue("@CoNumero", docCPartida.CoNumero);
                        cmd.Parameters.AddWithValue("@DpNumero", docCPartida.DpNumero);
                        cmd.Parameters.AddWithValue("@ArIdent", docCPartida.ArIdent);
                        cmd.Parameters.AddWithValue("@DiNumero", docCPartida.DiNumero);
                        cmd.Parameters.AddWithValue("@DpDescripcion", docCPartida.DpDescripcion);
                        cmd.Parameters.AddWithValue("@DpCantidad", docCPartida.DpCantidad);
                        cmd.Parameters.AddWithValue("@DpUnidad", docCPartida.DpUnidad);
                        cmd.Parameters.AddWithValue("@DpCosto", docCPartida.DpCosto);
                        cmd.Parameters.AddWithValue("@DpPjCosto", docCPartida.DpPjCosto);
                        cmd.Parameters.AddWithValue("@DpPrecio", docCPartida.DpPrecio);
                        cmd.Parameters.AddWithValue("@DpSubtotal", docCPartida.DpSubtotal);
                        cmd.Parameters.AddWithValue("@DpPjDesc", docCPartida.DpPjDesc);
                        cmd.Parameters.AddWithValue("@DpImpDesc", docCPartida.DpImpDesc);
                        cmd.Parameters.AddWithValue("@DpImporteMoE", docCPartida.DpImporteMoE);
                        cmd.Parameters.AddWithValue("@DpMonEx", docCPartida.DpMonEx);
                        cmd.Parameters.AddWithValue("@DpImporte", docCPartida.DpImporte);
                        cmd.Parameters.AddWithValue("@DpTratamiento", docCPartida.DpTratamiento);
                        cmd.Parameters.AddWithValue("@DpEstatus", docCPartida.DpEstatus);
                        cmd.Parameters.AddWithValue("@DpAvance", docCPartida.DpAvance);
                        cmd.Parameters.AddWithValue("@DpReferencia", docCPartida.DpReferencia);
                        cmd.Parameters.AddWithValue("@DpFabricado", docCPartida.DpFabricado);
                        cmd.Parameters.AddWithValue("@DpOrden", docCPartida.DpOrden);
                        cmd.Parameters.AddWithValue("@DpActivo", docCPartida.DpActivo);
                        cmd.Parameters.AddWithValue("@DpAudUsuCre", docCPartida.DpAudUsuCre);
                        cmd.Parameters.AddWithValue("@DpAudFeCre", docCPartida.DpAudFeCre);
                    }
                    else
                    {
                        string comandoSQL = "sp_delDocCPartida";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoIdent", docCPartida.DoIdent);
                        cmd.Parameters.AddWithValue("@CoNumero", docCPartida.CoNumero);
                        cmd.Parameters.AddWithValue("@DpNumero", docCPartida.DpNumero);
                        cmd.Parameters.AddWithValue("@DpActivo", docCPartida.DpActivo);
                        cmd.Parameters.AddWithValue("@DpAudUsuEl", docCPartida.DpAudUsuEl);
                        cmd.Parameters.AddWithValue("@DpAudFeEl", docCPartida.DpAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public DOCCPARTIDA getDocCPartida(DOCCPARTIDA docCPartida)
        {
            DOCCPARTIDA item = new DOCCPARTIDA();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getDocCPartida";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", docCPartida.DoIdent);
                    cmd.Parameters.AddWithValue("@CoNumero", docCPartida.CoNumero);
                    cmd.Parameters.AddWithValue("@DpNumero", docCPartida.DpNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CoNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.DpNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][2]));
                        item.ArIdent = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.DpDescripcion = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.DpCantidad = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][6]));
                        item.DpUnidad = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.DpCosto = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][8]));
                        item.DpPjCosto = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][9]));
                        item.DpPrecio = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][10]));
                        item.DpSubtotal = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][11]));
                        item.DpPjDesc = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][12]));
                        item.DpImpDesc = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][13]));
                        item.DpImporteMoE = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][14]));
                        item.DpMonEx = Convert.ToString(ds.Tables[0].Rows[i][15]);
                        item.DpImporte = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][16]));
                        item.DpTratamiento = Convert.ToString(ds.Tables[0].Rows[i][17]);
                        item.DpEstatus = Convert.ToString(ds.Tables[0].Rows[i][18]);
                        item.DpAvance = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][19]));
                        item.DpReferencia = Convert.ToString(ds.Tables[0].Rows[i][20]);
                        item.DpFabricado = Convert.ToString(ds.Tables[0].Rows[i][21]);
                        item.DpFePedidoPg = ds.Tables[0].Rows[i][22].ToString() == "" ? item.DpFePedidoPg : Convert.ToDateTime(ds.Tables[0].Rows[i][22]);
                        item.DpFePedidoRe = ds.Tables[0].Rows[i][23].ToString() == "" ? item.DpFePedidoRe : Convert.ToDateTime(ds.Tables[0].Rows[i][23]);
                        item.DpFeReciboPg = ds.Tables[0].Rows[i][24].ToString() == "" ? item.DpFeReciboPg : Convert.ToDateTime(ds.Tables[0].Rows[i][24]);
                        item.DpFeReciboRe = ds.Tables[0].Rows[i][25].ToString() == "" ? item.DpFeReciboRe : Convert.ToDateTime(ds.Tables[0].Rows[i][25]);
                        item.DpFeEnvioPg = ds.Tables[0].Rows[i][26].ToString() == "" ? item.DpFeEnvioPg : Convert.ToDateTime(ds.Tables[0].Rows[i][26]);
                        item.DpFeEnvioRe = ds.Tables[0].Rows[i][27].ToString() == "" ? item.DpFeEnvioRe : Convert.ToDateTime(ds.Tables[0].Rows[i][27]);
                        item.DpFeEntregaPg = ds.Tables[0].Rows[i][28].ToString() == "" ? item.DpFeEntregaPg : Convert.ToDateTime(ds.Tables[0].Rows[i][28]);
                        item.DpFeEntregaRe = ds.Tables[0].Rows[i][29].ToString() == "" ? item.DpFeEntregaRe : Convert.ToDateTime(ds.Tables[0].Rows[i][29]);
                        item.DpFeCancel = ds.Tables[0].Rows[i][30].ToString() == "" ? item.DpFeCancel : Convert.ToDateTime(ds.Tables[0].Rows[i][30]);
                        item.ArCodigo = Convert.ToString(ds.Tables[0].Rows[i][31]);
                        item.ArPrecioPub = Convert.ToDouble(ds.Tables[0].Rows[i][32].ToString());
                        item.DpOrden = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][33]));
                        item.DpActivo = Convert.ToString(ds.Tables[0].Rows[i][34]);
                        item.DpAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][35]);
                        item.DpAudFeCre = ds.Tables[0].Rows[i][36].ToString() == "" ? item.DpAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][36]);
                        item.DpAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][37]);
                        item.DpAudFeMod = ds.Tables[0].Rows[i][38].ToString() == "" ? item.DpAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][38]);
                        item.DpAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][39]);
                        item.DpAudFeEl = ds.Tables[0].Rows[i][40].ToString() == "" ? item.DpAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][40]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<DOCCPARTIDA> getDocCPartidas(DOCCPARTIDA docCPartida)
        {
            DOCCPARTIDA item = new DOCCPARTIDA();
            List<DOCCPARTIDA> lista = new List<DOCCPARTIDA>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getDocCPartida";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", docCPartida.DoIdent);
                    cmd.Parameters.AddWithValue("@CoNumero", docCPartida.CoNumero);
                    cmd.Parameters.AddWithValue("@DpNumero", docCPartida.DpNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CoNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.DpNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][2]));
                        item.ArIdent = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.DpDescripcion = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.DpCantidad = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][6]));
                        item.DpUnidad = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.DpCosto = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][8]));
                        item.DpPjCosto = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][9]));
                        item.DpPrecio = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][10]));
                        item.DpSubtotal = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][11]));
                        item.DpPjDesc = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][12]));
                        item.DpImpDesc = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][13]));
                        item.DpImporteMoE = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][14]));
                        item.DpMonEx = Convert.ToString(ds.Tables[0].Rows[i][15]);
                        item.DpImporte = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][16]));
                        item.DpTratamiento = Convert.ToString(ds.Tables[0].Rows[i][17]);
                        item.DpEstatus = Convert.ToString(ds.Tables[0].Rows[i][18]);
                        item.DpAvance = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][19]));
                        item.DpReferencia = Convert.ToString(ds.Tables[0].Rows[i][20]);
                        item.DpFabricado = Convert.ToString(ds.Tables[0].Rows[i][21]);
                        item.DpFePedidoPg = ds.Tables[0].Rows[i][22].ToString() == "" ? item.DpFePedidoPg : Convert.ToDateTime(ds.Tables[0].Rows[i][22]);
                        item.DpFePedidoRe = ds.Tables[0].Rows[i][23].ToString() == "" ? item.DpFePedidoRe : Convert.ToDateTime(ds.Tables[0].Rows[i][23]);
                        item.DpFeReciboPg = ds.Tables[0].Rows[i][24].ToString() == "" ? item.DpFeReciboPg : Convert.ToDateTime(ds.Tables[0].Rows[i][24]);
                        item.DpFeReciboRe = ds.Tables[0].Rows[i][25].ToString() == "" ? item.DpFeReciboRe : Convert.ToDateTime(ds.Tables[0].Rows[i][25]);
                        item.DpFeEnvioPg = ds.Tables[0].Rows[i][26].ToString() == "" ? item.DpFeEnvioPg : Convert.ToDateTime(ds.Tables[0].Rows[i][26]);
                        item.DpFeEnvioRe = ds.Tables[0].Rows[i][27].ToString() == "" ? item.DpFeEnvioRe : Convert.ToDateTime(ds.Tables[0].Rows[i][27]);
                        item.DpFeEntregaPg = ds.Tables[0].Rows[i][28].ToString() == "" ? item.DpFeEntregaPg : Convert.ToDateTime(ds.Tables[0].Rows[i][28]);
                        item.DpFeEntregaRe = ds.Tables[0].Rows[i][29].ToString() == "" ? item.DpFeEntregaRe : Convert.ToDateTime(ds.Tables[0].Rows[i][29]);
                        item.DpFeCancel = ds.Tables[0].Rows[i][30].ToString() == "" ? item.DpFeCancel : Convert.ToDateTime(ds.Tables[0].Rows[i][30]);
                        item.ArCodigo = Convert.ToString(ds.Tables[0].Rows[i][31]);
                        item.ArPrecioPub = Convert.ToDouble(ds.Tables[0].Rows[i][32].ToString());
                        item.DpOrden = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][33]));
                        item.DpActivo = Convert.ToString(ds.Tables[0].Rows[i][34]);
                        item.DpAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][35]);
                        item.DpAudFeCre = ds.Tables[0].Rows[i][36].ToString() == "" ? item.DpAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][36]);
                        item.DpAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][37]);
                        item.DpAudFeMod = ds.Tables[0].Rows[i][38].ToString() == "" ? item.DpAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][38]);
                        item.DpAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][39]);
                        item.DpAudFeEl = ds.Tables[0].Rows[i][40].ToString() == "" ? item.DpAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][40]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public List<PARTIDASDOC> getPartidasDosc(PARTIDASDOC partidasDocs)
        {
            PARTIDASDOC item = new PARTIDASDOC();
            List<PARTIDASDOC> lista = new List<PARTIDASDOC>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getPartidasDocs";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiNomCorto", partidasDocs.DiNomCorto);
                    cmd.Parameters.AddWithValue("@PyNombre", partidasDocs.PyNombre);
                    cmd.Parameters.AddWithValue("@PyObjetivo", partidasDocs.PyObjetivo);
                    cmd.Parameters.AddWithValue("@PyTipoSis", partidasDocs.PyTipoSis);
                    cmd.Parameters.AddWithValue("@DoDescripcion", partidasDocs.DoDescripcion);
                    cmd.Parameters.AddWithValue("@DcDescripcion", partidasDocs.DcDescripcion);
                    cmd.Parameters.AddWithValue("@DpDescripcion", partidasDocs.DpDescripcion);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.DiNomCorto = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.PyNumero = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.PyNombre = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.PyObjetivo = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.PyTipoSis = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.DoDescripcion = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.CoNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][8]));
                        item.DcDescripcion = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.DpNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][10]));
                        item.DpDescripcion = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.ArIdent = Convert.ToString(ds.Tables[0].Rows[i][12]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setDocCPNota(DOCCPNOTA docCPNota)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setDocCPNota";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", docCPNota.DoIdent);
                    cmd.Parameters.AddWithValue("@CoNumero", docCPNota.CoNumero);
                    cmd.Parameters.AddWithValue("@DpNumero", docCPNota.DpNumero);
                    cmd.Parameters.AddWithValue("@DtNumero", docCPNota.DtNumero);
                    cmd.Parameters.AddWithValue("@DtDescripcion", docCPNota.DtDescripcion);
                    cmd.Parameters.AddWithValue("@DtTipo", docCPNota.DtTipo);
                    cmd.Parameters.AddWithValue("@DtOrden", docCPNota.DtOrden);
                    cmd.Parameters.AddWithValue("@NoIdent", docCPNota.NoIdent);
                    cmd.Parameters.AddWithValue("@DtArIdent", docCPNota.DtArIdent);
                    cmd.Parameters.AddWithValue("@DtAnNumero", docCPNota.DtAnNumero);
                    cmd.Parameters.AddWithValue("@DtActivo", docCPNota.DtActivo);
                    cmd.Parameters.AddWithValue("@DtAudUsuCre", docCPNota.DtAudUsuCre);
                    cmd.Parameters.AddWithValue("@DtAudFeCre", docCPNota.DtAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updDocCPNota(DOCCPNOTA docCPNota, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updDocCPNota";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoIdent", docCPNota.DoIdent);
                        cmd.Parameters.AddWithValue("@CoNumero", docCPNota.CoNumero);
                        cmd.Parameters.AddWithValue("@DpNumero", docCPNota.DpNumero);
                        cmd.Parameters.AddWithValue("@DtNumero", docCPNota.DtNumero);
                        cmd.Parameters.AddWithValue("@DtDescripcion", docCPNota.DtDescripcion);
                        cmd.Parameters.AddWithValue("@DtTipo", docCPNota.DtTipo);
                        cmd.Parameters.AddWithValue("@DtOrden", docCPNota.DtOrden);
                        cmd.Parameters.AddWithValue("@NoIdent", docCPNota.NoIdent);
                        cmd.Parameters.AddWithValue("@DtArIdent", docCPNota.DtArIdent);
                        cmd.Parameters.AddWithValue("@DtAnNumero", docCPNota.DtAnNumero);
                        cmd.Parameters.AddWithValue("@DtActivo", docCPNota.DtActivo);
                        cmd.Parameters.AddWithValue("@DtAudUsuMod", docCPNota.DtAudUsuMod);
                        cmd.Parameters.AddWithValue("@DtAudFeMod", docCPNota.DtAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delDocCPNota";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoIdent", docCPNota.DoIdent);
                        cmd.Parameters.AddWithValue("@CoNumero", docCPNota.CoNumero);
                        cmd.Parameters.AddWithValue("@DpNumero", docCPNota.DpNumero);
                        cmd.Parameters.AddWithValue("@DtNumero", docCPNota.DtNumero);
                        cmd.Parameters.AddWithValue("@DtActivo", docCPNota.DtActivo);
                        cmd.Parameters.AddWithValue("@DtAudUsuEl", docCPNota.DtAudUsuEl);
                        cmd.Parameters.AddWithValue("@DtAudFeEl", docCPNota.DtAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public DOCCPNOTA getDocCPNota(DOCCPNOTA docCPNota)
        {
            DOCCPNOTA item = new DOCCPNOTA();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getDocCPNota";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", docCPNota.DoIdent);
                    cmd.Parameters.AddWithValue("@CoNumero", docCPNota.CoNumero);
                    cmd.Parameters.AddWithValue("@DpNumero", docCPNota.DpNumero);
                    cmd.Parameters.AddWithValue("@DtNumero", docCPNota.DtNumero);
                    cmd.Parameters.AddWithValue("@DtTipo", docCPNota.DtTipo);
                    cmd.Parameters.AddWithValue("@NoIdent", docCPNota.NoIdent);
                    cmd.Parameters.AddWithValue("@DtArIdent", docCPNota.DtArIdent);
                    cmd.Parameters.AddWithValue("@DtAnNumero", docCPNota.DtAnNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CoNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.DpNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][2]));
                        item.DtNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][3]));
                        item.DtDescripcion = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.DtTipo = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.DtOrden = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][6]));
                        item.NoIdent = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.DtArIdent = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.DtAnNumero = Convert.ToInt16(ds.Tables[0].Rows[i][9]);
                        item.DtActivo = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.DtAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.DtAudFeCre = ds.Tables[0].Rows[i][12].ToString() == "" ? item.DtAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                        item.DtAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.DtAudFeMod = ds.Tables[0].Rows[i][14].ToString() == "" ? item.DtAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][14]);
                        item.DtAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][15]);
                        item.DtAudFeEl = ds.Tables[0].Rows[i][16].ToString() == "" ? item.DtAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][16]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<DOCCPNOTA> getDocCPNotas(DOCCPNOTA docCPNota)
        {
            DOCCPNOTA item = new DOCCPNOTA();
            List<DOCCPNOTA> lista = new List<DOCCPNOTA>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getDocCPNota";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", docCPNota.DoIdent);
                    cmd.Parameters.AddWithValue("@CoNumero", docCPNota.CoNumero);
                    cmd.Parameters.AddWithValue("@DpNumero", docCPNota.DpNumero);
                    cmd.Parameters.AddWithValue("@DtNumero", docCPNota.DtNumero);
                    cmd.Parameters.AddWithValue("@DtTipo", docCPNota.DtTipo);
                    cmd.Parameters.AddWithValue("@NoIdent", docCPNota.NoIdent);
                    cmd.Parameters.AddWithValue("@DtArIdent", docCPNota.DtArIdent);
                    cmd.Parameters.AddWithValue("@DtAnNumero", docCPNota.DtAnNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CoNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.DpNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][2]));
                        item.DtNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][3]));
                        item.DtDescripcion = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.DtTipo = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.DtOrden = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][6]));
                        item.NoIdent = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.DtArIdent = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.DtAnNumero = Convert.ToInt16(ds.Tables[0].Rows[i][9]);
                        item.DtActivo = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.DtAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.DtAudFeCre = ds.Tables[0].Rows[i][12].ToString() == "" ? item.DtAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                        item.DtAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.DtAudFeMod = ds.Tables[0].Rows[i][14].ToString() == "" ? item.DtAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][14]);
                        item.DtAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][15]);
                        item.DtAudFeEl = ds.Tables[0].Rows[i][16].ToString() == "" ? item.DtAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][16]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setDocSeguimiento(DOCSEGUIMIENTO docSeguimiento)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setDocSeguimiento";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", docSeguimiento.DoIdent);
                    cmd.Parameters.AddWithValue("@DsNumero", docSeguimiento.DsNumero);
                    cmd.Parameters.AddWithValue("@DsFechaSeg", docSeguimiento.DsFechaSeg);
                    cmd.Parameters.AddWithValue("@DsDescripcion", docSeguimiento.DsDescripcion);
                    cmd.Parameters.AddWithValue("@DsFechaReal", docSeguimiento.DsFechaReal);
                    cmd.Parameters.AddWithValue("@DsObservacion", docSeguimiento.DsObservacion);
                    cmd.Parameters.AddWithValue("@DsActivo", docSeguimiento.DsActivo);
                    cmd.Parameters.AddWithValue("@DsAudUsuCre", docSeguimiento.DsAudUsuCre);
                    cmd.Parameters.AddWithValue("@DsAudFeCre", docSeguimiento.DsAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updDocSeguimiento(DOCSEGUIMIENTO docSeguimiento, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updDocSeguimiento";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoIdent", docSeguimiento.DoIdent);
                        cmd.Parameters.AddWithValue("@DsNumero", docSeguimiento.DsNumero);
                        cmd.Parameters.AddWithValue("@DsFechaSeg", docSeguimiento.DsFechaSeg);
                        cmd.Parameters.AddWithValue("@DsDescripcion", docSeguimiento.DsDescripcion);
                        cmd.Parameters.AddWithValue("@DsFechaReal", docSeguimiento.DsFechaReal);
                        cmd.Parameters.AddWithValue("@DsObservacion", docSeguimiento.DsObservacion);
                        cmd.Parameters.AddWithValue("@DsActivo", docSeguimiento.DsActivo);
                        cmd.Parameters.AddWithValue("@DsAudUsuMod", docSeguimiento.DsAudUsuMod);
                        cmd.Parameters.AddWithValue("@DsAudFeMod", docSeguimiento.DsAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delDocSeguimiento";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoIdent", docSeguimiento.DoIdent);
                        cmd.Parameters.AddWithValue("@DsNumero", docSeguimiento.DsNumero);
                        cmd.Parameters.AddWithValue("@DsActivo", docSeguimiento.DsActivo);
                        cmd.Parameters.AddWithValue("@DsAudUsuEl", docSeguimiento.DsAudUsuEl);
                        cmd.Parameters.AddWithValue("@DsAudFeEl", docSeguimiento.DsAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public DOCSEGUIMIENTO getDocSeguimiento(DOCSEGUIMIENTO docSeguimiento)
        {
            DOCSEGUIMIENTO item = new DOCSEGUIMIENTO();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getDocSeguimiento";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", docSeguimiento.DoIdent);
                    cmd.Parameters.AddWithValue("@DsNumero", docSeguimiento.DsNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.DsNumero = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.DsFechaSeg = ds.Tables[0].Rows[i][2].ToString() == "" ? item.DsFechaSeg : Convert.ToDateTime(ds.Tables[0].Rows[i][2]);
                        item.DsDescripcion = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.DsFechaReal = ds.Tables[0].Rows[i][4].ToString() == "" ? item.DsFechaReal : Convert.ToDateTime(ds.Tables[0].Rows[i][4]);
                        item.DsObservacion = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.DsActivo = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.DsAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.DsAudFeCre = ds.Tables[0].Rows[i][8].ToString() == "" ? item.DsAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][8]);
                        item.DsAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.DsAudFeMod = ds.Tables[0].Rows[i][10].ToString() == "" ? item.DsAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][10]);
                        item.DsAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.DsAudFeEl = ds.Tables[0].Rows[i][12].ToString() == "" ? item.DsAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<DOCSEGUIMIENTO> getDocSeguimientos(DOCSEGUIMIENTO docSeguimiento)
        {
            DOCSEGUIMIENTO item = new DOCSEGUIMIENTO();
            List<DOCSEGUIMIENTO> lista = new List<DOCSEGUIMIENTO>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getDocCPartida";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", docSeguimiento.DoIdent);
                    cmd.Parameters.AddWithValue("@DsNumero", docSeguimiento.DsNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.DsNumero = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.DsFechaSeg = ds.Tables[0].Rows[i][2].ToString() == "" ? item.DsFechaSeg : Convert.ToDateTime(ds.Tables[0].Rows[i][2]);
                        item.DsDescripcion = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.DsFechaReal = ds.Tables[0].Rows[i][4].ToString() == "" ? item.DsFechaReal : Convert.ToDateTime(ds.Tables[0].Rows[i][4]);
                        item.DsObservacion = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.DsActivo = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.DsAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.DsAudFeCre = ds.Tables[0].Rows[i][8].ToString() == "" ? item.DsAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][8]);
                        item.DsAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.DsAudFeMod = ds.Tables[0].Rows[i][10].ToString() == "" ? item.DsAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][10]);
                        item.DsAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.DsAudFeEl = ds.Tables[0].Rows[i][12].ToString() == "" ? item.DsAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setPago(PAGO pago)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setPago";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PgNumero", pago.PgNumero);
                    cmd.Parameters.AddWithValue("@PgMontoPrg", pago.PgMontoPrg);
                    cmd.Parameters.AddWithValue("@PgMontoReal", pago.PgMontoReal);
                    cmd.Parameters.AddWithValue("@PgMoneda", pago.PgMoneda);
                    cmd.Parameters.AddWithValue("@PgFechaPrg", pago.PgFechaPrg);
                    cmd.Parameters.AddWithValue("@PgFechaReal", pago.PgFechaReal);
                    cmd.Parameters.AddWithValue("@PgObservacion", pago.PgObservacion);
                    cmd.Parameters.AddWithValue("@DoIdent", pago.DoIdent);
                    cmd.Parameters.AddWithValue("@DiNumeroCl", pago.DiNumeroCl);
                    cmd.Parameters.AddWithValue("@DiNumeroPv", pago.DiNumeroPv);
                    cmd.Parameters.AddWithValue("@PgTipo", pago.PgTipo);
                    cmd.Parameters.AddWithValue("@PgReferencia", pago.PgReferencia);
                    cmd.Parameters.AddWithValue("@PgActivo", pago.PgActivo);
                    cmd.Parameters.AddWithValue("@PgAudUsuCre", pago.PgAudUsuCre);
                    cmd.Parameters.AddWithValue("@PgAudFeCre", pago.PgAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updPago(PAGO pago, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updPago";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PgNumero", pago.PgNumero);
                        cmd.Parameters.AddWithValue("@PgMontoPrg", pago.PgMontoPrg);
                        cmd.Parameters.AddWithValue("@PgMontoReal", pago.PgMontoReal);
                        cmd.Parameters.AddWithValue("@PgMoneda", pago.PgMoneda);
                        cmd.Parameters.AddWithValue("@PgFechaPrg", pago.PgFechaPrg);
                        cmd.Parameters.AddWithValue("@PgFechaReal", pago.PgFechaReal);
                        cmd.Parameters.AddWithValue("@PgObservacion", pago.PgObservacion);
                        cmd.Parameters.AddWithValue("@DoIdent", pago.DoIdent);
                        cmd.Parameters.AddWithValue("@DiNumeroCl", pago.DiNumeroCl);
                        cmd.Parameters.AddWithValue("@DiNumeroPv", pago.DiNumeroPv);
                        cmd.Parameters.AddWithValue("@PgTipo", pago.PgTipo);
                        cmd.Parameters.AddWithValue("@PgReferencia", pago.PgReferencia);
                        cmd.Parameters.AddWithValue("@PgActivo", pago.PgActivo);
                        cmd.Parameters.AddWithValue("@PgAudUsuMod", pago.PgAudUsuMod);
                        cmd.Parameters.AddWithValue("@PgAudFeMod", pago.PgAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delPago";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PgNumero", pago.PgNumero);
                        cmd.Parameters.AddWithValue("@PgActivo", pago.PgActivo);
                        cmd.Parameters.AddWithValue("@PgAudUsuEl", pago.PgAudUsuEl);
                        cmd.Parameters.AddWithValue("@PgAudFeEl", pago.PgAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public PAGO getPago(PAGO pago)
        {
            PAGO item = new PAGO();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getPago";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PgNumero", pago.PgNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.PgNumero = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i][0]));
                        item.PgMontoPrg = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.PgMontoReal = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][2]));
                        item.PgMoneda = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.PgFechaPrg = ds.Tables[0].Rows[i][4].ToString() == "" ? item.PgFechaPrg : Convert.ToDateTime(ds.Tables[0].Rows[i][4]);
                        item.PgFechaReal = ds.Tables[0].Rows[i][5].ToString() == "" ? item.PgFechaReal : Convert.ToDateTime(ds.Tables[0].Rows[i][5]);
                        item.PgObservacion = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.DiNumeroCl = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.DiNumeroPv = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.PgTipo = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.PgReferencia = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.PgActivo = Convert.ToString(ds.Tables[0].Rows[i][12]);
                        item.PgAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.PgAudFeCre = ds.Tables[0].Rows[i][14].ToString() == "" ? item.PgAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][14]);
                        item.PgAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][15]);
                        item.PgAudFeMod = ds.Tables[0].Rows[i][16].ToString() == "" ? item.PgAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][16]);
                        item.PgAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][17]);
                        item.PgAudFeEl = ds.Tables[0].Rows[i][18].ToString() == "" ? item.PgAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][18]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<PAGO> getPagos(PAGO pago)
        {
            PAGO item = new PAGO();
            List<PAGO> lista = new List<PAGO>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getPago";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PgNumero", pago.PgNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.PgNumero = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i][0]));
                        item.PgMontoPrg = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.PgMontoReal = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][2]));
                        item.PgMoneda = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.PgFechaPrg = ds.Tables[0].Rows[i][4].ToString() == "" ? item.PgFechaPrg : Convert.ToDateTime(ds.Tables[0].Rows[i][4]);
                        item.PgFechaReal = ds.Tables[0].Rows[i][5].ToString() == "" ? item.PgFechaReal : Convert.ToDateTime(ds.Tables[0].Rows[i][5]);
                        item.PgObservacion = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.DiNumeroCl = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.DiNumeroPv = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.PgTipo = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.PgReferencia = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.PgActivo = Convert.ToString(ds.Tables[0].Rows[i][12]);
                        item.PgAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.PgAudFeCre = ds.Tables[0].Rows[i][14].ToString() == "" ? item.PgAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][14]);
                        item.PgAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][15]);
                        item.PgAudFeMod = ds.Tables[0].Rows[i][16].ToString() == "" ? item.PgAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][16]);
                        item.PgAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][17]);
                        item.PgAudFeEl = ds.Tables[0].Rows[i][18].ToString() == "" ? item.PgAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][18]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setPrecioLista(PRECIOLISTA precioLista)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setPrecioLista";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArIdent", precioLista.ArIdent);
                    cmd.Parameters.AddWithValue("@DiNumero", precioLista.DiNumero);
                    cmd.Parameters.AddWithValue("@PlPrecioLista", precioLista.PlPrecioLista);
                    cmd.Parameters.AddWithValue("@PlMoneda", precioLista.PlMoneda);
                    cmd.Parameters.AddWithValue("@PlCodPrv", precioLista.PlCodPrv);
                    cmd.Parameters.AddWithValue("@PlPlazo", precioLista.PlPlazo);
                    cmd.Parameters.AddWithValue("@PlReferencia", precioLista.PlReferencia);
                    cmd.Parameters.AddWithValue("@PlObservacion", precioLista.PlObservacion);
                    cmd.Parameters.AddWithValue("@PlActivo", precioLista.PlActivo);
                    cmd.Parameters.AddWithValue("@PlAudUsuCre", precioLista.PlAudUsuCre);
                    cmd.Parameters.AddWithValue("@PlAudFeCre", precioLista.PlAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updPrecioLista(PRECIOLISTA precioLista, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updPrecioLista";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ArIdent", precioLista.ArIdent);
                        cmd.Parameters.AddWithValue("@DiNumero", precioLista.DiNumero);
                        cmd.Parameters.AddWithValue("@PlPrecioLista", precioLista.PlPrecioLista);
                        cmd.Parameters.AddWithValue("@PlMoneda", precioLista.PlMoneda);
                        cmd.Parameters.AddWithValue("@PlCodPrv", precioLista.PlCodPrv);
                        cmd.Parameters.AddWithValue("@PlPlazo", precioLista.PlPlazo);
                        cmd.Parameters.AddWithValue("@PlReferencia", precioLista.PlReferencia);
                        cmd.Parameters.AddWithValue("@PlObservacion", precioLista.PlObservacion);
                        cmd.Parameters.AddWithValue("@PlActivo", precioLista.PlActivo);
                        cmd.Parameters.AddWithValue("@PlAudUsuMod", precioLista.PlAudUsuMod);
                        cmd.Parameters.AddWithValue("@PlAudFeMod", precioLista.PlAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delPrecioLista";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ArIdent", precioLista.ArIdent);
                        cmd.Parameters.AddWithValue("@DiNumero", precioLista.DiNumero);
                        cmd.Parameters.AddWithValue("@PlActivo", precioLista.PlActivo);
                        cmd.Parameters.AddWithValue("@PlAudUsuEl", precioLista.PlAudUsuEl);
                        cmd.Parameters.AddWithValue("@PlAudFeEl", precioLista.PlAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public PRECIOLISTA getPrecioLista(PRECIOLISTA precioLista)
        {
            PRECIOLISTA item = new PRECIOLISTA();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getPrecioLista";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArIdent", precioLista.ArIdent);
                    cmd.Parameters.AddWithValue("@DiNumero", precioLista.DiNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.ArIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.ArDescripcion = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.DiNomCorto = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.PlPrecioLista = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][4]));
                        item.PlMoneda = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.PlCodPrv = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.PlPlazo = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.PlReferencia = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.PlObservacion = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.PlActivo = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.PlAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.PlAudFeCre = ds.Tables[0].Rows[i][12].ToString() == "" ? item.PlAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                        item.PlAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.PlAudFeMod = ds.Tables[0].Rows[i][14].ToString() == "" ? item.PlAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][14]);
                        item.PlAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][15]);
                        item.PlAudFeEl = ds.Tables[0].Rows[i][16].ToString() == "" ? item.PlAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][16]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<PRECIOLISTA> getPreciosLista(PRECIOLISTA precioLista)
        {
            PRECIOLISTA item = new PRECIOLISTA();
            List<PRECIOLISTA> lista = new List<PRECIOLISTA>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getPrecioLista";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArIdent", precioLista.ArIdent);
                    cmd.Parameters.AddWithValue("@DiNumero", precioLista.DiNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.ArIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.ArDescripcion = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.DiNomCorto = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.PlPrecioLista = Convert.ToDouble(Convert.ToString(ds.Tables[0].Rows[i][4]));
                        item.PlMoneda = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.PlCodPrv = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.PlPlazo = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.PlReferencia = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.PlObservacion = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.PlActivo = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.PlAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.PlAudFeCre = ds.Tables[0].Rows[i][12].ToString() == "" ? item.PlAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                        item.PlAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.PlAudFeMod = ds.Tables[0].Rows[i][14].ToString() == "" ? item.PlAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][14]);
                        item.PlAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][15]);
                        item.PlAudFeEl = ds.Tables[0].Rows[i][16].ToString() == "" ? item.PlAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][16]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setPlantilla(PLANTILLA plantilla)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setPlantilla";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PaIdent", plantilla.PaIdent);
                    cmd.Parameters.AddWithValue("@PaDescripcion", plantilla.PaDescripcion);
                    cmd.Parameters.AddWithValue("@DoIdent", plantilla.DoIdent);
                    cmd.Parameters.AddWithValue("@PaActivo", plantilla.PaActivo);
                    cmd.Parameters.AddWithValue("@PaAudUsuCre", plantilla.PaAudUsuCre);
                    cmd.Parameters.AddWithValue("@PaAudFeCre", plantilla.PaAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updPlantilla(PLANTILLA plantilla, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updPlantilla";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PaIdent", plantilla.PaIdent);
                        cmd.Parameters.AddWithValue("@PaDescripcion", plantilla.PaDescripcion);
                        cmd.Parameters.AddWithValue("@DoIdent", plantilla.DoIdent);
                        cmd.Parameters.AddWithValue("@PaActivo", plantilla.PaActivo);
                        cmd.Parameters.AddWithValue("@PaAudUsuMod", plantilla.PaAudUsuMod);
                        cmd.Parameters.AddWithValue("@PaAudFeMod", plantilla.PaAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delPlantilla";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PaIdent", plantilla.PaIdent);
                        cmd.Parameters.AddWithValue("@PaActivo", plantilla.PaActivo);
                        cmd.Parameters.AddWithValue("@PaAudUsuEl", plantilla.PaAudUsuEl);
                        cmd.Parameters.AddWithValue("@PaAudFeEl", plantilla.PaAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public PLANTILLA getPlantilla(PLANTILLA plantilla)
        {
            PLANTILLA item = new PLANTILLA();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getPlantilla";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PaIdent", plantilla.PaIdent);
                    cmd.Parameters.AddWithValue("@PaDescripcion", plantilla.PaDescripcion);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.PaIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.PaDescripcion = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.PaActivo = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.PaAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.PaAudFeCre = ds.Tables[0].Rows[i][5].ToString() == "" ? item.PaAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][5]);
                        item.PaAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.PaAudFeMod = ds.Tables[0].Rows[i][7].ToString() == "" ? item.PaAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][7]);
                        item.PaAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.PaAudFeEl = ds.Tables[0].Rows[i][9].ToString() == "" ? item.PaAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][9]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<PLANTILLA> getPlantillas(PLANTILLA plantilla)
        {
            PLANTILLA item = new PLANTILLA();
            List<PLANTILLA> lista = new List<PLANTILLA>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getPlantilla";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PaIdent", plantilla.PaIdent);
                    cmd.Parameters.AddWithValue("@PaDescripcion", plantilla.PaDescripcion);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.PaIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.PaDescripcion = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.PaActivo = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.PaAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.PaAudFeCre = ds.Tables[0].Rows[i][5].ToString() == "" ? item.PaAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][5]);
                        item.PaAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.PaAudFeMod = ds.Tables[0].Rows[i][7].ToString() == "" ? item.PaAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][7]);
                        item.PaAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.PaAudFeEl = ds.Tables[0].Rows[i][9].ToString() == "" ? item.PaAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][9]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setCategoria(CATEGORIA categoria)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setCategoria";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaIdent", categoria.CaIdent);
                    cmd.Parameters.AddWithValue("@CaDescripcion", categoria.CaDescripcion);
                    cmd.Parameters.AddWithValue("@CaActivo", categoria.CaActivo);
                    cmd.Parameters.AddWithValue("@CaAudUsuCre", categoria.CaAudUsuCre);
                    cmd.Parameters.AddWithValue("@CaAudFeCre", categoria.CaAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updCategoria(CATEGORIA categoria, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updCategoria";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CaIdent", categoria.CaIdent);
                        cmd.Parameters.AddWithValue("@CaDescripcion", categoria.CaDescripcion);
                        cmd.Parameters.AddWithValue("@CaActivo", categoria.CaActivo);
                        cmd.Parameters.AddWithValue("@CaAudUsuMod", categoria.CaAudUsuMod);
                        cmd.Parameters.AddWithValue("@CaAudFeMod", categoria.CaAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delCategoria";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CaIdent", categoria.CaIdent);
                        cmd.Parameters.AddWithValue("@CaActivo", categoria.CaActivo);
                        cmd.Parameters.AddWithValue("@CaAudUsuEl", categoria.CaAudUsuEl);
                        cmd.Parameters.AddWithValue("@CaAudFeEl", categoria.CaAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public CATEGORIA getCategoria(CATEGORIA categoria)
        {
            CATEGORIA item = new CATEGORIA();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getCategoria";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaIdent", categoria.CaIdent);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.CaIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CaDescripcion = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.CaActivo = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.CaAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.CaAudFeCre = ds.Tables[0].Rows[i][4].ToString() == "" ? item.CaAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][4]);
                        item.CaAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.CaAudFeMod = ds.Tables[0].Rows[i][6].ToString() == "" ? item.CaAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][6]);
                        item.CaAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.CaAudFeEl = ds.Tables[0].Rows[i][8].ToString() == "" ? item.CaAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][8]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<CATEGORIA> getCategorias(CATEGORIA categoria)
        {
            CATEGORIA item = new CATEGORIA();
            List<CATEGORIA> lista = new List<CATEGORIA>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getCategoria";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaIdent", categoria.CaIdent);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.CaIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CaDescripcion = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.CaActivo = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.CaAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.CaAudFeCre = ds.Tables[0].Rows[i][4].ToString() == "" ? item.CaAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][4]);
                        item.CaAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.CaAudFeMod = ds.Tables[0].Rows[i][6].ToString() == "" ? item.CaAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][6]);
                        item.CaAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.CaAudFeEl = ds.Tables[0].Rows[i][8].ToString() == "" ? item.CaAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][8]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setCategoriaPrv(CATEGORIAPRV categoriaprv)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setCategoriaPrv";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaIdent", categoriaprv.CaIdent);
                    cmd.Parameters.AddWithValue("@DiNumero", categoriaprv.DiNumero);
                    cmd.Parameters.AddWithValue("@CpActivo", categoriaprv.CpActivo);
                    cmd.Parameters.AddWithValue("@CpAudUsuCre", categoriaprv.CpAudUsuCre);
                    cmd.Parameters.AddWithValue("@CpAudFeCre", categoriaprv.CpAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updCategoriaPrv(CATEGORIAPRV categoriaprv, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updCategoriaPrv";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CaIdent", categoriaprv.CaIdent);
                        cmd.Parameters.AddWithValue("@DiNumero", categoriaprv.DiNumero);
                        cmd.Parameters.AddWithValue("@CpActivo", categoriaprv.CpActivo);
                        cmd.Parameters.AddWithValue("@CpAudUsuMod", categoriaprv.CpAudUsuMod);
                        cmd.Parameters.AddWithValue("@CpAudFeMod", categoriaprv.CpAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delCategoriaPrv";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CaIdent", categoriaprv.CaIdent);
                        cmd.Parameters.AddWithValue("@DiNumero", categoriaprv.DiNumero);
                        cmd.Parameters.AddWithValue("@CpActivo", categoriaprv.CpActivo);
                        cmd.Parameters.AddWithValue("@CpAudUsuEl", categoriaprv.CpAudUsuEl);
                        cmd.Parameters.AddWithValue("@CpAudFeEl", categoriaprv.CpAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public CATEGORIAPRV getCategoriaPrv(CATEGORIAPRV categoriaprv)
        {
            CATEGORIAPRV item = new CATEGORIAPRV();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getCategoriaPrv";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaIdent", categoriaprv.CaIdent);
                    cmd.Parameters.AddWithValue("@DiNumero", categoriaprv.DiNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.CaIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.DiNombreCom = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.CaDescripcion = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.CpActivo = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.CpAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.CpAudFeCre = ds.Tables[0].Rows[i][6].ToString() == "" ? item.CpAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][6]);
                        item.CpAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.CpAudFeMod = ds.Tables[0].Rows[i][8].ToString() == "" ? item.CpAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][8]);
                        item.CpAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.CpAudFeEl = ds.Tables[0].Rows[i][10].ToString() == "" ? item.CpAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][10]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<CATEGORIAPRV> getCategoriasPrv(CATEGORIAPRV categoriaprv)
        {
            CATEGORIAPRV item = new CATEGORIAPRV();
            List<CATEGORIAPRV> lista = new List<CATEGORIAPRV>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getCategoriaPrv";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaIdent", categoriaprv.CaIdent);
                    cmd.Parameters.AddWithValue("@DiNumero", categoriaprv.DiNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.CaIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.DiNumero = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.DiNombreCom = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.CaDescripcion = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.CpActivo = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.CpAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.CpAudFeCre = ds.Tables[0].Rows[i][6].ToString() == "" ? item.CpAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][6]);
                        item.CpAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.CpAudFeMod = ds.Tables[0].Rows[i][8].ToString() == "" ? item.CpAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][8]);
                        item.CpAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.CpAudFeEl = ds.Tables[0].Rows[i][10].ToString() == "" ? item.CpAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][10]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setCodigo(CODIGO codigo)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setCodigo";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CdCategoria", codigo.CdCategoria);
                    cmd.Parameters.AddWithValue("@CdGrupo", codigo.CdGrupo);
                    cmd.Parameters.AddWithValue("@CdTipo", codigo.CdTipo);
                    cmd.Parameters.AddWithValue("@CdDescripcion", codigo.CdDescripcion);
                    cmd.Parameters.AddWithValue("@CdOrden", codigo.CdOrden);
                    cmd.Parameters.AddWithValue("@CdActivo", codigo.CdActivo);
                    cmd.Parameters.AddWithValue("@CdAudUsuCre", codigo.CdAudUsuCre);
                    cmd.Parameters.AddWithValue("@CdAudFeCre", codigo.CdAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updCodigo(CODIGO codigo, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updCodigo";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CdCategoria", codigo.CdCategoria);
                        cmd.Parameters.AddWithValue("@CdGrupo", codigo.CdGrupo);
                        cmd.Parameters.AddWithValue("@CdTipo", codigo.CdTipo);
                        cmd.Parameters.AddWithValue("@CdDescripcion", codigo.CdDescripcion);
                        cmd.Parameters.AddWithValue("@CdOrden", codigo.CdOrden);
                        cmd.Parameters.AddWithValue("@CdActivo", codigo.CdActivo);
                        cmd.Parameters.AddWithValue("@CdAudUsuMod", codigo.CdAudUsuMod);
                        cmd.Parameters.AddWithValue("@CdAudFeMod", codigo.CdAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delCodigo";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CdCategoria", codigo.CdCategoria);
                        cmd.Parameters.AddWithValue("@CdGrupo", codigo.CdGrupo);
                        cmd.Parameters.AddWithValue("@CdTipo", codigo.CdTipo);
                        cmd.Parameters.AddWithValue("@CdActivo", codigo.CdActivo);
                        cmd.Parameters.AddWithValue("@CdAudUsuEl", codigo.CdAudUsuEl);
                        cmd.Parameters.AddWithValue("@CdAudFeEl", codigo.CdAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public CODIGO getCodigo(CODIGO codigo)
        {
            CODIGO item = new CODIGO();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getCodigo";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CdCategoria", codigo.CdCategoria);
                    cmd.Parameters.AddWithValue("@CdGrupo", codigo.CdGrupo);
                    cmd.Parameters.AddWithValue("@CdTipo", codigo.CdTipo);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.CdCategoria = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CdGrupo = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.CdTipo = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.CdDescripcion = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.CdOrden = Convert.ToInt16(ds.Tables[0].Rows[i][4]);
                        item.CdActivo = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.CdAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.CdAudFeCre = ds.Tables[0].Rows[i][7].ToString() == "" ? item.CdAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][7]);
                        item.CdAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.CdAudFeMod = ds.Tables[0].Rows[i][9].ToString() == "" ? item.CdAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][9]);
                        item.CdAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.CdAudFeEl = ds.Tables[0].Rows[i][11].ToString() == "" ? item.CdAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][11]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<CODIGO> getCodigos(CODIGO codigo)
        {
            CODIGO item = new CODIGO();
            List<CODIGO> lista = new List<CODIGO>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getCodigo";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CdCategoria", codigo.CdCategoria);
                    cmd.Parameters.AddWithValue("@CdGrupo", codigo.CdGrupo);
                    cmd.Parameters.AddWithValue("@CdTipo", codigo.CdTipo);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.CdCategoria = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CdGrupo = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.CdTipo = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.CdDescripcion = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.CdOrden = Convert.ToInt16(ds.Tables[0].Rows[i][4]);
                        item.CdActivo = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.CdAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.CdAudFeCre = ds.Tables[0].Rows[i][7].ToString() == "" ? item.CdAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][7]);
                        item.CdAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.CdAudFeMod = ds.Tables[0].Rows[i][9].ToString() == "" ? item.CdAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][9]);
                        item.CdAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.CdAudFeEl = ds.Tables[0].Rows[i][11].ToString() == "" ? item.CdAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][11]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setCalVenta(CALVENTA calventa)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setCalVenta";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", calventa.DoIdent);
                    cmd.Parameters.AddWithValue("@CvPresupuesto", calventa.CvPresupuesto);
                    cmd.Parameters.AddWithValue("@CvAutoridad", calventa.CvAutoridad);
                    cmd.Parameters.AddWithValue("@CvNecesidad", calventa.CvNecesidad);
                    cmd.Parameters.AddWithValue("@CvTiempo", calventa.CvTiempo);
                    cmd.Parameters.AddWithValue("@CvCalificacion", calventa.CvCalificacion);
                    cmd.Parameters.AddWithValue("@CvOportunidad", calventa.CvOportunidad);
                    cmd.Parameters.AddWithValue("@CvActivo", calventa.CvActivo);
                    cmd.Parameters.AddWithValue("@CvAudUsuCre", calventa.CvAudUsuCre);
                    cmd.Parameters.AddWithValue("@CvAudFeCre", calventa.CvAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updCalVenta(CALVENTA calventa, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updCalVenta";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoIdent", calventa.DoIdent);
                        cmd.Parameters.AddWithValue("@CvPresupuesto", calventa.CvPresupuesto);
                        cmd.Parameters.AddWithValue("@CvAutoridad", calventa.CvAutoridad);
                        cmd.Parameters.AddWithValue("@CvNecesidad", calventa.CvNecesidad);
                        cmd.Parameters.AddWithValue("@CvTiempo", calventa.CvTiempo);
                        cmd.Parameters.AddWithValue("@CvCalificacion", calventa.CvCalificacion);
                        cmd.Parameters.AddWithValue("@CvOportunidad", calventa.CvOportunidad);
                        cmd.Parameters.AddWithValue("@CvActivo", calventa.CvActivo);
                        cmd.Parameters.AddWithValue("@CvAudUsuMod", calventa.CvAudUsuMod);
                        cmd.Parameters.AddWithValue("@CvAudFeMod", calventa.CvAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delCalVenta";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoIdent", calventa.DoIdent);
                        cmd.Parameters.AddWithValue("@CvActivo", calventa.CvActivo);
                        cmd.Parameters.AddWithValue("@CvAudUsuEl", calventa.CvAudUsuEl);
                        cmd.Parameters.AddWithValue("@CvAudFeEl", calventa.CvAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public CALVENTA getCalVenta(CALVENTA calventa)
        {
            CALVENTA item = new CALVENTA();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getCalVenta";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", calventa.DoIdent);
                    cmd.Parameters.AddWithValue("@CvOportunidad", calventa.CvOportunidad);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CvPresupuesto = Convert.ToInt16(ds.Tables[0].Rows[i][1]);
                        item.CvAutoridad = Convert.ToInt16(ds.Tables[0].Rows[i][2]);
                        item.CvNecesidad = Convert.ToInt16(ds.Tables[0].Rows[i][3]);
                        item.CvTiempo = Convert.ToInt16(ds.Tables[0].Rows[i][4]);
                        item.CvCalificacion = Convert.ToInt16(ds.Tables[0].Rows[i][5]);
                        item.CvOportunidad = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.CvActivo = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.CvAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.CvAudFeCre = ds.Tables[0].Rows[i][9].ToString() == "" ? item.CvAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][9]);
                        item.CvAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.CvAudFeMod = ds.Tables[0].Rows[i][11].ToString() == "" ? item.CvAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][11]);
                        item.CvAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][12]);
                        item.CvAudFeEl = ds.Tables[0].Rows[i][13].ToString() == "" ? item.CvAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][13]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<CALVENTA> getCalVentas(CALVENTA calventa)
        {
            CALVENTA item = new CALVENTA();
            List<CALVENTA> lista = new List<CALVENTA>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getCalVenta";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoIdent", calventa.DoIdent);
                    cmd.Parameters.AddWithValue("@CvOportunidad", calventa.CvOportunidad);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.DoIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CvPresupuesto = Convert.ToInt16(ds.Tables[0].Rows[i][1]);
                        item.CvAutoridad = Convert.ToInt16(ds.Tables[0].Rows[i][2]);
                        item.CvNecesidad = Convert.ToInt16(ds.Tables[0].Rows[i][3]);
                        item.CvTiempo = Convert.ToInt16(ds.Tables[0].Rows[i][4]);
                        item.CvCalificacion = Convert.ToInt16(ds.Tables[0].Rows[i][5]);
                        item.CvOportunidad = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.CvActivo = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.CvAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.CvAudFeCre = ds.Tables[0].Rows[i][9].ToString() == "" ? item.CvAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][9]);
                        item.CvAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][10]);
                        item.CvAudFeMod = ds.Tables[0].Rows[i][11].ToString() == "" ? item.CvAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][11]);
                        item.CvAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][12]);
                        item.CvAudFeEl = ds.Tables[0].Rows[i][13].ToString() == "" ? item.CvAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][13]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setGrCarp(GRCARP grcarp)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setGrCarp";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GcIdent", grcarp.GcIdent);
                    cmd.Parameters.AddWithValue("@GcDescripcion", grcarp.GcDescripcion);
                    cmd.Parameters.AddWithValue("@GcPath", grcarp.GcPath);
                    cmd.Parameters.AddWithValue("@GcActivo", grcarp.GcActivo);
                    cmd.Parameters.AddWithValue("@GcAudUsuCre", grcarp.GcAudUsuCre);
                    cmd.Parameters.AddWithValue("@GcAudFeCre", grcarp.GcAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updGrCarp(GRCARP grcarp, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updGrCarp";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@GcIdent", grcarp.GcIdent);
                        cmd.Parameters.AddWithValue("@GcDescripcion", grcarp.GcDescripcion);
                        cmd.Parameters.AddWithValue("@GcPath", grcarp.GcPath);
                        cmd.Parameters.AddWithValue("@GcActivo", grcarp.GcActivo);
                        cmd.Parameters.AddWithValue("@GcAudUsuMod", grcarp.GcAudUsuMod);
                        cmd.Parameters.AddWithValue("@GcAudFeMod", grcarp.GcAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delGrCarp";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@GcIdent", grcarp.GcIdent);
                        cmd.Parameters.AddWithValue("@GcActivo", grcarp.GcActivo);
                        cmd.Parameters.AddWithValue("@GcAudUsuEl", grcarp.GcAudUsuEl);
                        cmd.Parameters.AddWithValue("@GcAudFeEl", grcarp.GcAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public GRCARP getGrCarp(GRCARP grcarp)
        {
            GRCARP item = new GRCARP();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getGrCarp";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GcIdent", grcarp.GcIdent);
                    cmd.Parameters.AddWithValue("@GcDescripcion", grcarp.GcDescripcion);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.GcIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.GcDescripcion = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.GcPath = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.GcActivo = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.GcAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.GcAudFeCre = ds.Tables[0].Rows[i][5].ToString() == "" ? item.GcAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][5]);
                        item.GcAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.GcAudFeMod = ds.Tables[0].Rows[i][7].ToString() == "" ? item.GcAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][7]);
                        item.GcAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.GcAudFeEl = ds.Tables[0].Rows[i][9].ToString() == "" ? item.GcAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][9]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<GRCARP> getGrCarps(GRCARP grcarp)
        {
            GRCARP item = new GRCARP();
            List<GRCARP> lista = new List<GRCARP>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getGrCarp";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GcIdent", grcarp.GcIdent);
                    cmd.Parameters.AddWithValue("@GcDescripcion", grcarp.GcDescripcion);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.GcIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.GcDescripcion = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.GcPath = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.GcActivo = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.GcAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.GcAudFeCre = ds.Tables[0].Rows[i][5].ToString() == "" ? item.GcAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][5]);
                        item.GcAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.GcAudFeMod = ds.Tables[0].Rows[i][7].ToString() == "" ? item.GcAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][7]);
                        item.GcAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.GcAudFeEl = ds.Tables[0].Rows[i][9].ToString() == "" ? item.GcAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][9]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setCarpeta(CARPETA carpeta)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setCarpeta";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GcIdent", carpeta.GcIdent);
                    cmd.Parameters.AddWithValue("@CrIdent", carpeta.CrIdent);
                    cmd.Parameters.AddWithValue("@CrNombre", carpeta.CrNombre);
                    cmd.Parameters.AddWithValue("@CrActivo", carpeta.CrActivo);
                    cmd.Parameters.AddWithValue("@CrAudUsuCre", carpeta.CrAudUsuCre);
                    cmd.Parameters.AddWithValue("@CrAudFeCre", carpeta.CrAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updCarpeta(CARPETA carpeta, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updCarpeta";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@GcIdent", carpeta.GcIdent);
                        cmd.Parameters.AddWithValue("@CrIdent", carpeta.CrIdent);
                        cmd.Parameters.AddWithValue("@CrNombre", carpeta.CrNombre);
                        cmd.Parameters.AddWithValue("@CrActivo", carpeta.CrActivo);
                        cmd.Parameters.AddWithValue("@CrAudUsuMod", carpeta.CrAudUsuMod);
                        cmd.Parameters.AddWithValue("@CrAudFeMod", carpeta.CrAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delCarpeta";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@GcIdent", carpeta.GcIdent);
                        cmd.Parameters.AddWithValue("@CrIdent", carpeta.CrIdent);
                        cmd.Parameters.AddWithValue("@CrActivo", carpeta.CrActivo);
                        cmd.Parameters.AddWithValue("@CrAudUsuEl", carpeta.CrAudUsuEl);
                        cmd.Parameters.AddWithValue("@CrAudFeEl", carpeta.CrAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public CARPETA getCarpeta(CARPETA carpeta)
        {
            CARPETA item = new CARPETA();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getCarpeta";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GcIdent", carpeta.GcIdent);
                    cmd.Parameters.AddWithValue("@CrIdent", carpeta.CrIdent);
                    cmd.Parameters.AddWithValue("@CrNombre", carpeta.CrNombre);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.GcIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CrIdent = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.CrNombre = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.CrActivo = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.CrAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.CrAudFeCre = ds.Tables[0].Rows[i][5].ToString() == "" ? item.CrAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][5]);
                        item.CrAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.CrAudFeMod = ds.Tables[0].Rows[i][7].ToString() == "" ? item.CrAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][7]);
                        item.CrAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.CrAudFeEl = ds.Tables[0].Rows[i][9].ToString() == "" ? item.CrAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][9]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<CARPETA> getCarpetas(CARPETA carpeta)
        {
            CARPETA item = new CARPETA();
            List<CARPETA> lista = new List<CARPETA>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getCarpeta";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GcIdent", carpeta.GcIdent);
                    cmd.Parameters.AddWithValue("@CrIdent", carpeta.CrIdent);
                    cmd.Parameters.AddWithValue("@CrNombre", carpeta.CrNombre);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.GcIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CrIdent = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.CrNombre = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.CrActivo = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.CrAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.CrAudFeCre = ds.Tables[0].Rows[i][5].ToString() == "" ? item.CrAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][5]);
                        item.CrAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.CrAudFeMod = ds.Tables[0].Rows[i][7].ToString() == "" ? item.CrAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][7]);
                        item.CrAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.CrAudFeEl = ds.Tables[0].Rows[i][9].ToString() == "" ? item.CrAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][9]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setPryCarp(PRYCARP prycarp)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setPryCarp";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PyNumero", prycarp.PyNumero);
                    cmd.Parameters.AddWithValue("@GcIdent", prycarp.GcIdent);
                    cmd.Parameters.AddWithValue("@CrIdent", prycarp.CrIdent);
                    cmd.Parameters.AddWithValue("@PcActivo", prycarp.PcActivo);
                    cmd.Parameters.AddWithValue("@PcAudUsuCre", prycarp.PcAudUsuCre);
                    cmd.Parameters.AddWithValue("@PcAudFeCre", prycarp.PcAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updPryCarp(PRYCARP prycarp, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updPryCarp";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PyNumero", prycarp.PyNumero);
                        cmd.Parameters.AddWithValue("@GcIdent", prycarp.GcIdent);
                        cmd.Parameters.AddWithValue("@CrIdent", prycarp.CrIdent);
                        cmd.Parameters.AddWithValue("@PcActivo", prycarp.PcActivo);
                        cmd.Parameters.AddWithValue("@PcAudUsuMod", prycarp.PcAudUsuMod);
                        cmd.Parameters.AddWithValue("@PcAudFeMod", prycarp.PcAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delPryCarp";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PyNumero", prycarp.PyNumero);
                        cmd.Parameters.AddWithValue("@GcIdent", prycarp.GcIdent);
                        cmd.Parameters.AddWithValue("@CrIdent", prycarp.CrIdent);
                        cmd.Parameters.AddWithValue("@PcActivo", prycarp.PcActivo);
                        cmd.Parameters.AddWithValue("@PcAudUsuEl", prycarp.PcAudUsuEl);
                        cmd.Parameters.AddWithValue("@PcAudFeEl", prycarp.PcAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public PRYCARP getPryCarp(PRYCARP prycarp)
        {
            PRYCARP item = new PRYCARP();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getPryCarp";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PyNumero", prycarp.PyNumero);
                    cmd.Parameters.AddWithValue("@GcIdent", prycarp.GcIdent);
                    cmd.Parameters.AddWithValue("@CrIdent", prycarp.CrIdent);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.PyNumero = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.GcIdent = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.CrIdent = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.PcActivo = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.PcAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.PcAudFeCre = ds.Tables[0].Rows[i][5].ToString() == "" ? item.PcAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][5]);
                        item.PcAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.PcAudFeMod = ds.Tables[0].Rows[i][7].ToString() == "" ? item.PcAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][7]);
                        item.PcAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.PcAudFeEl = ds.Tables[0].Rows[i][9].ToString() == "" ? item.PcAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][9]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<PRYCARP> getPryCarps(PRYCARP prycarp)
        {
            PRYCARP item = new PRYCARP();
            List<PRYCARP> lista = new List<PRYCARP>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getPryCarp";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PyNumero", prycarp.PyNumero);
                    cmd.Parameters.AddWithValue("@GcIdent", prycarp.GcIdent);
                    cmd.Parameters.AddWithValue("@CrIdent", prycarp.CrIdent);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.PyNumero = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.GcIdent = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        item.CrIdent = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.PcActivo = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.PcAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][4]);
                        item.PcAudFeCre = ds.Tables[0].Rows[i][5].ToString() == "" ? item.PcAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][5]);
                        item.PcAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.PcAudFeMod = ds.Tables[0].Rows[i][7].ToString() == "" ? item.PcAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][7]);
                        item.PcAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.PcAudFeEl = ds.Tables[0].Rows[i][9].ToString() == "" ? item.PcAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][9]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setArtNota(ARTNOTA artNota)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setArtNota";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArIdent", artNota.ArIdent);
                    cmd.Parameters.AddWithValue("@AnNumero", artNota.AnNumero);
                    cmd.Parameters.AddWithValue("@AnDescripcion", artNota.AnDescripcion);
                    cmd.Parameters.AddWithValue("@AnTipo", artNota.AnTipo);
                    cmd.Parameters.AddWithValue("@AnOrden", artNota.AnOrden);
                    cmd.Parameters.AddWithValue("@NoIdent", artNota.NoIdent);
                    cmd.Parameters.AddWithValue("@AnCaIdent", artNota.AnCaIdent);
                    cmd.Parameters.AddWithValue("@AnCtNumero", artNota.AnCtNumero);
                    cmd.Parameters.AddWithValue("@AnActivo", artNota.AnActivo);
                    cmd.Parameters.AddWithValue("@AnAudUsuCre", artNota.AnAudUsuCre);
                    cmd.Parameters.AddWithValue("@AnAudFeCre", artNota.AnAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updArtNota(ARTNOTA artNota, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updArtNota";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ArIdent", artNota.ArIdent);
                        cmd.Parameters.AddWithValue("@AnNumero", artNota.AnNumero);
                        cmd.Parameters.AddWithValue("@AnDescripcion", artNota.AnDescripcion);
                        cmd.Parameters.AddWithValue("@AnTipo", artNota.AnTipo);
                        cmd.Parameters.AddWithValue("@AnOrden", artNota.AnOrden);
                        cmd.Parameters.AddWithValue("@NoIdent", artNota.NoIdent);
                        cmd.Parameters.AddWithValue("@AnCaIdent", artNota.AnCaIdent);
                        cmd.Parameters.AddWithValue("@AnCtNumero", artNota.AnCtNumero);
                        cmd.Parameters.AddWithValue("@AnActivo", artNota.AnActivo);
                        cmd.Parameters.AddWithValue("@AnAudUsuMod", artNota.AnAudUsuMod);
                        cmd.Parameters.AddWithValue("@AnAudFeMod", artNota.AnAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delArtNota";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ArIdent", artNota.ArIdent);
                        cmd.Parameters.AddWithValue("@AnNumero", artNota.AnNumero);
                        cmd.Parameters.AddWithValue("@AnActivo", artNota.AnActivo);
                        cmd.Parameters.AddWithValue("@AnAudUsuEl", artNota.AnAudUsuEl);
                        cmd.Parameters.AddWithValue("@AnAudFeEl", artNota.AnAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public ARTNOTA getArtNota(ARTNOTA artNota)
        {
            ARTNOTA item = new ARTNOTA();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getArtNota";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArIdent", artNota.ArIdent);
                    cmd.Parameters.AddWithValue("@AnNumero", artNota.AnNumero);
                    cmd.Parameters.AddWithValue("@AnTipo", artNota.AnTipo);
                    cmd.Parameters.AddWithValue("@NoIdent", artNota.NoIdent);
                    cmd.Parameters.AddWithValue("@AnCaIdent", artNota.AnCaIdent);
                    cmd.Parameters.AddWithValue("@AnCtNumero", artNota.AnCtNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.ArIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.AnNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.AnDescripcion = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.AnTipo = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.AnOrden = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][4]));
                        item.NoIdent = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.AnCaIdent = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.AnCtNumero = Convert.ToInt16(ds.Tables[0].Rows[i][7]);
                        item.AnActivo = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.AnAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.AnAudFeCre = ds.Tables[0].Rows[i][10].ToString() == "" ? item.AnAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][10]);
                        item.AnAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.AnAudFeMod = ds.Tables[0].Rows[i][12].ToString() == "" ? item.AnAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                        item.AnAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.AnAudFeEl = ds.Tables[0].Rows[i][14].ToString() == "" ? item.AnAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][14]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<ARTNOTA> getArtNotas(ARTNOTA artNota)
        {
            ARTNOTA item = new ARTNOTA();
            List<ARTNOTA> lista = new List<ARTNOTA>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getArtNota";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArIdent", artNota.ArIdent);
                    cmd.Parameters.AddWithValue("@AnNumero", artNota.AnNumero);
                    cmd.Parameters.AddWithValue("@AnTipo", artNota.AnTipo);
                    cmd.Parameters.AddWithValue("@NoIdent", artNota.NoIdent);
                    cmd.Parameters.AddWithValue("@AnCaIdent", artNota.AnCaIdent);
                    cmd.Parameters.AddWithValue("@AnCtNumero", artNota.AnCtNumero);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.ArIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.AnNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.AnDescripcion = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.AnTipo = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.AnOrden = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][4]));
                        item.NoIdent = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.AnCaIdent = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.AnCtNumero = Convert.ToInt16(ds.Tables[0].Rows[i][7]);
                        item.AnActivo = Convert.ToString(ds.Tables[0].Rows[i][8]);
                        item.AnAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.AnAudFeCre = ds.Tables[0].Rows[i][10].ToString() == "" ? item.AnAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][10]);
                        item.AnAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.AnAudFeMod = ds.Tables[0].Rows[i][12].ToString() == "" ? item.AnAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                        item.AnAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][13]);
                        item.AnAudFeEl = ds.Tables[0].Rows[i][14].ToString() == "" ? item.AnAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][14]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public void setCatNota(CATNOTA catNota)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_setCatNota";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaIdent", catNota.CaIdent);
                    cmd.Parameters.AddWithValue("@CtNumero", catNota.CtNumero);
                    cmd.Parameters.AddWithValue("@CtDescripcion", catNota.CtDescripcion);
                    cmd.Parameters.AddWithValue("@CtTipo", catNota.CtTipo);
                    cmd.Parameters.AddWithValue("@CtOrden", catNota.CtOrden);
                    cmd.Parameters.AddWithValue("@NoIdent", catNota.NoIdent);
                    cmd.Parameters.AddWithValue("@CtActivo", catNota.CtActivo);
                    cmd.Parameters.AddWithValue("@CtAudUsuCre", catNota.CtAudUsuCre);
                    cmd.Parameters.AddWithValue("@CtAudFeCre", catNota.CtAudFeCre);
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public void updCatNota(CATNOTA catNota, modo m)
        {
            int filas = 0;
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    SqlCommand cmd;
                    if (modo.update == m)
                    {
                        string comandoSQL = "sp_updCatNota";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CaIdent", catNota.CaIdent);
                        cmd.Parameters.AddWithValue("@CtNumero", catNota.CtNumero);
                        cmd.Parameters.AddWithValue("@CtDescripcion", catNota.CtDescripcion);
                        cmd.Parameters.AddWithValue("@CtTipo", catNota.CtTipo);
                        cmd.Parameters.AddWithValue("@CtOrden", catNota.CtOrden);
                        cmd.Parameters.AddWithValue("@NoIdent", catNota.NoIdent);
                        cmd.Parameters.AddWithValue("@CtActivo", catNota.CtActivo);
                        cmd.Parameters.AddWithValue("@CtAudUsuMod", catNota.CtAudUsuMod);
                        cmd.Parameters.AddWithValue("@CtAudFeMod", catNota.CtAudFeMod);
                    }
                    else
                    {
                        string comandoSQL = "sp_delCatNota";
                        cmd = new SqlCommand(comandoSQL, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CaIdent", catNota.CaIdent);
                        cmd.Parameters.AddWithValue("@CtNumero", catNota.CtNumero);
                        cmd.Parameters.AddWithValue("@CtActivo", catNota.CtActivo);
                        cmd.Parameters.AddWithValue("@CtAudUsuEl", catNota.CtAudUsuEl);
                        cmd.Parameters.AddWithValue("@CtAudFeEl", catNota.CtAudFeEl);
                    }
                    con.Open();
                    filas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public CATNOTA getCatNota(CATNOTA catNota)
        {
            CATNOTA item = new CATNOTA();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getCatNota";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaIdent", catNota.CaIdent);
                    cmd.Parameters.AddWithValue("@CtNumero", catNota.CtNumero);
                    cmd.Parameters.AddWithValue("@CtTipo", catNota.CtTipo);
                    cmd.Parameters.AddWithValue("@NoIdent", catNota.NoIdent);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = 0;
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        item.CaIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CtNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.CtDescripcion = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.CtTipo = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.CtOrden = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][4]));
                        item.NoIdent = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.CtActivo = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.CtAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.CtAudFeCre = ds.Tables[0].Rows[i][8].ToString() == "" ? item.CtAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][8]);
                        item.CtAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.CtAudFeMod = ds.Tables[0].Rows[i][10].ToString() == "" ? item.CtAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][10]);
                        item.CtAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.CtAudFeEl = ds.Tables[0].Rows[i][12].ToString() == "" ? item.CtAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return item;
        }

        public List<CATNOTA> getCatNotas(CATNOTA catNota)
        {
            CATNOTA item = new CATNOTA();
            List<CATNOTA> lista = new List<CATNOTA>();
            error = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                using (con)
                {
                    string comandoSQL = "sp_getCatNota";
                    SqlCommand cmd = new SqlCommand(comandoSQL, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaIdent", catNota.CaIdent);
                    cmd.Parameters.AddWithValue("@CtNumero", catNota.CtNumero);
                    cmd.Parameters.AddWithValue("@CtTipo", catNota.CtTipo);
                    cmd.Parameters.AddWithValue("@NoIdent", catNota.NoIdent);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        item.CaIdent = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        item.CtNumero = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][1]));
                        item.CtDescripcion = Convert.ToString(ds.Tables[0].Rows[i][2]);
                        item.CtTipo = Convert.ToString(ds.Tables[0].Rows[i][3]);
                        item.CtOrden = Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[i][4]));
                        item.NoIdent = Convert.ToString(ds.Tables[0].Rows[i][5]);
                        item.CtActivo = Convert.ToString(ds.Tables[0].Rows[i][6]);
                        item.CtAudUsuCre = Convert.ToString(ds.Tables[0].Rows[i][7]);
                        item.CtAudFeCre = ds.Tables[0].Rows[i][8].ToString() == "" ? item.CtAudFeCre : Convert.ToDateTime(ds.Tables[0].Rows[i][8]);
                        item.CtAudUsuMod = Convert.ToString(ds.Tables[0].Rows[i][9]);
                        item.CtAudFeMod = ds.Tables[0].Rows[i][10].ToString() == "" ? item.CtAudFeMod : Convert.ToDateTime(ds.Tables[0].Rows[i][10]);
                        item.CtAudUsuEl = Convert.ToString(ds.Tables[0].Rows[i][11]);
                        item.CtAudFeEl = ds.Tables[0].Rows[i][12].ToString() == "" ? item.CtAudFeEl : Convert.ToDateTime(ds.Tables[0].Rows[i][12]);
                        lista.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }
    }
}
