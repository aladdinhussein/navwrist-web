using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Players")]
        public Dictionary<string, Player> GetPlayers()
        {
            return _GetSamplePlayers();
        }

        private Dictionary<string, Player> _GetSamplePlayers()
        {
            var dictionary = new Dictionary<string, Player>();
            var player1 = new Player() {Id = "57bccba1-dc47-4d08-9cf9-bccfab5c7e72", Name =  "Franko"};
            dictionary.Add(player1.Id, player1);
            var player2 = new Player() {Id = "a2150ecc-6f92-463c-b6d7-b263bc678dbc", Name = "Everyone Else"};
            dictionary.Add(player2.Id, player2);
            return dictionary;
        }

        [HttpGet("CompletedGames")]
        public Dictionary<string, CompletedGame> GetCompletedGames()
        {
            return _GetSampleCompletedGames(
                _GetSamplePlayers().Select(p => p.Value).ToList());
        }

        public Dictionary<string, CompletedGame> _GetSampleCompletedGames(List<Player> players)
        {
            var game = new CompletedGame(){ Id = "7c26bdcc-b355-4259-98bc-419553ec289e"};
            game.Winner = players[0].Id;
            game.WinnerScore = 21;
            game.Loser = players[1].Id;
            var dictionary = new Dictionary<string, CompletedGame>();
            dictionary.Add(game.Id, game);
            return dictionary;
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
