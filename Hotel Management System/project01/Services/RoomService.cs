using project01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Services
{
    public class RoomService
    {
        public static void DisplayAllRooms(List<RoomModel> room)
        {
            foreach (var r in room)
            {
                Console.WriteLine($"Room Number: {r.roomNumber}");
                Console.WriteLine($"Room Type: {r.roomType}");
                Console.WriteLine($"Price Per Night: {r.pricePerNight}");
                Console.WriteLine($"Is Room Available: {r.isAvailable}");
            }
        }

        //=================
        public static void DisplayAvailableRooms(List<RoomModel>room)
        {
            foreach (var r in room)
            {
                if (r.isAvailable ==true)
                {
                    Console.WriteLine($"Room Number: {r.roomNumber}");
                }
            }
        }
        //=================
        public static RoomModel FindRoomByNumber(List<RoomModel>room, string roomNumber)
        {

            foreach (var r in room)
            {
                if (r.roomNumber == roomNumber)

                    return r;
            }
            return null;
        }
        //=================
        public static double CalculateTotalPrice(RoomModel room, int nights)
        {
            return room.pricePerNight * nights;
        }
    }
}


