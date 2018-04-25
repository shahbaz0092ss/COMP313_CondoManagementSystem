
// FOR: Passing data from TimelinesController to Timlines-related Views


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShahbazWebsite_MVCPlatform.Models
{

    public class Timelines_Event

    {

        public string title { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public string url { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string color { get; set; }
        public bool displayEventEnd { get; set; }
        public bool displayEventTime { get; set; }
        public bool overlap { get; set; }


    }

}