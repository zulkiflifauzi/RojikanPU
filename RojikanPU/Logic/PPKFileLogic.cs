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
    public class PPKFileLogic : IPPKFileLogic
    {
        private readonly PPKFileRepository _repository = new PPKFileRepository(new ApplicationDbContext());
        public ResponseMessage Create(PPKFile entity)
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

        public ResponseMessage Edit(PPKFile entity)
        {
            throw new NotImplementedException();
        }

        public List<PPKFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<PPKFile> GetPPKFiles(int reportId)
        {
            return _repository.GetPPKFiles(reportId);
        }

        public PPKFile GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}