﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RojikanPU.Models
{
    public class PPKCommentViewModel
    {
        public int ReportId { get; set; }

        [Required]
        [DisplayName("Komentar")]
        [AllowHtml]
        public string Comment { get; set; }

        public string PPKComment { get; set; }
    }
}