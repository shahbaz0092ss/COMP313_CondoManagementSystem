

// Adding validation
// https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/validation

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShahbazWebsite_MVCPlatform.Models
{
    public partial class Maintenance
    {
        public int MaintenanceId { get; set; }
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

        [StringLength(25, MinimumLength = 0)]
        public string MaintenanceDetail { get; set; }

        public string Status { get; set; }
        public int? DollarAmount { get; set; }
        public string Note { get; set; }

        public User User { get; set; }
    }
}
