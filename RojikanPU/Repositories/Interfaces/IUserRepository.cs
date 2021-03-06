﻿using RojikanPU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojikanPU.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<ApplicationUser>
    {
        List<ApplicationUser> GetFreeUsers(List<int> exceptions);

        ApplicationUser GetUserByEmail(string email);

        List<ApplicationUser> GetPPKUsers(int? excludedId);
    }
}
