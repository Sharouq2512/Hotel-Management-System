using project01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace project01.Services
{
    public class BookingService
    {
        public static void DisplayAllBookings(List<BookingModel> bookings)
        {
            foreach (var s in bookings)
            {
                Console.WriteLine($"Booking Id: {s.bookingId}");
                Console.WriteLine($"Guest Id: {s.guestId}");
                Console.WriteLine($"Room Number: {s.roomNumber}");
                Console.WriteLine($"Check-in Date: {s.checkInDate}");
                Console.WriteLine($"Check-out Date: {s.checkOutDate}");
                Console.WriteLine($"Status: {s.status}");
            }
        }

        //===========================
        public static BookingModel FindBookingById(List<BookingModel> bookings, string bookingId)
        {
            foreach (var b in bookings)
            {
                if (b.bookingId == bookingId)
                    return b;
            }
            return null;
        }
        //=============================
        public static bool CancelBooking( BookingModel booking)
        {
            if (booking.status == "Cancelled")
            {
                return false;
            }
            else
            {
                booking.status = "Cancelled";
                return true;
            }
        }
        //==============================
        public static bool CompleteBooking(BookingModel booking , RoomModel room)
        {
            if (booking.status == "Completed")
            {
                return false;
            }
            else
            {
                booking.status = "Completed";
                room.isAvailable = true;
                return true;
            }
        }

       
    }
}


