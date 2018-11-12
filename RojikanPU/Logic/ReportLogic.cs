using RojikanPU.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RojikanPU.Base;
using RojikanPU.Domain;
using RojikanPU.Repositories;
using RojikanPU.Context;
using RojikanPU.Models;

namespace RojikanPU.Logic
{
    public class ReportLogic : IReportLogic
    {
        private readonly ReportRepository _repository = new ReportRepository(new ApplicationDbContext());

        public void AssignReport(Report report)
        {
            var oldData = _repository.GetById(report.Id);
            oldData.PPKId = report.PPKId;
            oldData.StaffComment = report.StaffComment;
            oldData.ProcessDate = DateTime.Now;
            oldData.Status = Constant.ReportStatus.ONPROCESS;
            _repository.Edit(oldData);
        }

        public ResponseMessage Create(Report entity)
        {
            ResponseMessage response = new ResponseMessage();

            _repository.Create(entity);

            response.CreatedId = _repository.GetLatestReportId();

            return response;
        }

        public ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            _repository.Delete(id);

            return response;
        }

        public ResponseMessage Edit(Report entity)
        {
            ResponseMessage response = new ResponseMessage();

            _repository.Edit(entity);

            return response;
        }

        public List<Report> GetAll()
        {
            return _repository.GetAll();
        }

        public Report GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Report> GetByPPKId(int ppkId)
        {
            return _repository.GetByPPKId(ppkId);
        }

        public DashboardDTO GetDashboard()
        {
            DashboardDTO result = new DashboardDTO();
            result.TotalReportNotYetAssigned = _repository.TotalReportNotYetAssigned();
            result.TotalReportNotYetCommented = _repository.TotalReportNotYetCommented();
            result.TotalReportThisMonth = _repository.TotalReportThisMonth();
            result.TotalReportThisYear = _repository.TotalReportThisYear();
            return result;
        }

        public List<Report> GetReportGraph(int year)
        {
            return _repository.GetReportsGraph(year);
        }

        public List<string> GetYears()
        {
            return _repository.GetYears();
        }

        public void UpdatePPKComment(Report report)
        {
            var oldData = _repository.GetById(report.Id);
            oldData.PPKComment = report.PPKComment;
            oldData.ClosedDate = DateTime.Now;
            oldData.Status = Constant.ReportStatus.CLOSED;
            _repository.Edit(oldData);
        }
    }
}