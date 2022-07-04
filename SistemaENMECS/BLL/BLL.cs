using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using SistemaENMECS.DAL;

namespace SistemaENMECS.BLL
{
    class BLL
    {
    }

    static class usuarioCache
    {
        public static string nombreUsuario;

        public static void Inicializar()
        {
            nombreUsuario = "";
        }
    }

    public class _Directorio
    {
        public string DiNumero { get; set; }
        public string DiTipo { get; set; }
        public string DiTipo2 { get; set; }
        public string DiRFC { get; set; }
        public string DiRazonSocial { get; set; }
        public string DiTipoEmpresa { get; set; }
        public string DiNombreCom { get; set; }
        public string DiCalle { get; set; }
        public string DiNumExt { get; set; }
        public string DiNumInt { get; set; }
        public string DiColonia { get; set; }
        public string DiCP { get; set; }
        public string DiPoblacion { get; set; }
        public string DiMunicipio { get; set; }
        public string DiEstado { get; set; }
        public string DiPais { get; set; }
        public string DiNacional { get; set; }
        public string DiPaginaWeb { get; set; }
        public string DiNomCorto { get; set; }
        public string DiClasif { get; set; }
        public string DiRapido { get; set; }
        public string DiCCredito { get; set; }
        public int DiDCredito { get; set; }
        public double DiLCredito { get; set; }
        public string DiDBBenef { get; set; }
        public string DiDBBanco { get; set; }
        public string DiDBSucursal { get; set; }
        public string DiDBNumCta { get; set; }
        public string DiDBCLABE { get; set; }
        public int DiPjDesc { get; set; }
        public string DiActivo { get; set; }
        //AUDITORIA
        public string DiAudUsuCre { get; set; }
        public DateTime DiAudFeCre { get; set; }
        public string DiAudUsuMod { get; set; }
        public DateTime DiAudFeMod { get; set; }
        public string DiAudUsuEl { get; set; }
        public DateTime DiAudFeEl { get; set; }

        public List<DIRECTORIO> listDir { get; set; }

        public List<string> errores { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                DiAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                DiAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                DiAudUsuMod = usuarioCache.nombreUsuario;
                DiAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                DiAudUsuEl = usuarioCache.nombreUsuario;
                DiAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";
            errores = new List<string>();

            m = modo.insert;
            auditoria();

            DIRECTORIO directorio = new DIRECTORIO();
            if (DiNumero == "")
                errores.Add("Falta indicar el numero de direccion");
            else
                directorio.DiNumero = DiNumero;
            if (DiTipo == "")
                errores.Add("Falta indicar el tipo");
            else
                directorio.DiTipo = DiTipo;
            directorio.DiTipo2 = DiTipo2;
            if (DiRFC == "")
                errores.Add("Falta indicar el RFC");
            else
                directorio.DiRFC = DiRFC;
            if (DiRazonSocial == "")
                errores.Add("Falta indicar la Razon Social");
            else
                directorio.DiRazonSocial = DiRazonSocial;
            if (DiTipoEmpresa == "")
                errores.Add("Falta indicar el Tipo de Persosa (Fisica/Moral)");
            else
                directorio.DiTipoEmpresa = DiTipoEmpresa;
            if (DiNombreCom == "")
                errores.Add("Falta indicar el nombre comercial");
            else
                directorio.DiNombreCom = DiNombreCom;
            directorio.DiCalle = DiCalle;
            directorio.DiNumExt = DiNumExt;
            directorio.DiNumInt = DiNumInt;
            directorio.DiColonia = DiColonia;
            directorio.DiCP = DiCP;
            directorio.DiPoblacion = DiPoblacion;
            directorio.DiMunicipio = DiMunicipio;
            directorio.DiEstado = DiEstado;
            directorio.DiPais = DiPais;
            directorio.DiNacional = DiNacional;
            directorio.DiPaginaWeb = DiPaginaWeb;
            directorio.DiNomCorto = DiNomCorto;
            if (DiClasif == "")
                errores.Add("Falta indicar la clasificacion");
            else
                directorio.DiClasif = DiClasif;
            if (DiRapido == "")
                errores.Add("Falta indicar si es rapido");
            else
                directorio.DiRapido = DiRapido;
            if (DiCCredito == "")
                errores.Add("Falta indicar si hay credito");
            else
                directorio.DiCCredito = DiCCredito;
            directorio.DiDCredito = DiDCredito;
            directorio.DiLCredito = DiLCredito;
            directorio.DiDBBenef = DiDBBenef;
            directorio.DiDBBanco = DiDBBanco;
            directorio.DiDBSucursal = DiDBSucursal;
            directorio.DiDBNumCta = DiDBNumCta;
            directorio.DiDBCLABE = DiDBCLABE;
            directorio.DiPjDesc = DiPjDesc;
            directorio.DiActivo = "A";

            directorio.DiAudUsuCre = DiAudUsuCre;
            directorio.DiAudFeCre = DiAudFeCre;

            resultado = errores.Count == 0 ? "" : "error";

            if (resultado == "")
            {
                db.setDireccion(directorio);
                if (db.error != "")
                    errores.Add("DB: " + db.error);
            }
            resultado = errores.Count == 0 ? "" : "error";

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";
            errores = new List<string>();

            m = modo.update;
            auditoria();

            DIRECTORIO directorio = new DIRECTORIO();
            if (DiNumero == "")
                errores.Add("Falta indicar el numero de direccion");
            else
                directorio.DiNumero = DiNumero;
            if (DiTipo == "")
                errores.Add("Falta indicar el tipo");
            else
                directorio.DiTipo = DiTipo;
            directorio.DiTipo2 = DiTipo2;
            if (DiRFC == "")
                errores.Add("Falta indicar el RFC");
            else
                directorio.DiRFC = DiRFC;
            if (DiRazonSocial == "")
                errores.Add("Falta indicar la Razon Social");
            else
                directorio.DiRazonSocial = DiRazonSocial;
            if (DiTipoEmpresa == "")
                errores.Add("Falta indicar el Tipo de Persosa (Fisica/Moral)");
            else
                directorio.DiTipoEmpresa = DiTipoEmpresa;
            if (DiNombreCom == "")
                errores.Add("Falta indicar el nombre comercial");
            else
                directorio.DiNombreCom = DiNombreCom;
            directorio.DiCalle = DiCalle;
            directorio.DiNumExt = DiNumExt;
            directorio.DiNumInt = DiNumInt;
            directorio.DiColonia = DiColonia;
            directorio.DiCP = DiCP;
            directorio.DiPoblacion = DiPoblacion;
            directorio.DiMunicipio = DiMunicipio;
            directorio.DiEstado = DiEstado;
            directorio.DiPais = DiPais;
            directorio.DiNacional = DiNacional;
            directorio.DiPaginaWeb = DiPaginaWeb;
            directorio.DiNomCorto = DiNomCorto;
            if (DiClasif == "")
                errores.Add("Falta indicar la clasificacion");
            else
                directorio.DiClasif = DiClasif;
            if (DiRapido == "")
                errores.Add("Falta indicar si es rapido");
            else
                directorio.DiRapido = DiRapido;
            if (DiCCredito == "")
                errores.Add("Falta indicar si hay credito");
            else
                directorio.DiCCredito = DiCCredito;
            directorio.DiDCredito = DiDCredito;
            directorio.DiLCredito = DiLCredito;
            directorio.DiDBBenef = DiDBBenef;
            directorio.DiDBBanco = DiDBBanco;
            directorio.DiDBSucursal = DiDBSucursal;
            directorio.DiDBNumCta = DiDBNumCta;
            directorio.DiDBCLABE = DiDBCLABE;
            directorio.DiPjDesc = DiPjDesc;
            directorio.DiActivo = "A";

            directorio.DiAudUsuMod = DiAudUsuMod;
            directorio.DiAudFeMod = DiAudFeMod;

            resultado = errores.Count == 0 ? "" : "error";

            if (resultado == "")
            {
                db.updDireccion(directorio, m);
                if (db.error != "")
                    errores.Add("DB: " + db.error);
            }
            resultado = errores.Count == 0 ? "" : "error";

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";
            errores = new List<string>();

            m = modo.delete;
            auditoria();

            DIRECTORIO directorio = new DIRECTORIO();
            if (DiNumero == "")
                errores.Add("Es necesario el Identificador");
            else
                directorio.DiNumero = DiNumero;
            directorio.DiActivo = "I";

            directorio.DiAudUsuEl = DiAudUsuEl;
            directorio.DiAudFeEl = DiAudFeEl;

            resultado = errores.Count == 0 ? "" : "Error";

            if (resultado == "")
            {
                db.updDireccion(directorio, m);
                if (db.error != "")
                    errores.Add("DB: " + db.error);
            }
            resultado = errores.Count == 0 ? "" : "error";

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";
            errores = new List<string>();

            DIRECTORIO directorio = new DIRECTORIO();
            if (DiNumero == "")
                errores.Add("Es necesario el Identificador");
            else
                directorio.DiNumero = DiNumero;
            directorio.DiTipo = "";
            directorio.DiRFC = "";
            directorio.DiNombreCom = "";

            resultado = errores.Count == 0 ? "" : "error";

            if (resultado == "")
            {
                DIRECTORIO item = db.getDireccion(directorio);
                if (db.error != "")
                    errores.Add("DB: " + db.error);

                DiNumero = item.DiNumero;
                DiTipo = item.DiTipo;
                DiTipo2 = item.DiTipo2;
                DiRFC = item.DiRFC;
                DiRazonSocial = item.DiRazonSocial;
                DiTipoEmpresa = item.DiTipoEmpresa;
                DiNombreCom = item.DiNombreCom;
                DiCalle = item.DiCalle;
                DiNumExt = item.DiNumExt;
                DiNumInt = item.DiNumInt;
                DiColonia = item.DiColonia;
                DiCP = item.DiCP;
                DiPoblacion = item.DiPoblacion;
                DiMunicipio = item.DiMunicipio;
                DiEstado = item.DiEstado;
                DiPais = item.DiPais;
                DiNacional = item.DiNacional;
                DiPaginaWeb = item.DiPaginaWeb;
                DiNomCorto = item.DiNomCorto;
                DiClasif = item.DiClasif;
                DiRapido = item.DiRapido;
                DiCCredito = item.DiCCredito;
                DiDCredito = item.DiDCredito;
                DiLCredito = item.DiLCredito;
                DiDBBenef = item.DiDBBenef;
                DiDBBanco = item.DiDBBanco;
                DiDBSucursal = item.DiDBSucursal;
                DiDBNumCta = item.DiDBNumCta;
                DiDBCLABE = item.DiDBCLABE;
                DiPjDesc = item.DiPjDesc;
                DiActivo = item.DiActivo;
                DiAudUsuCre = item.DiAudUsuCre;
                DiAudFeCre = item.DiAudFeCre;
                DiAudUsuMod = item.DiAudUsuMod;
                DiAudFeMod = item.DiAudFeMod;
                DiAudUsuEl = item.DiAudUsuEl;
                DiAudFeEl = item.DiAudFeEl;
            }
            resultado = errores.Count == 0 ? "" : "error";

            return resultado;
        }

        public string listado()
        {
            string resultado = "";
            errores = new List<string>();

            DIRECTORIO directorio = new DIRECTORIO();
            directorio.DiNumero = DiNumero;
            directorio.DiTipo = DiTipo;
            directorio.DiRFC = DiRFC;
            directorio.DiNombreCom = DiNombreCom;

            if (resultado == "")
            {
                listDir = db.getDirecciones(directorio);
                if (db.error != "")
                    errores.Add("DB: " + db.error);
            }
            resultado = errores.Count == 0 ? "" : "error";

            return resultado;
        }
    }

    public class _Contacto
    {
        public string DiNumero { get; set; }
        public int CnNumero { get; set; }
        public string CnTipo { get; set; }
        public string CnNombre { get; set; }
        public string CnAPaterno { get; set; }
        public string CnAMaterno { get; set; }
        public string CnCorreo { get; set; }
        public string CnTelefono { get; set; }
        public string CnPuesto { get; set; }
        public string CnGradoEst { get; set; }
        public string CnAbrGraEst { get; set; }
        public string CnCedula { get; set; }
        public string CnNota { get; set; }
        public string CnActivo { get; set; }
        //AUDITORIA
        public string CnAudUsuCre { get; set; }
        public DateTime CnAudFeCre { get; set; }
        public string CnAudUsuMod { get; set; }
        public DateTime CnAudFeMod { get; set; }
        public string CnAudUsuEl { get; set; }
        public DateTime CnAudFeEl { get; set; }

