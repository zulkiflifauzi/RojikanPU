using Microsoft.AspNet.Identity.EntityFramework;
using RojikanPU.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RojikanPU.Domain;

namespace RojikanPU.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, NetRole, int, NetUserLogin, NetUserRole, NetUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<ApplicationDbContext>(null);
        }        

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleFile> ArticleFiles { get; set; }

        public DbSet<PPK> PPKs { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<ReporterFile> ReporterFiles { get; set; }

        public DbSet<StaffFile> StaffFiles { get; set; }

        public DbSet<PPKFile> PPKFiles { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}