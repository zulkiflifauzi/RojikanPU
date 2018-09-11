using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RojikanPU.Models
{
    public class PPKCommentViewModel
    {
        public int ReportId { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}