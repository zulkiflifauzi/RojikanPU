using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RojikanPU.Models
{
    public class PPKViewModel
    {
        [Required]
        [DisplayName("PIC")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Nama")]
        public string Name { get; set; }

        public string PIC { get; set; }

        public int? OldId { get; set; }
    }
}