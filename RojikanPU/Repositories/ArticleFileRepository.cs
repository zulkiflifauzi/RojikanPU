using RojikanPU.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RojikanPU.Domain;
using RojikanPU.Context;

namespace RojikanPU.Repositories
{
    public class ArticleFileRepository : IArticleFileRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ArticleFileRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(ArticleFile entity)
        {
            _db.ArticleFiles.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ArticleFile Edit(ArticleFile entity)
        {
            throw new NotImplementedException();
        }

        public List<ArticleFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ArticleFile> GetArticleFiles(int articleId)
        {
            return _db.ArticleFiles.Where(c => c.ArticleId == articleId).ToList();
        }

        public ArticleFile GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}