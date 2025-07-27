using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class FitnessAppContext: DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }


        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-E0P9L99\\SQLEXPRESS01;database=FitnessApp;Trusted_Connection=True;TrustServerCertificate=True;");
        }

    }
}
