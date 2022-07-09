using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaENMECS.BLL
{
    class Estructuras
    {
        public Estructuras()
        {

        }
    }

    public enum modo
    {
        none = 0,
        insert = 1,
        update = 2,
        delete = 3,
        select = 4
    }

    public enum tipoFolio
    {
        ART = 0,
        BKF = 1,
        CLI = 2,
        CON = 3,
        COT = 4,
        EMP = 5,
        EMX = 6,
        NOT = 7,
        PAR = 8,
        PRE = 9,
        PRO = 10,
        PRV = 11,
        PRY = 12,
        SER = 13,
        SOF = 14
    }

    public struct DIRECTORIO
    {
        public string DiNumero;
        public string DiTipo;
        public string DiTipo2;
        public string DiRFC;
        public string DiRazonSocial;
        public string DiTipoEmpresa;
        public string DiNombreCom;
        public string DiCalle;
        public string DiNumExt;
        public string DiNumInt;
        public string DiColonia;
        public string DiCP;
        public string DiPoblacion;
        public string DiMunicipio;
        public string DiEstado;
        public string DiPais;
        public string DiNacional;
        public string DiPaginaWeb;
        public string DiNomCorto;
        public string DiClasif;
        public string DiRapido;
        public string DiCCredito;
        public int DiDCredito;
        public double DiLCredito;
        public string DiDBBenef;
        public string DiDBBanco;
        public string DiDBSucursal;
        public string DiDBNumCta;
        public string DiDBCLABE;
        public int DiPjDesc;
        public string DiActivo;
        //AUDITORIA
        public string DiAudUsuCre;
        public DateTime DiAudFeCre;
        public string DiAudUsuMod;
        public DateTime DiAudFeMod;
        public string DiAudUsuEl;
        public DateTime DiAudFeEl;
    }

    public struct CONTACTO
    {
        public string DiNumero;
        public int CnNumero;
        public string CnTipo;
        public string CnNombre;
        public string CnAPaterno;
        public string CnAMaterno;
        public string CnCorreo;
        public string CnTelefono;
        public string CnPuesto;
        public string CnGradoEst;
        public string CnAbrGraEst;
        public string CnCedula;
        public string CnNota;
        public string CnActivo;
        //AUDITORIA
        public string CnAudUsuCre;
        public DateTime CnAudFeCre;
        public string CnAudUsuMod;
        public DateTime CnAudFeMod;
        public string CnAudUsuEl;
        public DateTime CnAudFeEl;
    }

    public struct USUARIO
    {
        public string DiNumero;
        public int CnNumero;
        public string UsNombre;
        public string UsUsuario;
        public string UsPassword;
        public string UsPerfil;
        public string UsActivo;
        //AUDITORIA
        public string UsAudUsuCre;
        public DateTime UsAudFeCre;
        public string UsAudUsuMod;
        public DateTime UsAudFeMod;
        public string UsAudUsuEl;
        public DateTime UsAudFeEl;
    }

    public struct PROYECTO
    {
        public string PyNumero;
        public int PyFolio;
        public string PyNombre;
        public string PyNomCorA;
        public string PyNomCarp;
        public string PyObjetivo;
        public string PyTipoSis;
        public string PyEstado;
        public string PyMaster;
        public string DiNumero;
        public string DiNombre;
        public string EmIdent;
        public string PyCambio;
        public string PyUsuCam;
        public DateTime PyFeCam;
        public string PyEstatus;
        public string PyClasif;
        public string PyActivo;
        //AUDITORIA
        public string PyAudUsuCre;
        public DateTime PyAudFeCre;
        public string PyAudUsuMod;
        public DateTime PyAudFeMod;
        public string PyAudUsuEl;
        public DateTime PyAudFeEl;
    }

    public struct ARTICULO
    {
        public string ArIdent;
        public string ArCodigo;
        public string ArCodCom;
        public string ArDescripcion;
        public double ArCosto;
        public double ArPrecioPub;
        public string ArMoneda;
        public string ArUnidad;
        public string ArClasificacion;
        public string ArCategoria;
        public string ArUso;
        public string ArTipo;
        public string ArModeloCom;
        public string ArMarca;
        public string ArGenerico;
        public string ArAlto;
        public string ArLargo;
        public string ArAncho;
        public string ArPeso;
        public string ArActivo;
        //AUDITORIA
        public string ArAudUsuCre;
        public DateTime ArAudFeCre;
        public string ArAudUsuMod;
        public DateTime ArAudFeMod;
        public string ArAudUsuEl;
        public DateTime ArAudFeEl;
    }

    public struct CONFIGURACION
    {
        public string CgIdent;
        public string CgImpuesto;
        public double CgPjImpuesto;
        public string CgMoneda;
        public string CgGcIdent;
        public string CgCrIdent;
        public string CgPathPry;
        public string CgPathCot;
        public string CgNoTipo;
        public string CgDfArt;
        public string CgDfCli;
        public string CgDfPrv;
        public string CgDfEmp;
        public string CgDfPry;
        public string CgActivo;
        //AUDITORIA
        public string CgAudUsuCre;
        public DateTime CgAudFeCre;
        public string CgAudUsuMod;
        public DateTime CgAudFeMod;
        public string CgAudUsuEl;
        public DateTime CgAudFeEl;
    }

    public struct FOLIO
    {
        public string FoIdent;
        public string FoTipo;
        public string FoDescrip;
        public int FoFolio;
        public string FoPath;
        public string FoActivo;
        //AUDITORIA
        public string FoAudUsuCre;
        public DateTime FoAudFeCre;
        public string FoAudUsuMod;
        public DateTime FoAudFeMod;
        public string FoAudUsuEl;
        public DateTime FoAudFeEl;
    }

    public struct TIPOCAMBIO
    {
        public string TcIdent;
        public DateTime TcFecha;
        public double TcImporte;
        public string TcMonedaOri;
        public DateTime FeIni;
        public DateTime FeFin;
        //AUDITORIA
        public string TcAudUsuCre;
        public DateTime TcAudFeCre;
        public string TcAudUsuMod;
        public DateTime TcAudFeMod;
    }

    public struct NOTA
    {
        public string NoIdent;
        public string NoTipo;
        public string NoDescripcion;
        public string EfIdent;
        public string NoActivo;
        //DOCNOTA
        public string DoIdent;
        public int DnNumero;
        public string DnDescripcion;
        public string DnActivo;
        //AUDITORIA
        public string NoAudUsuCre;
        public DateTime NoAudFeCre;
        public string NoAudUsuMod;
        public DateTime NoAudFeMod;
        public string NoAudUsuEl;
        public DateTime NoAudFeEl;
    }

    public struct EFECTO
    {
        public string EfIdent;
        public string EfTipo;
        public string EfDescripcion;
        public string EfUnidad;
        public double EfValor01;
        public double EfValor02;
        public double EfValor03;
        public double EfValor04;
        public double EfValor05;
        public DateTime EfFecha01;
        public DateTime EfFecha02;
        public DateTime EfFecha03;
        public DateTime EfFecha04;
        public DateTime EfFecha05;
        public string EfCodigo01;
        public string EfCodigo02;
        public string EfCodigo03;
        public string EfCodigo04;
        public string EfCodigo05;
        public string EfActivo;
        //AUDITORIA
        public string EfAudUsuCre;
        public DateTime EfAudFeCre;
        public string EfAudUsuMod;
        public DateTime EfAudFeMod;
        public string EfAudUsuEl;
        public DateTime EfAudFeEl;
    }

    public struct EMPRESA
    {
        public string EmIdent;
        public string EmLogotipo;
        public string EmLeyenda01;
        public string EmLeyenda02;
        public string EmLeyenda03;
        public string EmLeyenda04;
        public string EmLeyenda05;
        public string DiNumero;
        public string DiNomCorto;
        public string EmPrefijo;
        public string EmPrefijoPry;
        public string EmGrIdent;
        public string EmCrIdent;
        public string EmGrIdCot;
        public string EmCrIdCot;
        public string EmActivo;
        //AUDITORIA
        public string EmAudUsuCre;
        public DateTime EmAudFeCre;
        public string EmAudUsuMod;
        public DateTime EmAudFeMod;
        public string EmAudUsuEl;
        public DateTime EmAudFeEl;
    }

    public struct DOCUMENTO
    {
        public string DoIdent;
        public string DoTipo;
        public string DoFolio;
        public int DoVersion;
        public string DoVersionL;
        public DateTime DoFecha;
        public string PyNumero;
        public string PyNombre;
        public string EmIdent;
        public string EmNombre;
        public string DiNumero;
        public string DiNomCorto;
        public int CnNumero01;
        public int CnNumero02;
        public int CnNumero03;
        public int CnNumero04;
        public int CnNumero05;
        public double DoSubTotalMoE;
        public double DoTotalMoE;
        public string DoMonEx;
        public double DoSubTotal;
        public double DoDesc;
        public double DoPjDesc;
        public string DoTipoDesc;
        public double DoSubTDesc;
        public int DoImpuesto;
        public double DoImpImp;
        public double DoTotal;
        public string DoMoneda;
        public string DoNombre;
        public string DoPath;
        public DateTime DoFechaIni;
        public DateTime DoFechaFin;
        public string DoEstatus;
        public int DoAvance;
        public string DoUsuSeg;
        public double DoTiCambio;
        public string DoReferencia;
        public string DoDescripcion;
        public string DoDocRef;
        public string DoVendedor;
        public string DoGrupo;
        public int DoGrupoOrden;
        public string DoActivo;
        public DateTime FeIni;
        public DateTime FeFin;
        //AUDITORIA
        public string DoAudUsuCre;
        public DateTime DoAudFeCre;
        public string DoAudUsuMod;
        public DateTime DoAudFeMod;
        public string DoAudUsuEl;
        public DateTime DoAudFeEl;
    }

    public struct DOCNOTA
    {
        public string DoIdent;
        public int DnNumero;
        public string DnDescripcion;
        public string DnTipo;
        public int DnOrden;
        public string NoIdent;
        public string DnActivo;
        //AUDITORIA
        public string DnAudUsuCre;
        public DateTime DnAudFeCre;
        public string DnAudUsuMod;
        public DateTime DnAudFeMod;
        public string DnAudUsuEl;
        public DateTime DnAudFeEl;
    }

    public struct DOCCONCEPTO
    {
        public string DoIdent;
        public int CoNumero;
        public string CoDescripcion;
        public string DcDescripcion;
        public double DcPjDesc;
        public double DcImpDesc;
        public double DcSubtotal;
        public double DcTotal;
        public string DcMoneda;
        public string DcEstatus;
        public int DcAvance;
        public string DcReferencia;
        public DateTime DcFeInicio;
        public DateTime DcFeTermino;
        public DateTime DcFeCancel;
        public int DcOrden;
        public string DcActivo;
        //AUDITORIA
        public string DcAudUsuCre;
        public DateTime DcAudFeCre;
        public string DcAudUsuMod;
        public DateTime DcAudFeMod;
        public string DcAudUsuEl;
        public DateTime DcAudFeEl;
    }

    public struct CONCEPTO
    {
        public int CoNumero;
        public string CoDescripcion;
        public string CoActivo;
        //AUDITORIA
        public string CoAudUsuCre;
        public DateTime CoAudFeCre;
        public string CoAudUsuMod;
        public DateTime CoAudFeMod;
        public string CoAudUsuEl;
        public DateTime CoAudFeEl;
    }

    public struct DOCCPARTIDA
    {
        public string DoIdent;
        public int CoNumero;
        public int DpNumero;
        public string ArIdent;
        public string DiNumero;
        public string DpDescripcion;
        public double DpCantidad;
        public string DpUnidad;
        public double DpCosto;
        public double DpPjCosto;
        public double DpPrecio;
        public double DpSubtotal;
        public double DpPjDesc;
        public double DpImpDesc;
        public double DpImporteMoE;
        public string DpMonEx;
        public double DpImporte;
        public string DpTratamiento;
        public string DpEstatus;
        public int DpAvance;
        public string DpReferencia;
        public string DpFabricado;
        public DateTime DpFePedidoPg;
        public DateTime DpFePedidoRe;
        public DateTime DpFeReciboPg;
        public DateTime DpFeReciboRe;
        public DateTime DpFeEnvioPg;
        public DateTime DpFeEnvioRe;
        public DateTime DpFeEntregaPg;
        public DateTime DpFeEntregaRe;
        public DateTime DpFeCancel;
        public int DpOrden;
        public string DpActivo;
        public string ArCodigo;
        public double ArPrecioPub;
        //AUDITORIA
        public string DpAudUsuCre;
        public DateTime DpAudFeCre;
        public string DpAudUsuMod;
        public DateTime DpAudFeMod;
        public string DpAudUsuEl;
        public DateTime DpAudFeEl;
    }

    public struct DOCCPNOTA
    {
        public string DoIdent;
        public int CoNumero;
        public int DpNumero;
        public int DtNumero;
        public string DtDescripcion;
        public string DtTipo;
        public int DtOrden;
        public string NoIdent;
        public string DtArIdent;
        public int DtAnNumero;
        public string DtActivo;
        //AUDITORIA
        public string DtAudUsuCre;
        public DateTime DtAudFeCre;
        public string DtAudUsuMod;
        public DateTime DtAudFeMod;
        public string DtAudUsuEl;
        public DateTime DtAudFeEl;
    }

    public struct DOCSEGUIMIENTO
    {
        public string DoIdent;
        public int DsNumero;
        public DateTime DsFechaSeg;
        public string DsDescripcion;
        public DateTime DsFechaReal;
        public string DsObservacion;
        public string DsActivo;
        //AUDITORIA
        public string DsAudUsuCre;
        public DateTime DsAudFeCre;
        public string DsAudUsuMod;
        public DateTime DsAudFeMod;
        public string DsAudUsuEl;
        public DateTime DsAudFeEl;
    }

    public struct PAGO
    {
        public int PgNumero;
        public double PgMontoPrg;
        public double PgMontoReal;
        public string PgMoneda;
        public DateTime PgFechaPrg;
        public DateTime PgFechaReal;
        public string PgObservacion;
        public string DoIdent;
        public string DiNumeroCl;
        public string DiNombreCl;
        public string DiNumeroPv;
        public string DiNombrePv;
        public string PgTipo;
        public string PgReferencia;
        public string PgActivo;
        //AUDITORIA
        public string PgAudUsuCre;
        public DateTime PgAudFeCre;
        public string PgAudUsuMod;
        public DateTime PgAudFeMod;
        public string PgAudUsuEl;
        public DateTime PgAudFeEl;
    }

    public struct PRECIOLISTA
    {
        public string ArIdent;
        public string DiNumero;
        public string ArDescripcion;
        public string DiNomCorto;
        public double PlPrecioLista;
        public string PlMoneda;
        public string PlCodPrv;
        public string PlPlazo;
        public string PlReferencia;
        public string PlObservacion;
        public string PlActivo;
        //AUDITORIA
        public string PlAudUsuCre;
        public DateTime PlAudFeCre;
        public string PlAudUsuMod;
        public DateTime PlAudFeMod;
        public string PlAudUsuEl;
        public DateTime PlAudFeEl;
    }

    public struct PLANTILLA
    {
        public string PaIdent;
        public string PaDescripcion;
        public string DoIdent;
        public string PaActivo;
        //AUDITORIA
        public string PaAudUsuCre;
        public DateTime PaAudFeCre;
        public string PaAudUsuMod;
        public DateTime PaAudFeMod;
        public string PaAudUsuEl;
        public DateTime PaAudFeEl;
    }

    public struct CATEGORIA
    {
        public string CaIdent;
        public string CaDescripcion;
        public string CaActivo;
        //AUDITORIA
        public string CaAudUsuCre;
        public DateTime CaAudFeCre;
        public string CaAudUsuMod;
        public DateTime CaAudFeMod;
        public string CaAudUsuEl;
        public DateTime CaAudFeEl;
    }

    public struct CATEGORIAPRV
    {
        public string CaIdent;
        public string DiNumero;
        public string CaDescripcion;
        public string DiNombreCom;
        public string CpActivo;
        //AUDITORIA
        public string CpAudUsuCre;
        public DateTime CpAudFeCre;
        public string CpAudUsuMod;
        public DateTime CpAudFeMod;
        public string CpAudUsuEl;
        public DateTime CpAudFeEl;
    }

    public struct CODIGO
    {
        public string CdCategoria;
        public string CdGrupo;
        public string CdTipo;
        public string CdDescripcion;
        public int CdOrden;
        public string CdActivo;
        //AUDITORIA
        public string CdAudUsuCre;
        public DateTime CdAudFeCre;
        public string CdAudUsuMod;
        public DateTime CdAudFeMod;
        public string CdAudUsuEl;
        public DateTime CdAudFeEl;
    }

    public struct CALVENTA
    {
        public string DoIdent;
        public int CvPresupuesto;
        public int CvAutoridad;
        public int CvNecesidad;
        public int CvTiempo;
        public int CvCalificacion;
        public string CvOportunidad;
        public string CvActivo;
        //AUDITORIA
        public string CvAudUsuCre;
        public DateTime CvAudFeCre;
        public string CvAudUsuMod;
        public DateTime CvAudFeMod;
        public string CvAudUsuEl;
        public DateTime CvAudFeEl;
    }

    public struct GRCARP
    {
        public string GcIdent;
        public string GcDescripcion;
        public string GcPath;
        public string GcActivo;
        //AUDITORIA
        public string GcAudUsuCre;
        public DateTime GcAudFeCre;
        public string GcAudUsuMod;
        public DateTime GcAudFeMod;
        public string GcAudUsuEl;
        public DateTime GcAudFeEl;
    }

    public struct CARPETA
    {
        public string GcIdent;
        public string CrIdent;
        public string CrNombre;
        public string CrActivo;
        //AUDITORIA
        public string CrAudUsuCre;
        public DateTime CrAudFeCre;
        public string CrAudUsuMod;
        public DateTime CrAudFeMod;
        public string CrAudUsuEl;
        public DateTime CrAudFeEl;
    }

    public struct PRYCARP
    {
        public string PyNumero;
        public string GcIdent;
        public string CrIdent;
        public string PcActivo;
        //AUDITORIA
        public string PcAudUsuCre;
        public DateTime PcAudFeCre;
        public string PcAudUsuMod;
        public DateTime PcAudFeMod;
        public string PcAudUsuEl;
        public DateTime PcAudFeEl;
    }

    public struct ARTNOTA
    {
        public string ArIdent;
        public int AnNumero;
        public string AnDescripcion;
        public string AnTipo;
        public int AnOrden;
        public string NoIdent;
        public string AnCaIdent;
        public int AnCtNumero;
        public string AnActivo;
        //AUDITORIA
        public string AnAudUsuCre;
        public DateTime AnAudFeCre;
        public string AnAudUsuMod;
        public DateTime AnAudFeMod;
        public string AnAudUsuEl;
        public DateTime AnAudFeEl;
    }

    public struct CATNOTA
    {
        public string CaIdent;
        public int CtNumero;
        public string CtDescripcion;
        public string CtTipo;
        public int CtOrden;
        public string NoIdent;
        public string CtActivo;
        //AUDITORIA
        public string CtAudUsuCre;
        public DateTime CtAudFeCre;
        public string CtAudUsuMod;
        public DateTime CtAudFeMod;
        public string CtAudUsuEl;
        public DateTime CtAudFeEl;
    }

    public struct PARTIDASDOC
    {
        public string DiNumero;
        public string DiNomCorto;
        public string PyNumero;
        public string PyNombre;
        public string PyObjetivo;
        public string PyTipoSis;
        public string DoIdent;
        public string DoDescripcion;
        public int CoNumero;
        public string DcDescripcion;
        public int DpNumero;
        public string DpDescripcion;
        public string ArIdent;
    }

    public struct ARTICULOCLIENTES
    {
        public string ArIdent;
        public string DiNumero;
        public string DiNombreCom;
        public string DiNomCorto;
        public string DoFolio;
    }
    
    public struct BATEO
    {
        public string DoIdent;
        public string DoFolio;
        public int DoVersion;
        public string DoVersionL;
        public DateTime DoFecha;
        public string DoUsuSeg;
        public string DoActivo;
        public string PyNumero;
        public int PyFolio;
        public string PyNombre;
        public string PyActivo;

        public int CvCalificacion;
        public string CvOportunidad;
        public string Interes;
        public string PlanAccion;
        public string Norte;

        public double ImporteMOE;
        public double ImporteMXN;
    }
}
