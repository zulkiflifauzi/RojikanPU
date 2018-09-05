using RojikanPU.Domain;
using RojikanPU.Logic;
using RojikanPU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RojikanPU.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private ArticleLogic _articleLogic = new ArticleLogic();
        private ArticleFileLogic _articleFileLogic = new ArticleFileLogic();
        private UserLogic _userLogic = new UserLogic();
        // GET: Article
        public ActionResult Index()
        {
            var articles = _articleLogic.GetAll();
            List<ArticleViewModel> results = new List<ArticleViewModel>();
            foreach (var item in articles)
            {
                ArticleViewModel article = new ArticleViewModel() { Id = item.Id, SubTitle = item.SubTitle, Title = item.Title, Type = item.Type, AuthorName = item.Author.FirstName + " " + item.Author.LastName, CreatedDate = item.CreatedDate.ToString("dd-MMM-yyyy") };

                results.Add(article);
            }
            return View(results);
        }

        // GET: Article/Details/5
        public ActionResult Details(int id)
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

        // GET: Article/Create
        public ActionResult Create()
        {
            PrepareSelectList();
            return View();
        }

        private void PrepareSelectList()
        {
            List<SelectListItem> articleType = new List<SelectListItem>();
            articleType.Add(new SelectListItem { Value = "INFO PUBLIK", Text = "INFO PUBLIK" });
            articleType.Add(new SelectListItem { Value = "SISDA", Text = "SISDA" });
            articleType.Add(new SelectListItem { Value = "REKOMTEK", Text = "REKOMTEK" });
            articleType.Add(new SelectListItem { Value = "POSKO", Text = "POSKO" });

            ViewData["Types"] = articleType;
        }

        // POST: Article/Create
        [HttpPost]
        public ActionResult Create(ArticleViewModel model)
        {
            try
            {
                var user = User.Identity.Name;
                var loggedInUser = _userLogic.GetUserByEmail(user);

                Article article = new Article() { Type = model.Type, Title = model.Title, SubTitle = model.SubTitle, Content = model.Content, AuthorId = loggedInUser.Id };
                var response = _articleLogic.Create(article);
                if (response.IsError == true)
                {
                    foreach (var item in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }
                    PrepareSelectList();
                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int id)
        {
            var article = _articleLogic.GetById(id);
            PrepareSelectList();
            ArticleViewModel result = new ArticleViewModel() { Id = article.Id, Content = article.Content, SubTitle =article.SubTitle, Title = article.Title, Type = article.Type };
            return View(result);
        }

        // POST: Article/Edit/5
        [HttpPost]
        public ActionResult Edit(ArticleViewModel model)
        {
            try
            {
                Article article = new Article() { Id = model.Id, Type = model.Type, Title = model.Title, SubTitle = model.SubTitle, Content = model.Content };
                var response = _articleLogic.Edit(article);
                if (response.IsError == true)
                {
                    foreach (var item in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }
                    PrepareSelectList();
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int id)
        {
            var article = _articleLogic.GetById(id);
            ArticleViewModel result = new ArticleViewModel() { Id = article.Id, Content = article.Content, SubTitle = article.SubTitle, Title = article.Title, Type = article.Type, AuthorName = article.Author.FirstName + " " + article.Author.LastName, CreatedDate = article.CreatedDate.ToString("dd-MMM-yyyy") };
            return View(result);
        }

        // POST: Article/Delete/5
        [HttpPost]
        public ActionResult Delete(ArticleViewModel model)
        {
            try
            {
                var articleFiles = _articleFileLogic.GetArticleFiles(model.Id);
                var response = _articleLogic.Delete(model.Id); ;
                if (response.IsError == true)
                {
                    foreach (var error in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }

                    var article = _articleLogic.GetById(model.Id);
                    ArticleViewModel result = new ArticleViewModel() { Id = article.Id, Content = article.Content, SubTitle = article.SubTitle, Title = article.Title, Type = article.Type };
                    return View(result);
                }
                else
                {
                    foreach (var item in articleFiles)
                    {
                        var filePath = model.Id.ToString() + "_" + item.FileName;
                        string fullPath = Request.MapPath("~/Content/Upload/" + filePath);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                    }                    
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
