using RojikanPU.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RojikanPU.Domain;
using RojikanPU.Context;

namespace RojikanPU.Repositories
{
    public class PPKFileRepository : IPPKFileRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="PPKFileRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public PPKFileRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(PPKFile entity)
        {
            _db.PPKFiles.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var oldData = _db.PPKFiles.SingleOrDefault(c => c.Id == id);
            
            _db.PPKFiles.Remove(oldData);
            _db.SaveChanges();
        }

        public PPKFile Edit(PPKFile entity)
        {
            throw new NotImplementedException();
        }

        public List<PPKFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<PPKFile> GetPPKFiles(int reportId)
        {
            return _db.PPKFiles.Where(c => c.ReportId == reportId).ToList();
        }

        public PPKFile GetById(int id)
        {
            return _db.PPKFiles.SingleOrDefault(c => c.Id == id);
        }
    }
}