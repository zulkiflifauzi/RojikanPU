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
    public class PPKLogic : IPPKLogic
    {
        private readonly PPKRepository _repository = new PPKRepository(new ApplicationDbContext());
        private readonly ReportRepository _reportRepository = new ReportRepository(new ApplicationDbContext());


        public ResponseMessage Create(PPK entity)
        {
            ResponseMessage response = new ResponseMessage();

            if (_repository.IsPPKExist(entity.Name))
            {
                response.IsError = true;
                response.ErrorCodes.Add("PPK Already Exist");
                return response;
            }

            _repository.Create(entity);

            return response;
        }

        public ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (_reportRepository.IsReportsExist(id))
            {
                response.IsError = true;
                response.ErrorCodes.Add("PPK telah didisposisi Laporan, hapus terlebih dahulu laporan tersebut.");
                return response;
            }

            _repository.Delete(id);

            return response;
        }

        public ResponseMessage Edit(PPK entity)
        {
            ResponseMessage response = new ResponseMessage();
            if (_repository.IsPPKExist(entity.Name, entity.Id))
            {
                response.IsError = true;
                response.ErrorCodes.Add("PPK Already Exist");
                return response;
            }
            _repository.Edit(entity);

            return response;
        }

        public List<PPK> GetAll()
        {
            return _repository.GetAll();
        }

        public PPK GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}