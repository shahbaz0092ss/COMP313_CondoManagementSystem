
using System;
using System.Collections.Generic;

namespace ShahbazWebsite_MVCPlatform.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int? UserId { get; set; }
        public int? AmountPaid { get; set; }
        public string TypeOfPayment { get; set; }

        public User User { get; set; }
    }
}
