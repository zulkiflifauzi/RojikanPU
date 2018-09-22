using RojikanPU.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojikanPU.Logic.Interface
{
    public interface IStaffFileLogic : IBaseLogic<StaffFile>
    {
        List<StaffFile> GetStaffFiles(int articleId);
    }
}
