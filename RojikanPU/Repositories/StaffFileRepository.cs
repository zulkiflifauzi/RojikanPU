using RojikanPU.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RojikanPU.Domain;
using RojikanPU.Context;

namespace RojikanPU.Repositories
{
    public class StaffFileRepository : IStaffFileRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="StaffFileRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public StaffFileRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(StaffFile entity)
        {
            _db.StaffFiles.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var oldData = _db.StaffFiles.SingleOrDefault(c => c.Id == id);
            
            _db.StaffFiles.Remove(oldData);
            _db.SaveChanges();
        }

        public StaffFile Edit(StaffFile entity)
        {
            throw new NotImplementedException();
        }

        public List<StaffFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<StaffFile> GetStaffFiles(int reportId)
        {
            return _db.StaffFiles.Where(c => c.ReportId == reportId).ToList();
        }

        public StaffFile GetById(int id)
        {
            return _db.StaffFiles.SingleOrDefault(c => c.Id == id);
        }
    }
}