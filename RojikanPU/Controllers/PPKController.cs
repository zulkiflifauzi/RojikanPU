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
    [Authorize(Roles = "Administrator, Data Entry")]
    public class PPKController : Controller
    {
        private PPKLogic _ppkLogic = new PPKLogic();
        private UserLogic _userLogic = new UserLogic();
        // GET: PPK
        public ActionResult Index()
        {
            var ppks = _ppkLogic.GetAll();
            List<PPKViewModel> results = new List<PPKViewModel>();
            foreach (var item in ppks)
            {
                PPKViewModel program = new PPKViewModel() { Id = item.Id, Name = item.Name, PIC = item.PIC.FirstName + " " + item.PIC.LastName };
                results.Add(program);
            }
            return View(results);
        }

        public ActionResult Create()
        {
            PrepareSelectList();
            return View();
        }

        private void PrepareSelectList(int? excludedId = null)
        {
            var ppkUsers = _userLogic.GetPPKUsers(excludedId);
            List<SelectListItem> ppkUserList = new List<SelectListItem>();
            foreach (var item in ppkUsers)
            {
                ppkUserList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.FirstName + " " + item.LastName });
            }
            ViewData["Users"] = ppkUserList;
        }

        [HttpPost]
        public ActionResult Create(PPKViewModel model)
        {
            try
            {
                PPK ppk = new PPK() { Id = model.Id, Name = model.Name };
                var response = _ppkLogic.Create(ppk);
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

        // GET: Instructor/Edit/5
        public ActionResult Edit(int id)
        {
            var item = _ppkLogic.GetById(id);
            PrepareSelectList(id);
            PPKViewModel ppk = new PPKViewModel() { Id = item.Id, Name = item.Name, OldId = item.Id };
            return View(ppk);
        }

        // POST: Instructor/Edit/5
        [HttpPost]
        public ActionResult Edit(PPKViewModel model)
        {
            try
            {
                PPK program = new PPK() { Id = model.Id, Name = model.Name, OldId = model.OldId.Value };
                var response = _ppkLogic.Edit(program);
                if (response.IsError == true)
                {
                    foreach (var item in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }
                    PrepareSelectList(model.Id);
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var item = _ppkLogic.GetById(id);
            PPKViewModel ppk = new PPKViewModel() { Id = item.Id, Name = item.Name, OldId = item.Id };
            return View(ppk);
        }

        // POST: Instructor/Edit/5
        [HttpPost]
        public ActionResult Delete(PPKViewModel model)
        {
            try
            {
                var response = _ppkLogic.Delete(model.Id);
                if (response.IsError == true)
                {
                    foreach (var item in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }
                    return View(model);
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