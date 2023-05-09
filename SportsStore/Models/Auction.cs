using System;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models
{
    public class Auction
    {
        public int AuctionID { get; set; }

        [Required(ErrorMessage = "Please enter a product ID")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [Required(ErrorMessage = "Please enter a starting price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive starting price")]
        public decimal StartingPrice { get; set; }

        [Required(ErrorMessage = "Please enter a minimum bid amount")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive minimum bid amount")]
        public decimal MinimumBid { get; set; }

        public decimal CurrentPrice { get; set; }

        [Required(ErrorMessage = "Please enter an auction start time")]
        public DateTime StartDateTime { get; set; } 

        [Required(ErrorMessage = "Please enter an auction end time")]
        public DateTime EndDateTime { get; set; } 

        public bool IsActive => DateTime.Now >= StartDateTime && DateTime.Now <= EndDateTime;
    }
}
