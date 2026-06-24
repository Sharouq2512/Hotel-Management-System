using project01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Services
{
    public class GuestService
    {
        public static void DisplayAllGuests(List<GuestModel> guests)
        {
            foreach (var s in guests)
            {
                Console.WriteLine($"Guest Id: {s.guestId}");
                Console.WriteLine($"Full Name: {s.fullName}");
                Console.WriteLine($"Email: {s.email}");
                Console.WriteLine($"Phone Number: {s.phoneNumber}");
            }


        }
        //===========================
        public static GuestModel FindGuestById(List<GuestModel> guests, string guestId)
        {
            foreach (var s in guests)
            {
                if (s.guestId == guestId)
                    
                return s; 
            }
            return null;
        }
    }
}