using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AdministradoresController : Controller
    {
        private readonly APIContext db;

        public AdministradoresController(APIContext context)
        {
            db = context;
        }


        class InfoEmpresas
        {
            public string cod { get; set; }
            public string nombre { get; set; }
            public string direccion { get; set; }
            public string pathArchivo { get; set; }
            public DateTime? fechaRevision { get; set; }
            public string fechaSolicitud { get; set; }
            public bool isRevisado { get; set; }
        }


        [HttpGet]
        public async Task<IActionResult> RevisionesPendientes([FromRoute]string cod)
        {
            var listaEmpresas = db.Empresa.Where(x => x.ListaEspera.codAdmin.Equals(cod)).Include(x => x.ListaEspera).ToList();

            if (listaEmpresas.Count > 0)
            {
                var response = new List<InfoEmpresas>();
                foreach (var emp in listaEmpresas)
                {
                    var info = new InfoEmpresas()
                    {
                        cod = emp.codEmpresa,
                        nombre = emp.nombreEmpresa,
                        direccion = emp.direccionEmpresa,
                        pathArchivo = emp.archivoVerificacionEmpresa,
                        fechaRevision = emp.ListaEspera.fechaRevision,
                        fechaSolicitud = emp.ListaEspera.fechaSolicitudRevision.ToString("dd-MM-yyyy"),
                        isRevisado = emp.ListaEspera.isRevisado
                    };
                    response.Add(info);
                }
                return Ok(response);
            }

            return BadRequest("No hay ninguna empresa asignada a este usuario");
        }
        //public async Task<IActionResult> Create(Administrador request)
        //{

        //}
    }
}
