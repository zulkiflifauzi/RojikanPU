using RojikanPU.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RojikanPU.Models;
using RojikanPU.Context;

namespace RojikanPU.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public UserRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser Edit(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> GetAll()
        {
            return _db.Users.ToList();
        }

        public ApplicationUser GetById(int id)
        {
            return _db.Users.SingleOrDefault(c => c.Id == id);
        }

        public List<ApplicationUser> GetFreeUsers(List<int> exceptions)
        {
            return _db.Users.Where(c => !exceptions.Contains(c.Id)).ToList();
        }

        public List<ApplicationUser> GetPPKUsers(int? excludedId = null)
        {
            var userIds = _db.PPKs.Where(c => c.Id != excludedId).Select(c => c.Id).ToList();

            var role = _db.Roles.Where(c => c.Name.Equals("PPK")).FirstOrDefault();

            var userRoleIds = role.Users.Select(c => c.UserId).ToList();

            if (excludedId != null)
            {
                return _db.Users.Where(c => !userIds.Contains(c.Id) && userRoleIds.Contains(c.Id)).ToList();
            }

            return _db.Users.Where(c => !userIds.Contains(c.Id) && userRoleIds.Contains(c.Id)).ToList();
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            return _db.Users.Where(c => c.Email.Equals(email)).SingleOrDefault();
        }
    }
}