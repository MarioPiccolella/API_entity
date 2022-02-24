using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using API_entity.Models;

namespace API_entity.DataModels
{
    public class Context: DbContext
    {
        public DbSet<skill> skills { get; set; }
        public DbSet<washer> washers { get; set; }
        public DbSet<washer_skill> washers_skills { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EFEasyExample;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"data source=DESKTOP-6OABVID\SQLEXPRESS; initial catalog=DB_washer;persist security info=True; Integrated Security=SSPI;");
        }
    }
}
