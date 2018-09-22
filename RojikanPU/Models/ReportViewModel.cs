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

        [DisplayName("Media")]
        public string Origin { get; set; }

        [DisplayName("Tanggal Laporan")]
        public string CreatedDate { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Tanggal Assign")]
        public string AssignedDate { get; set; }

        [DisplayName("PPK")]
        public string AssignedToPPK { get; set; }

        [DisplayName("Tanggal Diselesaikan")]
        public string ClosedDate { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Komentar Staff")]
        public string StaffComment { get; set; }

        [DisplayName("Komentar PPK")]
        public string PPKComment { get; set; }

        public string ReportFileURL { get; set; }

        public string StaffFileURL { get; set; }

        public string PPKFileURL { get; set; }
    }

    public class HomeViewModel : ReportViewModel
    {
        public List<ReportViewModel> ReportList { get; set; }
    }
}