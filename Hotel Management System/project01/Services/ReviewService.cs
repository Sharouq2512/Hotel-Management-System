using project01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Services
{
    public class ReviewService
    {
        public static void AddReview(BookingModel booking, ReviewModel review)
        {
            booking.bookingReviews.Add(review);
        }
        //===================================
        public static void DisplayReviewsForBooking(BookingModel booking)
        {
            if (booking.bookingReviews.Count == 0 )
            {
                Console.WriteLine("No reviews yet.");
               
            }

            foreach (var review in booking.bookingReviews)
            {
                Console.WriteLine($"Rating: {review.rating}");
                Console.WriteLine($"Comment: {review.comment}");
            }
        }
    }
}
