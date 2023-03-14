using Ejemplo_ASP_NET_MVC.Herramientas;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Ejemplo_ASP_NET_MVC.Controllers
{
    public class TelefonoController : Controller
    {
        public IActionResult Index()
        {
            var ddbb = new InstitutoDbContext();
            var telefonos = ddbb.Telefonos.ToList();
            string texto = "";
            foreach (var telf in telefonos)
                texto += $"CI: {telf.codigoEst}, num: {telf.numero}" +
                    $"Nombre: {telf.estudiante.nombre}, Apellido: {telf.estudiante.apellido}\n";

            ViewBag.texto = texto;
            return View();
        }
    }
}
