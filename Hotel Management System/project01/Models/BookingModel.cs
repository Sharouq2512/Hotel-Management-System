using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class BookingModel
    {
        public string bookingId { get; set; }
        public string guestId { get; set; } //**
        public string roomNumber { get; set; }//**
        public string checkInDate { get; set; } //**
        public string checkOutDate { get; set; }
        public double totalPrice { get; set; }
        public string status { get; set; } //**
        public List<ReviewModel> bookingReviews { get; set; }

    }
}
