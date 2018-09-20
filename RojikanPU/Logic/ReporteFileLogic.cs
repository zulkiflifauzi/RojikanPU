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
    public class ReporterFileLogic : IReporterFileLogic
    {
        private readonly ReporterFileRepository _repository = new ReporterFileRepository(new ApplicationDbContext());
        public ResponseMessage Create(ReporterFile entity)
        {
            ResponseMessage response = new ResponseMessage();

            _repository.Create(entity);

            return response;
        }

        public ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            _repository.Delete(id);

            return response;
        }

        public ResponseMessage Edit(ReporterFile entity)
        {
            throw new NotImplementedException();
        }

        public List<ReporterFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ReporterFile> GetReporterFiles(int reportId)
        {
            return _repository.GetReporterFiles(reportId);
        }

        public ReporterFile GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}