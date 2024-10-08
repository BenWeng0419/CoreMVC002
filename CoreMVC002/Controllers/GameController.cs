using Microsoft.AspNetCore.Mvc;
using CoreMVC002.Models;

namespace CoreMVC002.Controllers
{
    public class GameController : Controller
    {
        private static XAXBEngine _game;

        public IActionResult Index()
        {
            if (_game == null)
            {
                _game = new XAXBEngine();
            }
            return View(_game);
        }

        [HttpPost]
        public IActionResult Guess(string guessNumber)
        {
            if (_game.IsGameOver(guessNumber))
            {
                ViewBag.GameOver = true;
                ViewBag.Message = "恭喜！你已經猜到這個數字了！";
            }
            else
            {
                ViewBag.GameOver = false;
            }
            return View("Index", _game);
        }

        [HttpPost]
        public IActionResult Restart()
        {
            _game.Reset();
            return RedirectToAction("Index");
        }
    }
}
