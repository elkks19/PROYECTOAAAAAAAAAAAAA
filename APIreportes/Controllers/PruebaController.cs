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
    }
}
