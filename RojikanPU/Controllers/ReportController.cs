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
        // GET: Report
        public ActionResult Index()
        {
            List<ReportViewModel> model = new List<ReportViewModel>();
            var reports = _reportLogic.GetAll();
            foreach (var item in reports)
            {
                ReportViewModel report = new ReportViewModel() { Address = item.Address, Description = item.Description, Name = item.Name, Origin = item.Origin, CreatedDate = item.CreatedDate.ToString("dd-MMM-yyyy hh:mm"), Status = item.Status, Id = item.Id, AssignedDate = item.ProcessDate.HasValue ? item.ProcessDate.Value.ToString("dd-MMM-yyyy hh:mm") : string.Empty, PhoneNumber = item.PhoneNumber, AssignedToPPK = item.PPK != null ? item.PPK.Name : string.Empty };
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
            return View();
        }

        // POST: Report/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
