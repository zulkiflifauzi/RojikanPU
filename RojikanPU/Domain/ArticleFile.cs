using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RojikanPU.Domain
{
    [Table("ArticleFiles")]
    public class ArticleFile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }

        [Required]
        public string FileName { get; set; }
    }
}