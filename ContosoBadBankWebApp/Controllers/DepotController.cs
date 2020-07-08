using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoBadBank.Models;

namespace ContosoBadBank.Controllers
{
    public class DepotController : Controller
    {
        private readonly StockDBContext _context;
        private string _currentUser;


        public DepotController(StockDBContext context)
        {

            _context = context;

        }


        //[Microsoft.AspNetCore.Authorization.Authorize]
        public async Task<IActionResult> DepotOverview()
        {
            var identity = User.Identity as System.Security.Claims.ClaimsIdentity;
            _currentUser = identity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            return View(await _context.DepotEntries.Where(t => t.objectId == _currentUser).ToListAsync());

        }

        //[Microsoft.AspNetCore.Authorization.Authorize]
        public async Task<IActionResult> Orders()
        {
            var identity = User.Identity as System.Security.Claims.ClaimsIdentity;
            _currentUser = identity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            return View(await _context.Orders.Where(t => t.objectId == _currentUser).ToListAsync());

        }


        public async Task<IActionResult> Buy()
        {
            return View();

        }

        public async Task<IActionResult> Sell(string stockSymbol)
        {
            
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmBuy([Bind("ID,NrOfTradeItems,StockSymbol")] Order trade)
        {
            var identity = User.Identity as System.Security.Claims.ClaimsIdentity;
            _currentUser = identity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            trade.TradeDate = DateTime.Now;
            trade.objectId = _currentUser;
            trade.OrderStatus = "open";
            trade.Action = "buy";

            if (ModelState.IsValid)
            {
                _context.Add(trade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Orders));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmSell([Bind("ID,NrOfTradeItems,StockSymbol")] Order trade)
        {
            var identity = User.Identity as System.Security.Claims.ClaimsIdentity;
            _currentUser = identity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            trade.TradeDate = DateTime.Now;
            trade.objectId = _currentUser;
            trade.OrderStatus = "open";
            trade.Action = "sell";
            trade.NrOfTradeItems = trade.NrOfTradeItems * -1;

            if (ModelState.IsValid)
            {
                _context.Add(trade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Orders));
            }
            return View();
        }



    }
}
