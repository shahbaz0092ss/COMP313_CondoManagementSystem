

// THIS MODEL USED FOR: Passing data from Controller:  Action: 
//                      to View: 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShahbazWebsite_MVCPlatform.Models
{

    public class Reporting_Aggregates

    {

        public int User_TotalEmployees { get; set; }
        public int User_TotalTenants{ get; set; }
        
        public int Booking_TotalParking { get; set; }
        public int Booking_TotalGuestParking { get; set; }
        public int Booking_TotalPartyHall { get; set; }

        public int Maintenance_TotalRepair { get; set; }
        public int Maintenance_TotalEmergency { get; set; }
        public int Maintenance_TotalElectrical { get; set; }
        public int Maintenance_TotalPlumbing { get; set; }
        public int Maintenance_TotalHVAC { get; set; }
        public int Maintenance_TotalCleaning { get; set; }
        public int Maintenance_TotalDollarAmount { get; set; }

        public int Payment_TotalUsers { get; set; }
        public int Payment_TotalAmountPaid { get; set; }
        public int Payment_TotalUsersRent { get; set; }
        public int Payment_TotalRentPaid { get; set; }
        public int Payment_TotalLockerRental { get; set; }
        public int Payment_TotalPremiumCleaning { get; set; }



    }

}