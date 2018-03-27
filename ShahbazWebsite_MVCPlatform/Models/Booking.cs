using System;

using System.Collections.Generic;



namespace ShahbazWebsite_MVCPlatform.Models

{

    public partial class Booking

    {

        public int BookingID { get; set; }

        public int? UserID { get; set; }

        public string Category { get; set; }

        public string Date { get; set; }

        public string TimeFrom { get; set; }

        public string TimeTo { get; set; }

        public string BookingDetail { get; set; }

        public string Status { get; set; }

        public User User { get; set; }

    }

}