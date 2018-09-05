using RojikanPU.Logic;
using RojikanPU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RojikanPU.Controllers
{
    public class PublicController : Controller
    {
        private ArticleLogic _articleLogic = new ArticleLogic();
        // GET: Article
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Articles(string id)
        {
            var articles = _articleLogic.GetByType(id);
            ViewData["ArticleType"] = id;
            List<ArticleViewModel> results = new List<ArticleViewModel>();
            foreach (var item in articles)
            {
                ArticleViewModel article = new ArticleViewModel() { Id = item.Id, SubTitle = item.SubTitle, Title = item.Title, Type = item.Type, AuthorName = item.Author.FirstName + " " + item.Author.LastName, CreatedDate = item.CreatedDate.ToString("dd-MMM-yyyy") };

                results.Add(article);
            }
            return View(results);
        }

        // GET: Article/Details/5
        public ActionResult ArticleDetail(int id)
        {
            var article = _articleLogic.GetById(id);
            ArticleViewModel result = new ArticleViewModel() { Id = article.Id, Content = article.Content, SubTitle = article.SubTitle, Title = article.Title, Type = article.Type, AuthorName = article.Author.FirstName + " " + article.Author.LastName, CreatedDate = article.CreatedDate.ToString("dd-MMM-yyyy") };

            result.Files = new List<ArticleFileViewModel>();
            if (article.ArticleFiles.Count() > 0)
            {
                foreach (var item in article.ArticleFiles)
                {
                    ArticleFileViewModel articleFile = new ArticleFileViewModel() { ArticleId = item.ArticleId, FileName = item.FileName, Id = item.Id, FileURL = item.ArticleId.ToString() + "_" + item.FileName };

                    result.Files.Add(articleFile);
                }
            }
            return View(result);
        }
    }
}