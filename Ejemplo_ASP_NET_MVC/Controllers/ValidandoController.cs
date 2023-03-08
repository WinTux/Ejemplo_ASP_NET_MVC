using Ejemplo_ASP_NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_ASP_NET_MVC.Controllers
{
    public class ValidandoController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", new CuentaUsuario());
        }
        [HttpPost]
        public IActionResult Registrar(CuentaUsuario cuentaUsuario) {
            if (ModelState.IsValid)
            {
                ViewBag.cuenta = cuentaUsuario;
                return View("Exito");
            }
            else {
                return View("Index");
            }

        }
    }
}
