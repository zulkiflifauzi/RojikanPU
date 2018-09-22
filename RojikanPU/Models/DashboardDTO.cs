using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RojikanPU.Models
{
    public class DashboardDTO
    {
        public int TotalReportThisMonth { get; set; }

        public int TotalReportThisYear { get; set; }

        public int TotalReportNotYetAssigned { get; set; }

        public int TotalReportNotYetCommented { get; set; }
    }
}