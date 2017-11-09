using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConquestionWebApp.RemoteWCFConquestionService;

namespace ConquestionWebApp.Controllers
{
    public class HomeController : Controller
    {
        ConquestionServiceClient client = new ConquestionServiceClient();
        [HttpPost]
        public ActionResult SavePlayer(Player player)
        {
            client.CreatePlayer(player);
            return View(player);
        }

        public ActionResult SavePlayer()
        {
            return View();
        }

        public ActionResult CreateNewPlayer()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}