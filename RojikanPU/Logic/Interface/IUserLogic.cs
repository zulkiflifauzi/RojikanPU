using RojikanPU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojikanPU.Logic.Interface
{
    public interface IUserLogic : IBaseLogic<ApplicationUser>
    {
        ApplicationUser GetUserByEmail(string email);

        List<ApplicationUser> GetPPKUsers(int? excludedId);
    }
}
