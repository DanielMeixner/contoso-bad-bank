using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using ContosoBadBank.Models;

namespace ContosoBadBank.Controllers
{
    public class HomeController : Controller
    {

        private readonly StockDBContext _context;

        public HomeController(StockDBContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
          

            var t = new Order();
            //t.ID = 1;
            t.NrOfTradeItems = 42;
            var identity = User.Identity as System.Security.Claims.ClaimsIdentity;
            var userId = identity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            t.objectId = userId;
            t.StockSymbol = "MSFT";
            t.TradeDate = DateTime.Now;
            t.Price = 14.92M;
            //_context.Add(t);
            //await _context.SaveChangesAsync();
            var c = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            //var res = User.Claims.FirstOrDefault(e => e.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;
            //var identity = User.Identity as System.Security.Claims.ClaimsIdentity;
            //var userId = identity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            


            return View();
        }

        [Authorize]
        public IActionResult Claims()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}