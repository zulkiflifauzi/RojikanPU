using RojikanPU.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RojikanPU.Base;
using RojikanPU.Domain;
using RojikanPU.Repositories;
using RojikanPU.Context;

namespace RojikanPU.Logic
{
    public class ArticleFileLogic : IArticleFileLogic
    {
        private readonly ArticleFileRepository _repository = new ArticleFileRepository(new ApplicationDbContext());
        public ResponseMessage Create(ArticleFile entity)
        {
            ResponseMessage response = new ResponseMessage();

            _repository.Create(entity);

            return response;
        }

        public ResponseMessage Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage Edit(ArticleFile entity)
        {
            throw new NotImplementedException();
        }

        public List<ArticleFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ArticleFile> GetArticleFiles(int articleId)
        {
            return _repository.GetArticleFiles(articleId);
        }

        public ArticleFile GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}