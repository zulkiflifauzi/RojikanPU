using RojikanPU.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RojikanPU.Domain;
using RojikanPU.Context;

namespace RojikanPU.Repositories
{
    public class ReporterFileRepository : IReporterFileRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReporterFileRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ReporterFileRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(ReporterFile entity)
        {
            _db.ReporterFiles.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var oldData = _db.ReporterFiles.SingleOrDefault(c => c.Id == id);
            
            _db.ReporterFiles.Remove(oldData);
            _db.SaveChanges();
        }

        public ReporterFile Edit(ReporterFile entity)
        {
            throw new NotImplementedException();
        }

        public List<ReporterFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ReporterFile> GetReporterFiles(int reportId)
        {
            return _db.ReporterFiles.Where(c => c.ReportId == reportId).ToList();
        }

        public ReporterFile GetById(int id)
        {
            return _db.ReporterFiles.SingleOrDefault(c => c.Id == id);
        }
    }
}