using Microsoft.AspNetCore.Mvc;
using SimpleAlgebra.Models;

namespace SimpleAlgebra.Controllers
{
    public class LinearController : Controller
    {
        StandardLine standardLine = new StandardLine();
        LinearStandardWord linearStandardWord = new LinearStandardWord();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Standard()
        {
            Console.WriteLine("In the standard view.");
            return View(standardLine);
        }

        public IActionResult StandardResults()
        {
            StandardLine toSend = standardLine;
            Console.WriteLine(toSend.messageLS1);
            Console.WriteLine(toSend.messageLS2);
            return View(toSend);
        }

        public IActionResult WordProblems()
        {
            return View(linearStandardWord);
        }

        [HttpPost]
        public IActionResult CheckAnswers(string studentResponseLS1, string studentResponseLS2)
        {
            Console.WriteLine("Received Request");
            Console.WriteLine(studentResponseLS1);
            Console.WriteLine(studentResponseLS2);
            standardLine.CheckSL1(studentResponseLS1);
            int response2 = Int32.Parse(studentResponseLS2);
            standardLine.CheckSL2(response2);
            Console.WriteLine("***After Checking Answers***");
            Console.WriteLine(standardLine.messageLS1);
            Console.WriteLine(standardLine.messageLS2);
            return RedirectToAction(nameof(StandardResults));
        }

        [HttpPost]
        public IActionResult ResetStandard1()
        {
            Console.WriteLine("Problem Reset");
            standardLine.ResetStandard1();
            return View(standardLine);
        }
    }
}
