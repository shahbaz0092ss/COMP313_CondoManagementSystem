using System;
using System.Collections.Generic;

namespace ShahbazWebsite_MVCPlatform.Models

{
    public partial class Messages
    {
        public int MessageId { get; set; }
        public string Message { get; set; }
        public string SentBy { get; set; }
        public string SentTo { get; set; }
        public DateTime? DateTimeOfMessage { get; set; }
    }
}