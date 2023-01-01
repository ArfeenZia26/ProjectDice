using dice.web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

namespace dice.web.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
     
        public IActionResult GetDiceRollResult(int face1, int factor1, int face2, int factor2, int times)
        {
            var vm = new ViewModel();
            var dice1 = new Utility.Dice();
            var dice2 = new Utility.Dice();

            dice1.GetDice();
            dice1.FavourSelection(face1, factor1);

            dice2.GetDice();
            dice2.FavourSelection(face2, factor2);

            for(int i=0; i < times; i++)
            {
                var d1 = dice1.RollDice();
                var d2 = dice2.RollDice();
                var result = new DicesFace
                {
                    Dice1 = new Dice
                    {
                        Face = d1,
                    },
                    Dice2 = new Dice
                    {
                        Face = d2,
                    },
                    Total = d1 + d2

                };
               vm.Dice.Add(result);
            }
            return PartialView("LoadResults", vm);
        }
    }
}