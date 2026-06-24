using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class RoomModel
    {
        public string roomNumber { get; set; } //**
        public string roomType { get; set; } //**
        public double pricePerNight { get; set; }
        public bool isAvailable { get; set; } = true;
        public int floor { get; set; }
    }
}
