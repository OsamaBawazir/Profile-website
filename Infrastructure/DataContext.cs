using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
     public  class DataContext: DbContext
    {
        public DataContext (DbContextOptions <DataContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Owner>().Property(
                x => x.ID).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<ProfileItem>().Property(
               x => x.ID).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Owner>().HasData(
                new Owner()
                {
                    ID = Guid.NewGuid(),
                    FullName ="Osama Mohammed",
                    Profile=".NET Devloper",
                    Address="Jeddah"
                }
                ) ; 

        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<ProfileItem> ProfileItems { get; set; }
    }
}
