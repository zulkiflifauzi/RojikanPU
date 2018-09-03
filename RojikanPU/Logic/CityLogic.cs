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
    public class CityLogic : ICityLogic
    {
        private readonly CityRepository _repository = new CityRepository(new ApplicationDbContext());

        public ResponseMessage Create(City entity)
        {
            ResponseMessage response = new ResponseMessage();

            if (_repository.IsCityExist(entity.AreaCode))
            {
                response.IsError = true;
                response.ErrorCodes.Add("City Already Exist");
                return response;
            }
            _repository.Create(entity);

            return response;
        }

        public ResponseMessage Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage Edit(City entity)
        {
            throw new NotImplementedException();
        }

        public List<City> GetAll()
        {
            return _repository.GetAll();
        }

        public City GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}