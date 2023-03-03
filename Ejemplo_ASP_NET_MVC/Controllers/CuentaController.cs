using Ejemplo_ASP_NET_MVC.Models;
using Ejemplo_ASP_NET_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ejemplo_ASP_NET_MVC.Controllers
{
    public class CuentaController : Controller
    {
        public IActionResult Index()
        {
            var cuentaVM = new CuentaViewModel();
            cuentaVM.Cuenta = new Models.Cuenta() { 
                Id = 123,
                Disponible = true,
                Genero = "M"
            };

            cuentaVM.Lenguajes = new List<Lenguaje>() { 
                new Lenguaje()
                {
                    Id = "leng1",
                    Nombre = "Java",
                    Tickeado = false
                },
                new Lenguaje()
                {
                    Id = "leng2",
                    Nombre = "C#",
                    Tickeado = true
                },
                new Lenguaje()
                {
                    Id = "leng3",
                    Nombre = "Python",
                    Tickeado = true
                }
            };
            var cargos = new List<Cargo>() { 
                new Cargo{Id="Rol1", Nombre="Auxiliar de sistemas"},
                new Cargo{Id="Rol2", Nombre="Consultor externo"},
                new Cargo{Id="Rol3", Nombre="Desarrollador"}
            };
            cuentaVM.Cargos = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(cargos, "Id","Nombre");
            return View("Index", cuentaVM);
        }
    }
}
