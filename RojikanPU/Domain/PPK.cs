using RojikanPU.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RojikanPU.Domain
{
    [Table("PPKs")]
    public class PPK
    {
        [Key]
        [ForeignKey("PIC")]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ApplicationUser PIC { get; set; }

        [NotMapped]
        public int OldId { get; set; }
    }
}