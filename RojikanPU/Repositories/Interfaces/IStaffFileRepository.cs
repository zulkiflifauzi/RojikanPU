using RojikanPU.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojikanPU.Repositories.Interfaces
{
    public interface IStaffFileRepository : IBaseRepository<StaffFile>
    {
        List<StaffFile> GetStaffFiles(int reportId);
    }
}
