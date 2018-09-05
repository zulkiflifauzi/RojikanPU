using RojikanPU.Context;
using RojikanPU.Domain;
using RojikanPU.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RojikanPU.Repositories
{
    public class PPKRepository : IPPKRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="PPKRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public PPKRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(PPK entity)
        {
            _db.PPKs.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var oldData = _db.PPKs.SingleOrDefault(c => c.Id == id);

            _db.PPKs.Remove(oldData);
            _db.SaveChanges();
        }

        public PPK Edit(PPK entity)
        {
            var oldData = _db.PPKs.SingleOrDefault(c => c.Id == entity.OldId);
            _db.PPKs.Remove(oldData);
            _db.PPKs.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public List<PPK> GetAll()
        {
            return _db.PPKs.ToList();
        }

        public PPK GetById(int id)
        {
            return _db.PPKs.SingleOrDefault(c => c.Id == id);
        }

        public bool IsPPKExist(string name, int? exludedId = null)
        {
            if (exludedId != null)
                return _db.PPKs.Any(c => c.Name.Equals(name) && c.Id != exludedId);
            else
                return _db.PPKs.Any(c => c.Name.Equals(name));
        }
    }
}