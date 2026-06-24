using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Services
{
    public class EmailService
    {
       
            public static string SystemEmail = "hms@grandcodeline.om";
            public static void SendEmail(string to, string subject, string body)
            {
                
                Console.WriteLine($"Sending email from: {SystemEmail}");
                Console.WriteLine($"Sending email to: {to}");
                Console.WriteLine($"Subject: {subject}");
                Console.WriteLine($"Body: {body}");
                Console.WriteLine("Email sent successfully!");
            }
        
    }
}
