using Ejemplo_ASP_NET_MVC.Herramientas;
using Ejemplo_ASP_NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
            if (ConversorParaSesiones.JsonAobjeto<List<Item>>(HttpContext.Session, "carrito") == null)
            {
                List<Item> carrito = new List<Item>();
                carrito.Add(new Item { Producto = prodMod.getProducto(id), Cantidad = 1 });
                ConversorParaSesiones.ObjetoAjson(HttpContext.Session, "carrito", carrito);
            }
            else {
                List<Item> carrito = ConversorParaSesiones.JsonAobjeto<List<Item>>(HttpContext.Session, "carrito");
                int indice = existeProducto(id);
                if (indice > -1) {
                    // el valor es 0, 1 o más
                    carrito[indice].Cantidad++;
                }
                else {
                    carrito.Add(new Item { Producto = prodMod.getProducto(id), Cantidad = 1 });
                }
                ConversorParaSesiones.ObjetoAjson(HttpContext.Session, "carrito", carrito);
            }
            return RedirectToAction("Index");
        }

        private int existeProducto(string id)
        {
            List<Item> carrito = ConversorParaSesiones.JsonAobjeto<List<Item>>(HttpContext.Session, "carrito");
            for (int i= 0; i< carrito.Count; i++) {
                if (carrito[i].Producto.Id.Equals(id))
                    return i;//Sí existe un rpducto con ese id, retornamos su posición en el carrito
            }
            return -1;//Nunca encontró un producto con el id recivido.
        }
        [Route("Quitar/{id}")]
        public IActionResult Quitar(string id) {
            List<Item> carrito = ConversorParaSesiones.JsonAobjeto<List<Item>>(HttpContext.Session, "carrito");
            int indice = existeProducto(id);
            carrito.RemoveAt(indice);
            ConversorParaSesiones.ObjetoAjson(HttpContext.Session, "carrito", carrito);
            return RedirectToAction("Index");
        }
    }
}
