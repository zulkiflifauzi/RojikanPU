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
            _db.Articles.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Article Edit(Article entity)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetAll()
        {
            return _db.Articles.ToList();
        }

        public Article GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}