using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RojikanPU.Base
{
    public static class Constant
    {
        public static class ReportStatus
        {
            public const string NEW = "NEW";
            public const string ONPROCESS = "ON PROCESS";
            public const string CLOSED = "CLOSED";
        }

        public static class ReportOrigin
        {
            public const string SMS = "SMS";
            public const string EMAIL = "EMAIL";
            public const string WEBSITE = "WEBSITE";
        }
    }
}