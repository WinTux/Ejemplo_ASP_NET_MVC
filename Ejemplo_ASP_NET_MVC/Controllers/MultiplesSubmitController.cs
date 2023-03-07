using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_ASP_NET_MVC.Controllers
{
    [Route("multi")]
    public class MultiplesSubmitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("destino1")]
        public IActionResult Destino1()
        {
            return View("Destino1");
        }
        [HttpPost]
        [Route("destino2")]
        public IActionResult Destino2()
        {
            return View("Destino2");
        }
        [HttpPost]
        [Route("destino3")]
        public IActionResult Destino3()
        {
            return View("Destino3");
        }
    }
}
