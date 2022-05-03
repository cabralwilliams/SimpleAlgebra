using Microsoft.AspNetCore.Mvc;
using SimpleAlgebra.Models;

namespace SimpleAlgebra.Controllers
{
    public class QuadraticController : Controller
    {
        public Quadratic quadratic1 = new Quadratic();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Standard()
        {
            return View(quadratic1);
        }
    }
}
