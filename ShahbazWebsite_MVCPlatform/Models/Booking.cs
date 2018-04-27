

// Scafollding: Create models from the existing database
// 
// "Getting Started with EF Core on ASP.NET Core with an Existing Database"
// https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/existing-db

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShahbazWebsite_MVCPlatform.Models

{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int? UserId { get; set; }
        public string Category { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage="This date field cannot be empty")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Required(ErrorMessage="This date field cannot be empty")]
        public DateTime? EndDate { get; set; }

        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }

        [StringLength(25, MinimumLength = 0)]
        public string BookingDetail { get; set; }

        public string Status { get; set; }

        public User User { get; set; }
    }
}
