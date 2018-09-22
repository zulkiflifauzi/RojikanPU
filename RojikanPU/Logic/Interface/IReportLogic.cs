using RojikanPU.Domain;
using RojikanPU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojikanPU.Logic.Interface
{
    public interface IReportLogic : IBaseLogic<Report>
    {
        void AssignReport(Report report);

        List<Report> GetByPPKId(int ppkId);

        void UpdatePPKComment(Report report);

        List<string> GetYears();

        List<Report> GetReportGraph(int year);

        DashboardDTO GetDashboard();
    }
}
