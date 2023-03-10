using Ejemplo_ASP_NET_MVC.Herramientas;
using Ejemplo_ASP_NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Ejemplo_ASP_NET_MVC.Controllers
{
    public class CarritoController : Controller
    {
        public IActionResult Index()
        {
            //El carrito solo guarda items -> carrot ES un List<Item> -> En la sesión estará guardado List<Item>
            var carrito = ConversorParaSesiones.JsonAobjeto<List<Item>>(HttpContext.Session, "carrito");
            ViewBag.carrito = carrito;
            ViewBag.total = carrito.Sum(it => it.Producto.Precio * it.Cantidad);//Usando LINQ
            return View();
        }
        [Route("Agregar/{id}")]
        public IActionResult Agregar(string id) {
            ProductoModel prodMod = new ProductoModel();

        }
    }
}
