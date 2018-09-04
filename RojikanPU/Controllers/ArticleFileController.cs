using RojikanPU.Domain;
using RojikanPU.Logic;
using RojikanPU.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RojikanPU.Controllers
{
    public class ArticleFileController : Controller
    {
        private ArticleFileLogic _articleFileLogic = new ArticleFileLogic();
        private ArticleLogic _articleLogic = new ArticleLogic();

        // GET: ArticleFile
        public ActionResult Index(int id)
        {
            var article = _articleLogic.GetById(id);
            ViewData["ArticleName"] = article.Title;
            ViewData["ArticleId"] = id;
            List<ArticleFileViewModel> results = new List<ArticleFileViewModel>();

            if (article.ArticleFiles.Count() > 0)
            {
                foreach (var item in article.ArticleFiles)
                {
                    ArticleFileViewModel articleFile = new ArticleFileViewModel() { ArticleId = item.ArticleId, FileName = item.FileName, Id = item.Id, FileURL = item.ArticleId.ToString() + "_" + item.FileName };
                    
                    results.Add(articleFile);
                }
            }
            
            return View(results);
        }

        // GET: ArticleFile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArticleFile/Create
        public ActionResult Create(int id)
        {
            ViewData["ArticleId"] = id;
            return View();
        }

        // POST: ArticleFile/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, ArticleFileViewModel model)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = model.ArticleId.ToString() + "_" + fileName;
                    var path = Path.Combine(Server.MapPath("~/Content/Upload"), filePath);
                    file.SaveAs(path);

                    ArticleFile articleView = new ArticleFile();
                    articleView.FileName = fileName;
                    articleView.ArticleId = model.ArticleId;                   

                    var response = _articleFileLogic.Create(articleView);
                    if (response.IsError == true)
                    {
                        foreach (var item in response.ErrorCodes)
                        {
                            ModelState.AddModelError(string.Empty, item);
                        }
                        return View(model);
                    }
                }

                return RedirectToAction("Index", new { id = model.ArticleId });
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleFile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArticleFile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleFile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArticleFile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
