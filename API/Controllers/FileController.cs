//using API.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace API.Controllers
//{
//    public class FileController : Controller
//    {
//        //protected internal async Task<string> ArchivoVerificacion(IFormFile archivo)
//        //{
//        //    string[] acceptedExtensions = { "pdf", "png", "jpg", "jpeg" };
//        //    var extension = archivo.FileName.Split(".").Last();

//        //    if (!acceptedExtensions.Contains(extension))
//        //    {
//        //        return null;
//        //    }
//        //}


//        //protected internal async Task<string> PFP(IFormFile archivo)
//        //{

//        //}


//        protected internal async Task<string> ImgProducto(IFormFile archivo, Empresa empresa)
//        {
//            string[] acceptedExtensions = { "png", "jpg", "jpeg" };
//            var extension = archivo.FileName.Split(".").Last();

//            if (!acceptedExtensions.Contains(extension))
//            {
//                return null;
//            }
//        }
        
//        private void GuardarArchivo(IFormFile archivo, Empresa empresa)
//        {
//            string path = dir + "\\" + empresa.nombreEmpresa + "\\" + archivo.FileName;

//            if (!Directory.Exists(dir + "\\" + empresa.nombreEmpresa))
//            {
//                Directory.CreateDirectory(dir + "\\" + empresa.nombreEmpresa);
//            }

//            string[] acceptedExtensions = {"pdf", "png", "jpg", "jpeg"};
//            var extension = archivo.FileName.Split(".").Last();
//            var ok = Array.Exists(acceptedExtensions, e => e == extension);
//            if(archivo.Length > 0)
//            {
//                if (!ok)
//                {
//                    return BadRequest("Tipo de archivo invalido");
//                }

//                if (!System.IO.File.Exists(path))
//                {
//                    var diskFile = System.IO.File.Create(path);
//                    await archivo.CopyToAsync(diskFile);
//                    diskFile.Close();
//                }
//                else
//                {
//                    var diskFile = System.IO.File.Open(path, FileMode.Open);
//                    await archivo.CopyToAsync(diskFile);
//                    diskFile.Close();
//                }
//            }

//            var cantEmpresas = db.Empresa.Count() + 1;
//            Empresa empresa = new Empresa()
//            {
//                codEmpresa = "EMP-" + cantEmpresas.ToString("000"),
//                nombreEmpresa = request.nombreEmpresa,
//                direccionEmpresa = request.direccionEmpresa,
//                archivoVerificacionEmpresa = path
//            };
//        }
//    }
//}
