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
    public class StaffFileLogic : IStaffFileLogic
    {
        private readonly StaffFileRepository _repository = new StaffFileRepository(new ApplicationDbContext());
        public ResponseMessage Create(StaffFile entity)
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

        public ResponseMessage Edit(StaffFile entity)
        {
            throw new NotImplementedException();
        }

        public List<StaffFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<StaffFile> GetStaffFiles(int reportId)
        {
            return _repository.GetStaffFiles(reportId);
        }

        public StaffFile GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}