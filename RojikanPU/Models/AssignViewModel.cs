using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RojikanPU.Models
{
    public class AssignViewModel
    {        
        public int Id { get; set; }

        [Required]
        [DisplayName("Komentar")]
        public string StaffComment { get; set; }

        [DisplayName("PPK")]
        public int PPKId { get; set; }
    }
}