using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoBadBank.Models
{
    public class DepotEntry
    {
        public int ID { get; set; }
        public string objectId { get; set; }        
        public int NrOfItems { get; set; }
        public string StockSymbol { get; set; }        

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