using RojikanPU.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojikanPU.Repositories.Interfaces
{
    public interface IReportRepository : IBaseRepository<Report>
    {
        int GetLatestReportId();

        bool IsReportsExist(int ppkId);

        List<Report> GetByPPKId(int ppkId);

        List<string> GetYears();

        List<Report> GetReportsGraph(int year);

        int TotalReportThisMonth();

        int TotalReportThisYear();

        int TotalReportNotYetAssigned();

        int TotalReportNotYetCommented();
    }
}
