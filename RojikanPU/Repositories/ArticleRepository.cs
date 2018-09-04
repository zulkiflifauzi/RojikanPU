using RojikanPU.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RojikanPU.Domain;
using RojikanPU.Context;

namespace RojikanPU.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ArticleRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(Article entity)
        {
            entity.CreatedDate = DateTime.Now;
            _db.Articles.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Article Edit(Article entity)
        {
            var article = _db.Articles.Find(entity.Id);
            article.SubTitle = entity.SubTitle;
            article.Title = entity.Title;
            article.Content = entity.Content;
            article.Type = entity.Type;
            _db.SaveChanges();
            return article;
        }

        public List<Article> GetAll()
        {
            return _db.Articles.ToList();
        }

        public Article GetById(int id)
        {
            return _db.Articles.SingleOrDefault(c => c.Id == id);
        }
    }
}