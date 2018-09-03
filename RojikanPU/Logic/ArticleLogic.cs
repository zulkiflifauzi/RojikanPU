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
    public class ArticleLogic : IArticleLogic
    {
        private readonly ArticleRepository _repository = new ArticleRepository(new ApplicationDbContext());

        public ResponseMessage Create(Article entity)
        {
            ResponseMessage response = new ResponseMessage();

            _repository.Create(entity);

            return response;
        }

        public ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            _repository.Delete(id);

            return response;
        }

        public ResponseMessage Edit(Article entity)
        {
            ResponseMessage response = new ResponseMessage();

            _repository.Edit(entity);

            return response;
        }

        public List<Article> GetAll()
        {
            return _repository.GetAll();
        }

        public Article GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}