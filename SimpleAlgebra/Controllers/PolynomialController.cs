using Microsoft.AspNetCore.Mvc;
using SimpleAlgebra.Models;

namespace SimpleAlgebra.Controllers
{
    public class PolynomialController : Controller
    {
        PolynomialDemo polyDemo = new PolynomialDemo();
        public IActionResult Index()
        {
            return View(polyDemo);
        }
    }
}
