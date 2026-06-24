using project01.Models;
using project01.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace project01
{
    public class Program
    {

        //#P-01 RegisterGuest
        public static void RegisterGuest(HotelContext context)
        {

            //Read guestId, fullName, email, phoneNumber from the console
            Console.WriteLine("Guest details:");

            Console.WriteLine("Enter guestId:");
            string guestId = Console.ReadLine();

            Console.WriteLine("Enter fullname:");
            string fullName = Console.ReadLine();

            Console.WriteLine("Enter email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter PhoneNumber:");
            string phoneNumber = Console.ReadLine();

            //Create a new GuestModel with an empty guestBookings list and add it to context.guests
            context.guests.Add(new GuestModel
            {
                guestId = guestId,
                fullName = fullName,
                email = email,
                phoneNumber = phoneNumber,
                guestBookings = new List<BookingModel>()
            });

            //Call EmailService.SendEmail to send a welcome email to the guest's email address.
            EmailService.SendEmail(email, "Welcome to Grand Codeline Hotel", fullName + ",\nThank you for registering. We look forward to hosting you!");

            Console.WriteLine("Guest registered successfully");
        }
        //===================================================
        //#P-02 AddRoom
        public static void AddRoom(HotelContext context)
        {
            //Read roomNumber, roomType, pricePerNight (convert to double), and floor (convert to int)
            Console.WriteLine("Room details:");

            Console.WriteLine("Enter room number:");
            string roomNumber = Console.ReadLine();

            Console.WriteLine("Enter room type:");
            string roomType = Console.ReadLine();

            Console.WriteLine("Enter price per night:");
            int pricePerNight = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter floor:");
            int floor = Convert.ToInt32(Console.ReadLine());
            // Create a new RoomModel with isAvailable = true and add it to context.rooms
            context.rooms.Add(new RoomModel
            {
                roomNumber = roomNumber,
                roomType = roomType,
                pricePerNight = pricePerNight,
                floor = floor,
                isAvailable = true,

            });
            //Print a confirmation message.

            Console.WriteLine("Room Details added successfully");
        }
        //================================================================
        //#P-03 DisplayAvailableRooms
        public static void DisplayAvailableRooms(HotelContext context)
        {
            if (context.rooms.Count == 0)
            {
                Console.WriteLine("No rooms in system");
                return;
            }

            RoomService.DisplayAvailableRooms(context.rooms);
        }

       
        //===================================================
        //#P-04 AddStaff
        public static void AddStaff(HotelContext context)
        {
            //Read staffId, fullName, role, email
            Console.WriteLine("Staff details:");

            Console.WriteLine("Enter staff id:");
            string staffId = Console.ReadLine();

            Console.WriteLine("Enter full name:");
            string fullName = Console.ReadLine();

            Console.WriteLine("Enter role:");
            string role = Console.ReadLine();

            Console.WriteLine("Enter email:");
            string email = Console.ReadLine();
            //Create a StaffModel with isOnDuty = true and add it to context.staff.
            context.staff.Add(new StaffModel
            {
                staffId = staffId,
                fullName = fullName,
                role = role,
                email = email,
                isOnDuty = true,

            });
            //Print confirmation

            Console.WriteLine("Staff Details added successfully");
        }


        //======================================================
        //#P-05 DisplayAllStaff
        //======================================================
        //#P-06 BookRoom
        public static void BookRoom(HotelContext context)
        {
            //1. Read guestId and roomNumber from console. 
            Console.WriteLine("Enter guestId:");
            string guestId = Console.ReadLine();

            Console.WriteLine("Enter room number:");
            string roomNumber = Console.ReadLine();
            //2. Use GuestService.FindGuestById and RoomService.FindRoomByNumber to locate both entities

            GuestModel guest = GuestService.FindGuestById(context.guests, guestId);

            RoomModel room = RoomService.FindRoomByNumber(context.rooms, roomNumber);
            //3. If either is not found,print an appropriate error and return.
            if (guest == null)
            {
                Console.WriteLine($"Guest not found.");
                return;
            }

            if (room == null)
            {
                Console.WriteLine($"Room not found.");
                return;
            }
            //4. If the room is not available (isAvailable == false)
            if (room.isAvailable == false)
            {
                Console.WriteLine("Room is not available.");
                return;
            }
            //5. Read checkInDate, checkOutDate, and numberOfNights (int).
            Console.WriteLine("Enter check In Date:");
            string checkInDate = Console.ReadLine();

            Console.WriteLine("Enter check Out Date:");
            string checkOutDate = Console.ReadLine();

            Console.WriteLine("Enter Number of nights:");
            int numberOfNights = Convert.ToInt32(Console.ReadLine());

            //6.Calculate totalPrice using RoomService.CalculateTotalPrice
            double totalPrice = RoomService.CalculateTotalPrice(room, numberOfNights);
            Console.WriteLine(totalPrice);

            //7.Read a bookingId from console.
            Console.WriteLine("Enter booking id:");
            string bookingId = Console.ReadLine();
            //8. Create a BookingModel (status = "Confirmed", empty bookingReviews list) and add it to context.bookings
            BookingModel booking = new BookingModel
            {
                bookingId = bookingId,
                guestId = guestId,
                roomNumber = roomNumber,
                checkInDate = checkInDate,
                checkOutDate = checkOutDate,
                totalPrice = totalPrice,
                status = "Confirmed",

                bookingReviews = new List<ReviewModel>(),

                

            };
            //9. Set room.isAvailable = false.
            room.isAvailable = false;

            //10.Add the booking also to guest.guestBookings
            guest.guestBookings.Add(booking);

            //11.Call EmailService.SendEmail to notify the guest
            EmailService.SendEmail(
                guest.email,
                $"Booking confirmed",
                $"Your booking for room {roomNumber} has been confirmed. Total: {totalPrice} OMR"
            );

           

        }
        //================================================
        //#P-07 CancelBooking
        public static void CancelBooking(HotelContext context)
        {
            //1. Read bookingId from console
            Console.WriteLine("Enter booking id:");
            string bookingId = Console.ReadLine();

            //2.Use BookingService.FindBookingById to find the booking
           var booking = BookingService.FindBookingById(context.bookings,bookingId);
           bool check = BookingService.CancelBooking(booking);
            if(check==false)
            {
                Console.WriteLine("booking already canceled");
                return;
            }

      
            //Call BookingService.CancelBooking.

            //5. Find the room by roomNumber and set isAvailable = true
            RoomModel room = RoomService.FindRoomByNumber(context.rooms, booking.roomNumber);
            room.isAvailable = true;


            //6. Find the guest by guestId and send a cancellation email.
            GuestModel guest = GuestService.FindGuestById(context.guests, booking.guestId);
            
            EmailService.SendEmail(
                guest.email,
                $"Booking Cancelled",
                $"Your booking {bookingId} has been cancelled"
            );

           
        }

        //================================================
        //#P-08 AddReviewToBooking
        public static void AddReviewToBooking(HotelContext context)
        {
            //Read bookingId from console and find the booking
            Console.WriteLine("Enter booking id:");
            string bookingId = Console.ReadLine();

            BookingModel booking = BookingService.FindBookingById(context.bookings, bookingId);
            //2. If not found, print error and return.
            if (booking == null)
            {
                Console.WriteLine("booking not found");
                return;
            }
            //3. If booking.status is not "Completed", print "Reviews can only be added to completed bookings." and return.
            if (booking.status != "Completed")
            {
                Console.WriteLine("Reviews can only be added to completed bookings");
                return;
            }
            //4.Read reviewId, rating(int, must be 1 - 5 — print error and return if out of range), and comment
            Console.WriteLine("Enter review id:");
            string reviewId = Console.ReadLine();

            Console.WriteLine("Enter rate between 1 and 5:");
            int rating = Convert.ToInt32(Console.ReadLine());
            if (rating < 1 || rating > 5)
            {
                Console.WriteLine("invalid rating");
                return;
            }
            Console.WriteLine("Enter comment:");
            string comment = Console.ReadLine();

            //5.Create a ReviewModel and add it using ReviewService.AddReview
            ReviewModel review = new ReviewModel
            {
                reviewId = reviewId,
                rating = rating,
                comment = comment
            };

            //6.Also add the review to context.reviews
            ReviewService.AddReview(booking, review);

            //7.Find the guest and send a thank -you email
            GuestModel guest = GuestService.FindGuestById(context.guests, booking.guestId);
            EmailService.SendEmail(
                guest.email,
                $"Thank You for Your Review",
                $"We appreciate your feedback! Rating: {rating}/5"
            ); }
            //===========================================================
            //#P-09 ToggleStaffDuty
            public static void ToggleStaffDuty(HotelContext context) { 
            //1. Read staffId from console.

            Console.WriteLine("Enter staff id:");
            string staffId = Console.ReadLine();

            //2. Use StaffService.FindStaffById to find the staff member
            StaffModel staff = StaffService.FindStaffById(context.staff, staffId);


        }



        
        static void Main(string[] args)
        {
           
           
        }
    }
}
