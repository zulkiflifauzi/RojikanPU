using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RojikanPU.Domain
{
    [Table("Reports")]
    public class Report
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public string Email { get; set; }

        public DateTime? ProcessDate { get; set; }

        public DateTime? ClosedDate { get; set; }

        public string StaffComment { get; set; }

        public string PPKComment { get; set; }

        [Required]
        public string Origin { get; set; }

        [ForeignKey("PPK")]
        public int? PPKId { get; set; }

        public virtual PPK PPK { get; set; }
    }
}