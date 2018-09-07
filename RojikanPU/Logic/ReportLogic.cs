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
            throw new NotImplementedException();
        }

        public ResponseMessage Edit(Report entity)
        {
            throw new NotImplementedException();
        }

        public List<Report> GetAll()
        {
            return _repository.GetAll();
        }

        public Report GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}