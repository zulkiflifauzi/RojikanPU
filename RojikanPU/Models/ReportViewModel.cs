using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RojikanPU.Models
{
    public class ReportViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Nama")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Asal")]
        public string Address { get; set; }

        [Required]
        [DisplayName("Nomor Telepon")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Not a valid phone number.")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Isi Laporan")]
        public string Description { get; set; }  
        
        public string Origin { get; set; }      

        public string CreatedDate { get; set; }

        public string Status { get; set; }

        public string AssignedDate { get; set; }

        public string AssignedToPPK { get; set; }
    }

    public class HomeViewModel : ReportViewModel
    {
        public List<ReportViewModel> ReportList { get; set; }
    }
}