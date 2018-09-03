﻿using RojikanPU.Logic.Interface;
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
    public class StateLogic : IStateLogic
    {
        private readonly StateRepository _repository = new StateRepository(new ApplicationDbContext());

        public ResponseMessage Create(State entity)
        {
            ResponseMessage response = new ResponseMessage();

            if (_repository.IsStateExist(entity.AreaCode))
            {
                response.IsError = true;
                response.ErrorCodes.Add("State Already Exist");
                return response;
            }
            _repository.Create(entity);

            return response;
        }

        public ResponseMessage Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage Edit(State entity)
        {
            throw new NotImplementedException();
        }

        public List<State> GetAll()
        {
            return _repository.GetAll();
        }

        public State GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<State> GetStatesGraph(string id, int year)
        {
            return _repository.GetStatesGraph(id, year);
        }
    }
}