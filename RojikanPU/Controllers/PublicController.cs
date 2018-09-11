using hbehr.recaptcha;
using RojikanPU.Base;
using RojikanPU.Domain;
using RojikanPU.Logic;
using RojikanPU.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace RojikanPU.Controllers
{
    public class PublicController : Controller
    {
        private ArticleLogic _articleLogic = new ArticleLogic();
        private ReportLogic _reportLogic = new ReportLogic();
        
        // GET: Article
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.ReportList = new List<ReportViewModel>();
            var reports = _reportLogic.GetAll();
            foreach (var item in reports)
            {
                ReportViewModel report = new ReportViewModel() { Address  = item.Address, Description = item.Description, Name = item.Name, Origin = item.Origin, CreatedDate = item.CreatedDate.ToString("dd-MMM-yyyy hh:mm"), Status = item.Status, Id = item.Id };
                model.ReportList.Add(report);
            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(HomeViewModel model)
        {
            string userResponse = HttpContext.Request.Params["g-recaptcha-response"];
            bool validCaptcha = ReCaptcha.ValidateCaptcha(userResponse);
            if (validCaptcha)
            {
                try
                {
                    Report report = new Report() { Name = model.Name, Address = model.Address, PhoneNumber = model.PhoneNumber, Description = model.Description, Origin = Constant.ReportOrigin.WEBSITE };

                    var response = _reportLogic.Create(report);
                    if (response.IsError == true)
                    {
                        foreach (var item in response.ErrorCodes)
                        {
                            ModelState.AddModelError(string.Empty, item);
                        }
                        return View(model);
                    }
                    else
                    {
                        var msg = new MailMessage();
                        msg.To.Add(new MailAddress(ConfigurationManager.AppSettings["AdminEmail"]));
                        msg.Subject = "LAPOR-BRANTAS New Report";
                        msg.Body = "Dari: " + model.PhoneNumber + ", Isi: " + model.Description;
                        msg.From = new MailAddress("admin@lapor-brantas.net");

                        using (var client = new SmtpClient() { Host = "relay-hosting.secureserver.net", Port = 25, EnableSsl = false, UseDefaultCredentials = false })
                        {
                            client.Send(msg);
                        }
                    }

                    return RedirectToAction("SubmitLandingPage", new { id = response.CreatedId, name = model.Name });
                }
                catch
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Captcha");
                HomeViewModel homeView = new HomeViewModel();
                homeView.ReportList = new List<ReportViewModel>();
                var reports = _reportLogic.GetAll();
                foreach (var item in reports)
                {
                    ReportViewModel report = new ReportViewModel() { Address = item.Address, Description = item.Description, Name = item.Name, Origin = item.Origin, CreatedDate = item.CreatedDate.ToString("dd-MMM-yyyy hh:mm"), Status = item.Status, Id = item.Id };
                    homeView.ReportList.Add(report);
                }
                return View(homeView);
            }

        }

        public ActionResult SubmitLandingPage(int id, string name)
        {
            ViewData["Id"] = id;
            ViewData["Name"] = name;
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

        // GET: Report/Details/5
        public ActionResult Details(int id)
        {
            var item = _reportLogic.GetById(id);
            ReportViewModel report = new ReportViewModel() { Address = item.Address, Description = item.Description, Name = item.Name, Origin = item.Origin, CreatedDate = item.CreatedDate.ToString("dd-MMM-yyyy hh:mm"), Status = item.Status, Id = item.Id, AssignedDate = item.ProcessDate.HasValue ? item.ProcessDate.Value.ToString("dd-MMM-yyyy hh:mm") : string.Empty, PhoneNumber = item.PhoneNumber, AssignedToPPK = item.PPK != null ? item.PPK.Name : string.Empty, ClosedDate = item.ClosedDate.HasValue ? item.ClosedDate.Value.ToString("dd-MMM-yyyy hh:mm") : string.Empty, StaffComment = item.StaffComment, PPKComment = item.PPKComment };
            return View(report);
        }

        [HttpPost]
        public ActionResult GetYears()
        {
            return Json(_reportLogic.GetYears());
        }

        [HttpPost]
        public ActionResult GetReportsGraph(int year = 0)
        {
            if (year == 0)
            {
                return Json(null);
            }
            var states = _reportLogic.GetReportGraph(year);
            List<ReportGraphViewModel> results = new List<ReportGraphViewModel>();

            var medias = states.Select(c => c.Origin).Distinct().ToList();
            foreach (var item in medias)
            {
                ReportGraphViewModel result = new ReportGraphViewModel();
                result.Media = item;
                result.Total = states.Where(c => c.Origin.Equals(item)).Count();
                results.Add(result);
            }
            return Json(results);
        }
    }
}