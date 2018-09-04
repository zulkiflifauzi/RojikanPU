﻿using RojikanPU.Context;
using RojikanPU.Logic.Interface;
using RojikanPU.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RojikanPU.Models;
using RojikanPU.Base;

namespace RojikanPU.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly UserRepository _repository = new UserRepository(new ApplicationDbContext());

        public ResponseMessage Create(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> GetAll()
        {
            return _repository.GetAll();
        }

        public ApplicationUser GetById(int id)
        {
            return _repository.GetById(id);
        }
        
        public ResponseMessage Edit(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            return _repository.GetUserByEmail(email);
        }
    }
}