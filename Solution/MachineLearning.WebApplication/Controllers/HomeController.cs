using MachineLearning.ClassLibrary;
using MachineLearning.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace MachineLearning.WebApplication.Controllers
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
            string? formProcessed = Request.Query["btnSubmit"];

            if (formProcessed != null && formProcessed.ToLower() == "review")
            {
                string testText = "This movie was horrible.";
                string? inputText = Request.Query["txtInput"]; inputText.Trim();

                if (string.IsNullOrEmpty(inputText))
                {
                    inputText = testText;
                }

                ViewBag.InputText = inputText;

                MachineLearningApp app = new MachineLearningApp();
                string result = app.MakePrediction(inputText);

                ViewBag.Result = result;
                ViewBag.Title = "Machine Learning";
                ViewBag.TagLine = "A simple machine learning web application.";
                ViewBag.AllRightsReserved = "All rights reserved";
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
