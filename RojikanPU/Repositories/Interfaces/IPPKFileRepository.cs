using RojikanPU.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojikanPU.Repositories.Interfaces
{
    public interface IPPKFileRepository : IBaseRepository<PPKFile>
    {
        List<PPKFile> GetPPKFiles(int reportId);
    }
}
