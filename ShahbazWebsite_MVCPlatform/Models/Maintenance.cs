using System;
using System.Collections.Generic;

namespace ShahbazWebsite_MVCPlatform.Models
{
    public partial class Maintenance
    {
        public int MaintenanceId { get; set; }
        public int? UserId { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }
        public string MaintenanceDetail { get; set; }
        public string Status { get; set; }
        public int? DollarAmount { get; set; }
        public string Note { get; set; }

        public User User { get; set; }
    }
}
