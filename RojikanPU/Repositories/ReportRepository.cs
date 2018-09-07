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
            throw new NotImplementedException();
        }

        public Report Edit(Report entity)
        {
            throw new NotImplementedException();
        }

        public List<Report> GetAll()
        {
            return _db.Reports.OrderByDescending(c => c.Id).ToList();
        }

        public Report GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetLatestReportId()
        {
            return _db.Reports.Max(c => c.Id);
        }
    }
}