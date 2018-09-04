using RojikanPU.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RojikanPU.Domain
{
    [Table("Articles")]
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string SubTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }

        private ICollection<int> _articleFileIds;
        [NotMapped]
        public ICollection<int> ArticleFileIds
        {
            get { return _articleFileIds ?? (_articleFileIds = ArticleFiles.Select(s => s.Id).ToList()); }
            set { _articleFileIds = value; }
        }

        private ICollection<ArticleFile> _articleFiles;
        public virtual ICollection<ArticleFile> ArticleFiles
        {
            get { return _articleFiles ?? (_articleFiles = new Collection<ArticleFile>()); }
            set { _articleFiles = value; }
        }
    }
}