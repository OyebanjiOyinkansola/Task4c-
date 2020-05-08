using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webApp.Models;

namespace webApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Squarer(String NosOne, String NosTwo){
            ViewBag.Result = SqrtMethod(NosOne, NosTwo);
            return View();
        }
        
        private static String SqrtMethod(String N1, String N2 ){
            int NosOne;
            int NosTwo;
            string result = string.Empty;
            bool Nos1 =int.TryParse(N1, out NosOne);
            bool Nos2 =int.TryParse(N2, out NosTwo);

            if (N1 == "" || N2 == ""){
                result = "Please input a value";
            }

            else if (Nos1 && Nos2) {
                if (NosOne < 0 || NosTwo < 0) {
                    result = "Error! This is not a valid input. It is a negative number";
                }
                else {
                    double value1 = Math.Sqrt(N1);
                    double value2 = Math.Sqrt(N2);

                    if (value1 > value2) {
                        result = "The number " + NosOne + "with Square root " + Nos1 + "Has a higher square root than the number " + NosTwo + "with Square root " + Nos2;
                    }
                    else if (value1 < value2) {
                        result = "The number " + NosTwo + "with Square root " + Nos2 + "Has a higher square root than the number" + NosOne + "with Square root " + Nos1;
                    }
                    else if (value1 == value2){
                        result = "These values are equal. Please enter another value";
                    }
                }
            }
            else {
                result = "Invalid! Please enter a valid number";
            }

            return result;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
