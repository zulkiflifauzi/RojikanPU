using RojikanPU.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RojikanPU.Domain;
using RojikanPU.Context;
using RojikanPU.Base;

namespace RojikanPU.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ReportRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(Report entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.Status = Constant.ReportStatus.NEW;
            _db.Reports.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var oldData = _db.Reports.SingleOrDefault(c => c.Id == id);
            _db.Reports.Remove(oldData);
            _db.SaveChanges();
        }

        public Report Edit(Report entity)
        {
            var report = _db.Reports.Find(entity.Id);
            _db.Entry(report).CurrentValues.SetValues(entity);
            _db.SaveChanges();
            return report;
        }

        public List<Report> GetAll()
        {
            return _db.Reports.OrderByDescending(c => c.Id).ToList();
        }

        public Report GetById(int id)
        {
            return _db.Reports.SingleOrDefault(c => c.Id == id);
        }

        public List<Report> GetByPPKId(int ppkId)
        {
            return _db.Reports.Where(c => c.PPKId == ppkId).ToList();
        }

        public int GetLatestReportId()
        {
            return _db.Reports.Max(c => c.Id);
        }

        public List<Report> GetReportsGraph(int year)
        {
            return _db.Reports.Where(c => c.CreatedDate.Year == year).ToList();
        }

        public List<string> GetYears()
        {
            return _db.Reports.Select(c => c.CreatedDate.Year.ToString()).Distinct().ToList();
        }

        public bool IsReportsExist(int ppkId)
        {
            return _db.Reports.Any(c => c.PPKId == ppkId);
        }

        public int TotalReportNotYetAssigned()
        {
            return _db.Reports.Where(c => c.Status == Constant.ReportStatus.NEW).Count();
        }

        public int TotalReportNotYetCommented()
        {
            return _db.Reports.Where(c => c.Status == Constant.ReportStatus.ONPROCESS).Count();
        }

        public int TotalReportThisMonth()
        {
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
            return _db.Reports.Where(c => c.CreatedDate.Year == year && c.CreatedDate.Month == month).Count();
        }

        public int TotalReportThisYear()
        {
            var year = DateTime.Now.Year;
            return _db.Reports.Where(c => c.CreatedDate.Year == year).Count();
        }

        public void UpdatePPKComment(Report report)
        {
            throw new NotImplementedException();
        }
    }
}