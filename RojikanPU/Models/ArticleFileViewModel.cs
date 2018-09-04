using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RojikanPU.Models
{
    public class ArticleFileViewModel
    {
        public int Id { get; set; }
        
        public int ArticleId { get; set; }
        
        [DisplayName("File")]
        public string FileName { get; set; }

        public string FileURL { get; set; }
    }
}