using Microsoft.AspNetCore.Mvc;
using MvcCreditApp.Models;
using System.Diagnostics;
using MvcCreditApp.Models;
using MvcCreditApp.Data;
using Microsoft.AspNetCore.Authorization;

namespace MvcCreditApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly CreditContext db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, CreditContext context)
        {
            
            _logger = logger;
            db = context;
        }

        private void GiveGredits() 
        {
            var allCredits = db.Credits.ToList<Credit>();
            ViewBag.Credits = allCredits;
        }

        public IActionResult Index()
        {
            GiveGredits();
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

        [Authorize]
        public ActionResult CreateBid() 
        {
            GiveGredits();
            var allBids = db.Bids.ToList<Bid>();
            ViewBag.Bids = allBids;
            return View();
        }

        [HttpPost]
        public string CreateBid(Bid newBid) 
        { 
            newBid.bidDate = DateTime.Now;
            db.Bids.Add(newBid);
            db.SaveChanges();
            return "Спасибо, " + newBid.Name + ", за выбор нашего банка.Ваша заявка будет рассмотрена в течении 10 дней.";
        }

        public ActionResult BidSearch (string name) 
        {
            var allBids = db.Bids.Where(a => a.CreditHead.Contains(name)).ToList();
            if (allBids.Count == 0)
            {
                return Content("Указанный кредит " + name + " не найден"); 
                // с помощью метода Content, контроллер может вернуть просто текст, без какого либо представления
            }
            return PartialView(allBids);
        }
    }
}
