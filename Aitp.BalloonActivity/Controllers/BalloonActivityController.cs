using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Aitp.BalloonActivity.Controllers
{
    public class BalloonActivityController : Controller
    {
        private static ICollection<Models.BalloonTeam> _teams = new List<Models.BalloonTeam>();

        // GET: /<controller>/
        
        public IActionResult Index()
        {
            return RedirectToAction("CreateTeam");
        }
                
        [HttpGet("BalloonActivity/Team/{team}")]
        public IActionResult Team(string team)
        {
            var tm = _teams.FirstOrDefault(t => t.Name == team);
            if(tm != null)
            {
                return View(tm);
            }
            return RedirectToAction("CreateTeam");
        }

        public IActionResult CreateTeam()
        {
            return View();
        }
        public IActionResult Save(Models.BalloonTeam team)
        {
            var tm = _teams.FirstOrDefault(t => t.Name == team.Name);
            if (tm != null)
            {
                tm.BalloonCount = team.BalloonCount;
                tm.Height = team.Height;
            }
            else
            {
                _teams.Add(team);
            }
            return Redirect("Team/" + team.Name);
        }

        public IActionResult ScoreBoard()
        {

            return View(_teams);
        }

        public IActionResult Delete(string team)
        {
            var tm = _teams.FirstOrDefault(t => t.Name == team);
            if (tm != null)
            {
                _teams.Remove(tm);
            }
            return RedirectToAction("ScoreBoard");
        }
    }
}
