using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FizzBuzzCore.Models;

namespace FizzBuzzCore.Controllers
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

        public IActionResult Code()
        {
            return View();
        }
        public IActionResult Solve()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solve(string fizzNum1, string fizzNum2)
        {
            if (string.IsNullOrWhiteSpace(fizzNum1) || string.IsNullOrWhiteSpace(fizzNum2))
            {
                return View();
            }
            int num1 = Int32.Parse(fizzNum1);
            int num2 = Int32.Parse(fizzNum2);
            // Start fizzbuzz
            ViewData["FizzBuzz"] = "";
            for(var i = 1; i <= 100; i++)
            {
                if (i % num1 == 0 && i % num2 == 0)
                {
                    // fizz buzz
                    ViewData["FizzBuzz"] += " FizzBuzz! -";
                } else if (i % num1 == 0)
                {
                    // fizz
                    ViewData["FizzBuzz"] += " Fizz! -";
                } else if (i % num2 == 0)
                {
                    // buzz
                    ViewData["FizzBuzz"] += " Buzz! -";
                } else
                {
                    // i
                    ViewData["FizzBuzz"] += $" {i} -";
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
