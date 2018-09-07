using RojikanPU.Base;
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
    public class ReportController : Controller
    {
        private ReportLogic _reportLogic = new ReportLogic();
        private PPKLogic _ppkLogic = new PPKLogic();
        // GET: Report
        public ActionResult Index()
        {
            List<ReportViewModel> model = new List<ReportViewModel>();
            var reports = _reportLogic.GetAll();
            foreach (var item in reports)
            {
                ReportViewModel report = new ReportViewModel() { Address = item.Address, Description = item.Description, Name = item.Name, Origin = item.Origin, CreatedDate = item.CreatedDate.ToString("dd-MMM-yyyy hh:mm"), Status = item.Status, Id = item.Id, AssignedDate = item.ProcessDate.HasValue ? item.ProcessDate.Value.ToString("dd-MMM-yyyy hh:mm") : string.Empty, PhoneNumber = item.PhoneNumber, AssignedToPPK = item.PPK != null ? item.PPK.Name : string.Empty, ClosedDate = item.ClosedDate.HasValue ? item.ClosedDate.Value.ToString("dd-MMM-yyyy hh:mm") : string.Empty };
                model.Add(report);
            }
            return View(model);
        }

        // GET: Report/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Report/Create
        public ActionResult Create()
        {
            PrepareSelectList();
            return View();
        }

        private void PrepareSelectList()
        {
            List<SelectListItem> origin = new List<SelectListItem>();
            origin.Add(new SelectListItem { Value = "SMS", Text = "SMS" });
            origin.Add(new SelectListItem { Value = "EMAIL", Text = "EMAIL" });

            ViewData["Origins"] = origin;
        }

        // POST: Report/Create
        [HttpPost]
        public ActionResult Create(ReportViewModel model)
        {
            if (model.Origin.Equals(Constant.ReportOrigin.EMAIL) && string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("Email", "The Email field is required.");
                PrepareSelectList();
                return View(model);
            }

            try
            {
                Report report = new Report() { Name = model.Name, Address = model.Address, PhoneNumber = model.PhoneNumber, Description = model.Description, Origin = model.Origin };

                var response = _reportLogic.Create(report);
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
                return RedirectToAction("Index");
            }
        }

        public ActionResult Assign(int id)
        {
            AssignViewModel assign = new AssignViewModel();
            assign.Id = id;
            PrepareAssignSelectList();
            return View(assign);
        }

        [HttpPost]
        public ActionResult Assign(AssignViewModel model)
        {
            Report report = new Report();
            report.Id = model.Id;
            report.PPKId = model.PPKId;
            report.StaffComment = model.StaffComment;
            _reportLogic.AssignReport(report);
            return RedirectToAction("Index");
        }

        private void PrepareAssignSelectList()
        {
            var ppks = _ppkLogic.GetAll();
            List<SelectListItem> ppkList = new List<SelectListItem>();
            foreach (var item in ppks)
            {
                ppkList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            ViewData["PPKs"] = ppkList;
        }

        // GET: Report/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Report/Edit/5
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

        // GET: Report/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Report/Delete/5
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
