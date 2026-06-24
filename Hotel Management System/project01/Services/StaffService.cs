using project01;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace project01.Services
{
    public class StaffService
    {
        public void DisplayAllStaff(List<StaffModel> staff)
        {
            foreach (var s in staff)
            {
                Console.WriteLine($"Staff Id: {s.staffId}");
                Console.WriteLine($"Full Name: {s.fullName}");
                Console.WriteLine($"Role: {s.role}");
                Console.WriteLine($"On Duty: {s.isOnDuty}");
            }
        }
        //==================

        public StaffModel FindStaffById(List<StaffModel> staff, string staffId)
        {
            foreach (var s in staff)
            {
                if (s.staffId == staffId)
                { 
                    return s;
                }
                    
            }
            return null;
        }
        //==================
        public void ToggleDutyStatus(StaffModel staff)
        {
            if (staff.isOnDuty==true)
            {
                staff.isOnDuty = false;
                
            }
            else
            {
                staff.isOnDuty = true;
                
            }
            Console.WriteLine($"New duty status for {staff.fullName}: {staff.isOnDuty}");
        }
        //==================

       
    }
}

