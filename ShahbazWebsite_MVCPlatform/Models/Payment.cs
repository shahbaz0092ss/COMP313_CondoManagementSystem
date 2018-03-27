
using System;

using System.Collections.Generic;



namespace ShahbazWebsite_MVCPlatform.Models

{

    public partial class Payment

    {

        public int PaymentID { get; set; }

        public int UserID { get; set; }

        public int AmountPaid { get; set; }

        public string TypeOfPayment { get; set; }

    }

}