

// THIS MODEL USED FOR: Passing data from Controller: ReportingController Action:Reporting_UserDetails 
//                      to View: Reporting_UserDetails.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShahbazWebsite_MVCPlatform.Models
{

        public class Reporting_UserDetails

                {

                    public ShahbazWebsite_MVCPlatform.Models.User User { get; set; }
                    public IEnumerable<Booking> Booking { get; set; }
                    public IEnumerable<Maintenance> Maintenance { get; set; }
                    public IEnumerable<Payment> Payment { get; set; }
                 }

}