        public List<CONTACTO> listCon { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                CnAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                CnAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                CnAudUsuMod = usuarioCache.nombreUsuario;
                CnAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                CnAudUsuEl = usuarioCache.nombreUsuario;
                CnAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            resultado = listado();

            if (resultado == "")
            {
                CONTACTO contacto = new CONTACTO();
                if (DiNumero == "")
                    resultado = "Falta indicar el numero de direccion";
                else
                    contacto.DiNumero = DiNumero;
                if (CnNumero == 0)
                    contacto.CnNumero = listCon.Count + 1;
                else
                    contacto.CnNumero = CnNumero;
                if (CnTipo == "")
                    resultado = "Falta indicar el tipo de contacto";
                else
                    contacto.CnTipo = CnTipo;
                if (CnNombre == "")
                    resultado = "Falta indicar el nombre";
                else
                    contacto.CnNombre = CnNombre;
                if (CnAPaterno == "")
                    resultado = "Falta indicar el primer Apellido";
                else
                    contacto.CnAPaterno = CnAPaterno;
                contacto.CnAMaterno = CnAMaterno;
                contacto.CnCorreo = CnCorreo;
                contacto.CnTelefono = CnTelefono;
                contacto.CnPuesto = CnPuesto;
                contacto.CnGradoEst = CnGradoEst;
                contacto.CnAbrGraEst = CnAbrGraEst;
                contacto.CnCedula = CnCedula;
                contacto.CnNota = CnNota;
                contacto.CnActivo = "A";

                contacto.CnAudUsuCre = CnAudUsuCre;
                contacto.CnAudFeCre = CnAudFeCre;

                if (resultado == "")
                    db.setContacto(contacto);
            }

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            CONTACTO contacto = new CONTACTO();
            if (DiNumero == "")
                resultado = "Falta indicar el numero de direccion";
            else
                contacto.DiNumero = DiNumero;
            if (CnNumero == 0)
                resultado = "Falta indicar el numero del contacto";
            else
                contacto.CnNumero = CnNumero;
            if (CnTipo == "")
                resultado = "Falta indicar el tipo de contacto";
            else
                contacto.CnTipo = CnTipo;
            if (CnNombre == "")
                resultado = "Falta indicar el nombre";
            else
                contacto.CnNombre = CnNombre;
            if (CnAPaterno == "")
                resultado = "Falta indicar el primer Apellido";
            else
                contacto.CnAPaterno = CnAPaterno;
            contacto.CnAMaterno = CnAMaterno;
            contacto.CnCorreo = CnCorreo;
            contacto.CnTelefono = CnTelefono;
            contacto.CnPuesto = CnPuesto;
            contacto.CnGradoEst = CnGradoEst;
            contacto.CnAbrGraEst = CnAbrGraEst;
            contacto.CnCedula = CnCedula;
            contacto.CnNota = CnNota;
            contacto.CnActivo = "A";

            contacto.CnAudUsuMod = CnAudUsuMod;
            contacto.CnAudFeMod = CnAudFeMod;

            if (resultado == "")
                db.updContacto(contacto, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            CONTACTO contacto = new CONTACTO();
            if (DiNumero == "")
                resultado = "Es necesario el Identificador";
            else
                contacto.DiNumero = DiNumero;
            if (CnNumero == 0)
                resultado = "Es necesario el numero de contacto";
            else
                contacto.CnNumero = CnNumero;
            contacto.CnActivo = "I";

            contacto.CnAudUsuEl = CnAudUsuEl;
            contacto.CnAudFeEl = CnAudFeEl;

            if (resultado == "")
                db.updContacto(contacto, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            CONTACTO contacto = new CONTACTO();
            if (DiNumero == "")
                resultado = "Es necesario el Identificador";
            else
                contacto.DiNumero = DiNumero;
            if (CnNumero == 0)
                resultado = "Es necesario el numero de contacto";
            else
                contacto.CnNumero = CnNumero;
            contacto.CnTipo = CnTipo;

            if (resultado == "")
            {
                CONTACTO item = db.getContacto(contacto);
                DiNumero = item.DiNumero;
                CnNumero = item.CnNumero;
                CnTipo = item.CnTipo;
                CnNombre = item.CnNombre;
                CnAPaterno = item.CnAPaterno;
                CnAMaterno = item.CnAMaterno;
                CnCorreo = item.CnCorreo;
                CnTelefono = item.CnTelefono;
                CnPuesto = item.CnPuesto;
                CnGradoEst = item.CnGradoEst;
                CnAbrGraEst = item.CnAbrGraEst;
                CnCedula = item.CnCedula;
                CnNota = item.CnNota;
                CnActivo = item.CnActivo;
                CnAudUsuCre = item.CnAudUsuCre;
                CnAudFeCre = item.CnAudFeCre;
                CnAudUsuMod = item.CnAudUsuMod;
                CnAudFeMod = item.CnAudFeMod;
                CnAudUsuEl = item.CnAudUsuEl;
                CnAudFeEl = item.CnAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            CONTACTO contacto = new CONTACTO();
            contacto.DiNumero = DiNumero;
            contacto.CnNumero = CnNumero;
            contacto.CnTipo = CnTipo;

            if (resultado == "")
                listCon = db.getContactos(contacto);

            return resultado;
        }
    }

    public class _Usuario
    {
        public string DiNumero { get; set; }
        public int CnNumero { get; set; }
        public string UsNombre { get; set; }
        public string UsUsuario { get; set; }
        public string UsPassword { get; set; }
        public string UsPerfil { get; set; }
        public string UsActivo { get; set; }
        //AUDITORIA
        public string UsAudUsuCre { get; set; }
        public DateTime UsAudFeCre { get; set; }
        public string UsAudUsuMod { get; set; }
        public DateTime UsAudFeMod { get; set; }
        public string UsAudUsuEl { get; set; }
        public DateTime UsAudFeEl { get; set; }

        public List<USUARIO> listUsu { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                UsAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                UsAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                UsAudUsuMod = usuarioCache.nombreUsuario;
                UsAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                UsAudUsuEl = usuarioCache.nombreUsuario;
                UsAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            USUARIO usuario = new USUARIO();
            if (DiNumero == "")
                resultado = "Falta indicar el numero de direccion";
            else
                usuario.DiNumero = DiNumero;
            if (CnNumero == 0)
                resultado = "Falta indicar el numero consecutivo";
            else
                usuario.CnNumero = CnNumero;
            usuario.UsNombre = UsNombre;
            if (UsUsuario == "")
                resultado = "Falta indicar el usuario";
            else
                usuario.UsUsuario = UsUsuario;
            if (UsPassword == "")
                resultado = "Falta indicar el password";
            else
                usuario.UsPassword = UsPassword;
            if (UsPerfil == "")
                resultado = "Falta indicar el perfil";
            else
                usuario.UsPerfil = UsPerfil;
            usuario.UsActivo = "A";

            usuario.UsAudUsuCre = UsAudUsuCre;
            usuario.UsAudFeCre = UsAudFeCre;

            usuario.UsPassword = hashString(usuario.UsPassword.Trim(), usuario.UsUsuario.Trim());

            if (resultado == "")
                db.setUsuario(usuario);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            USUARIO usuario = new USUARIO();
            if (DiNumero == "")
                resultado = "Falta indicar el numero de direccion";
            else
                usuario.DiNumero = DiNumero;
            if (CnNumero == 0)
                resultado = "Falta indicar el numero consecutivo";
            else
                usuario.CnNumero = CnNumero;
            usuario.UsNombre = UsNombre;
            if (UsUsuario == "")
                resultado = "Falta indicar el usuario";
            else
                usuario.UsUsuario = UsUsuario;
            if (UsPassword == "")
                resultado = "Falta indicar el password";
            else
                usuario.UsPassword = UsPassword;
            if (UsPerfil == "")
                resultado = "Falta indicar el perfil";
            else
                usuario.UsPerfil = UsPerfil;
            usuario.UsActivo = "A";

            usuario.UsAudUsuMod = UsAudUsuMod;
            usuario.UsAudFeMod = UsAudFeMod;
            
            if (resultado == "")
                db.updUsuario(usuario, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            USUARIO usuario = new USUARIO();
            if (DiNumero == "")
                resultado = "Falta indicar el numero de direccion";
            else
                usuario.DiNumero = DiNumero;
            if (CnNumero == 0)
                resultado = "Falta indicar el numero consecutivo";
            else
                usuario.CnNumero = CnNumero;
            usuario.UsActivo = "I";

            usuario.UsAudUsuEl = UsAudUsuEl;
            usuario.UsAudFeEl = UsAudFeEl;

            if (resultado == "")
                db.updUsuario(usuario, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            USUARIO usuario = new USUARIO();
            usuario.DiNumero = DiNumero.Trim();
            usuario.CnNumero = CnNumero;
            usuario.UsUsuario = UsUsuario == null ? "" : UsUsuario.Trim();
            if (resultado == "")
            {
                USUARIO item = db.getUsuario(usuario);
                DiNumero = item.DiNumero;
                CnNumero = item.CnNumero;
                UsNombre = item.UsNombre;
                UsUsuario = item.UsUsuario;
                UsPassword = item.UsPassword;
                UsPerfil = item.UsPerfil;
                UsActivo = item.UsActivo;
                UsAudUsuCre = item.UsAudUsuCre;
                UsAudFeCre = item.UsAudFeCre;
                UsAudUsuMod = item.UsAudUsuMod;
                UsAudFeMod = item.UsAudFeMod;
                UsAudUsuEl = item.UsAudUsuEl;
                UsAudFeEl = item.UsAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            USUARIO usuario = new USUARIO();
            usuario.DiNumero = DiNumero;
            usuario.CnNumero = 0;
            usuario.UsUsuario = "";

            if (resultado == "")
                listUsu = db.getUsuarios(usuario);

            return resultado;
        }

        public string login()
        {
            string resultado = "";

            USUARIO usuario = new USUARIO();
            usuario.DiNumero = DiNumero.Trim();
            usuario.CnNumero = CnNumero;
            usuario.UsUsuario = UsUsuario.Trim();
            if (resultado == "")
            {
                USUARIO item = db.getUsuario(usuario);
                if (item.DiNumero == null)
                    resultado = "Sin resultados";
                DiNumero = item.DiNumero;
                CnNumero = item.CnNumero;
                UsNombre = item.UsNombre;
                UsUsuario = item.UsUsuario;
                UsPassword = item.UsPassword;
                UsPerfil = item.UsPerfil;
                UsActivo = item.UsActivo;
                UsAudUsuCre = item.UsAudUsuCre;
                UsAudFeCre = item.UsAudFeCre;
                UsAudUsuMod = item.UsAudUsuMod;
                UsAudFeMod = item.UsAudFeMod;
                UsAudUsuEl = item.UsAudUsuEl;
                UsAudFeEl = item.UsAudFeEl;
            }

            return resultado;
        }

        public string hashString(string text, string salt = "")
        {
            if (String.IsNullOrEmpty(text))
            {
                return String.Empty;
            }

            // Uses SHA256 to create the hash
            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                // Convert the string to a byte array first, to be processed
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text + salt);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                // Convert back to a string, removing the '-' that BitConverter adds
                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);

                return hash;
            }
        }
    }

    public class _Proyecto
    {
        public string PyNumero { get; set; }
        public int PyFolio { get; set; }
        public string PyNombre { get; set; }
        public string PyNomCorA { get; set; }
        public string PyNomCarp { get; set; }
        public string PyObjetivo { get; set; }
        public string PyTipoSis { get; set; }
        public string PyEstado { get; set; }
        public string PyMaster { get; set; }
        public string DiNumero { get; set; }
        public string DiNombre { get; set; }
        public string EmIdent { get; set; }
        public string PyCambio { get; set; }
        public string PyUsuCam { get; set; }
        public DateTime PyFeCam { get; set; }
        public string PyEstatus { get; set; }
        public string PyClasif { get; set; }
        public string PyActivo { get; set; }
        //AUDITORIA
        public string PyAudUsuCre { get; set; }
        public DateTime PyAudFeCre { get; set; }
        public string PyAudUsuMod { get; set; }
        public DateTime PyAudFeMod { get; set; }
        public string PyAudUsuEl { get; set; }
        public DateTime PyAudFeEl { get; set; }

        public List<PROYECTO> listPry { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                PyAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                PyAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                PyAudUsuMod = usuarioCache.nombreUsuario;
                PyAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                PyAudUsuEl = usuarioCache.nombreUsuario;
                PyAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            PROYECTO proyecto = new PROYECTO();
            if (PyNumero == "")
                resultado = "Falta indicar el numero proyecto";
            else
                proyecto.PyNumero = PyNumero;
            if (PyFolio == 0)
                resultado = "Falta indicar el folio";
            else
                proyecto.PyFolio = PyFolio;
            if (PyNombre == "")
                resultado = "Falta indicar el nombre";
            else
                proyecto.PyNombre = PyNombre;
            proyecto.PyNomCorA = PyNomCorA;
            proyecto.PyNomCarp = PyNomCarp;
            proyecto.PyObjetivo = PyObjetivo;
            proyecto.PyTipoSis = PyTipoSis;
            proyecto.PyEstado = PyEstado;
            proyecto.PyMaster = PyMaster;
            if (DiNumero == "")
                resultado = "Falta indicar el numero Cliente";
            else
                proyecto.DiNumero = DiNumero;
            proyecto.EmIdent = EmIdent;
            proyecto.PyCambio = PyCambio;
            proyecto.PyUsuCam = PyUsuCam;
            proyecto.PyFeCam = PyFeCam;
            proyecto.PyEstatus = PyEstatus;
            proyecto.PyClasif = PyClasif;
            proyecto.PyActivo = "A";

            proyecto.PyAudUsuCre = PyAudUsuCre;
            proyecto.PyAudFeCre = PyAudFeCre;

            if (resultado == "")
                db.setProyecto(proyecto);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            PROYECTO proyecto = new PROYECTO();
            if (PyNumero == "")
                resultado = "Falta indicar el numero proyecto";
            else
                proyecto.PyNumero = PyNumero;
            if (PyFolio == 0)
                resultado = "Falta indicar el numero de folio";
            else
                proyecto.PyFolio = PyFolio;
            if (PyNombre == "")
                resultado = "Falta indicar el nombre";
            else
                proyecto.PyNombre = PyNombre;
            proyecto.PyNomCorA = PyNomCorA;
            proyecto.PyNomCarp = PyNomCarp;
            proyecto.PyObjetivo = PyObjetivo;
            proyecto.PyTipoSis = PyTipoSis;
            proyecto.PyEstado = PyEstado;
            proyecto.PyMaster = PyMaster;
            if (DiNumero == "")
                resultado = "Falta indicar el numero Cliente";
            else
                proyecto.DiNumero = DiNumero;
            proyecto.EmIdent = EmIdent;
            proyecto.PyCambio = PyCambio;
            proyecto.PyUsuCam = PyUsuCam;
            proyecto.PyFeCam = PyFeCam;
            proyecto.PyEstatus = PyEstatus;
            proyecto.PyClasif = PyClasif;
            proyecto.PyActivo = "A";

            proyecto.PyAudUsuMod = PyAudUsuMod;
            proyecto.PyAudFeMod = PyAudFeMod;

            if (resultado == "")
                db.updProyecto(proyecto, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            PROYECTO proyecto = new PROYECTO();
            if (PyNumero == "")
                resultado = "Falta indicar el numero proyecto";
            else
                proyecto.PyNumero = PyNumero;
            proyecto.PyActivo = "I";

            proyecto.PyAudUsuEl = PyAudUsuEl;
            proyecto.PyAudFeEl = PyAudFeEl;

            if (resultado == "")
                db.updProyecto(proyecto, m);

            return resultado;
        }

        public string viable()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            PROYECTO proyecto = new PROYECTO();
            if (PyNumero == "")
                resultado = "Falta indicar el numero proyecto";
            else
                proyecto.PyNumero = PyNumero;
            proyecto.PyCambio = PyCambio;
            proyecto.PyUsuCam = PyUsuCam;
            proyecto.PyFeCam = PyFeCam;
            proyecto.PyEstatus = PyEstatus;
            proyecto.PyActivo = PyActivo;
            proyecto.PyAudUsuMod = PyAudUsuMod;
            proyecto.PyAudFeMod = PyAudFeMod;

            if (resultado == "")
                db.viaProyecto(proyecto);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            PROYECTO proyecto = new PROYECTO();
            if (PyNumero == "")
                resultado = "Falta indicar el numero proyecto";
            else
                proyecto.PyNumero = PyNumero;
            proyecto.PyNombre = PyNombre;
            proyecto.DiNombre = DiNombre;

            if (resultado == "")
            {
                PROYECTO item = db.getProyecto(proyecto);
                PyNumero = item.PyNumero;
                PyFolio = item.PyFolio;
                PyNombre = item.PyNombre;
                PyNomCorA = item.PyNomCorA;
                PyNomCarp = item.PyNomCarp;
                PyObjetivo = item.PyObjetivo;
                PyTipoSis = item.PyTipoSis;
                PyEstado = item.PyEstado;
                PyMaster = item.PyMaster;
                DiNumero = item.DiNumero;
                DiNombre = item.DiNombre;
                EmIdent = item.EmIdent;
                PyCambio = item.PyCambio;
                PyUsuCam = item.PyUsuCam;
                PyFeCam = item.PyFeCam;
                PyEstatus = item.PyEstatus;
                PyClasif = item.PyClasif;
                PyActivo = item.PyActivo;
                PyAudUsuCre = item.PyAudUsuCre;
                PyAudFeCre = item.PyAudFeCre;
                PyAudUsuMod = item.PyAudUsuMod;
                PyAudFeMod = item.PyAudFeMod;
                PyAudUsuEl = item.PyAudUsuEl;
                PyAudFeEl = item.PyAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            PROYECTO proyecto = new PROYECTO();
            proyecto.PyNumero = PyNumero;
            proyecto.PyNombre = PyNombre;
            proyecto.DiNombre = DiNombre;

            if (resultado == "")
                listPry = db.getProyectos(proyecto);

            return resultado;
        }
    }

    public class _Articulo
    {
        public string ArIdent { get; set; }
        public string ArCodigo { get; set; }
        public string ArCodCom { get; set; }
        public string ArDescripcion { get; set; }
        public double ArCosto { get; set; }
        public double ArPrecioPub { get; set; }
        public string ArMoneda { get; set; }
        public string ArUnidad { get; set; }
        public string ArClasificacion { get; set; }
        public string ArCategoria { get; set; }
        public string ArUso { get; set; }
        public string ArTipo { get; set; }
        public string ArModeloCom { get; set; }
        public string ArMarca { get; set; }
        public string ArGenerico { get; set; }
        public string ArAlto { get; set; }
        public string ArLargo { get; set; }
        public string ArAncho { get; set; }
        public string ArPeso { get; set; }
        public string ArActivo { get; set; }
        //AUDITORIA
        private string ArAudUsuCre { get; set; }
        private DateTime ArAudFeCre { get; set; }
        private string ArAudUsuMod { get; set; }
        private DateTime ArAudFeMod { get; set; }
        private string ArAudUsuEl { get; set; }
        private DateTime ArAudFeEl { get; set; }

        public List<ARTICULO> listArt { get; set; }
        public List<ARTICULOCLIENTES> listDir { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                ArAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                ArAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                ArAudUsuMod = usuarioCache.nombreUsuario;
                ArAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                ArAudUsuEl = usuarioCache.nombreUsuario;
                ArAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            ARTICULO articulo = new ARTICULO();
            if (ArIdent == "")
                resultado = "Es necesario el Identificador";
            else
                articulo.ArIdent = ArIdent;
            if (ArCodigo == "")
                resultado = "Es necesario el Código";
            else
                articulo.ArCodigo = ArCodigo;
            articulo.ArCodCom = ArCodCom;
            if (ArDescripcion == "")
                resultado = "Es necesario la Descripción";
            else
                articulo.ArDescripcion = ArDescripcion;
            articulo.ArCosto = ArCosto;
            articulo.ArPrecioPub = ArPrecioPub;
            if (ArMoneda == "")
                resultado = "Es necesario la Moneda";
            else
                articulo.ArMoneda = ArMoneda;
            articulo.ArUnidad = ArUnidad;
            if (ArClasificacion == "")
                resultado = "Es necesario la Clasificación";
            else
                articulo.ArClasificacion = ArClasificacion;
            if (ArCategoria == "")
                resultado = "Es necesario la Categoria";
            else
                articulo.ArCategoria = ArCategoria;
            if (ArUso == "")
                resultado = "Es necesario el Uso";
            articulo.ArUso = ArUso;
            articulo.ArTipo = ArTipo;
            articulo.ArModeloCom = ArModeloCom;
            articulo.ArMarca = ArMarca;
            articulo.ArGenerico = ArGenerico;
            articulo.ArAlto = ArAlto;
            articulo.ArLargo = ArLargo;
            articulo.ArAncho = ArAncho;
            articulo.ArPeso = ArPeso;
            articulo.ArActivo = "A";

            articulo.ArAudUsuCre = ArAudUsuCre;
            articulo.ArAudFeCre = ArAudFeCre;

            if (resultado == "")
                db.setArticulo(articulo);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            ARTICULO articulo = new ARTICULO();
            if (ArIdent == "")
                resultado = "Es necesario el Identificador";
            else
                articulo.ArIdent = ArIdent;
            if (ArCodigo == "")
                resultado = "Es necesario el Código";
            else
                articulo.ArCodigo = ArCodigo;
            articulo.ArCodCom = ArCodCom;
            if (ArDescripcion == "")
                resultado = "Es necesario la Descripción";
            else
                articulo.ArDescripcion = ArDescripcion;
            articulo.ArCosto = ArCosto;
            articulo.ArPrecioPub = ArPrecioPub;
            if (ArMoneda == "")
                resultado = "Es necesario la Moneda";
            else
                articulo.ArMoneda = ArMoneda;
            articulo.ArUnidad = ArUnidad;
            if (ArClasificacion == "")
                resultado = "Es necesario la Clasificación";
            else
                articulo.ArClasificacion = ArClasificacion;
            if (ArCategoria == "")
                resultado = "Es necesario la Categoria";
            else
                articulo.ArCategoria = ArCategoria;
            if (ArUso == "")
                resultado = "Es necesario el Uso";
            articulo.ArUso = ArUso;
            articulo.ArTipo = ArTipo;
            articulo.ArModeloCom = ArModeloCom;
            articulo.ArMarca = ArMarca;
            articulo.ArGenerico = ArGenerico;
            articulo.ArAlto = ArAlto;
            articulo.ArLargo = ArLargo;
            articulo.ArAncho = ArAncho;
            articulo.ArPeso = ArPeso;
            articulo.ArActivo = ArActivo;

            articulo.ArAudUsuMod = ArAudUsuMod;
            articulo.ArAudFeMod = ArAudFeMod;

            if (resultado == "")
                db.updArticulo(articulo, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            ARTICULO articulo = new ARTICULO();
            if (ArIdent == "")
                resultado = "Es necesario el Identificador";
            else
                articulo.ArIdent = ArIdent;
            articulo.ArActivo = "I";

            articulo.ArAudUsuEl = ArAudUsuEl;
            articulo.ArAudFeEl = ArAudFeEl;

            if (resultado == "")
                db.updArticulo(articulo, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            ARTICULO articulo = new ARTICULO();
            if (ArIdent == "")
                resultado = "Es necesario el Identificador";
            else
                articulo.ArIdent = ArIdent;
            articulo.ArCodigo = ArCodigo;
            articulo.ArDescripcion = ArDescripcion;
            articulo.ArClasificacion = ArClasificacion;
            articulo.ArModeloCom = ArModeloCom;
            articulo.ArMarca = ArMarca;

            if (resultado == "")
            {
                ARTICULO item = db.getArticulo(articulo);
                ArIdent = item.ArIdent;
                ArCodigo = item.ArCodigo;
                ArCodCom = item.ArCodCom;
                ArDescripcion = item.ArDescripcion;
                ArCosto = item.ArCosto;
                ArPrecioPub = item.ArPrecioPub;
                ArMoneda = item.ArMoneda;
                ArUnidad = item.ArUnidad;
                ArClasificacion = item.ArClasificacion;
                ArCategoria = item.ArCategoria;
                ArUso = item.ArUso;
                ArTipo = item.ArTipo;
                ArModeloCom = item.ArModeloCom;
                ArMarca = item.ArMarca;
                ArGenerico = item.ArGenerico;
                ArAlto = item.ArAlto;
                ArLargo = item.ArLargo;
                ArAncho = item.ArAncho;
                ArPeso = item.ArPeso;
                ArActivo = item.ArActivo;
                ArAudUsuCre = item.ArAudUsuCre;
                ArAudFeCre = item.ArAudFeCre;
                ArAudUsuMod = item.ArAudUsuMod;
                ArAudFeMod = item.ArAudFeMod;
                ArAudUsuEl = item.ArAudUsuEl;
                ArAudFeEl = item.ArAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            ARTICULO articulo = new ARTICULO();

            articulo.ArIdent = ArIdent;
            articulo.ArCodigo = ArCodigo;
            articulo.ArDescripcion = ArDescripcion;
            articulo.ArClasificacion = ArClasificacion;
            articulo.ArModeloCom = ArModeloCom;
            articulo.ArMarca = ArMarca;

            if (resultado == "")
                listArt = db.getArticulos(articulo);

            return resultado;
        }

        public string listadoCLI()
        {
            string resultado = "";

            ARTICULOCLIENTES articulo = new ARTICULOCLIENTES();
            articulo.ArIdent = ArIdent;

            if (resultado == "")
                listDir = db.getDocCPartidaCLI(articulo);

            return resultado;
        }
    }

    public class _Configuracion
    {
        public string CgIdent { get; set; }
        public string CgImpuesto { get; set; }
        public double CgPjImpuesto { get; set; }
        public string CgMoneda { get; set; }
        public string CgGcIdent { get; set; }
        public string CgCrIdent { get; set; }
        public string CgPathPry { get; set; }
        public string CgPathCot { get; set; }
        public string CgNoTipo { get; set; }
        public string CgDfArt { get; set; }
        public string CgDfCli { get; set; }
        public string CgDfPrv { get; set; }
        public string CgDfEmp { get; set; }
        public string CgDfPry { get; set; }
        public string CgActivo { get; set; }
        //AUDITORIA
        public string CgAudUsuCre { get; set; }
        public DateTime CgAudFeCre { get; set; }
        public string CgAudUsuMod { get; set; }
        public DateTime CgAudFeMod { get; set; }
        public string CgAudUsuEl { get; set; }
        public DateTime CgAudFeEl { get; set; }

        public List<PROYECTO> listPry { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                CgAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                CgAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                CgAudUsuMod = usuarioCache.nombreUsuario;
                CgAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                CgAudUsuEl = usuarioCache.nombreUsuario;
                CgAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            CONFIGURACION configuracion = new CONFIGURACION();
            configuracion.CgIdent = CgIdent;
            configuracion.CgImpuesto = CgImpuesto;
            configuracion.CgPjImpuesto = CgPjImpuesto;
            configuracion.CgMoneda = CgMoneda;
            configuracion.CgGcIdent = CgGcIdent;
            configuracion.CgCrIdent = CgCrIdent;
            configuracion.CgPathPry = CgPathPry;
            configuracion.CgPathCot = CgPathCot;
            configuracion.CgNoTipo = CgNoTipo;
            configuracion.CgDfArt = CgDfArt;
            configuracion.CgDfCli = CgDfCli;
            configuracion.CgDfPrv = CgDfPrv;
            configuracion.CgDfEmp = CgDfEmp;
            configuracion.CgDfPry = CgDfPry;
            configuracion.CgActivo = "A";

            configuracion.CgAudUsuCre = CgAudUsuCre;
            configuracion.CgAudFeCre = CgAudFeCre;

            if (resultado == "")
                db.setConfiguracion(configuracion);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            CONFIGURACION configuracion = new CONFIGURACION();
            configuracion.CgIdent = CgIdent;
            configuracion.CgImpuesto = CgImpuesto;
            configuracion.CgPjImpuesto = CgPjImpuesto;
            configuracion.CgMoneda = CgMoneda;
            configuracion.CgGcIdent = CgGcIdent;
            configuracion.CgCrIdent = CgCrIdent;
            configuracion.CgPathPry = CgPathPry;
            configuracion.CgPathCot = CgPathCot;
            configuracion.CgNoTipo = CgNoTipo;
            configuracion.CgDfArt = CgDfArt;
            configuracion.CgDfCli = CgDfCli;
            configuracion.CgDfPrv = CgDfPrv;
            configuracion.CgDfEmp = CgDfEmp;
            configuracion.CgDfPry = CgDfPry;
            configuracion.CgActivo = "A";

            configuracion.CgAudUsuMod = CgAudUsuMod;
            configuracion.CgAudFeMod = CgAudFeMod;

            if (resultado == "")
                db.updConfiguracion(configuracion, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            CONFIGURACION configuracion = new CONFIGURACION();
            if (CgIdent == "")
                resultado = "Falta indicar el Identificador";
            else
                configuracion.CgIdent = CgIdent;
            configuracion.CgActivo = "I";

            configuracion.CgAudUsuEl = CgAudUsuEl;
            configuracion.CgAudFeEl = CgAudFeEl;

            if (resultado == "")
                db.updConfiguracion(configuracion, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            CONFIGURACION configuracion = new CONFIGURACION();
            if (CgIdent == "")
                resultado = "Falta indicar el Identificador";
            else
                configuracion.CgIdent = CgIdent;

            if (resultado == "")
            {
                CONFIGURACION item = db.getConfiguracion(configuracion);
                CgIdent = item.CgIdent;
                CgImpuesto = item.CgImpuesto;
                CgPjImpuesto = item.CgPjImpuesto;
                CgMoneda = item.CgMoneda;
                CgGcIdent = item.CgGcIdent;
                CgCrIdent = item.CgCrIdent;
                CgPathPry = item.CgPathPry;
                CgPathCot = item.CgPathCot;
                CgNoTipo = item.CgNoTipo;
                CgDfArt = item.CgDfArt;
                CgDfCli = item.CgDfCli;
                CgDfPrv = item.CgDfPrv;
                CgDfEmp = item.CgDfEmp;
                CgDfPry = item.CgDfPry;
                CgActivo = item.CgActivo;
            }

            return resultado;
        }
    }

    public class _Folio
    {
        public string FoIdent { get; set; }
        public string FoTipo { get; set; }
        public string FoDescrip { get; set; }
        public int FoFolio { get; set; }
        public string FoPath { get; set; }
        public string FoActivo { get; set; }
        //AUDITORIA
        public string FoAudUsuCre { get; set; }
        public DateTime FoAudFeCre { get; set; }
        public string FoAudUsuMod { get; set; }
        public DateTime FoAudFeMod { get; set; }
        public string FoAudUsuEl { get; set; }
        public DateTime FoAudFeEl { get; set; }

        public List<FOLIO> listFol { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                FoAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                FoAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                FoAudUsuMod = usuarioCache.nombreUsuario;
                FoAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                FoAudUsuEl = usuarioCache.nombreUsuario;
                FoAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            FOLIO folio = new FOLIO();
            if (FoIdent == "")
                resultado = "Falta indicar el Identificador";
            else
                folio.FoIdent = FoIdent;
            if (FoTipo == "")
                resultado = "Falta indicar el tipo";
            else
                folio.FoTipo = FoTipo;
            folio.FoDescrip = FoDescrip == null ? "" : FoDescrip;
            if (FoFolio == 0)
                resultado = "Falta indicar el numero";
            else
                folio.FoFolio = FoFolio;
            if (FoPath == "")
                resultado = "Falta indicar el Path";
            else
                folio.FoPath = FoPath;
            folio.FoActivo = "A";

            folio.FoAudUsuCre = FoAudUsuCre;
            folio.FoAudFeCre = FoAudFeCre;

            if (resultado == "")
                db.setFolio(folio);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            FOLIO folio = new FOLIO();
            if (FoIdent == "")
                resultado = "Falta indicar el Identificador";
            else
                folio.FoIdent = FoIdent;
            if (FoTipo == "")
                resultado = "Falta indicar el tipo";
            else
                folio.FoTipo = FoTipo;
            folio.FoDescrip = FoDescrip == null ? "" : FoDescrip;
            if (FoFolio == 0)
                resultado = "Falta indicar el numero";
            else
                folio.FoFolio = FoFolio;
            if (FoPath == "")
                resultado = "Falta indicar el Path";
            else
                folio.FoPath = FoPath;
            folio.FoActivo = "A";

            folio.FoAudUsuMod = FoAudUsuMod;
            folio.FoAudFeMod = FoAudFeMod;

            if (resultado == "")
                db.updFolio(folio, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            FOLIO folio = new FOLIO();
            if (FoIdent == "")
                resultado = "Falta indicar el Identificador";
            else
                folio.FoIdent = FoIdent;
            folio.FoActivo = "I";

            folio.FoAudUsuEl = FoAudUsuEl;
            folio.FoAudFeEl = FoAudFeEl;

            if (resultado == "")
                db.updFolio(folio, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            FOLIO folio = new FOLIO();
            if (FoIdent == "")
                resultado = "Falta indicar el Indentificador";
            else
                folio.FoIdent = FoIdent;

            if (resultado == "")
            {
                FOLIO item = db.getFolio(folio);
                FoIdent = item.FoIdent;
                FoTipo = item.FoTipo;
                FoDescrip = item.FoDescrip;
                FoFolio = item.FoFolio;
                FoPath = item.FoPath;
                FoActivo = item.FoActivo;
                FoAudUsuCre = item.FoAudUsuCre;
                FoAudFeCre = item.FoAudFeCre;
                FoAudUsuMod = item.FoAudUsuMod;
                FoAudFeMod = item.FoAudFeMod;
                FoAudUsuEl = item.FoAudUsuEl;
                FoAudFeEl = item.FoAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            FOLIO folio = new FOLIO();
            folio.FoIdent = "";

            if (resultado == "")
                listFol = db.getFolios(folio);

            return resultado;
        }

        ///////////////////////////////////ADICIONAL////////////////////////////////////

        public int consecutivo(tipoFolio Ident)
        {
            int fol = 0;

            FoIdent = Ident.ToString();
            string res = consultaUno();
            if (FoFolio == 0)
                fol = 1;
            else
                fol = FoFolio + 1;

            return fol;
        }
    }

    public class _TipoCambio
    {
        public string TcIdent { get; set; }
        public DateTime TcFecha { get; set; }
        public double TcImporte { get; set; }
        public string TcMonedaOri { get; set; }
        public DateTime FeIni { get; set; }
        public DateTime FeFin { get; set; }
        //AUDITORIA
        public string TcAudUsuCre { get; set; }
        public DateTime TcAudFeCre { get; set; }
        public string TcAudUsuMod { get; set; }
        public DateTime TcAudFeMod { get; set; }

        public List<TIPOCAMBIO> listTiC { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                TcAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                TcAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                TcAudUsuMod = usuarioCache.nombreUsuario;
                TcAudFeMod = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            TIPOCAMBIO tipocambio = new TIPOCAMBIO();
            if (TcIdent == "")
                resultado = "Falta indicar el Identificador";
            else
                tipocambio.TcIdent = TcIdent;
            if (TcFecha == null)
                resultado = "Falta indicar la fecha";
            else
                tipocambio.TcFecha = TcFecha;
            if (TcImporte == 0)
                resultado = "Falta indicar el importe";
            else
                tipocambio.TcImporte = TcImporte;
            if (TcMonedaOri == "")
                resultado = "Falta indicar la moneda";
            else
                tipocambio.TcMonedaOri = TcMonedaOri;

            tipocambio.TcAudUsuCre = TcAudUsuCre;
            tipocambio.TcAudFeCre = TcAudFeCre;

            if (resultado == "")
                db.setTipoCambio(tipocambio);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            TIPOCAMBIO tipocambio = new TIPOCAMBIO();
            if (TcIdent == "")
                resultado = "Falta indicar el Identificador";
            else
                tipocambio.TcIdent = TcIdent;
            if (TcFecha == null)
                resultado = "Falta indicar la fecha";
            else
                tipocambio.TcFecha = TcFecha;
            if (TcImporte == 0)
                resultado = "Falta indicar el importe";
            else
                tipocambio.TcImporte = TcImporte;
            if (TcMonedaOri == "")
                resultado = "Falta indicar la moneda";
            else
                tipocambio.TcMonedaOri = TcMonedaOri;

            tipocambio.TcAudUsuMod = TcAudUsuMod;
            tipocambio.TcAudFeMod = TcAudFeMod;

            if (resultado == "")
                db.updTipoCambio(tipocambio);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            TIPOCAMBIO tipocambio = new TIPOCAMBIO();
            if (TcIdent == "")
                resultado = "Falta indicar el Indentificador";
            else
                tipocambio.TcIdent = TcIdent;
            tipocambio.FeIni = FeIni;
            tipocambio.FeFin = FeFin;

            if (resultado == "")
            {
                TIPOCAMBIO item = db.getTipoCambio(tipocambio);
                TcIdent = item.TcIdent;
                TcFecha = item.TcFecha;
                TcImporte = item.TcImporte;
                TcMonedaOri = item.TcMonedaOri;
                TcAudUsuCre = item.TcAudUsuCre;
                TcAudFeCre = item.TcAudFeCre;
                TcAudUsuMod = item.TcAudUsuMod;
                TcAudFeMod = item.TcAudFeMod;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            TIPOCAMBIO tipocambio = new TIPOCAMBIO();

            tipocambio.TcIdent = "";
            tipocambio.FeIni = FeIni;
            tipocambio.FeFin = FeFin;

            if (resultado == "")
                listTiC = db.getTiposCambios(tipocambio);

            return resultado;
        }
    }

    public class _Nota
    {
        public string NoIdent { get; set; }
        public string NoTipo { get; set; }
        public string NoDescripcion { get; set; }
        public string EfIdent { get; set; }
        public string NoActivo { get; set; }
        //AUDITORIA
        public string NoAudUsuCre { get; set; }
        public DateTime NoAudFeCre { get; set; }
        public string NoAudUsuMod { get; set; }
        public DateTime NoAudFeMod { get; set; }
        public string NoAudUsuEl { get; set; }
        public DateTime NoAudFeEl { get; set; }

        public List<NOTA> listNot { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                NoAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                NoAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                NoAudUsuMod = usuarioCache.nombreUsuario;
                NoAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                NoAudUsuEl = usuarioCache.nombreUsuario;
                NoAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            NOTA nota = new NOTA();
            if (NoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                nota.NoIdent = NoIdent;
            if (NoTipo == "")
                resultado = "Falta indicar el tipo";
            else
                nota.NoTipo = NoTipo;
            if (NoDescripcion == "")
                resultado = "Falta indicar la descripcion";
            else
                nota.NoDescripcion = NoDescripcion;
            nota.EfIdent = EfIdent;
            nota.NoActivo = "A";

            nota.NoAudUsuCre = NoAudUsuCre;
            nota.NoAudFeCre = NoAudFeCre;

            if (resultado == "")
                db.setNota(nota);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            NOTA nota = new NOTA();
            if (NoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                nota.NoIdent = NoIdent;
            if (NoTipo == "")
                resultado = "Falta indicar el tipo";
            else
                nota.NoTipo = NoTipo;
            if (NoDescripcion == "")
                resultado = "Falta indicar la descripcion";
            else
                nota.NoDescripcion = NoDescripcion;
            nota.EfIdent = EfIdent;
            nota.NoActivo = NoActivo;

            nota.NoAudUsuMod = NoAudUsuMod;
            nota.NoAudFeMod = NoAudFeMod;

            if (resultado == "")
                db.updNota(nota, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            NOTA nota = new NOTA();
            if (NoIdent == "")
                resultado = "Es necesario el Identificador";
            else
                nota.NoIdent = NoIdent;
            nota.NoActivo = "I";

            nota.NoAudUsuEl = NoAudUsuEl;
            nota.NoAudFeEl = NoAudFeEl;

            if (resultado == "")
                db.updNota(nota, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            NOTA nota = new NOTA();
            if (NoIdent == "")
                resultado = "Es necesario el Identificador";
            else
                nota.NoIdent = NoIdent;
            nota.NoTipo = NoTipo;
            if (resultado == "")
            {
                NOTA item = db.getNota(nota);
                NoIdent = item.NoIdent;
                NoTipo = item.NoTipo;
                NoDescripcion = item.NoDescripcion;
                EfIdent = item.EfIdent;
                NoActivo = item.NoActivo;
                NoAudUsuCre = item.NoAudUsuCre;
                NoAudFeCre = item.NoAudFeCre;
                NoAudUsuMod = item.NoAudUsuMod;
                NoAudFeMod = item.NoAudFeMod;
                NoAudUsuEl = item.NoAudUsuEl;
                NoAudFeEl = item.NoAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            NOTA nota = new NOTA();
            nota.NoIdent = NoIdent;
            nota.NoTipo = NoTipo;

            if (resultado == "")
                listNot = db.getNotas(nota);

            return resultado;
        }

        public string listadoDocNota(string DoIdent)
        {
            string resultado = "";
            int ban = -1;

            NOTA nota = new NOTA();
            nota.NoIdent = NoIdent;
            nota.NoTipo = NoTipo;

            if (resultado == "")
                listNot = db.getNotas(nota);

            _DocNota docNota = new _DocNota();
            docNota.DoIdent = DoIdent;
            docNota.DnNumero = 0;
            docNota.DnTipo = "";
            docNota.NoIdent = "";
            docNota.listado();

            List<NOTA> listaCruce = new List<NOTA>();
            NOTA itemCruce = new NOTA();
            foreach (NOTA item in listNot)
            {
                itemCruce.NoIdent = item.NoIdent;
                itemCruce.NoTipo = item.NoTipo;
                itemCruce.NoDescripcion = item.NoDescripcion;
                itemCruce.EfIdent = item.EfIdent;
                itemCruce.NoActivo = item.NoActivo;
                //AUDITORIA
                itemCruce.NoAudUsuCre = item.NoAudUsuCre;
                itemCruce.NoAudFeCre = item.NoAudFeCre;
                itemCruce.NoAudUsuMod = item.NoAudUsuMod;
                itemCruce.NoAudFeMod = item.NoAudFeMod;
                itemCruce.NoAudUsuEl = item.NoAudUsuEl;
                itemCruce.NoAudFeEl = item.NoAudFeEl;

                ban = 0;
                foreach (DOCNOTA subitem in docNota.listDoN)
                    if (item.NoIdent == subitem.NoIdent)
                    {
                        ban = 1;
                        //DOCNOTA
                        itemCruce.DoIdent = subitem.DoIdent;
                        itemCruce.DnNumero = subitem.DnNumero;
                        itemCruce.DnDescripcion = subitem.DnDescripcion;
                        itemCruce.DnActivo = subitem.DnActivo;
                        listaCruce.Add(itemCruce);
                    }

                if (ban == 0)
                    listaCruce.Add(itemCruce);
            }

            listNot = listaCruce;
            
            return resultado;
        }
    }

    public class _Efecto
    {
        public string EfIdent { get; set; }
        public string EfTipo { get; set; }
        public string EfDescripcion { get; set; }
        public string EfUnidad { get; set; }
        public double EfValor01 { get; set; }
        public double EfValor02 { get; set; }
        public double EfValor03 { get; set; }
        public double EfValor04 { get; set; }
        public double EfValor05 { get; set; }
        public DateTime EfFecha01 { get; set; }
        public DateTime EfFecha02 { get; set; }
        public DateTime EfFecha03 { get; set; }
        public DateTime EfFecha04 { get; set; }
        public DateTime EfFecha05 { get; set; }
        public string EfCodigo01 { get; set; }
        public string EfCodigo02 { get; set; }
        public string EfCodigo03 { get; set; }
        public string EfCodigo04 { get; set; }
        public string EfCodigo05 { get; set; }
        public string EfActivo { get; set; }
        //AUDITORIA
        public string EfAudUsuCre { get; set; }
        public DateTime EfAudFeCre { get; set; }
        public string EfAudUsuMod { get; set; }
        public DateTime EfAudFeMod { get; set; }
        public string EfAudUsuEl { get; set; }
        public DateTime EfAudFeEl { get; set; }

        public List<EFECTO> listEfe { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                EfAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                EfAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                EfAudUsuMod = usuarioCache.nombreUsuario;
                EfAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                EfAudUsuEl = usuarioCache.nombreUsuario;
                EfAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            EFECTO efecto = new EFECTO();
            if (EfIdent == "")
                resultado = "Falta indicar el identificador";
            else
                efecto.EfIdent = EfIdent;
            if (EfTipo == "")
                resultado = "Falta indicar el tipo";
            else
                efecto.EfTipo = EfTipo;
            if (EfDescripcion == "")
                resultado = "Falta indicar la descripcion";
            else
                efecto.EfDescripcion = EfDescripcion;
            efecto.EfUnidad = EfUnidad;
            efecto.EfValor01 = EfValor01;
            efecto.EfValor02 = EfValor02;
            efecto.EfValor03 = EfValor03;
            efecto.EfValor04 = EfValor04;
            efecto.EfValor05 = EfValor05;
            efecto.EfFecha01 = EfFecha01;
            efecto.EfFecha02 = EfFecha02;
            efecto.EfFecha03 = EfFecha03;
            efecto.EfFecha04 = EfFecha04;
            efecto.EfFecha05 = EfFecha05;
            efecto.EfCodigo01 = EfCodigo01;
            efecto.EfCodigo02 = EfCodigo02;
            efecto.EfCodigo03 = EfCodigo03;
            efecto.EfCodigo04 = EfCodigo04;
            efecto.EfCodigo05 = EfCodigo05;
            efecto.EfActivo = "A";

            efecto.EfAudUsuCre = EfAudUsuCre;
            efecto.EfAudFeCre = EfAudFeCre;

            if (resultado == "")
                db.setEfecto(efecto);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            EFECTO efecto = new EFECTO();
            if (EfIdent == "")
                resultado = "Falta indicar el identificador";
            else
                efecto.EfIdent = EfIdent;
            if (EfTipo == "")
                resultado = "Falta indicar el tipo";
            else
                efecto.EfTipo = EfTipo;
            if (EfDescripcion == "")
                resultado = "Falta indicar la descripcion";
            else
                efecto.EfDescripcion = EfDescripcion;
            efecto.EfUnidad = EfUnidad;
            efecto.EfValor01 = EfValor01;
            efecto.EfValor02 = EfValor02;
            efecto.EfValor03 = EfValor03;
            efecto.EfValor04 = EfValor04;
            efecto.EfValor05 = EfValor05;
            efecto.EfFecha01 = EfFecha01;
            efecto.EfFecha02 = EfFecha02;
            efecto.EfFecha03 = EfFecha03;
            efecto.EfFecha04 = EfFecha04;
            efecto.EfFecha05 = EfFecha05;
            efecto.EfCodigo01 = EfCodigo01;
            efecto.EfCodigo02 = EfCodigo02;
            efecto.EfCodigo03 = EfCodigo03;
            efecto.EfCodigo04 = EfCodigo04;
            efecto.EfCodigo05 = EfCodigo05;
            efecto.EfActivo = "A";

            efecto.EfAudUsuMod = EfAudUsuMod;
            efecto.EfAudFeMod = EfAudFeMod;

            if (resultado == "")
                db.updEfecto(efecto, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            EFECTO efecto = new EFECTO();
            if (EfIdent == "")
                resultado = "Falta indicar el identificador";
            else
                efecto.EfIdent = EfIdent;
            efecto.EfActivo = "I";

            efecto.EfAudUsuEl = EfAudUsuEl;
            efecto.EfAudFeEl = EfAudFeEl;

            if (resultado == "")
                db.updEfecto(efecto, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            EFECTO efecto = new EFECTO();
            if (EfIdent == "")
                resultado = "Falta indicar el identificador";
            else
                efecto.EfIdent = EfIdent;

            if (resultado == "")
            {
                EFECTO item = db.getEfecto(efecto);
                EfIdent = item.EfIdent;
                EfTipo = item.EfTipo;
                EfDescripcion = item.EfDescripcion;
                EfUnidad = item.EfUnidad;
                EfValor01 = item.EfValor01;
                EfValor02 = item.EfValor02;
                EfValor03 = item.EfValor03;
                EfValor04 = item.EfValor04;
                EfValor05 = item.EfValor05;
                EfFecha01 = item.EfFecha01;
                EfFecha02 = item.EfFecha02;
                EfFecha03 = item.EfFecha03;
                EfFecha04 = item.EfFecha04;
                EfFecha05 = item.EfFecha05;
                EfCodigo01 = item.EfCodigo01;
                EfCodigo02 = item.EfCodigo02;
                EfCodigo03 = item.EfCodigo03;
                EfCodigo04 = item.EfCodigo04;
                EfCodigo05 = item.EfCodigo05;
                EfActivo = item.EfActivo;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            EFECTO efecto = new EFECTO();

            if (resultado == "")
                listEfe = db.getEfectos(efecto);

            return resultado;
        }
    }

    public class _Empresa
    {
        public string EmIdent { get; set; }
        public string EmLogotipo { get; set; }
        public string EmLeyenda01 { get; set; }
        public string EmLeyenda02 { get; set; }
        public string EmLeyenda03 { get; set; }
        public string EmLeyenda04 { get; set; }
        public string EmLeyenda05 { get; set; }
        public string DiNumero { get; set; }
        public string DiNomCorto { get; set; }
        public string EmPrefijo { get; set; }
        public string EmPrefijoPry { get; set; }
        public string EmGrIdent { get; set; }
        public string EmGrIdCot { get; set; }
        public string EmActivo { get; set; }
        //AUDITORIA
        public string EmAudUsuCre { get; set; }
        public DateTime EmAudFeCre { get; set; }
        public string EmAudUsuMod { get; set; }
        public DateTime EmAudFeMod { get; set; }
        public string EmAudUsuEl { get; set; }
        public DateTime EmAudFeEl { get; set; }

        public List<EMPRESA> listEmp { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                EmAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                EmAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                EmAudUsuMod = usuarioCache.nombreUsuario;
                EmAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                EmAudUsuEl = usuarioCache.nombreUsuario;
                EmAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            EMPRESA empresa = new EMPRESA();
            if (EmIdent == "")
                resultado = "Falta indicar el identificador";
            else
                empresa.EmIdent = EmIdent;
            if (EmLogotipo == "")
                resultado = "Falta indicar el logotipo";
            else
                empresa.EmLogotipo = EmLogotipo;
            empresa.EmLeyenda01 = EmLeyenda01;
            empresa.EmLeyenda02 = EmLeyenda02;
            empresa.EmLeyenda03 = EmLeyenda03;
            empresa.EmLeyenda04 = EmLeyenda04;
            empresa.EmLeyenda05 = EmLeyenda05;
            if (DiNumero == "")
                resultado = "Falta indicar el numero directorio";
            else
                empresa.DiNumero = DiNumero;
            empresa.EmPrefijo = EmPrefijo;
            empresa.EmPrefijoPry = EmPrefijoPry;
            empresa.EmGrIdent = EmGrIdent;
            empresa.EmGrIdCot = EmGrIdCot;
            empresa.EmActivo = "A";

            empresa.EmAudUsuCre = EmAudUsuCre;
            empresa.EmAudFeCre = EmAudFeCre;

            if (resultado == "")
                db.setEmpresa(empresa);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            EMPRESA empresa = new EMPRESA();
            if (EmIdent == "")
                resultado = "Falta indicar el identificador";
            else
                empresa.EmIdent = EmIdent;
            if (EmLogotipo == "")
                resultado = "Falta indicar el logotipo";
            else
                empresa.EmLogotipo = EmLogotipo;
            empresa.EmLeyenda01 = EmLeyenda01;
            empresa.EmLeyenda02 = EmLeyenda02;
            empresa.EmLeyenda03 = EmLeyenda03;
            empresa.EmLeyenda04 = EmLeyenda04;
            empresa.EmLeyenda05 = EmLeyenda05;
            if (DiNumero == "")
                resultado = "Falta indicar el numero directorio";
            else
                empresa.DiNumero = DiNumero;
            empresa.EmPrefijo = EmPrefijo;
            empresa.EmPrefijoPry = EmPrefijoPry;
            empresa.EmGrIdent = EmGrIdent;
            empresa.EmGrIdCot = EmGrIdCot;
            empresa.EmActivo = EmActivo;

            empresa.EmAudUsuMod = EmAudUsuMod;
            empresa.EmAudFeMod = EmAudFeMod;

            if (resultado == "")
                db.updEmpresa(empresa, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            EMPRESA empresa = new EMPRESA();
            if (EmIdent == "")
                resultado = "Falta indicar el identificador";
            else
                empresa.EmIdent = EmIdent;
            empresa.EmActivo = "I";

            empresa.EmAudUsuEl = EmAudUsuEl;
            empresa.EmAudFeEl = EmAudFeEl;

            if (resultado == "")
                db.updEmpresa(empresa, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            EMPRESA empresa = new EMPRESA();
            if (EmIdent == "")
                resultado = "Falta indicar el identificador";
            else
                empresa.EmIdent = EmIdent;

            if (resultado == "")
            {
                EMPRESA item = db.getEmpresa(empresa);
                EmIdent = item.EmIdent;
                EmLogotipo = item.EmLogotipo;
                EmLeyenda01 = item.EmLeyenda01;
                EmLeyenda02 = item.EmLeyenda02;
                EmLeyenda03 = item.EmLeyenda03;
                EmLeyenda04 = item.EmLeyenda04;
                EmLeyenda05 = item.EmLeyenda05;
                DiNumero = item.DiNumero;
                DiNomCorto = item.DiNomCorto;
                EmPrefijo = item.EmPrefijo;
                EmPrefijoPry = item.EmPrefijoPry;
                EmGrIdent = item.EmGrIdent;
                EmGrIdCot = item.EmGrIdCot;
                EmActivo = item.EmActivo;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            EMPRESA empresa = new EMPRESA();
            empresa.EmIdent = EmIdent;

            if (resultado == "")
                listEmp = db.getEmpresas(empresa);

            return resultado;
        }
    }

    public class _Documento
    {
        public string DoIdent { get; set; }
        public string DoTipo { get; set; }
        public string DoFolio { get; set; }
        public int DoVersion { get; set; }
        public string DoVersionL { get; set; }
        public DateTime DoFecha { get; set; }
        public string PyNumero { get; set; }
        public string PyNombre { get; set; }
        public string EmIdent { get; set; }
        public string EmNombre { get; set; }
        public string DiNumero { get; set; }
        public string DiNomCorto { get; set; }
        public int CnNumero01 { get; set; }
        public int CnNumero02 { get; set; }
        public int CnNumero03 { get; set; }
        public int CnNumero04 { get; set; }
        public int CnNumero05 { get; set; }
        public double DoSubTotalMoE { get; set; }
        public double DoTotalMoE { get; set; }
        public string DoMonEx { get; set; }
        public double DoSubTotal { get; set; }
        public double DoDesc { get; set; }
        public double DoPjDesc { get; set; }
        public string DoTipoDesc { get; set; }
        public double DoSubTDesc { get; set; }
        public int DoImpuesto { get; set; }
        public double DoImpImp { get; set; }
        public double DoTotal { get; set; }
        public string DoMoneda { get; set; }
        public string DoNombre { get; set; }
        public string DoPath { get; set; }
        public DateTime DoFechaIni { get; set; }
        public DateTime DoFechaFin { get; set; }
        public string DoEstatus { get; set; }
        public int DoAvance { get; set; }
        public string DoUsuSeg { get; set; }
        public double DoTiCambio { get; set; }
        public string DoReferencia { get; set; }
        public string DoDescripcion { get; set; }
        public string DoDocRef { get; set; }
        public string DoVendedor { get; set; }
        public string DoGrupo { get; set; }
        public int DoGrupoOrden { get; set; }
        public string DoActivo { get; set; }
        public DateTime FeIni { get; set; }
        public DateTime FeFin { get; set; }
        //AUDITORIA
        public string DoAudUsuCre { get; set; }
        public DateTime DoAudFeCre { get; set; }
        public string DoAudUsuMod { get; set; }
        public DateTime DoAudFeMod { get; set; }
        public string DoAudUsuEl { get; set; }
        public DateTime DoAudFeEl { get; set; }

        public List<DOCUMENTO> listDoc { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                DoAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                DoAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                DoAudUsuMod = usuarioCache.nombreUsuario;
                DoAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                DoAudUsuEl = usuarioCache.nombreUsuario;
                DoAudFeEl = DateTime.Now;
            }
        }
        
        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            DOCUMENTO documento = new DOCUMENTO();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                documento.DoIdent = DoIdent;
            if (DoTipo == "")
                resultado = "Falta indicar el tipo";
            else
                documento.DoTipo = DoTipo;
            if (DoFolio == "")
                resultado = "Falta indicar el folio";
            else
                documento.DoFolio = DoFolio;
            if (DoVersion == 0)
                resultado = "Falta indicar la version";
            else
                documento.DoVersion = DoVersion;
            documento.DoVersionL = DoVersionL;
            if (DoFecha == null)
                resultado = "Falta indicar la fecha";
            else
                documento.DoFecha = DoFecha;
            if (PyNumero == "")
                resultado = "Falta indicar el proyecto";
            else
                documento.PyNumero = PyNumero;
            if (EmIdent == "")
                resultado = "Falta indicar la empresa";
            else
                documento.EmIdent = EmIdent;
            if (DiNumero == "")
                resultado = "Falta indicar el cliente";
            else
                documento.DiNumero = DiNumero;
            documento.CnNumero01 = CnNumero01;
            documento.CnNumero02 = CnNumero02;
            documento.CnNumero03 = CnNumero03;
            documento.CnNumero04 = CnNumero04;
            documento.CnNumero05 = CnNumero05;
            documento.DoSubTotalMoE = DoSubTotalMoE;
            documento.DoTotalMoE = DoTotalMoE;
            documento.DoMonEx = DoMonEx;
            documento.DoSubTotal = DoSubTotal;
            documento.DoDesc = DoDesc;
            documento.DoPjDesc = DoPjDesc;
            documento.DoTipoDesc = DoTipoDesc;
            documento.DoImpuesto = DoImpuesto;
            documento.DoTotal = DoTotal;
            if (DoMoneda == "")
                resultado = "Falta indicar la moneda";
            else
                documento.DoMoneda = DoMoneda;
            documento.DoNombre = DoNombre;
            documento.DoPath = DoPath;
            documento.DoFechaIni = DoFechaIni;
            documento.DoFechaFin = DoFechaFin;
            if (DoEstatus == "")
                resultado = "Falta indicar el estatus";
            else
                documento.DoEstatus = DoEstatus;
            documento.DoAvance = DoAvance;
            documento.DoUsuSeg = DoUsuSeg;
            documento.DoTiCambio = DoTiCambio;
            documento.DoReferencia = DoReferencia;
            documento.DoDescripcion = DoDescripcion;
            documento.DoDocRef = DoDocRef;
            documento.DoVendedor = DoVendedor;
            documento.DoGrupo = DoGrupo;
            documento.DoGrupoOrden = DoGrupoOrden;
            documento.DoActivo = "A";

            documento.DoAudUsuCre = DoAudUsuCre;
            documento.DoAudFeCre = DoAudFeCre;

            if (resultado == "")
                db.setDocumento(documento);

            return resultado;
        }
        
        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            DOCUMENTO documento = new DOCUMENTO();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                documento.DoIdent = DoIdent;
            if (DoTipo == "")
                resultado = "Falta indicar el tipo";
            else
                documento.DoTipo = DoTipo;
            if (DoFolio == "")
                resultado = "Falta indicar el folio";
            else
                documento.DoFolio = DoFolio;
            if (DoVersion == 0)
                resultado = "Falta indicar la version";
            else
                documento.DoVersion = DoVersion;
            documento.DoVersionL = DoVersionL;
            if (DoFecha == null)
                resultado = "Falta indicar la fecha";
            else
                documento.DoFecha = DoFecha;
            if (PyNumero == "")
                resultado = "Falta indicar el proyecto";
            else
                documento.PyNumero = PyNumero;
            if (EmIdent == "")
                resultado = "Falta indicar la empresa";
            else
                documento.EmIdent = EmIdent;
            if (DiNumero == "")
                resultado = "Falta indicar el cliente";
            else
                documento.DiNumero = DiNumero;
            documento.CnNumero01 = CnNumero01;
            documento.CnNumero02 = CnNumero02;
            documento.CnNumero03 = CnNumero03;
            documento.CnNumero04 = CnNumero04;
            documento.CnNumero05 = CnNumero05;
            documento.DoSubTotalMoE = DoSubTotalMoE;
            documento.DoTotalMoE = DoTotalMoE;
            documento.DoMonEx = DoMonEx;
            documento.DoSubTotal = DoSubTotal;
            documento.DoDesc = DoDesc;
            documento.DoPjDesc = DoPjDesc;
            documento.DoTipoDesc = DoTipoDesc;
            documento.DoImpuesto = DoImpuesto;
            documento.DoTotal = DoTotal;
            if (DoMoneda == "")
                resultado = "Falta indicar la moneda";
            else
                documento.DoMoneda = DoMoneda;
            documento.DoNombre = DoNombre;
            documento.DoPath = DoPath;
            documento.DoFechaIni = DoFechaIni;
            documento.DoFechaFin = DoFechaFin;
            if (DoEstatus == "")
                resultado = "Falta indicar el estatus";
            else
                documento.DoEstatus = DoEstatus;
            documento.DoAvance = DoAvance;
            documento.DoUsuSeg = DoUsuSeg;
            documento.DoTiCambio = DoTiCambio;
            documento.DoReferencia = DoReferencia;
            documento.DoDescripcion = DoDescripcion;
            documento.DoDocRef = DoDocRef;
            documento.DoVendedor = DoVendedor;
            documento.DoGrupo = DoGrupo;
            documento.DoGrupoOrden = DoGrupoOrden;
            documento.DoActivo = DoActivo;

            documento.DoAudUsuMod = DoAudUsuMod;
            documento.DoAudFeMod = DoAudFeMod;

            if (resultado == "")
                db.updDocumento(documento, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            DOCUMENTO documento = new DOCUMENTO();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                documento.DoIdent = DoIdent;
            documento.DoActivo = "I";

            documento.DoAudUsuEl = DoAudUsuEl;
            documento.DoAudFeEl = DoAudFeEl;

            if (resultado == "")
                db.updDocumento(documento, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            DOCUMENTO documento = new DOCUMENTO();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                documento.DoIdent = DoIdent;

            documento.DoFolio = DoFolio == null ? "" : DoFolio;
            documento.DoTipo = DoTipo;
            documento.DiNumero = DiNumero;
            documento.DiNomCorto = DiNomCorto == null ? "" : DiNomCorto;
            documento.EmIdent = EmIdent;
            documento.DoEstatus = DoEstatus;
            documento.FeIni = FeIni;
            documento.FeFin = FeFin;
            documento.PyNumero = PyNumero == null ? "" : PyNumero;
            documento.PyNombre = PyNombre == null ? "" : PyNombre;
            documento.DoUsuSeg = DoUsuSeg;
            documento.DoVendedor = DoVendedor;

            if (resultado == "")
            {
                DOCUMENTO item = db.getDocumento(documento);
                DoIdent = item.DoIdent;
                DoTipo = item.DoTipo;
                DoFolio = item.DoFolio;
                DoVersion = item.DoVersion;
                DoVersionL = item.DoVersionL;
                DoFecha = item.DoFecha;
                PyNumero = item.PyNumero;
                PyNombre = item.PyNombre;
                EmIdent = item.EmIdent;
                DiNumero = item.DiNumero;
                DiNomCorto = item.DiNomCorto;
                CnNumero01 = item.CnNumero01;
                CnNumero02 = item.CnNumero02;
                CnNumero03 = item.CnNumero03;
                CnNumero04 = item.CnNumero04;
                CnNumero05 = item.CnNumero05;
                DoSubTotalMoE = item.DoSubTotalMoE;
                DoTotalMoE = item.DoTotalMoE;
                DoMonEx = item.DoMonEx;
                DoSubTotal = item.DoSubTotal;
                DoDesc = item.DoDesc;
                DoPjDesc = item.DoPjDesc;
                DoTipoDesc = item.DoTipoDesc;
                DoImpuesto = item.DoImpuesto;
                DoTotal = item.DoTotal;
                DoMoneda = item.DoMoneda;
                DoNombre = item.DoNombre;
                DoPath = item.DoPath;
                DoFechaIni = item.DoFechaIni;
                DoFechaFin = item.DoFechaFin;
                DoEstatus = item.DoEstatus;
                DoAvance = item.DoAvance;
                DoUsuSeg = item.DoUsuSeg;
                DoTiCambio = item.DoTiCambio;
                DoReferencia = item.DoReferencia;
                DoDescripcion = item.DoDescripcion;
                DoDocRef = item.DoDocRef;
                DoVendedor = item.DoVendedor;
                DoGrupo = item.DoGrupo;
                DoGrupoOrden = item.DoGrupoOrden;
                FeIni = item.FeIni;
                FeFin = item.FeFin;
                DoActivo = item.DoActivo;
                DoAudUsuCre = item.DoAudUsuCre;
                DoAudFeCre = item.DoAudFeCre;
                DoAudUsuMod = item.DoAudUsuMod;
                DoAudFeMod = item.DoAudFeMod;
                DoAudUsuEl = item.DoAudUsuEl;
                DoAudFeEl = item.DoAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            DOCUMENTO documento = new DOCUMENTO();

            documento.DoIdent = DoIdent;
            documento.DoFolio = DoFolio == null ? "" : DoFolio;
            documento.DoTipo = DoTipo;
            documento.DiNumero = DiNumero;
            documento.DiNomCorto = DiNomCorto == null ? "" : DiNomCorto;
            documento.EmIdent = EmIdent;
            documento.DoEstatus = DoEstatus;
            documento.FeIni = FeIni;
            documento.FeFin = FeFin;
            documento.PyNumero = PyNumero == null ? "" : PyNumero;
            documento.PyNombre = PyNombre == null ? "" : PyNombre;
            documento.DoUsuSeg = DoUsuSeg;
            documento.DoVendedor = DoVendedor;

            if (resultado == "")
                listDoc = db.getDocumentos(documento);

            return resultado;
        }

        public _Documento copiaDocumento()
        {
            _Documento original = new _Documento();
            _DocConcepto docCon = new _DocConcepto();
            _DocNota docNot = new _DocNota();
            _DocCPartida docCPar = new _DocCPartida();
            _DocCPNota docCPN = new _DocCPNota();
            _DocSeguimiento docSeg = new _DocSeguimiento();

            original.DoIdent = DoIdent;
            original.DoTipo = "";
            original.DiNumero = "";
            original.EmIdent = "";
            original.DoEstatus = "";
            original.FeIni = DateTime.Now;
            original.FeFin = DateTime.Now;
            original.DoUsuSeg = "";
            original.DoVendedor = "";
            original.consultaUno();

            int ver = 1;// version(original.DoIdent, 0);
                        //string DoIdentCopia = original.DoIdent + ver.ToString().PadLeft(2, '0');
            m = modo.insert;
            string DoIdentCopia = foliador(m, 'N');
            _Documento copia = original;
            
            auditoria();

            copia.DoIdent = DoIdentCopia;
            copia.DoFolio = DoIdentCopia;
            copia.DoVersion = DoVersion;
            copia.DoVersionL = DoVersionL;
            copia.PyNumero = PyNumero;
            copia.DoTipo = DoTipo;
            copia.EmIdent = EmIdent;
            copia.DiNumero = DiNumero;
            copia.DoFecha = DateTime.Now;
            copia.DoFechaIni = DateTime.Now.AddDays(-1);
            copia.DoFechaFin = DateTime.Now.AddDays(-1);
            copia.DoEstatus = "NUEVO";
            copia.DoUsuSeg = usuarioCache.nombreUsuario;
            copia.DoDocRef = DoIdent;
            copia.guardar();

            docCon.DoIdent = DoIdent;
            docCon.CoNumero = 0;
            docCon.listado();

            docNot.DoIdent = DoIdent;
            docNot.DnNumero = 0;
            docNot.DnTipo = "";
            docNot.NoIdent = "";
            docNot.listado();

            docSeg.DoIdent = DoIdent;
            docSeg.DsNumero = 0;
            docSeg.listado();

            foreach(DOCCONCEPTO itemDC in docCon.listDoC)
            {
                docCPar.DoIdent = itemDC.DoIdent;
                docCPar.CoNumero = itemDC.CoNumero;
                docCPar.DpNumero = 0;
                docCPar.listado();

                docCon.DoIdent = DoIdentCopia;
                docCon.CoNumero = itemDC.CoNumero;
                docCon.DcDescripcion = itemDC.DcDescripcion;
                docCon.DcPjDesc = itemDC.DcPjDesc;
                docCon.DcImpDesc = itemDC.DcImpDesc;
                docCon.DcSubtotal = itemDC.DcSubtotal;
                docCon.DcTotal = itemDC.DcTotal;
                docCon.DcMoneda = itemDC.DcMoneda;
                docCon.DcEstatus = itemDC.DcEstatus;
                docCon.DcAvance = itemDC.DcAvance;
                docCon.DcReferencia = itemDC.DcReferencia;
                /*docCon.DcFeInicio = itemDC.DcFeInicio;
                docCon.DcFeTermino = itemDC.DcFeTermino;
                docCon.DcFeCancel = itemDC.DcFeCancel;*/
                docCon.DcOrden = itemDC.DcOrden;
                docCon.DcActivo = itemDC.DcActivo;
                docCon.guardar();

                foreach(DOCCPARTIDA itemCP in docCPar.listDCP)
                {
                    docCPN.DoIdent = itemDC.DoIdent;
                    docCPN.CoNumero = itemDC.CoNumero;
                    docCPN.DpNumero = itemCP.DpNumero;
                    docCPN.DtNumero = 0;
                    docCPN.listado();

                    docCPar.DoIdent = DoIdentCopia;
                    docCPar.CoNumero = itemCP.CoNumero;
                    docCPar.DpNumero = itemCP.DpNumero;
                    docCPar.ArIdent = itemCP.ArIdent;
                    docCPar.DiNumero = itemCP.DiNumero;
                    docCPar.DpDescripcion = itemCP.DpDescripcion;
                    docCPar.DpCantidad = itemCP.DpCantidad;
                    docCPar.DpUnidad = itemCP.DpUnidad;
                    docCPar.DpCosto = itemCP.DpCosto;
                    docCPar.DpPjCosto = itemCP.DpPjCosto;
                    docCPar.DpPrecio = itemCP.DpPrecio;
                    docCPar.DpSubtotal = itemCP.DpSubtotal;
                    docCPar.DpPjDesc = itemCP.DpPjDesc;
                    docCPar.DpImpDesc = itemCP.DpImpDesc;
                    docCPar.DpImporteMoE = itemCP.DpImporteMoE;
                    docCPar.DpMonEx = itemCP.DpMonEx;
                    docCPar.DpImporte = itemCP.DpImporte;
                    docCPar.DpTratamiento = itemCP.DpTratamiento;
                    docCPar.DpEstatus = itemCP.DpEstatus;
                    docCPar.DpAvance = itemCP.DpAvance;
                    docCPar.DpReferencia = itemCP.DpReferencia;
                    docCPar.DpFabricado = itemCP.DpFabricado;
                    /*docCPar.DpFePedidoPg = itemCP.DpFePedidoPg;
                    docCPar.DpFePedidoRe = itemCP.DpFePedidoRe;
                    docCPar.DpFeReciboPg = itemCP.DpFeReciboPg;
                    docCPar.DpFeReciboRe = itemCP.DpFeReciboRe;
                    docCPar.DpFeEnvioPg = itemCP.DpFeEnvioPg;
                    docCPar.DpFeEnvioRe = itemCP.DpFeEnvioRe;
                    docCPar.DpFeEntregaPg = itemCP.DpFeEntregaPg;
                    docCPar.DpFeEntregaRe = itemCP.DpFeEntregaRe;
                    docCPar.DpFeCancel = itemCP.DpFeCancel;*/
                    docCPar.DpOrden = itemCP.DpOrden;
                    docCPar.DpActivo = itemCP.DpActivo;
                    docCPar.guardar();

                    foreach (DOCCPNOTA itemPN in docCPN.listDPN)
                    {
                        docCPN.DoIdent = DoIdentCopia;
                        docCPN.CoNumero = itemPN.CoNumero;
                        docCPN.DpNumero = itemPN.DpNumero;
                        docCPN.DtNumero = itemPN.DtNumero;
                        docCPN.DtDescripcion = itemPN.DtDescripcion;
                        docCPN.DtTipo = itemPN.DtTipo;
                        docCPN.DtOrden = itemPN.DtOrden;
                        docCPN.NoIdent = itemPN.NoIdent;
                        docCPN.DtArIdent = itemPN.DtArIdent;
                        docCPN.DtAnNumero = itemPN.DtAnNumero;
                        docCPN.DtActivo = itemPN.DtActivo;
                        docCPN.guardar();
                    }
                }
            }

            foreach(DOCNOTA itemDN in docNot.listDoN)
            {
                docNot.DoIdent = DoIdentCopia;
                docNot.DnNumero = itemDN.DnNumero;
                docNot.DnDescripcion = itemDN.DnDescripcion;
                docNot.DnTipo = itemDN.DnTipo;
                docNot.DnOrden = itemDN.DnOrden;
                docNot.NoIdent = itemDN.NoIdent;
                docNot.DnActivo = itemDN.DnActivo;
                docNot.guardar();
            }

            foreach(DOCSEGUIMIENTO itemDS in docSeg.listDoS)
            {
                docSeg.DoIdent = DoIdentCopia;
                docSeg.DsNumero = itemDS.DsNumero;
                docSeg.DsFechaSeg = itemDS.DsFechaSeg;
                docSeg.DsDescripcion = itemDS.DsDescripcion;
                docSeg.DsFechaReal = itemDS.DsFechaReal;
                docSeg.DsObservacion = itemDS.DsObservacion;
                docSeg.DsActivo = itemDS.DsActivo;
                docSeg.guardar();
            }

            return copia;
        }

        private string version(string PyNum)
        {
            return db.getVerDocumento(PyNum);
        }

        private int version(string PyNum, string DoVerL)
        {
            return db.getVerDocumento(PyNum, DoVerL);
        }

        public string foliador(modo m, char cf)
        {
            string folio = "";

            _Empresa emp = new _Empresa();
            emp.EmIdent = EmIdent;
            emp.consultaUno();

            DateTime dt = DateTime.Now;

            string fe = "";

            if (cf == 'S' || m == modo.insert)
                fe = dt.Year.ToString().Substring(2, 2).PadLeft(2, '0') + dt.Month.ToString().PadLeft(2, '0') + dt.Day.ToString().PadLeft(2, '0');
            else if (cf == 'N' && m == modo.update)
                fe = DoFecha.Year.ToString().Substring(2, 2).PadLeft(2, '0') + DoFecha.Month.ToString().PadLeft(2, '0') + DoFecha.Day.ToString().PadLeft(2, '0');

            string ver = "", vL = "";

            if (m == modo.insert)
            {
                ver = version(PyNumero);
                if (ver == "")
                {
                    vL = "A";
                    ver = vL.Trim() + "1";
                }
                else
                {
                    vL = Convert.ToString(Convert.ToChar(Convert.ToInt16(Encoding.ASCII.GetBytes(ver)[0]) + 1));
                    ver = vL.Trim() + "1";
                }
            }
            else if (m == modo.update)
            {
                int v = version(PyNumero, DoVersionL) + 1;
                vL = DoVersionL;
                ver = DoVersionL.Trim() + v.ToString().Trim();
            }
            DoVersionL = vL;
            folio = emp.EmPrefijo.Substring(0, 2) + PyNumero.PadLeft(4, '0') + "-" + fe.Trim() + "-" + ver.Trim();
            
            return folio;
        }

        /*private int version (string DoIdentOri, int ver)
        {
            int v = ver + 1;

            string DoIdentCop;

            if (v > 1)
                DoIdentCop = DoIdentOri + v.ToString().PadLeft(2, '0');
            else
                DoIdentCop = DoIdentOri;

            _Documento ori = new _Documento();
            ori.DoIdent = DoIdentCop;
            ori.DoTipo = "";
            ori.DiNumero = "";
            ori.EmIdent = "";
            ori.DoEstatus = "";
            ori.FeIni = DateTime.Now;
            ori.FeFin = DateTime.Now;
            ori.DoUsuSeg = "";
            ori.DoVendedor = "";
            ori.consultaUno();

            if (ori.DoAudUsuCre != null)
                v = version(DoIdentOri, v);

            return v;
        }*/

        private string folio (string tipo, string v)
        {
            string resp = "";
            
            string fol = PyNumero.Trim() + DoFecha.Year.ToString().Substring(3, 2) + DoFecha.Month.ToString().PadLeft(2, '0') + DoFecha.Day.ToString().PadLeft(2, '0');

            if (tipo == "Mayor")
                fol = fol + v + "";
            else if (tipo == "menor")
                fol = fol;
            return resp;
        }
    }

    public class _DocNota
    {
        public string DoIdent { get; set; }
        public int DnNumero { get; set; }
        public string DnDescripcion { get; set; }
        public string DnTipo { get; set; }
        public int DnOrden { get; set; }
        public string NoIdent { get; set; }
        public string DnActivo { get; set; }
        //AUDITORIA
        public string DnAudUsuCre { get; set; }
        public DateTime DnAudFeCre { get; set; }
        public string DnAudUsuMod { get; set; }
        public DateTime DnAudFeMod { get; set; }
        public string DnAudUsuEl { get; set; }
        public DateTime DnAudFeEl { get; set; }

        public List<DOCNOTA> listDoN { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                DnAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                DnAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                DnAudUsuMod = usuarioCache.nombreUsuario;
                DnAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                DnAudUsuEl = usuarioCache.nombreUsuario;
                DnAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            DOCNOTA docnota = new DOCNOTA();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                docnota.DoIdent = DoIdent;
            if (DnNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                docnota.DnNumero = DnNumero;
            docnota.DnDescripcion = DnDescripcion;
            docnota.DnTipo = DnTipo;
            docnota.DnOrden = DnOrden;
            docnota.NoIdent = NoIdent;
            docnota.DnActivo = "A";

            docnota.DnAudUsuCre = DnAudUsuCre;
            docnota.DnAudFeCre = DnAudFeCre;

            if (resultado == "")
                db.setDocNota(docnota);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            DOCNOTA docnota = new DOCNOTA();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                docnota.DoIdent = DoIdent;
            if (DnNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                docnota.DnNumero = DnNumero;
            docnota.DnDescripcion = DnDescripcion;
            docnota.DnTipo = DnTipo;
            docnota.DnOrden = DnOrden;
            docnota.NoIdent = NoIdent;
            docnota.DnActivo = DnActivo;

            docnota.DnAudUsuMod = DnAudUsuMod;
            docnota.DnAudFeMod = DnAudFeMod;

            if (resultado == "")
                db.updDocNota(docnota, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            DOCNOTA docnota = new DOCNOTA();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                docnota.DoIdent = DoIdent;
            if (DnNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                docnota.DnNumero = DnNumero;
            docnota.DnActivo = "I";

            docnota.DnAudUsuEl = DnAudUsuEl;
            docnota.DnAudFeEl = DnAudFeEl;

            if (resultado == "")
                db.updDocNota(docnota, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            DOCNOTA docnota = new DOCNOTA();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                docnota.DoIdent = DoIdent;
            if (DnNumero == 0 && NoIdent == "")
                resultado = "Falta indicar el concecutivo o el identificador de la nota";
            else
            {
                docnota.DnNumero = DnNumero;
                docnota.NoIdent = NoIdent;
            }
            docnota.DnTipo = DnTipo;

            if (resultado == "")
            {
                DOCNOTA item = db.getDocNota(docnota);
                DoIdent = item.DoIdent;
                DnNumero = item.DnNumero;
                DnDescripcion = item.DnDescripcion;
                DnTipo = item.DnTipo;
                DnOrden = item.DnOrden;
                NoIdent = item.NoIdent;
                DnActivo = item.DnActivo;
                DnAudUsuCre = item.DnAudUsuCre;
                DnAudFeCre = item.DnAudFeCre;
                DnAudUsuMod = item.DnAudUsuMod;
                DnAudFeMod = item.DnAudFeMod;
                DnAudUsuEl = item.DnAudUsuEl;
                DnAudFeEl = item.DnAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            DOCNOTA docnota = new DOCNOTA();

            docnota.DoIdent = DoIdent;
            docnota.DnNumero = DnNumero;
            docnota.DnTipo = DnTipo;
            docnota.NoIdent = NoIdent;

            if (resultado == "")
                listDoN = db.getDocNotas(docnota);

            return resultado;
        }
    }

    public class _DocConcepto
    {
        public string DoIdent { get; set; }
        public int CoNumero { get; set; }
        public string CoDescripcion { get; set; }
        public string DcDescripcion { get; set; }
        public double DcPjDesc { get; set; }
        public double DcImpDesc { get; set; }
        public double DcSubtotal { get; set; }
        public double DcTotal { get; set; }
        public string DcMoneda { get; set; }
        public string DcEstatus { get; set; }
        public int DcAvance { get; set; }
        public string DcReferencia { get; set; }
        public DateTime DcFeInicio { get; set; }
        public DateTime DcFeTermino { get; set; }
        public DateTime DcFeCancel { get; set; }
        public int DcOrden { get; set; }
        public string DcActivo { get; set; }
        //AUDITORIA
        public string DcAudUsuCre { get; set; }
        public DateTime DcAudFeCre { get; set; }
        public string DcAudUsuMod { get; set; }
        public DateTime DcAudFeMod { get; set; }
        public string DcAudUsuEl { get; set; }
        public DateTime DcAudFeEl { get; set; }

        public List<DOCCONCEPTO> listDoC { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                DcAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                DcAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                DcAudUsuMod = usuarioCache.nombreUsuario;
                DcAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                DcAudUsuEl = usuarioCache.nombreUsuario;
                DcAudFeEl = DateTime.Now;
            }
        }
        
        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            DOCCONCEPTO docconcepto = new DOCCONCEPTO();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                docconcepto.DoIdent = DoIdent;
            if (CoNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                docconcepto.CoNumero = CoNumero;
            docconcepto.DcDescripcion = DcDescripcion;
            docconcepto.DcPjDesc = DcPjDesc;
            docconcepto.DcImpDesc = DcImpDesc;
            docconcepto.DcSubtotal = DcSubtotal;
            docconcepto.DcTotal = DcTotal;
            docconcepto.DcMoneda = DcMoneda;
            docconcepto.DcEstatus = DcEstatus;
            docconcepto.DcAvance = DcAvance;
            docconcepto.DcReferencia = DcReferencia;
            /*docconcepto.DcFeInicio = DcFeInicio;
            docconcepto.DcFeTermino = DcFeTermino;
            docconcepto.DcFeCancel = DcFeCancel;*/
            docconcepto.DcOrden = DcOrden;
            docconcepto.DcActivo = "A";

            docconcepto.DcAudUsuCre = DcAudUsuCre;
            docconcepto.DcAudFeCre = DcAudFeCre;

            if (resultado == "")
                db.setDocConcepto(docconcepto);

            return resultado;
        }
        
        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            DOCCONCEPTO docconcepto = new DOCCONCEPTO();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                docconcepto.DoIdent = DoIdent;
            if (CoNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                docconcepto.CoNumero = CoNumero;
            docconcepto.DcDescripcion = DcDescripcion;
            docconcepto.DcPjDesc = DcPjDesc;
            docconcepto.DcImpDesc = DcImpDesc;
            docconcepto.DcSubtotal = DcSubtotal;
            docconcepto.DcTotal = DcTotal;
            docconcepto.DcMoneda = DcMoneda;
            docconcepto.DcEstatus = DcEstatus;
            docconcepto.DcAvance = DcAvance;
            docconcepto.DcReferencia = DcReferencia;
            /*docconcepto.DcFeInicio = DcFeInicio;
            docconcepto.DcFeTermino = DcFeTermino;
            docconcepto.DcFeCancel = DcFeCancel;*/
            docconcepto.DcOrden = DcOrden;
            docconcepto.DcActivo = "A";

            docconcepto.DcAudUsuMod = DcAudUsuMod;
            docconcepto.DcAudFeMod = DcAudFeMod;

            if (resultado == "")
                db.updDocConcepto(docconcepto, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            DOCCONCEPTO docconcepto = new DOCCONCEPTO();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                docconcepto.DoIdent = DoIdent;
            if (CoNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                docconcepto.CoNumero = CoNumero;
            docconcepto.DcActivo = "I";

            docconcepto.DcAudUsuEl = DcAudUsuEl;
            docconcepto.DcAudFeEl = DcAudFeEl;

            if (resultado == "")
                db.updDocConcepto(docconcepto, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            DOCCONCEPTO docconcepto = new DOCCONCEPTO();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                docconcepto.DoIdent = DoIdent;
            if (CoNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                docconcepto.CoNumero = CoNumero;

            if (resultado == "")
            {
                DOCCONCEPTO item = db.getDocConcepto(docconcepto);
                DoIdent = item.DoIdent;
                CoNumero = item.CoNumero;
                CoDescripcion = item.CoDescripcion;
                DcDescripcion = item.DcDescripcion;
                DcPjDesc = item.DcPjDesc;
                DcImpDesc = item.DcImpDesc;
                DcSubtotal = item.DcSubtotal;
                DcTotal = item.DcTotal;
                DcMoneda = item.DcMoneda;
                DcEstatus = item.DcEstatus;
                DcAvance = item.DcAvance;
                DcReferencia = item.DcReferencia;
                /*DcFeInicio = item.DcFeInicio;
                DcFeTermino = item.DcFeTermino;
                DcFeCancel = item.DcFeCancel;*/
                DcOrden = item.DcOrden;
                DcActivo = item.DcActivo;
                DcAudUsuCre = item.DcAudUsuCre;
                DcAudFeCre = item.DcAudFeCre;
                DcAudUsuMod = item.DcAudUsuMod;
                DcAudFeMod = item.DcAudFeMod;
                DcAudUsuEl = item.DcAudUsuEl;
                DcAudFeEl = item.DcAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            DOCCONCEPTO docconcepto = new DOCCONCEPTO();

            docconcepto.DoIdent = DoIdent;
            docconcepto.CoNumero = CoNumero;

            if (resultado == "")
                listDoC = db.getDocConceptos(docconcepto);

            return resultado;
        }
    }

    public class _Concepto
    {
        public int CoNumero { get; set; }
        public string CoDescripcion { get; set; }
        public string CoActivo { get; set; }
        //AUDITORIA
        public string CoAudUsuCre { get; set; }
        public DateTime CoAudFeCre { get; set; }
        public string CoAudUsuMod { get; set; }
        public DateTime CoAudFeMod { get; set; }
        public string CoAudUsuEl { get; set; }
        public DateTime CoAudFeEl { get; set; }

        public List<CONCEPTO> listCon { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                CoAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                CoAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                CoAudUsuMod = usuarioCache.nombreUsuario;
                CoAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                CoAudUsuEl = usuarioCache.nombreUsuario;
                CoAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            CONCEPTO concepto = new CONCEPTO();
            if (CoNumero == 0)
                resultado = "Falta indicar el numero concecutivo";
            else
                concepto.CoNumero = CoNumero;
            concepto.CoDescripcion = CoDescripcion;
            concepto.CoActivo = "A";

            concepto.CoAudUsuCre = CoAudUsuCre;
            concepto.CoAudFeCre = CoAudFeCre;

            if (resultado == "")
                db.setConcepto(concepto);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            CONCEPTO concepto = new CONCEPTO();
            if (CoNumero == 0)
                resultado = "Falta indicar el numero concecutivo";
            else
                concepto.CoNumero = CoNumero;
            concepto.CoDescripcion = CoDescripcion;
            concepto.CoActivo = CoActivo;

            concepto.CoAudUsuMod = CoAudUsuMod;
            concepto.CoAudFeMod = CoAudFeMod;

            if (resultado == "")
                db.updConcepto(concepto, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            CONCEPTO concepto = new CONCEPTO();
            if (CoNumero == 0)
                resultado = "Es necesario el numero concecutivo";
            else
                concepto.CoNumero = CoNumero;
            concepto.CoDescripcion = CoDescripcion;
            concepto.CoActivo = "I";

            concepto.CoAudUsuEl = CoAudUsuEl;
            concepto.CoAudFeEl = CoAudFeEl;

            if (resultado == "")
                db.updConcepto(concepto, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            CONCEPTO concepto = new CONCEPTO();
            if (CoNumero == 0)
                resultado = "Es necesario el numero concecutivo";
            else
                concepto.CoNumero = CoNumero;
            

            if (resultado == "")
            {
                CONCEPTO item = db.getConcepto(concepto);
                CoNumero = item.CoNumero;
                CoDescripcion = item.CoDescripcion;
                CoActivo = item.CoActivo;
                CoAudUsuCre = item.CoAudUsuCre;
                CoAudFeCre = item.CoAudFeCre;
                CoAudUsuMod = item.CoAudUsuMod;
                CoAudFeMod = item.CoAudFeMod;
                CoAudUsuEl = item.CoAudUsuEl;
                CoAudFeEl = item.CoAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            CONCEPTO concepto = new CONCEPTO();
            
            if (resultado == "")
                listCon = db.getConceptos(concepto);

            return resultado;
        }
    }

    public class _DocCPartida
    {
        public string DoIdent { get; set; }
        public int CoNumero { get; set; }
        public int DpNumero { get; set; }
        public string ArIdent { get; set; }
        public string DiNumero { get; set; }
        public string DpDescripcion { get; set; }
        public double DpCantidad { get; set; }
        public string DpUnidad { get; set; }
        public double DpCosto { get; set; }
        public double DpPjCosto { get; set; }
        public double DpPrecio { get; set; }
        public double DpSubtotal { get; set; }
        public double DpPjDesc { get; set; }
        public double DpImpDesc { get; set; }
        public double DpImporteMoE { get; set; }
        public string DpMonEx { get; set; }
        public double DpImporte { get; set; }
        public string DpTratamiento { get; set; }
        public string DpEstatus { get; set; }
        public int DpAvance { get; set; }
        public string DpReferencia { get; set; }
        public string DpFabricado { get; set; }
        public DateTime DpFePedidoPg { get; set; }
        public DateTime DpFePedidoRe { get; set; }
        public DateTime DpFeReciboPg { get; set; }
        public DateTime DpFeReciboRe { get; set; }
        public DateTime DpFeEnvioPg { get; set; }
        public DateTime DpFeEnvioRe { get; set; }
        public DateTime DpFeEntregaPg { get; set; }
        public DateTime DpFeEntregaRe { get; set; }
        public DateTime DpFeCancel { get; set; }
        public int DpOrden { get; set; }
        public string DpActivo { get; set; }
        //AUDITORIA
        public string DpAudUsuCre { get; set; }
        public DateTime DpAudFeCre { get; set; }
        public string DpAudUsuMod { get; set; }
        public DateTime DpAudFeMod { get; set; }
        public string DpAudUsuEl { get; set; }
        public DateTime DpAudFeEl { get; set; }
        //EXTERNOS
        public string ArCodigo { get; set; }
        public double ArPrecioPub { get; set; }

        public PARTIDASDOC partidaDoc { get; set; }
        public List<PARTIDASDOC> partidasDoc { get; set; }
        public List<DOCCPARTIDA> listDCP { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                DpAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                DpAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                DpAudUsuMod = usuarioCache.nombreUsuario;
                DpAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                DpAudUsuEl = usuarioCache.nombreUsuario;
                DpAudFeEl = DateTime.Now;
            }
        }
        
        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            DOCCPARTIDA doccpartida = new DOCCPARTIDA();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                doccpartida.DoIdent = DoIdent;
            if (CoNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                doccpartida.CoNumero = CoNumero;
            if (DpNumero == 0)
                resultado = "Falta indicar el numero partida";
            else
                doccpartida.DpNumero = DpNumero;
            if (ArIdent == "")
                resultado = "Falta indicar el articulo";
            else
                doccpartida.ArIdent = ArIdent;
            doccpartida.DiNumero = DiNumero;
            doccpartida.DpDescripcion = DpDescripcion;
            if (DpCantidad == 0)
                resultado = "Falta indicar la cantidad";
            else
                doccpartida.DpCantidad = DpCantidad;
            doccpartida.DpUnidad = DpUnidad;
            doccpartida.DpCosto = DpCosto;
            doccpartida.DpPjCosto = DpPjCosto;
            doccpartida.DpPrecio = DpPrecio;
            doccpartida.DpSubtotal = DpSubtotal;
            doccpartida.DpPjDesc = DpPjDesc;
            doccpartida.DpImpDesc = DpImpDesc;
            doccpartida.DpImporteMoE = DpImporteMoE;
            doccpartida.DpMonEx = DpMonEx;
            doccpartida.DpImporte = DpImporte;
            doccpartida.DpTratamiento = DpTratamiento;
            doccpartida.DpEstatus = DpEstatus;
            doccpartida.DpAvance = DpAvance;
            doccpartida.DpReferencia = DpReferencia;
            doccpartida.DpFabricado = DpFabricado;
            /*doccpartida.DpFePedidoPg = DpFePedidoPg;
            doccpartida.DpFePedidoRe = DpFePedidoRe;
            doccpartida.DpFeReciboPg = DpFeReciboPg;
            doccpartida.DpFeReciboRe = DpFeReciboRe;
            doccpartida.DpFeEnvioPg = DpFeEnvioPg;
            doccpartida.DpFeEnvioRe = DpFeEnvioRe;
            doccpartida.DpFeEntregaPg = DpFeEntregaPg;
            doccpartida.DpFeEntregaRe = DpFeEntregaRe;
            doccpartida.DpFeCancel = DpFeCancel;*/
            doccpartida.DpOrden = DpOrden;
            doccpartida.DpActivo = "A";

            doccpartida.DpAudUsuCre = DpAudUsuCre;
            doccpartida.DpAudFeCre = DpAudFeCre;

            if (resultado == "")
                db.setDocCPartida(doccpartida);

            return resultado;
        }
        
        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            DOCCPARTIDA doccpartida = new DOCCPARTIDA();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                doccpartida.DoIdent = DoIdent;
            if (CoNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                doccpartida.CoNumero = CoNumero;
            if (DpNumero == 0)
                resultado = "Falta indicar el numero partida";
            else
                doccpartida.DpNumero = DpNumero;
            if (ArIdent == "")
                resultado = "Falta indicar el articulo";
            else
                doccpartida.ArIdent = ArIdent;
            doccpartida.DiNumero = DiNumero;
            doccpartida.DpDescripcion = DpDescripcion;
            if (DpCantidad == 0)
                resultado = "Falta indicar la cantidad";
            else
                doccpartida.DpCantidad = DpCantidad;
            doccpartida.DpUnidad = DpUnidad;
            doccpartida.DpCosto = DpCosto;
            doccpartida.DpPjCosto = DpPjCosto;
            doccpartida.DpPrecio = DpPrecio;
            doccpartida.DpSubtotal = DpSubtotal;
            doccpartida.DpPjDesc = DpPjDesc;
            doccpartida.DpImpDesc = DpImpDesc;
            doccpartida.DpImporteMoE = DpImporteMoE;
            doccpartida.DpMonEx = DpMonEx;
            doccpartida.DpImporte = DpImporte;
            doccpartida.DpTratamiento = DpTratamiento;
            doccpartida.DpEstatus = DpEstatus;
            doccpartida.DpAvance = DpAvance;
            doccpartida.DpReferencia = DpReferencia;
            doccpartida.DpFabricado = DpFabricado;
            /*doccpartida.DpFePedidoPg = DpFePedidoPg;
            doccpartida.DpFePedidoRe = DpFePedidoRe;
            doccpartida.DpFeReciboPg = DpFeReciboPg;
            doccpartida.DpFeReciboRe = DpFeReciboRe;
            doccpartida.DpFeEnvioPg = DpFeEnvioPg;
            doccpartida.DpFeEnvioRe = DpFeEnvioRe;
            doccpartida.DpFeEntregaPg = DpFeEntregaPg;
            doccpartida.DpFeEntregaRe = DpFeEntregaRe;
            doccpartida.DpFeCancel = DpFeCancel;*/
            doccpartida.DpOrden = DpOrden;
            doccpartida.DpActivo = "A";

            doccpartida.DpAudUsuMod = DpAudUsuMod;
            doccpartida.DpAudFeMod = DpAudFeMod;

            if (resultado == "")
                db.updDocCPartida(doccpartida, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            DOCCPARTIDA doccpartida = new DOCCPARTIDA();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                doccpartida.DoIdent = DoIdent;
            if (CoNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                doccpartida.CoNumero = CoNumero;
            if (DpNumero == 0)
                resultado = "Falta indicar el numero partida";
            else
                doccpartida.DpNumero = DpNumero;
            doccpartida.DpActivo = "I";

            doccpartida.DpAudUsuEl = DpAudUsuEl;
            doccpartida.DpAudFeEl = DpAudFeEl;

            if (resultado == "")
                db.updDocCPartida(doccpartida, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            DOCCPARTIDA doccpartida = new DOCCPARTIDA();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                doccpartida.DoIdent = DoIdent;
            if (CoNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                doccpartida.CoNumero = CoNumero;
            if (DpNumero == 0)
                resultado = "Falta indicar el numero partida";
            else
                doccpartida.DpNumero = DpNumero;

            if (resultado == "")
            {
                DOCCPARTIDA item = db.getDocCPartida(doccpartida);
                DoIdent = item.DoIdent;
                CoNumero = item.CoNumero;
                DpNumero = item.DpNumero;
                ArIdent = item.ArIdent;
                DiNumero = item.DiNumero;
                DpDescripcion = item.DpDescripcion;
                DpCantidad = item.DpCantidad;
                DpUnidad = item.DpUnidad;
                DpCosto = item.DpCosto;
                DpPjCosto = item.DpPjCosto;
                DpPrecio = item.DpPrecio;
                DpSubtotal = item.DpSubtotal;
                DpPjDesc = item.DpPjDesc;
                DpImpDesc = item.DpImpDesc;
                DpImporteMoE = item.DpImporteMoE;
                DpMonEx = item.DpMonEx;
                DpImporte = item.DpImporte;
                DpTratamiento = item.DpTratamiento;
                DpEstatus = item.DpEstatus;
                DpAvance = item.DpAvance;
                DpReferencia = item.DpReferencia;
                DpFabricado = item.DpFabricado;
                /*DpFePedidoPg = item.DpFePedidoPg;
                DpFePedidoRe = item.DpFePedidoRe;
                DpFeReciboPg = item.DpFeReciboPg;
                DpFeReciboRe = item.DpFeReciboRe;
                DpFeEnvioPg = item.DpFeEnvioPg;
                DpFeEnvioRe = item.DpFeEnvioRe;
                DpFeEntregaPg = item.DpFeEntregaPg;
                DpFeEntregaRe = item.DpFeEntregaRe;
                DpFeCancel = item.DpFeCancel;*/
                ArCodigo = item.ArCodigo;
                ArPrecioPub = item.ArPrecioPub;
                DpOrden = item.DpOrden;
                DpActivo = item.DpActivo;
                DpAudUsuCre = item.DpAudUsuCre;
                DpAudFeCre = item.DpAudFeCre;
                DpAudUsuMod = item.DpAudUsuMod;
                DpAudFeMod = item.DpAudFeMod;
                DpAudUsuEl = item.DpAudUsuEl;
                DpAudFeEl = item.DpAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            DOCCPARTIDA doccpartida = new DOCCPARTIDA();

            doccpartida.DoIdent = DoIdent;
            doccpartida.CoNumero = CoNumero;
            doccpartida.DpNumero = DpNumero;

            if (resultado == "")
                listDCP = db.getDocCPartidas(doccpartida);

            return resultado;
        }

        public string listadoPartidas()
        {
            string resultado = "";

            if (resultado == "")
                partidasDoc = db.getPartidasDosc(partidaDoc);

            return resultado;
        }
    }

    public class _DocCPNota
    {
        public string DoIdent { get; set; }
        public int CoNumero { get; set; }
        public int DpNumero { get; set; }
        public int DtNumero { get; set; }
        public string DtDescripcion { get; set; }
        public string DtTipo { get; set; }
        public int DtOrden { get; set; }
        public string NoIdent { get; set; }
        public string DtArIdent { get; set; }
        public int DtAnNumero { get; set; }
        public string DtActivo { get; set; }
        //AUDITORIA
        public string DtAudUsuCre { get; set; }
        public DateTime DtAudFeCre { get; set; }
        public string DtAudUsuMod { get; set; }
        public DateTime DtAudFeMod { get; set; }
        public string DtAudUsuEl { get; set; }
        public DateTime DtAudFeEl { get; set; }

        public List<DOCCPNOTA> listDPN { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                DtAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                DtAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                DtAudUsuMod = usuarioCache.nombreUsuario;
                DtAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                DtAudUsuEl = usuarioCache.nombreUsuario;
                DtAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            DOCCPNOTA doccpnota = new DOCCPNOTA();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                doccpnota.DoIdent = DoIdent;
            if (CoNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                doccpnota.CoNumero = CoNumero;
            if (DpNumero == 0)
                resultado = "Falta indicar el numero partida";
            else
                doccpnota.DpNumero = DpNumero;
            if (DtNumero == 0)
                resultado = "Falta indicar el numero de nota";
            else
                doccpnota.DtNumero = DtNumero;
            doccpnota.DtDescripcion = DtDescripcion;
            doccpnota.DtTipo = DtTipo;
            doccpnota.DtOrden = DtOrden;
            doccpnota.NoIdent = NoIdent;
            doccpnota.DtArIdent = DtArIdent;
            doccpnota.DtAnNumero = DtAnNumero;
            doccpnota.DtActivo = "A";

            doccpnota.DtAudUsuCre = DtAudUsuCre;
            doccpnota.DtAudFeCre = DtAudFeCre;

            if (resultado == "")
                db.setDocCPNota(doccpnota);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            DOCCPNOTA doccpnota = new DOCCPNOTA();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                doccpnota.DoIdent = DoIdent;
            if (CoNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                doccpnota.CoNumero = CoNumero;
            if (DpNumero == 0)
                resultado = "Falta indicar el numero partida";
            else
                doccpnota.DpNumero = DpNumero;
            if (DtNumero == 0)
                resultado = "Falta indicar el numero de nota";
            else
                doccpnota.DtNumero = DtNumero;
            doccpnota.DtDescripcion = DtDescripcion;
            doccpnota.DtTipo = DtTipo;
            doccpnota.DtOrden = DtOrden;
            doccpnota.NoIdent = NoIdent;
            doccpnota.DtArIdent = DtArIdent;
            doccpnota.DtAnNumero = DtAnNumero;
            doccpnota.DtActivo = DtActivo;

            doccpnota.DtAudUsuMod = DtAudUsuMod;
            doccpnota.DtAudFeMod = DtAudFeMod;

            if (resultado == "")
                db.updDocCPNota(doccpnota, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            DOCCPNOTA doccpnota = new DOCCPNOTA();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                doccpnota.DoIdent = DoIdent;
            if (CoNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                doccpnota.CoNumero = CoNumero;
            if (DpNumero == 0)
                resultado = "Falta indicar el numero partida";
            else
                doccpnota.DpNumero = DpNumero;
            if (DtNumero == 0)
                resultado = "Falta indicar el numero de nota";
            else
                doccpnota.DtNumero = DtNumero;
            doccpnota.DtActivo = "I";

            doccpnota.DtAudUsuEl = DtAudUsuEl;
            doccpnota.DtAudFeEl = DtAudFeEl;

            if (resultado == "")
                db.updDocCPNota(doccpnota, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            DOCCPNOTA doccpnota = new DOCCPNOTA();
            doccpnota.DoIdent = DoIdent;
            doccpnota.CoNumero = CoNumero;
            doccpnota.DpNumero = DpNumero;
            doccpnota.DtNumero = DtNumero;
            doccpnota.DtTipo = DtTipo;
            doccpnota.NoIdent = NoIdent;
            doccpnota.DtArIdent = DtArIdent;
            doccpnota.DtAnNumero = DtAnNumero;

            if (resultado == "")
            {
                DOCCPNOTA item = db.getDocCPNota(doccpnota);
                DoIdent = item.DoIdent;
                CoNumero = item.CoNumero;
                DpNumero = item.DpNumero;
                DtNumero = item.DtNumero;
                DtDescripcion = item.DtDescripcion;
                DtTipo = item.DtTipo;
                DtOrden = item.DtOrden;
                NoIdent = item.NoIdent;
                DtArIdent = item.DtArIdent;
                DtAnNumero = item.DtAnNumero;
                DtActivo = item.DtActivo;
                DtAudUsuCre = item.DtAudUsuCre;
                DtAudFeCre = item.DtAudFeCre;
                DtAudUsuMod = item.DtAudUsuMod;
                DtAudFeMod = item.DtAudFeMod;
                DtAudUsuEl = item.DtAudUsuEl;
                DtAudFeEl = item.DtAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            DOCCPNOTA doccpnota = new DOCCPNOTA();
            doccpnota.DoIdent = DoIdent;
            doccpnota.CoNumero = CoNumero;
            doccpnota.DpNumero = DpNumero;
            doccpnota.DtNumero = DtNumero;
            doccpnota.DtTipo = DtTipo;
            doccpnota.NoIdent = NoIdent;
            doccpnota.DtArIdent = DtArIdent;
            doccpnota.DtAnNumero = DtAnNumero;

            if (resultado == "")
                listDPN = db.getDocCPNotas(doccpnota);

            return resultado;
        }
    }

    public class _DocSeguimiento
    {
        public string DoIdent { get; set; }
        public int DsNumero { get; set; }
        public DateTime DsFechaSeg { get; set; }
        public string DsDescripcion { get; set; }
        public DateTime DsFechaReal { get; set; }
        public string DsObservacion { get; set; }
        public string DsActivo { get; set; }
        //AUDITORIA
        public string DsAudUsuCre { get; set; }
        public DateTime DsAudFeCre { get; set; }
        public string DsAudUsuMod { get; set; }
        public DateTime DsAudFeMod { get; set; }
        public string DsAudUsuEl { get; set; }
        public DateTime DsAudFeEl { get; set; }

        public List<DOCSEGUIMIENTO> listDoS { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                DsAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                DsAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                DsAudUsuMod = usuarioCache.nombreUsuario;
                DsAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                DsAudUsuEl = usuarioCache.nombreUsuario;
                DsAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            DOCSEGUIMIENTO docseguimiento = new DOCSEGUIMIENTO();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                docseguimiento.DoIdent = DoIdent;
            if (DsNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                docseguimiento.DsNumero = DsNumero;
            docseguimiento.DsFechaSeg = DsFechaSeg;
            if (DsDescripcion == "")
                resultado = "Falta indicar una descripción";
            else
                docseguimiento.DsDescripcion = DsDescripcion;
            docseguimiento.DsFechaReal = DsFechaReal;
            docseguimiento.DsObservacion = DsObservacion;
            docseguimiento.DsActivo = "A";

            docseguimiento.DsAudUsuCre = DsAudUsuCre;
            docseguimiento.DsAudFeCre = DsAudFeCre;

            if (resultado == "")
                db.setDocSeguimiento(docseguimiento);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            DOCSEGUIMIENTO docseguimiento = new DOCSEGUIMIENTO();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                docseguimiento.DoIdent = DoIdent;
            if (DsNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                docseguimiento.DsNumero = DsNumero;
            docseguimiento.DsFechaSeg = DsFechaSeg;
            if (DsDescripcion == "")
                resultado = "Falta indicar una descripción";
            else
                docseguimiento.DsDescripcion = DsDescripcion;
            docseguimiento.DsFechaReal = DsFechaReal;
            docseguimiento.DsObservacion = DsObservacion;
            docseguimiento.DsActivo = "A";

            docseguimiento.DsAudUsuMod = DsAudUsuMod;
            docseguimiento.DsAudFeMod = DsAudFeMod;

            if (resultado == "")
                db.updDocSeguimiento(docseguimiento, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            DOCSEGUIMIENTO docseguimiento = new DOCSEGUIMIENTO();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                docseguimiento.DoIdent = DoIdent;
            if (DsNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                docseguimiento.DsNumero = DsNumero;
            docseguimiento.DsActivo = "I";

            docseguimiento.DsAudUsuEl = DsAudUsuEl;
            docseguimiento.DsAudFeEl = DsAudFeEl;

            if (resultado == "")
                db.updDocSeguimiento(docseguimiento, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            DOCSEGUIMIENTO docseguimiento = new DOCSEGUIMIENTO();
            if (DoIdent == "")
                resultado = "Falta indicar el identificador";
            else
                docseguimiento.DoIdent = DoIdent;
            if (DsNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                docseguimiento.DsNumero = DsNumero;

            if (resultado == "")
            {
                DOCSEGUIMIENTO item = db.getDocSeguimiento(docseguimiento);
                DoIdent = item.DoIdent;
                DsNumero = item.DsNumero;
                DsFechaSeg = item.DsFechaSeg;
                DsDescripcion = item.DsDescripcion;
                DsFechaReal = item.DsFechaReal;
                DsObservacion = item.DsObservacion;
                DsActivo = item.DsActivo;
                DsAudUsuCre = item.DsAudUsuCre;
                DsAudFeCre = item.DsAudFeCre;
                DsAudUsuMod = item.DsAudUsuMod;
                DsAudFeMod = item.DsAudFeMod;
                DsAudUsuEl = item.DsAudUsuEl;
                DsAudFeEl = item.DsAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            DOCSEGUIMIENTO docseguimiento = new DOCSEGUIMIENTO();

            if (resultado == "")
                listDoS = db.getDocSeguimientos(docseguimiento);

            return resultado;
        }
    }

    public class _Pago
    {
        public int PgNumero { get; set; }
        public double PgMontoPrg { get; set; }
        public double PgMontoReal { get; set; }
        public string PgMoneda { get; set; }
        public DateTime PgFechaPrg { get; set; }
        public DateTime PgFechaReal { get; set; }
        public string PgObservacion { get; set; }
        public string DoIdent { get; set; }
        public string DiNumeroCl { get; set; }
        public string DiNombreCl { get; set; }
        public string DiNumeroPv { get; set; }
        public string DiNombrePv { get; set; }
        public string PgTipo { get; set; }
        public string PgReferencia { get; set; }
        public string PgActivo { get; set; }
        //AUDITORIA
        public string PgAudUsuCre { get; set; }
        public DateTime PgAudFeCre { get; set; }
        public string PgAudUsuMod { get; set; }
        public DateTime PgAudFeMod { get; set; }
        public string PgAudUsuEl { get; set; }
        public DateTime PgAudFeEl { get; set; }

        public List<PAGO> listPag { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                PgAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                PgAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                PgAudUsuMod = usuarioCache.nombreUsuario;
                PgAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                PgAudUsuEl = usuarioCache.nombreUsuario;
                PgAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            PAGO pago = new PAGO();
            if (PgNumero == 0)
                resultado = "Falta indicar consecutivo pago";
            else
                pago.PgNumero = PgNumero;
            pago.PgMontoPrg = PgMontoPrg;
            pago.PgMontoReal = PgMontoReal;
            if (PgMoneda == "")
                resultado = "Falta indicar la moneda";
            else
                pago.PgMoneda = PgMoneda;
            pago.PgFechaPrg = PgFechaPrg;
            pago.PgFechaReal = PgFechaReal;
            pago.PgObservacion = PgObservacion;
            pago.DoIdent = DoIdent;
            pago.DiNumeroCl = DiNumeroCl;
            pago.DiNumeroPv = DiNumeroPv;
            if (PgTipo == "")
                resultado = "Tipo de pago";
            else
                pago.PgTipo = PgTipo;
            pago.PgReferencia = PgReferencia;
            pago.PgActivo = "A";

            pago.PgAudUsuCre = PgAudUsuCre;
            pago.PgAudFeCre = PgAudFeCre;

            if (resultado == "")
                db.setPago(pago);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            PAGO pago = new PAGO();
            if (PgNumero == 0)
                resultado = "Falta indicar consecutivo pago";
            else
                pago.PgNumero = PgNumero;
            pago.PgMontoPrg = PgMontoPrg;
            pago.PgMontoReal = PgMontoReal;
            if (PgMoneda == "")
                resultado = "Falta indicar la moneda";
            else
                pago.PgMoneda = PgMoneda;
            pago.PgFechaPrg = PgFechaPrg;
            pago.PgFechaReal = PgFechaReal;
            pago.PgObservacion = PgObservacion;
            pago.DoIdent = DoIdent;
            pago.DiNumeroCl = DiNumeroCl;
            pago.DiNumeroPv = DiNumeroPv;
            if (PgTipo == "")
                resultado = "Tipo de pago";
            else
                pago.PgTipo = PgTipo;
            pago.PgReferencia = PgReferencia;
            pago.PgActivo = PgActivo;

            pago.PgAudUsuMod = PgAudUsuMod;
            pago.PgAudFeMod = PgAudFeMod;

            if (resultado == "")
                db.updPago(pago, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            PAGO pago = new PAGO();
            if (PgNumero == 0)
                resultado = "Falta indicar consecutivo pago";
            else
                pago.PgNumero = PgNumero;
            pago.PgActivo = "I";

            pago.PgAudUsuEl = PgAudUsuEl;
            pago.PgAudFeEl = PgAudFeEl;

            if (resultado == "")
                db.updPago(pago, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            PAGO pago = new PAGO();
            if (PgNumero == 0)
                resultado = "Falta indicar consecutivo pago";
            else
                pago.PgNumero = PgNumero;

            if (resultado == "")
            {
                PAGO item = db.getPago(pago);
                PgNumero = item.PgNumero;
                PgMontoPrg = item.PgMontoPrg;
                PgMontoReal = item.PgMontoReal;
                PgMoneda = item.PgMoneda;
                PgFechaPrg = item.PgFechaPrg;
                PgFechaReal = item.PgFechaReal;
                PgObservacion = item.PgObservacion;
                DoIdent = item.DoIdent;
                DiNumeroCl = item.DiNumeroCl;
                DiNumeroPv = item.DiNumeroPv;
                PgTipo = item.PgTipo;
                PgReferencia = item.PgReferencia;
                PgActivo = item.PgActivo;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            PAGO pago = new PAGO();

            if (resultado == "")
                listPag = db.getPagos(pago);

            return resultado;
        }
    }

    public class _PrecioLista
    {
        public string ArIdent { get; set; }
        public string DiNumero { get; set; }
        public string ArDescripcion { get; set; }
        public string DiNomCorto { get; set; }
        public double PlPrecioLista { get; set; }
        public string PlMoneda { get; set; }
        public string PlCodPrv { get; set; }
        public string PlPlazo { get; set; }
        public string PlReferencia { get; set; }
        public string PlObservacion { get; set; }
        public string PlActivo { get; set; }
        //AUDITORIA
        public string PlAudUsuCre { get; set; }
        public DateTime PlAudFeCre { get; set; }
        public string PlAudUsuMod { get; set; }
        public DateTime PlAudFeMod { get; set; }
        public string PlAudUsuEl { get; set; }
        public DateTime PlAudFeEl { get; set; }

        public List<PRECIOLISTA> listPrl { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                PlAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                PlAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                PlAudUsuMod = usuarioCache.nombreUsuario;
                PlAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                PlAudUsuEl = usuarioCache.nombreUsuario;
                PlAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            PRECIOLISTA preciolista = new PRECIOLISTA();
            if (ArIdent == "")
                resultado = "Falta indicar el Identificador";
            else
                preciolista.ArIdent = ArIdent;
            if (DiNumero == "")
                resultado = "Falta indicar el Numero de Proveedor";
            else
                preciolista.DiNumero = DiNumero;
            //if (PlPrecioLista == 0)
            //    resultado = "Falta indicar el Precio";
            //else
                preciolista.PlPrecioLista = PlPrecioLista;
            if (PlMoneda == "")
                resultado = "Falta indicar la moneda";
            else
                preciolista.PlMoneda = PlMoneda;
            preciolista.PlCodPrv = PlCodPrv;
            preciolista.PlPlazo = PlPlazo;
            preciolista.PlReferencia = PlReferencia;
            preciolista.PlObservacion = PlObservacion;
            preciolista.PlActivo = "A";

            preciolista.PlAudUsuCre = PlAudUsuCre;
            preciolista.PlAudFeCre = PlAudFeCre;

            if (resultado == "")
                db.setPrecioLista(preciolista);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            PRECIOLISTA preciolista = new PRECIOLISTA();
            if (ArIdent == "")
                resultado = "Falta indicar el Identificador";
            else
                preciolista.ArIdent = ArIdent;
            if (DiNumero == "")
                resultado = "Falta indicar el Numero de Proveedor";
            else
                preciolista.DiNumero = DiNumero;
            if (PlPrecioLista == 0)
                resultado = "Falta indicar el Precio";
            else
                preciolista.PlPrecioLista = PlPrecioLista;
            if (PlMoneda == "")
                resultado = "Falta indicar la moneda";
            else
                preciolista.PlMoneda = PlMoneda;
            preciolista.PlCodPrv = PlCodPrv;
            preciolista.PlPlazo = PlPlazo;
            preciolista.PlReferencia = PlReferencia;
            preciolista.PlObservacion = PlObservacion;
            preciolista.PlActivo = "A";

            preciolista.PlAudUsuMod = PlAudUsuMod;
            preciolista.PlAudFeMod = PlAudFeMod;

            if (resultado == "")
                db.updPrecioLista(preciolista, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            PRECIOLISTA preciolista = new PRECIOLISTA();
            if (ArIdent == "")
                resultado = "Falta indicar el Identificador";
            else
                preciolista.ArIdent = ArIdent;
            if (DiNumero == "")
                resultado = "Falta indicar el Numero de Proveedor";
            else
                preciolista.DiNumero = DiNumero;
            preciolista.PlActivo = "I";

            preciolista.PlAudUsuEl = PlAudUsuEl;
            preciolista.PlAudFeEl = PlAudFeEl;

            if (resultado == "")
                db.updPrecioLista(preciolista, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            PRECIOLISTA preciolista = new PRECIOLISTA();
            if (ArIdent == "")
                resultado = "Falta indicar el Identificador";
            else
                preciolista.ArIdent = ArIdent;
            if (DiNumero == "")
                resultado = "Falta indicar el Numero de Proveedor";
            else
                preciolista.DiNumero = DiNumero;

            if (resultado == "")
            {
                PRECIOLISTA item = db.getPrecioLista(preciolista);
                ArIdent = item.ArIdent;
                DiNumero = item.DiNumero;
                ArDescripcion = item.ArDescripcion;
                DiNomCorto = item.DiNomCorto;
                PlPrecioLista = item.PlPrecioLista;
                PlMoneda = item.PlMoneda;
                PlCodPrv = item.PlCodPrv;
                PlPlazo = item.PlPlazo;
                PlReferencia = item.PlReferencia;
                PlObservacion = item.PlObservacion;
                PlActivo = item.PlActivo;
                PlAudUsuCre = item.PlAudUsuCre;
                PlAudFeCre = item.PlAudFeCre;
                PlAudUsuMod = item.PlAudUsuMod;
                PlAudFeMod = item.PlAudFeMod;
                PlAudUsuEl = item.PlAudUsuEl;
                PlAudFeEl = item.PlAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            PRECIOLISTA preciolista = new PRECIOLISTA();
            preciolista.ArIdent = ArIdent;
            preciolista.DiNumero = DiNumero;

            if (resultado == "")
                listPrl = db.getPreciosLista(preciolista);

            return resultado;
        }
    }

    public class _Plantilla
    {
        public string PaIdent { get; set; }
        public string PaDescripcion { get; set; }
        public string DoIdent { get; set; }
        public string PaActivo { get; set; }
        //AUDITORIA
        public string PaAudUsuCre { get; set; }
        public DateTime PaAudFeCre { get; set; }
        public string PaAudUsuMod { get; set; }
        public DateTime PaAudFeMod { get; set; }
        public string PaAudUsuEl { get; set; }
        public DateTime PaAudFeEl { get; set; }

        public List<PLANTILLA> listPla { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                PaAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                PaAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                PaAudUsuMod = usuarioCache.nombreUsuario;
                PaAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                PaAudUsuEl = usuarioCache.nombreUsuario;
                PaAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            PLANTILLA plantilla = new PLANTILLA();
            if (PaIdent == "")
                resultado = "Falta indicar el identificador";
            else
                plantilla.PaIdent = PaIdent;
            if (PaDescripcion == "")
                resultado = "Falta indicar la descripción";
            else
                plantilla.PaDescripcion = PaDescripcion;
            if (DoIdent == "")
                resultado = "Falta indicar el documento";
            else
                plantilla.DoIdent = DoIdent;
            plantilla.PaActivo = "A";

            plantilla.PaAudUsuCre = PaAudUsuCre;
            plantilla.PaAudFeCre = PaAudFeCre;

            if (resultado == "")
                db.setPlantilla(plantilla);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            PLANTILLA plantilla = new PLANTILLA();
            if (PaIdent == "")
                resultado = "Falta indicar el identificador";
            else
                plantilla.PaIdent = PaIdent;
            if (PaDescripcion == "")
                resultado = "Falta indicar la descripción";
            else
                plantilla.PaDescripcion = PaDescripcion;
            if (DoIdent == "")
                resultado = "Falta indicar el documento";
            else
                plantilla.DoIdent = DoIdent;
            plantilla.PaActivo = PaActivo;

            plantilla.PaAudUsuMod = PaAudUsuMod;
            plantilla.PaAudFeMod = PaAudFeMod;

            if (resultado == "")
                db.updPlantilla(plantilla, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            PLANTILLA plantilla = new PLANTILLA();
            if (PaIdent == "")
                resultado = "Falta indicar el identificador";
            else
                plantilla.PaIdent = PaIdent;
            plantilla.PaActivo = "I";

            plantilla.PaAudUsuEl = PaAudUsuEl;
            plantilla.PaAudFeEl = PaAudFeEl;

            if (resultado == "")
                db.updPlantilla(plantilla, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            PLANTILLA plantilla = new PLANTILLA();
            if (PaIdent == "")
                resultado = "Falta indicar el identificador";
            else
                plantilla.PaIdent = PaIdent;
            plantilla.PaDescripcion = PaDescripcion == null ? "" : PaDescripcion;

            if (resultado == "")
            {
                PLANTILLA item = db.getPlantilla(plantilla);
                PaIdent = item.PaIdent;
                PaDescripcion = item.PaDescripcion;
                DoIdent = item.DoIdent;
                PaActivo = item.PaActivo;
                PaAudUsuCre = item.PaAudUsuCre;
                PaAudFeCre = item.PaAudFeCre;
                PaAudUsuMod = item.PaAudUsuMod;
                PaAudFeMod = item.PaAudFeMod;
                PaAudUsuEl = item.PaAudUsuEl;
                PaAudFeEl = item.PaAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            PLANTILLA plantilla = new PLANTILLA();
            plantilla.PaIdent = PaIdent == null ? "" : PaIdent;
            plantilla.PaDescripcion = PaDescripcion == null ? "" : PaDescripcion;

            if (resultado == "")
                listPla = db.getPlantillas(plantilla);

            return resultado;
        }
    }

    public class _Categoria
    {
        public string CaIdent { get; set; }
        public string CaDescripcion { get; set; }
        public string CaActivo { get; set; }
        //AUDITORIA
        public string CaAudUsuCre { get; set; }
        public DateTime CaAudFeCre { get; set; }
        public string CaAudUsuMod { get; set; }
        public DateTime CaAudFeMod { get; set; }
        public string CaAudUsuEl { get; set; }
        public DateTime CaAudFeEl { get; set; }

        public List<CATEGORIA> listCat { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                CaAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                CaAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                CaAudUsuMod = usuarioCache.nombreUsuario;
                CaAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                CaAudUsuEl = usuarioCache.nombreUsuario;
                CaAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            CATEGORIA categoria = new CATEGORIA();
            if (CaIdent == "")
                resultado = "Falta indicar el identificador";
            else
                categoria.CaIdent = CaIdent;
            if (CaDescripcion == "")
                resultado = "Falta indicar la descripción";
            else
                categoria.CaDescripcion = CaDescripcion;
            categoria.CaActivo = "A";

            categoria.CaAudUsuCre = CaAudUsuCre;
            categoria.CaAudFeCre = CaAudFeCre;

            if (resultado == "")
                db.setCategoria(categoria);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            CATEGORIA categoria = new CATEGORIA();
            if (CaIdent == "")
                resultado = "Falta indicar el identificador";
            else
                categoria.CaIdent = CaIdent;
            if (CaDescripcion == "")
                resultado = "Falta indicar la descripción";
            else
                categoria.CaDescripcion = CaDescripcion;
            categoria.CaActivo = CaActivo;

            categoria.CaAudUsuMod = CaAudUsuMod;
            categoria.CaAudFeMod = CaAudFeMod;

            if (resultado == "")
                db.updCategoria(categoria, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            CATEGORIA categoria = new CATEGORIA();
            if (CaIdent == "")
                resultado = "Falta indicar el identificador";
            else
                categoria.CaIdent = CaIdent;
            categoria.CaActivo = "I";

            categoria.CaAudUsuEl = CaAudUsuEl;
            categoria.CaAudFeEl = CaAudFeEl;

            if (resultado == "")
                db.updCategoria(categoria, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            CATEGORIA categoria = new CATEGORIA();
            if (CaIdent == "")
                resultado = "Falta indicar el identificador";
            else
                categoria.CaIdent = CaIdent;

            if (resultado == "")
            {
                CATEGORIA item = db.getCategoria(categoria);
                CaIdent = item.CaIdent;
                CaDescripcion = item.CaDescripcion;
                CaActivo = item.CaActivo;
                CaAudUsuCre = item.CaAudUsuCre;
                CaAudFeCre = item.CaAudFeCre;
                CaAudUsuMod = item.CaAudUsuMod;
                CaAudFeMod = item.CaAudFeMod;
                CaAudUsuEl = item.CaAudUsuEl;
                CaAudFeEl = item.CaAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            CATEGORIA categoria = new CATEGORIA();

            categoria.CaIdent = CaIdent;
            if (resultado == "")
                listCat = db.getCategorias(categoria);

            return resultado;
        }
    }

    public class _CategoriaPrv
    {
        public string CaIdent { get; set; }
        public string DiNumero { get; set; }
        public string DiNombreCom { get; set; }
        public string CaDescripcion { get; set; }
        public string CpActivo { get; set; }
        //AUDITORIA
        public string CpAudUsuCre { get; set; }
        public DateTime CpAudFeCre { get; set; }
        public string CpAudUsuMod { get; set; }
        public DateTime CpAudFeMod { get; set; }
        public string CpAudUsuEl { get; set; }
        public DateTime CpAudFeEl { get; set; }

        public List<CATEGORIAPRV> listCtp { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                CpAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                CpAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                CpAudUsuMod = usuarioCache.nombreUsuario;
                CpAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                CpAudUsuEl = usuarioCache.nombreUsuario;
                CpAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            CATEGORIAPRV categoriaprv = new CATEGORIAPRV();
            if (CaIdent == "")
                resultado = "Falta indicar el identificador";
            else
                categoriaprv.CaIdent = CaIdent;
            if (DiNumero == "")
                resultado = "Falta indicar el proveedor";
            else
                categoriaprv.DiNumero = DiNumero;
            categoriaprv.CpActivo = "A";

            categoriaprv.CpAudUsuCre = CpAudUsuCre;
            categoriaprv.CpAudFeCre = CpAudFeCre;

            if (resultado == "")
                db.setCategoriaPrv(categoriaprv);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            CATEGORIAPRV categoriaprv = new CATEGORIAPRV();
            if (CaIdent == "")
                resultado = "Falta indicar el identificador";
            else
                categoriaprv.CaIdent = CaIdent;
            if (DiNumero == "")
                resultado = "Falta indicar el proveedor";
            else
                categoriaprv.DiNumero = DiNumero;
            categoriaprv.CpActivo = "A";

            categoriaprv.CpAudUsuMod = CpAudUsuMod;
            categoriaprv.CpAudFeMod = CpAudFeMod;

            if (resultado == "")
                db.updCategoriaPrv(categoriaprv, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            CATEGORIAPRV categoriaprv = new CATEGORIAPRV();
            if (CaIdent == "")
                resultado = "Falta indicar el identificador";
            else
                categoriaprv.CaIdent = CaIdent;
            if (DiNumero == "")
                resultado = "Falta indicar el proveedor";
            else
                categoriaprv.DiNumero = DiNumero;
            categoriaprv.CpActivo = "I";

            categoriaprv.CpAudUsuEl = CpAudUsuEl;
            categoriaprv.CpAudFeEl = CpAudFeEl;

            if (resultado == "")
                db.updCategoriaPrv(categoriaprv, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            CATEGORIAPRV categoriaprv = new CATEGORIAPRV();
            if (CaIdent == "")
                resultado = "Falta indicar el identificador";
            else
                categoriaprv.CaIdent = CaIdent;
            if (DiNumero == "")
                resultado = "Falta indicar el proveedor";
            else
                categoriaprv.DiNumero = DiNumero;

            if (resultado == "")
            {
                CATEGORIAPRV item = db.getCategoriaPrv(categoriaprv);
                CaIdent = item.CaIdent;
                DiNumero = item.DiNumero;
                DiNombreCom = item.DiNombreCom;
                CaDescripcion = item.CaDescripcion;
                CpActivo = item.CpActivo;
                CpAudUsuCre = item.CpAudUsuCre;
                CpAudFeCre = item.CpAudFeCre;
                CpAudUsuMod = item.CpAudUsuMod;
                CpAudFeMod = item.CpAudFeMod;
                CpAudUsuEl = item.CpAudUsuEl;
                CpAudFeEl = item.CpAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            CATEGORIAPRV categoriaprv = new CATEGORIAPRV();
            categoriaprv.CaIdent = CaIdent;
            categoriaprv.DiNumero = DiNumero;

            if (resultado == "")
                listCtp = db.getCategoriasPrv(categoriaprv);

            return resultado;
        }
    }

    public class _Codigo
    {
        public string CdCategoria { get; set; }
        public string CdGrupo { get; set; }
        public string CdTipo { get; set; }
        public string CdDescripcion { get; set; }
        public int CdOrden { get; set; }
        public string CdActivo { get; set; }
        //AUDITORIA
        public string CdAudUsuCre { get; set; }
        public DateTime CdAudFeCre { get; set; }
        public string CdAudUsuMod { get; set; }
        public DateTime CdAudFeMod { get; set; }
        public string CdAudUsuEl { get; set; }
        public DateTime CdAudFeEl { get; set; }

        public List<CODIGO> listCod { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                CdAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                CdAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                CdAudUsuMod = usuarioCache.nombreUsuario;
                CdAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                CdAudUsuEl = usuarioCache.nombreUsuario;
                CdAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            CODIGO codigo = new CODIGO();
            if (CdCategoria == "")
                resultado = "Falta indicar la categoria";
            else
                codigo.CdCategoria = CdCategoria;
            if (CdGrupo == "")
                resultado = "Falta indicar el grupo";
            else
                codigo.CdGrupo = CdGrupo;
            if (CdTipo == "")
                resultado = "Falta indicar el tipo";
            else
                codigo.CdTipo = CdTipo;
            codigo.CdDescripcion = CdDescripcion;
            codigo.CdOrden = CdOrden;
            codigo.CdActivo = "A";

            codigo.CdAudUsuCre = CdAudUsuCre;
            codigo.CdAudFeCre = CdAudFeCre;

            if (resultado == "")
                db.setCodigo(codigo);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            CODIGO codigo = new CODIGO();
            if (CdCategoria == "")
                resultado = "Falta indicar la categoria";
            else
                codigo.CdCategoria = CdCategoria;
            if (CdGrupo == "")
                resultado = "Falta indicar el grupo";
            else
                codigo.CdGrupo = CdGrupo;
            if (CdTipo == "")
                resultado = "Falta indicar el tipo";
            else
                codigo.CdTipo = CdTipo;
            codigo.CdDescripcion = CdDescripcion;
            codigo.CdOrden = CdOrden;
            codigo.CdActivo = CdActivo;

            codigo.CdAudUsuMod = CdAudUsuMod;
            codigo.CdAudFeMod = CdAudFeMod;

            if (resultado == "")
                db.updCodigo(codigo, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            CODIGO codigo = new CODIGO();
            if (CdCategoria == "")
                resultado = "Falta indicar la categoria";
            else
                codigo.CdCategoria = CdCategoria;
            if (CdGrupo == "")
                resultado = "Falta indicar el grupo";
            else
                codigo.CdGrupo = CdGrupo;
            if (CdTipo == "")
                resultado = "Falta indicar el tipo";
            else
                codigo.CdTipo = CdTipo;
            codigo.CdDescripcion = CdDescripcion;
            codigo.CdOrden = CdOrden;
            codigo.CdActivo = "I";

            codigo.CdAudUsuEl = CdAudUsuEl;
            codigo.CdAudFeEl = CdAudFeEl;

            if (resultado == "")
                db.updCodigo(codigo, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            CODIGO codigo = new CODIGO();
            if (CdCategoria == "")
                resultado = "Falta indicar la categoria";
            else
                codigo.CdCategoria = CdCategoria;
            if (CdGrupo == "")
                resultado = "Falta indicar el grupo";
            else
                codigo.CdGrupo = CdGrupo;
            if (CdTipo == "")
                resultado = "Falta indicar el proveedor";
            else
                codigo.CdTipo = CdTipo;

            if (resultado == "")
            {
                CODIGO item = db.getCodigo(codigo);
                CdCategoria = item.CdCategoria;
                CdGrupo = CdGrupo;
                CdTipo = item.CdTipo;
                CdDescripcion = item.CdDescripcion;
                CdOrden = item.CdOrden;
                CdActivo = item.CdActivo;
                CdAudUsuCre = item.CdAudUsuCre;
                CdAudFeCre = item.CdAudFeCre;
                CdAudUsuMod = item.CdAudUsuMod;
                CdAudFeMod = item.CdAudFeMod;
                CdAudUsuEl = item.CdAudUsuEl;
                CdAudFeEl = item.CdAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            CODIGO codigo = new CODIGO();
            codigo.CdCategoria = CdCategoria;
            codigo.CdGrupo = CdGrupo;
            codigo.CdTipo = CdTipo;

            if (resultado == "")
                listCod = db.getCodigos(codigo);

            return resultado;
        }
    }

    public class _CalVenta
    {
        public string DoIdent { get; set; }
        public int CvPresupuesto { get; set; }
        public int CvAutoridad { get; set; }
        public int CvNecesidad { get; set; }
        public int CvTiempo { get; set; }
        public int CvCalificacion { get; set; }
        public string CvOportunidad { get; set; }
        public string CvActivo { get; set; }
        //VECTORES
        public string[] presupuesto = new string[] {"No tiene presupuesto",
                                                    "No tiene presupuesto pero le gustaría tenerlo",
                                                    "Tiene presupuesto pero no es suficiente",
                                                    "Tiene presupuesto y es suficiente",
                                                    "Tiene presupuesto y se excede" };
        public string[] autoridad = new string[] {  "No toma la decisión ni tiene acceso a quien la toma",
                                                    "No toma la decisión pero tiene acceso a quien la toma",
                                                    "No toma la decisión pero influye en quien  la toma",
                                                    "Toma la decisión en conjunto con otras personas",
                                                    "Es quien toma la decisión" };
        public string[] necesidad = new string[] {  "No tiene necesidad",
                                                    "No tiene necesidad pero le gustaría tenerla",
                                                    "Tiene necesidad pero no es indispensable",
                                                    "Tiene necesidad, pero tiene con que cubrirla",
                                                    "Tiene necesidad y no sabe como solucionarlo" };
        public string[] tiempo = new string[] { "No tiene definido cuando",
                                                "Después de un año",
                                                "Entre 6 y 12 meses",
                                                "Entre 3 y 6 meses",
                                                "En menos de 3 meses" };
        public string[] oportunidad = new string[] {"Baja",
                                                    "Media Baja",
                                                    "Media",
                                                    "Alta" };
        public string[] interes = new string[] {"Mándalo a la papelera",
                                                "Revisalo ocasionalmente",
                                                "Es necesario dar seguimiento",
                                                "Dar seguimiento" };
        public string[] plan = new string[] {   "Deséchalo",
                                                "Monitoréalo",
                                                "Planificalo",
                                                "Cierralo" };
        public string[] norte = new string[] {  "Ni importante ni urgente",
                                                "Urgente pero no importante",
                                                "Importente pero no urgente",
                                                "Importante" };
        //AUDITORIA
        public string CvAudUsuCre { get; set; }
        public DateTime CvAudFeCre { get; set; }
        public string CvAudUsuMod { get; set; }
        public DateTime CvAudFeMod { get; set; }
        public string CvAudUsuEl { get; set; }
        public DateTime CvAudFeEl { get; set; }

        public List<CALVENTA> listCod { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                CvAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                CvAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                CvAudUsuMod = usuarioCache.nombreUsuario;
                CvAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                CvAudUsuEl = usuarioCache.nombreUsuario;
                CvAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            CALVENTA calventa = new CALVENTA();
            if (DoIdent == "")
                resultado = "Falta indicar el documento";
            else
                calventa.DoIdent = DoIdent;
            calventa.CvPresupuesto = CvPresupuesto;
            calventa.CvAutoridad = CvAutoridad;
            calventa.CvNecesidad = CvNecesidad;
            calventa.CvTiempo = CvTiempo;
            calventa.CvCalificacion = CvCalificacion;
            calventa.CvOportunidad = CvOportunidad;
            calventa.CvActivo = "A";

            calventa.CvAudUsuCre = CvAudUsuCre;
            calventa.CvAudFeCre = CvAudFeCre;

            if (resultado == "")
                db.setCalVenta(calventa);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            CALVENTA calventa = new CALVENTA();
            if (DoIdent == "")
                resultado = "Falta indicar el documento";
            else
                calventa.DoIdent = DoIdent;
            calventa.CvPresupuesto = CvPresupuesto;
            calventa.CvAutoridad = CvAutoridad;
            calventa.CvNecesidad = CvNecesidad;
            calventa.CvTiempo = CvTiempo;
            calventa.CvCalificacion = CvCalificacion;
            calventa.CvOportunidad = CvOportunidad;
            calventa.CvActivo = CvActivo;

            calventa.CvAudUsuMod = CvAudUsuMod;
            calventa.CvAudFeMod = CvAudFeMod;

            if (resultado == "")
                db.updCalVenta(calventa, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            CALVENTA calventa = new CALVENTA();
            if (DoIdent == "")
                resultado = "Falta indicar el documento";
            else
                calventa.DoIdent = DoIdent;
            
            calventa.CvActivo = "I";

            calventa.CvAudUsuEl = CvAudUsuEl;
            calventa.CvAudFeEl = CvAudFeEl;

            if (resultado == "")
                db.updCalVenta(calventa, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            CALVENTA calventa = new CALVENTA();
            calventa.DoIdent = DoIdent;
            calventa.CvOportunidad = CvOportunidad;

            if (resultado == "")
            {
                CALVENTA item = db.getCalVenta(calventa);
                DoIdent = item.DoIdent;
                CvPresupuesto = item.CvPresupuesto;
                CvAutoridad = item.CvAutoridad;
                CvNecesidad = item.CvNecesidad;
                CvTiempo = item.CvTiempo;
                CvCalificacion = item.CvCalificacion;
                CvOportunidad = item.CvOportunidad;
                CvActivo = item.CvActivo;
                CvAudUsuCre = item.CvAudUsuCre;
                CvAudFeCre = item.CvAudFeCre;
                CvAudUsuMod = item.CvAudUsuMod;
                CvAudFeMod = item.CvAudFeMod;
                CvAudUsuEl = item.CvAudUsuEl;
                CvAudFeEl = item.CvAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            CALVENTA calventa = new CALVENTA();
            calventa.DoIdent = DoIdent;
            calventa.CvOportunidad = CvOportunidad;

            if (resultado == "")
                listCod = db.getCalVentas(calventa);

            return resultado;
        }
    }

    public class _GrCarp
    {
        public string GcIdent { get; set; }
        public string GcDescripcion { get; set; }
        public string GcPath { get; set; }
        public string GcActivo { get; set; }
        //AUDITORIA
        public string GcAudUsuCre { get; set; }
        public DateTime GcAudFeCre { get; set; }
        public string GcAudUsuMod { get; set; }
        public DateTime GcAudFeMod { get; set; }
        public string GcAudUsuEl { get; set; }
        public DateTime GcAudFeEl { get; set; }

        public List<GRCARP> listGrC { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                GcAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                GcAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                GcAudUsuMod = usuarioCache.nombreUsuario;
                GcAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                GcAudUsuEl = usuarioCache.nombreUsuario;
                GcAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            GRCARP grcarp = new GRCARP();
            if (GcIdent == "")
                resultado = "Falta indicar el Identificador";
            else
                grcarp.GcIdent = GcIdent;
            grcarp.GcDescripcion = GcDescripcion;
            grcarp.GcPath = GcPath;
            grcarp.GcActivo = "A";

            grcarp.GcAudUsuCre = GcAudUsuCre;
            grcarp.GcAudFeCre = GcAudFeCre;

            if (resultado == "")
                db.setGrCarp(grcarp);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            GRCARP grcarp = new GRCARP();
            if (GcIdent == "")
                resultado = "Falta indicar el Identificador";
            else
                grcarp.GcIdent = GcIdent;
            grcarp.GcDescripcion = GcDescripcion;
            grcarp.GcPath = GcPath;
            grcarp.GcActivo = GcActivo;

            grcarp.GcAudUsuMod = GcAudUsuMod;
            grcarp.GcAudFeMod = GcAudFeMod;

            if (resultado == "")
                db.updGrCarp(grcarp, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            GRCARP grcarp = new GRCARP();
            if (GcIdent == "")
                resultado = "Falta indicar el Indicador";
            else
                grcarp.GcIdent = GcIdent;
            grcarp.GcDescripcion = GcDescripcion;
            grcarp.GcPath = GcPath;
            grcarp.GcActivo = "I";

            grcarp.GcAudUsuEl = GcAudUsuEl;
            grcarp.GcAudFeEl = GcAudFeEl;

            if (resultado == "")
                db.updGrCarp(grcarp, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            GRCARP grcarp = new GRCARP();
            if (GcIdent == "")
                resultado = "Falta indicar el Identificador";
            else
                grcarp.GcIdent = GcIdent;
            grcarp.GcDescripcion = "";

            if (resultado == "")
            {
                GRCARP item = db.getGrCarp(grcarp);
                GcIdent = item.GcIdent;
                GcDescripcion = item.GcDescripcion;
                GcPath = item.GcPath;
                GcActivo = item.GcActivo;
                GcAudUsuCre = item.GcAudUsuCre;
                GcAudFeCre = item.GcAudFeCre;
                GcAudUsuMod = item.GcAudUsuMod;
                GcAudFeMod = item.GcAudFeMod;
                GcAudUsuEl = item.GcAudUsuEl;
                GcAudFeEl = item.GcAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            GRCARP grcarp = new GRCARP();
            grcarp.GcIdent = GcIdent;
            grcarp.GcDescripcion = GcDescripcion;

            if (resultado == "")
                listGrC = db.getGrCarps(grcarp);

            return resultado;
        }
    }

    public class _Carpeta
    {
        public string GcIdent { get; set; }
        public string CrIdent { get; set; }
        public string CrNombre { get; set; }
        public string CrActivo { get; set; }
        //AUDITORIA
        public string CrAudUsuCre { get; set; }
        public DateTime CrAudFeCre { get; set; }
        public string CrAudUsuMod { get; set; }
        public DateTime CrAudFeMod { get; set; }
        public string CrAudUsuEl { get; set; }
        public DateTime CrAudFeEl { get; set; }

        public List<CARPETA> listCar { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                CrAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                CrAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                CrAudUsuMod = usuarioCache.nombreUsuario;
                CrAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                CrAudUsuEl = usuarioCache.nombreUsuario;
                CrAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            CARPETA carpeta = new CARPETA();
            if (GcIdent == "")
                resultado = "Falta indicar el Identificador de grupo";
            else
                carpeta.GcIdent = GcIdent;
            if (CrIdent == "")
                resultado = "Falta indicar el Identificador de carpeta";
            else
                carpeta.CrIdent = CrIdent;
            carpeta.CrNombre = CrNombre;
            carpeta.CrActivo = "A";

            carpeta.CrAudUsuCre = CrAudUsuCre;
            carpeta.CrAudFeCre = CrAudFeCre;

            if (resultado == "")
                db.setCarpeta(carpeta);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            CARPETA carpeta = new CARPETA();
            if (GcIdent == "")
                resultado = "Falta indicar el Identificador de grupo";
            else
                carpeta.GcIdent = GcIdent;
            if (CrIdent == "")
                resultado = "Falta indicar el Identificador de carpeta";
            else
                carpeta.CrIdent = CrIdent;
            carpeta.CrNombre = CrNombre;
            carpeta.CrActivo = CrActivo;

            carpeta.CrAudUsuMod = CrAudUsuMod;
            carpeta.CrAudFeMod = CrAudFeMod;

            if (resultado == "")
                db.updCarpeta(carpeta, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            CARPETA carpeta = new CARPETA();
            if (GcIdent == "")
                resultado = "Falta indicar el Identificador de grupo";
            else
                carpeta.GcIdent = GcIdent;
            if (CrIdent == "")
                resultado = "Falta indicar el Identificador de carpeta";
            else
                carpeta.CrIdent = CrIdent;
            carpeta.CrNombre = CrNombre;
            carpeta.CrActivo = CrActivo;

            carpeta.CrAudUsuEl = CrAudUsuEl;
            carpeta.CrAudFeEl = CrAudFeEl;

            if (resultado == "")
                db.updCarpeta(carpeta, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            CARPETA carpeta = new CARPETA();
            carpeta.GcIdent = GcIdent;
            carpeta.CrIdent = CrIdent;
            carpeta.CrNombre = CrNombre;

            if (resultado == "")
            {
                CARPETA item = db.getCarpeta(carpeta);
                GcIdent = item.GcIdent;
                CrIdent = item.CrIdent;
                CrNombre = item.CrNombre;
                CrActivo = item.CrActivo;
                CrAudUsuCre = item.CrAudUsuCre;
                CrAudFeCre = item.CrAudFeCre;
                CrAudUsuMod = item.CrAudUsuMod;
                CrAudFeMod = item.CrAudFeMod;
                CrAudUsuEl = item.CrAudUsuEl;
                CrAudFeEl = item.CrAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            CARPETA carpeta = new CARPETA();
            carpeta.GcIdent = GcIdent;
            carpeta.CrIdent = CrIdent;
            carpeta.CrNombre = CrNombre;

            if (resultado == "")
                listCar = db.getCarpetas(carpeta);

            return resultado;
        }
    }

    public class _PryCarp
    {
        public string PyNumero { get; set; }
        public string GcIdent { get; set; }
        public string CrIdent { get; set; }
        public string PcActivo { get; set; }
        //AUDITORIA
        public string PcAudUsuCre { get; set; }
        public DateTime PcAudFeCre { get; set; }
        public string PcAudUsuMod { get; set; }
        public DateTime PcAudFeMod { get; set; }
        public string PcAudUsuEl { get; set; }
        public DateTime PcAudFeEl { get; set; }

        public List<PRYCARP> listPyC { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                PcAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                PcAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                PcAudUsuMod = usuarioCache.nombreUsuario;
                PcAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                PcAudUsuEl = usuarioCache.nombreUsuario;
                PcAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            PRYCARP prycarp = new PRYCARP();
            if (PyNumero == "")
                resultado = "Falta indicar el proyecto";
            else
                prycarp.PyNumero = PyNumero;
            if (GcIdent == "")
                resultado = "Falta indicar el Identificador de grupo";
            else
                prycarp.GcIdent = GcIdent;
            if (CrIdent == "")
                resultado = "Falsta indicar el Identificador de carpeta";
            else
                prycarp.CrIdent = CrIdent;
            prycarp.PcActivo = "A";

            prycarp.PcAudUsuCre = PcAudUsuCre;
            prycarp.PcAudFeCre = PcAudFeCre;

            if (resultado == "")
                db.setPryCarp(prycarp);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            PRYCARP prycarp = new PRYCARP();
            if (PyNumero == "")
                resultado = "Falta indicar el proyecto";
            else
                prycarp.PyNumero = PyNumero;
            if (GcIdent == "")
                resultado = "Falta indicar el Identificador de grupo";
            else
                prycarp.GcIdent = GcIdent;
            if (CrIdent == "")
                resultado = "Falsta indicar el Identificador de carpeta";
            else
                prycarp.CrIdent = CrIdent;
            prycarp.PcActivo = PcActivo;

            prycarp.PcAudUsuMod = PcAudUsuMod;
            prycarp.PcAudFeMod = PcAudFeMod;

            if (resultado == "")
                db.updPryCarp(prycarp, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            PRYCARP prycarp = new PRYCARP();
            if (PyNumero == "")
                resultado = "Falta indicar el proyecto";
            else
                prycarp.PyNumero = PyNumero;
            if (GcIdent == "")
                resultado = "Falta indicar el Identificador de grupo";
            else
                prycarp.GcIdent = GcIdent;
            if (CrIdent == "")
                resultado = "Falsta indicar el Identificador de carpeta";
            else
                prycarp.CrIdent = CrIdent;
            prycarp.PcActivo = "I";

            prycarp.PcAudUsuEl = PcAudUsuEl;
            prycarp.PcAudFeEl = PcAudFeEl;

            if (resultado == "")
                db.updPryCarp(prycarp, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            PRYCARP prycarp = new PRYCARP();
            prycarp.PyNumero = PyNumero;
            prycarp.GcIdent = GcIdent;
            prycarp.CrIdent = CrIdent;

            if (resultado == "")
            {
                PRYCARP item = db.getPryCarp(prycarp);
                PyNumero = item.PyNumero;
                GcIdent = item.GcIdent;
                CrIdent = item.CrIdent;
                PcActivo = item.PcActivo;
                PcAudUsuCre = item.PcAudUsuCre;
                PcAudFeCre = item.PcAudFeCre;
                PcAudUsuMod = item.PcAudUsuMod;
                PcAudFeMod = item.PcAudFeMod;
                PcAudUsuEl = item.PcAudUsuEl;
                PcAudFeEl = item.PcAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            PRYCARP prycarp = new PRYCARP();
            prycarp.PyNumero = PyNumero;
            prycarp.GcIdent = GcIdent;
            prycarp.CrIdent = CrIdent;

            if (resultado == "")
                listPyC = db.getPryCarps(prycarp);

            return resultado;
        }
    }

    public class _ArtNota
    {
        public string ArIdent { get; set; }
        public int AnNumero { get; set; }
        public string AnDescripcion { get; set; }
        public string AnTipo { get; set; }
        public int AnOrden { get; set; }
        public string NoIdent { get; set; }
        public string AnCaIdent { get; set; }
        public int AnCtNumero { get; set; }
        public string AnActivo { get; set; }
        //AUDITORIA
        public string AnAudUsuCre { get; set; }
        public DateTime AnAudFeCre { get; set; }
        public string AnAudUsuMod { get; set; }
        public DateTime AnAudFeMod { get; set; }
        public string AnAudUsuEl { get; set; }
        public DateTime AnAudFeEl { get; set; }

        public List<ARTNOTA> listArN { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                AnAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                AnAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                AnAudUsuMod = usuarioCache.nombreUsuario;
                AnAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                AnAudUsuEl = usuarioCache.nombreUsuario;
                AnAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            ARTNOTA artnota = new ARTNOTA();
            if (ArIdent == "")
                resultado = "Falta indicar el identificador";
            else
                artnota.ArIdent = ArIdent;
            if (AnNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                artnota.AnNumero = AnNumero;
            artnota.AnDescripcion = AnDescripcion;
            artnota.AnTipo = AnTipo;
            artnota.AnOrden = AnOrden;
            artnota.NoIdent = NoIdent;
            artnota.AnCaIdent = AnCaIdent;
            artnota.AnCtNumero = AnCtNumero;
            artnota.AnActivo = "A";

            artnota.AnAudUsuCre = AnAudUsuCre;
            artnota.AnAudFeCre = AnAudFeCre;

            if (resultado == "")
                db.setArtNota(artnota);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            ARTNOTA artnota = new ARTNOTA();
            if (ArIdent == "")
                resultado = "Falta indicar el identificador";
            else
                artnota.ArIdent = ArIdent;
            if (AnNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                artnota.AnNumero = AnNumero;
            artnota.AnDescripcion = AnDescripcion;
            artnota.AnTipo = AnTipo;
            artnota.AnOrden = AnOrden;
            artnota.NoIdent = NoIdent;
            artnota.AnCaIdent = AnCaIdent;
            artnota.AnCtNumero = AnCtNumero;
            artnota.AnActivo = AnActivo;

            artnota.AnAudUsuMod = AnAudUsuMod;
            artnota.AnAudFeMod = AnAudFeMod;

            if (resultado == "")
                db.updArtNota(artnota, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            ARTNOTA artnota = new ARTNOTA();
            if (ArIdent == "")
                resultado = "Falta indicar el identificador";
            else
                artnota.ArIdent = ArIdent;
            if (AnNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                artnota.AnNumero = AnNumero;
            artnota.AnActivo = "I";

            artnota.AnAudUsuEl = AnAudUsuEl;
            artnota.AnAudFeEl = AnAudFeEl;

            if (resultado == "")
                db.updArtNota(artnota, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            ARTNOTA artnota = new ARTNOTA();
            artnota.ArIdent = ArIdent;
            artnota.AnNumero = AnNumero;
            artnota.NoIdent = NoIdent;
            artnota.AnCaIdent = AnCaIdent;
            artnota.AnCtNumero = AnCtNumero;
            artnota.AnTipo = AnTipo;

            if (resultado == "")
            {
                ARTNOTA item = db.getArtNota(artnota);
                ArIdent = item.ArIdent;
                AnNumero = item.AnNumero;
                AnDescripcion = item.AnDescripcion;
                AnTipo = item.AnTipo;
                AnOrden = item.AnOrden;
                NoIdent = item.NoIdent;
                AnCaIdent = item.AnCaIdent;
                AnCtNumero = item.AnCtNumero;
                AnActivo = item.AnActivo;
                AnAudUsuCre = item.AnAudUsuCre;
                AnAudFeCre = item.AnAudFeCre;
                AnAudUsuMod = item.AnAudUsuMod;
                AnAudFeMod = item.AnAudFeMod;
                AnAudUsuEl = item.AnAudUsuEl;
                AnAudFeEl = item.AnAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            ARTNOTA artnota = new ARTNOTA();

            artnota.ArIdent = ArIdent;
            artnota.AnNumero = AnNumero;
            artnota.AnTipo = AnTipo;
            artnota.NoIdent = NoIdent;
            artnota.AnCaIdent = AnCaIdent;
            artnota.AnCtNumero = AnCtNumero;

            if (resultado == "")
                listArN = db.getArtNotas(artnota);

            return resultado;
        }
    }

    public class _CatNota
    {
        public string CaIdent { get; set; }
        public int CtNumero { get; set; }
        public string CtDescripcion { get; set; }
        public string CtTipo { get; set; }
        public int CtOrden { get; set; }
        public string NoIdent { get; set; }
        public string CtActivo { get; set; }
        //AUDITORIA
        public string CtAudUsuCre { get; set; }
        public DateTime CtAudFeCre { get; set; }
        public string CtAudUsuMod { get; set; }
        public DateTime CtAudFeMod { get; set; }
        public string CtAudUsuEl { get; set; }
        public DateTime CtAudFeEl { get; set; }

        public List<CATNOTA> listCaN { get; set; }

        private DAL_SQL db = new DAL_SQL();
        private modo m { get; set; }

        private void auditoria()
        {
            if (modo.insert == m)
            {
                CtAudUsuCre = usuarioCache.nombreUsuario == null ? "" : usuarioCache.nombreUsuario;
                CtAudFeCre = DateTime.Now;
            }
            else if (modo.update == m)
            {
                CtAudUsuMod = usuarioCache.nombreUsuario;
                CtAudFeMod = DateTime.Now;
            }
            else if (modo.delete == m)
            {
                CtAudUsuEl = usuarioCache.nombreUsuario;
                CtAudFeEl = DateTime.Now;
            }
        }

        public string guardar()
        {
            string resultado = "";

            m = modo.insert;
            auditoria();

            CATNOTA catnota = new CATNOTA();
            if (CaIdent == "")
                resultado = "Falta indicar el identificador";
            else
                catnota.CaIdent = CaIdent;
            if (CtNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                catnota.CtNumero = CtNumero;
            catnota.CtDescripcion = CtDescripcion;
            catnota.CtTipo = CtTipo;
            catnota.CtOrden = CtOrden;
            catnota.NoIdent = NoIdent;
            catnota.CtActivo = "A";

            catnota.CtAudUsuCre = CtAudUsuCre;
            catnota.CtAudFeCre = CtAudFeCre;

            if (resultado == "")
                db.setCatNota(catnota);

            return resultado;
        }

        public string actualizar()
        {
            string resultado = "";

            m = modo.update;
            auditoria();

            CATNOTA catnota = new CATNOTA();
            if (CaIdent == "")
                resultado = "Falta indicar el identificador";
            else
                catnota.CaIdent = CaIdent;
            if (CtNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                catnota.CtNumero = CtNumero;
            catnota.CtDescripcion = CtDescripcion;
            catnota.CtTipo = CtTipo;
            catnota.CtOrden = CtOrden;
            catnota.NoIdent = NoIdent;
            catnota.CtActivo = CtActivo;

            catnota.CtAudUsuMod = CtAudUsuMod;
            catnota.CtAudFeMod = CtAudFeMod;

            if (resultado == "")
                db.updCatNota(catnota, m);

            return resultado;
        }

        public string eliminar()
        {
            string resultado = "";

            m = modo.delete;
            auditoria();

            CATNOTA catnota = new CATNOTA();
            if (CaIdent == "")
                resultado = "Falta indicar el identificador";
            else
                catnota.CaIdent = CaIdent;
            if (CtNumero == 0)
                resultado = "Falta indicar el concecutivo";
            else
                catnota.CtNumero = CtNumero;
            catnota.CtActivo = "I";

            catnota.CtAudUsuEl = CtAudUsuEl;
            catnota.CtAudFeEl = CtAudFeEl;

            if (resultado == "")
                db.updCatNota(catnota, m);

            return resultado;
        }

        public string consultaUno()
        {
            string resultado = "";

            CATNOTA catnota = new CATNOTA();
            catnota.CaIdent = CaIdent;
            catnota.CtNumero = CtNumero;
            catnota.NoIdent = NoIdent;
            catnota.CtTipo = CtTipo;

            if (resultado == "")
            {
                CATNOTA item = db.getCatNota(catnota);
                CaIdent = item.CaIdent;
                CtNumero = item.CtNumero;
                CtDescripcion = item.CtDescripcion;
                CtTipo = item.CtTipo;
                CtOrden = item.CtOrden;
                NoIdent = item.NoIdent;
                CtActivo = item.CtActivo;
                CtAudUsuCre = item.CtAudUsuCre;
                CtAudFeCre = item.CtAudFeCre;
                CtAudUsuMod = item.CtAudUsuMod;
                CtAudFeMod = item.CtAudFeMod;
                CtAudUsuEl = item.CtAudUsuEl;
                CtAudFeEl = item.CtAudFeEl;
            }

            return resultado;
        }

        public string listado()
        {
            string resultado = "";

            CATNOTA catnota = new CATNOTA();

            catnota.CaIdent = CaIdent;
            catnota.CtNumero = CtNumero;
            catnota.CtTipo = CtTipo;
            catnota.NoIdent = NoIdent;

            if (resultado == "")
                listCaN = db.getCatNotas(catnota);

            return resultado;
        }
    }

    public class _Bateo
    {
        public List<BATEO> bateo { get; set; }

        public void generaBateo()
        {
            bateo = new List<BATEO>();
            _Documento doc = new _Documento();
            _Proyecto pry;
            _CalVenta vta;
            _DocCPartida par;
            BATEO bat;

            DateTime hoy = DateTime.Today;

            doc.DoIdent = "";
            doc.DoTipo = "COT";
            doc.DiNumero = "";
            doc.EmIdent = "";
            doc.DoEstatus = "";
            doc.FeIni = hoy.AddYears(-2);
            doc.FeFin = hoy;
            doc.DoUsuSeg = "";
            doc.DoVendedor = "";
            doc.listado();

            foreach(DOCUMENTO item in doc.listDoc)
            {
                bat = new BATEO();

                pry = new _Proyecto();
                pry.PyNumero = item.PyNumero;
                pry.PyNombre = "";
                pry.DiNombre = "";
                pry.consultaUno();

                vta = new _CalVenta();
                vta.DoIdent = item.DoIdent;
                vta.CvOportunidad = "";
                vta.consultaUno();

                bat.DoIdent = item.DoIdent;
                bat.DoFolio = item.DoFolio;
                bat.DoVersion = item.DoVersion;
                bat.DoVersionL = item.DoVersionL;
                bat.DoFecha = item.DoFecha;
                bat.DoUsuSeg = item.DoUsuSeg;
                bat.DoActivo = item.DoActivo;
                bat.PyNumero = pry.PyNumero;
                bat.PyFolio = pry.PyFolio;
                bat.PyNombre = pry.PyNombre;
                bat.PyActivo = pry.PyActivo;

                bat.CvOportunidad = "";
                bat.Interes = "";
                bat.PlanAccion = "";
                bat.Norte = "";

                int calif = (vta.CvPresupuesto) + (vta.CvAutoridad) + (vta.CvNecesidad) + (vta.CvTiempo);
                if (vta.CvCalificacion >= 1 && vta.CvCalificacion <= 5)
                {
                    bat.CvOportunidad = vta.oportunidad[0];
                    bat.Interes = vta.interes[0];
                    bat.PlanAccion = vta.plan[0];
                    bat.Norte = vta.norte[0];
                }
                else if (vta.CvCalificacion >= 6 && vta.CvCalificacion <= 10)
                {
                    bat.CvOportunidad = vta.oportunidad[1];
                    bat.Interes = vta.interes[1];
                    bat.PlanAccion = vta.plan[1];
                    bat.Norte = vta.norte[1];
                }
                else if (vta.CvCalificacion >= 11 && vta.CvCalificacion <= 15)
                {
                    bat.CvOportunidad = vta.oportunidad[2];
                    bat.Interes = vta.interes[2];
                    bat.PlanAccion = vta.plan[2];
                    bat.Norte = vta.norte[2];
                }
                else if (vta.CvCalificacion >= 16 && vta.CvCalificacion <= 20)
                {
                    bat.CvOportunidad = vta.oportunidad[3];
                    bat.Interes = vta.interes[3];
                    bat.PlanAccion = vta.plan[3];
                    bat.Norte = vta.norte[3];
                }

                par = new _DocCPartida();
                par.DoIdent = item.DoIdent;
                par.CoNumero = 0;
                par.DpNumero = 0;
                par.listado();
                
                double ImpMOE = 0;
                double ImpMXN = 0;

                foreach(DOCCPARTIDA itemP in par.listDCP)
                {
                    if (itemP.DpMonEx == "USD")
                    {
                        ImpMOE = ImpMOE + Math.Round((itemP.DpPrecio * itemP.DpCantidad), 2);
                    }
                    else
                    {
                        ImpMXN = ImpMXN + Math.Round((itemP.DpPrecio * itemP.DpCantidad), 2);
                    }
                }

                bat.ImporteMOE = ImpMOE;
                bat.ImporteMXN = ImpMXN;

                bateo.Add(bat);
            }
        }
    }

    public class _Cripto
    {
        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}
