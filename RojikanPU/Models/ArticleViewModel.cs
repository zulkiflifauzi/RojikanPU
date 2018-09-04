using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RojikanPU.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tipe")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Judul")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Sub Judul")]
        public string SubTitle { get; set; }

        [Required]
        [Display(Name = "Konten")]
        [AllowHtml]
        public string Content { get; set; }

        [Display(Name = "Penulis")]
        public string AuthorName { get; set; }

        [Display(Name = "Ditulis Pada")]
        public string CreatedDate { get; set; }

        public List<ArticleFileViewModel> Files { get; set; }
    }
}