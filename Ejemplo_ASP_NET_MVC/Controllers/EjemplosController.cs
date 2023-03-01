using Microsoft.AspNetCore.Mvc;
using System;

namespace Ejemplo_ASP_NET_MVC.Controllers
{
    public class EjemplosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EjemploPasarDatos()
        {
            ViewBag.edad = 13;
            ViewBag.nombre = "Pepe";
            ViewBag.aprobado = true;
            ViewBag.calificacion = 67.5;
            ViewBag.fechaAprobacion = DateTime.Now;
            return View();
        }
    }
}
