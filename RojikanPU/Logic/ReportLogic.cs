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