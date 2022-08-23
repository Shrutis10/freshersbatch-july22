using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_2.Models
{
    [Table("BusInfo")]
    public class BusInfo
    {
        public int BusID { get; set; }
        public string BoardingPoint { get; set; }
        public DateTime TravelDate { get; set; }
        public double Amount { get; set; }
        public int Rating { get; set; }
    }
}