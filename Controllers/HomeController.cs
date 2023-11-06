using Microsoft.AspNetCore.Mvc;
using MiProyecto_v1.Models;
using System.Diagnostics;
using Microsoft.ML;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Net.Mime.MediaTypeNames;


namespace MiProyecto_v1.Controllers
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


        public IActionResult Evaluate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Evaluate(string userInputText)
        {
            // Crear una instancia de ModelInput con el texto del usuario.
            var input = new SentimentModel.ModelInput
            {
                Col0 = userInputText
            };

            // Predecir el sentimiento utilizando el modelo.
            var result = SentimentModel.Predict(input);

            // Determinar si el sentimiento es positivo o negativo.
            var sentiment = result.PredictedLabel == 1 ? "Positive" : "Negative";

            // Pasar el resultado y el texto original de vuelta a la vista.
            ViewBag.SentimentResult = sentiment;
            ViewBag.UserInput = userInputText;
            return View("Evaluate");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}