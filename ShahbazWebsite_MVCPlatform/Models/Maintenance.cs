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
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? EndDate { get; set; }
        public string MaintenanceDetail { get; set; }
        public string Status { get; set; }
        public int? DollarAmount { get; set; }
        public string Note { get; set; }

        public User User { get; set; }
    }
}
