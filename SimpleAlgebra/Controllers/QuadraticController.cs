using Microsoft.AspNetCore.Mvc;
using SimpleAlgebra.Models;

namespace SimpleAlgebra.Controllers
{
    public class QuadraticController : Controller
    {
        public Quadratic quadratic1 = new Quadratic();
        public QuadraticDemo quadraticDemo = new QuadraticDemo();
        public IActionResult Index()
        {
            return View(quadraticDemo);
        }

        public IActionResult Standard()
        {
            return View(quadratic1);
        }

        public IActionResult Factored()
        {
            return View(quadratic1);
        }

        public IActionResult Vertex()
        {
            return View(quadratic1);
        }
    }
}
