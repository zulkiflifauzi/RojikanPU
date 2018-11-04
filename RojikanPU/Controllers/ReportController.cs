using Microsoft.AspNet.Identity;
using RojikanPU.Base;
using RojikanPU.Domain;
using RojikanPU.Logic;
using RojikanPU.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace RojikanPU.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private ReportLogic _reportLogic = new ReportLogic();
        private PPKLogic _ppkLogic = new PPKLogic();
        private StaffFileLogic _staffFileLogic = new StaffFileLogic();
        private PPKFileLogic _ppkFileLogic = new PPKFileLogic();
        // GET: Report
        [Authorize(Roles = "Administrator, Data Entry")]
        public ActionResult Index()
        {
            List<ReportViewModel> model = new List<ReportViewModel>();
            var reports = _reportLogic.GetAll();
            foreach (var item in reports)
            {
                ReportViewModel report = new ReportViewModel() { Address = item.Address, Description = item.Description, Name = item.Name, Origin = item.Origin, CreatedDate = item.CreatedDate.ToString("dd-MMM-yyyy hh:mm"), Status = item.Status, Id = item.Id, AssignedDate = item.ProcessDate.HasValue ? item.ProcessDate.Value.ToString("dd-MMM-yyyy hh:mm") : string.Empty, PhoneNumber = item.PhoneNumber, AssignedToPPK = item.PPK != null ? item.PPK.Name : string.Empty, ClosedDate = item.ClosedDate.HasValue ? item.ClosedDate.Value.ToString("dd-MMM-yyyy hh:mm") : string.Empty, Type = item.Type };
                model.Add(report);
            }
            return View(model);
        }

        [Authorize(Roles = "PPK")]
        public ActionResult Assigned()
        {
            List<ReportViewModel> model = new List<ReportViewModel>();
            var userId = Convert.ToInt32(User.Identity.GetUserId());
            var reports = _reportLogic.GetByPPKId(userId);
            foreach (var item in reports)
            {
                ReportViewModel report = new ReportViewModel() { Address = item.Address, Description = item.Description, Name = item.Name, Origin = item.Origin, CreatedDate = item.CreatedDate.ToString("dd-MMM-yyyy hh:mm"), Status = item.Status, Id = item.Id, AssignedDate = item.ProcessDate.HasValue ? item.ProcessDate.Value.ToString("dd-MMM-yyyy hh:mm") : string.Empty, PhoneNumber = item.PhoneNumber, AssignedToPPK = item.PPK != null ? item.PPK.Name : string.Empty, ClosedDate = item.ClosedDate.HasValue ? item.ClosedDate.Value.ToString("dd-MMM-yyyy hh:mm") : string.Empty };
                model.Add(report);
            }
            return View(model);
        }

        public ActionResult PPKComment(int id)
        {
            ViewData["ReportId"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult PPKComment(HttpPostedFileBase file, PPKCommentViewModel model)
        {
            Report report = new Report() { PPKComment = model.Comment, Id = model.ReportId };
            _reportLogic.UpdatePPKComment(report);

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = model.ReportId + "_" + fileName;
                var path = Path.Combine(Server.MapPath("~/Content/UploadPPK"), filePath);
                file.SaveAs(path);

                PPKFile ppkFile = new PPKFile();
                ppkFile.FileName = fileName;
                ppkFile.ReportId = model.ReportId;

                _ppkFileLogic.Create(ppkFile);
            }

            try
            {
                try
                {
                    var msg = new MailMessage();
                    msg.To.Add(new MailAddress(ConfigurationManager.AppSettings["AdminEmail"]));
                    msg.Subject = "LAPOR-BRANTAS New Comment From PPK";
                    msg.Body = model.Comment;
                    msg.From = new MailAddress("admin@lapor-brantas.net");

                    using (var client = new SmtpClient() { Host = "relay-hosting.secureserver.net", Port = 25, EnableSsl = false, UseDefaultCredentials = false })
                    {
                        client.Send(msg);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Assigned");
        }

        // GET: Report/Details/5
        public ActionResult Details(int id)
        {
            var item = _reportLogic.GetById(id);
            ReportViewModel report = new ReportViewModel() { Address = item.Address, Description = item.Description, Name = item.Name, Origin = item.Origin, CreatedDate = item.CreatedDate.ToString("dd-MMM-yyyy hh:mm"), Status = item.Status, Id = item.Id, AssignedDate = item.ProcessDate.HasValue ? item.ProcessDate.Value.ToString("dd-MMM-yyyy hh:mm") : string.Empty, PhoneNumber = item.PhoneNumber, AssignedToPPK = item.PPK != null ? item.PPK.Name : string.Empty, ClosedDate = item.ClosedDate.HasValue ? item.ClosedDate.Value.ToString("dd-MMM-yyyy hh:mm") : string.Empty, StaffComment = item.StaffComment, PPKComment = item.PPKComment, ReportFileURL = item.ReporterFiles.Count() > 0 ? "/Content/UploadReporter/" + item.Id + "_" + item.ReporterFiles.FirstOrDefault().FileName : "", StaffFileURL = item.StaffFiles.Count() > 0 ? "/Content/UploadStaff/" + item.Id + "_" + item.StaffFiles.FirstOrDefault().FileName : "", PPKFileURL = item.PPKFiles.Count() > 0 ? "/Content/UploadPPK/" + item.Id + "_" + item.PPKFiles.FirstOrDefault().FileName : "", IDCardURL = "/Content/UploadKTP/" + item.Id + "_" + item.IDCardFileName, LicenseURL = "/Content/UploadLicense/" + item.Id + "_" + item.LicenseFileName, OrganizationPermitURL = "/Content/UploadOrganizationPermit/" + item.Id + "_" + item.OrganizationpermitFileName, Type = item.Type };
            return View(report);
        }

        // GET: Report/Create
        [Authorize(Roles = "Administrator, Data Entry")]
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
        [Authorize(Roles = "Administrator, Data Entry")]
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

        [Authorize(Roles = "Administrator, Data Entry")]
        public ActionResult Assign(int id)
        {
            AssignViewModel assign = new AssignViewModel();
            assign.Id = id;
            PrepareAssignSelectList();
            return View(assign);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Data Entry")]
        public ActionResult Assign(HttpPostedFileBase file, AssignViewModel model)
        {
            Report report = new Report();
            report.Id = model.Id;
            report.PPKId = model.PPKId;
            report.StaffComment = model.StaffComment;
            _reportLogic.AssignReport(report);
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = model.Id + "_" + fileName;
                var path = Path.Combine(Server.MapPath("~/Content/UploadStaff"), filePath);
                file.SaveAs(path);

                StaffFile staffFile = new StaffFile();
                staffFile.FileName = fileName;
                staffFile.ReportId = model.Id;

                _staffFileLogic.Create(staffFile);
            }

            try {
                var ppk = _ppkLogic.GetById(model.PPKId);

                if (ppk != null)
                {
                    if (ppk.PIC != null)
                    {
                        var msg = new MailMessage();
                        msg.To.Add(new MailAddress(ppk.PIC.Email));
                        msg.Subject = "LAPOR-BRANTAS New Disposition";
                        msg.Body = model.StaffComment;
                        msg.From = new MailAddress("admin@lapor-brantas.net");

                        using (var client = new SmtpClient() { Host = "relay-hosting.secureserver.net", Port = 25, EnableSsl = false, UseDefaultCredentials = false })
                        {
                            client.Send(msg);
                        }
                    }                   
                }                
            }
            catch (Exception ex)
            {

            }

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
        [Authorize(Roles = "Administrator, Data Entry")]
        public ActionResult Delete(int id)
        {
            var item = _reportLogic.GetById(id);
            ReportViewModel report = new ReportViewModel() { Address = item.Address, Description = item.Description, Name = item.Name, Origin = item.Origin, CreatedDate = item.CreatedDate.ToString("dd-MMM-yyyy hh:mm"), Status = item.Status, Id = item.Id, AssignedDate = item.ProcessDate.HasValue ? item.ProcessDate.Value.ToString("dd-MMM-yyyy hh:mm") : string.Empty, PhoneNumber = item.PhoneNumber, AssignedToPPK = item.PPK != null ? item.PPK.Name : string.Empty, ClosedDate = item.ClosedDate.HasValue ? item.ClosedDate.Value.ToString("dd-MMM-yyyy hh:mm") : string.Empty, StaffComment = item.StaffComment, PPKComment = item.PPKComment };
            return View(report);
        }

        // POST: Report/Delete/5
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(ReportViewModel model)
        {
            try
            {
                var response = _reportLogic.Delete(model.Id);
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
