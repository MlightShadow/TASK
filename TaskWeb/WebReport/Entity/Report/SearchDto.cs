using System;

namespace WebReport.Entity.Report
{
    public class SearchDto
    {
        public string No { get; set; }
        public string type { get; set; }
        public DateTime? beginTime { get; set; }
        public DateTime? endTime { get; set; }
    }
}