using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoBadBank.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string objectId { get; set; }
        public DateTime TradeDate { get; set; }
        public int NrOfTradeItems { get; set; }
        public string StockSymbol { get; set; }
        public string OrderStatus { get; set; }
        public string Action { get; set; }
        public decimal Price { get; set; }

    }
}

#if Never
#region snippet1
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
#endregion
#endif