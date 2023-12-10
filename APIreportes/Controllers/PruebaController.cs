using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace APIreportes.Controllers
{
    public class PruebaController : Controller
    {
        [HttpGet]
        [Route("prueba/prueba")]
        public ActionResult prueba()
        {
            ReportDocument report = new ReportDocument();
            report.Load(System.Web.HttpContext.Current.Server.MapPath("~/CrystalReport1.rpt"));
            report.DataSourceConnections[0].IntegratedSecurity = true;
            var a = report.ExportToStream(ExportFormatType.PortableDocFormat);

            return File(a, "application/pdf");
        }

        [HttpGet]
        public ActionResult empresas()
        {
            ReportDocument report = new ReportDocument();
            report.Load(System.Web.HttpContext.Current.Server.MapPath("~/UltimoMesEmpresas.rpt"));
            report.DataSourceConnections[0].IntegratedSecurity = true;
            var a = report.ExportToStream(ExportFormatType.PortableDocFormat);

            return File(a, "application/pdf");
        }

        [HttpGet]
        public ActionResult ventas()
        {
            ReportDocument report = new ReportDocument();
            report.Load(System.Web.HttpContext.Current.Server.MapPath("~/UltimoMesVentas.rpt"));
            report.DataSourceConnections[0].IntegratedSecurity = true;
            var a = report.ExportToStream(ExportFormatType.PortableDocFormat);

            return File(a, "application/pdf");
        }

        [HttpGet]
        public ActionResult usuarios()
        {
            ReportDocument report = new ReportDocument();
            report.Load(System.Web.HttpContext.Current.Server.MapPath("~/UltimoMesUsuarios.rpt"));
            report.DataSourceConnections[0].IntegratedSecurity = true;
            var a = report.ExportToStream(ExportFormatType.PortableDocFormat);

            return File(a, "application/pdf");
        }

        [HttpGet]
        public ActionResult guardadosWishlist()
        {
            ReportDocument report = new ReportDocument();
            report.Load(System.Web.HttpContext.Current.Server.MapPath("~/GuardadosWishlist.rpt"));
            report.DataSourceConnections[0].IntegratedSecurity = true;
            var a = report.ExportToStream(ExportFormatType.PortableDocFormat);

            return File(a, "application/pdf");
        }

        [HttpGet]
        public ActionResult visitas()
        {
            ReportDocument report = new ReportDocument();
            report.Load(System.Web.HttpContext.Current.Server.MapPath("~/Visitas.rpt"));
            report.DataSourceConnections[0].IntegratedSecurity = true;
            var a = report.ExportToStream(ExportFormatType.PortableDocFormat);

            return File(a, "application/pdf");
        }
    }
}
