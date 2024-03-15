using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using WebApplication2.TPC;
using WebApplication2.TPH;
using WebApplication2.TPT;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplication2;

public class NewContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Configuring the Connection String
        optionsBuilder.UseSqlServer(@"Server=.;Database=EFCoreDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseEntityTPH>().UseTphMappingStrategy();
        modelBuilder.Entity<BaseEntityTPT>().UseTptMappingStrategy();
        modelBuilder.Entity<BaseEntityTPC>().UseTpcMappingStrategy();


    }
    public DbSet<BaseEntityTPH> BaseEntityTPH { get; set; }
    public DbSet<PersonTPH> PersonTPH { get; set; }
    public DbSet<CompanyTPH> CompanyTPH { get; set; }


    public DbSet<BaseEntityTPT> BaseEntityTPT { get; set; }
    public DbSet<PersonTPT> PersonTPT { get; set; }
    public DbSet<CompanyTPT> CompanyTPT { get; set; }


    public DbSet<BaseEntityTPC> BaseEntityTPC { get; set; }
    public DbSet<PersonTPC> PersonTPC { get; set; }
    public DbSet<CompanyTPC> CompanyTPC { get; set; }


    /*Old
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        //TPH
        modelBuilder.Entity<BaseEntityTPH>()
            .ToTable("BaseEntityTPH")
            .HasDiscriminator<string>("types")
            .HasValue<PersonTPH>("Person")
            .HasValue<CompanyTPH>("Company");


        //TPT
        modelBuilder.Entity<BaseEntityTPT>().ToTable("BaseEntityTPT");
        modelBuilder.Entity<PersonTPT>().ToTable("PersonTPT");
        modelBuilder.Entity<CompanyTPT>().ToTable("CompanyTPT");

        modelBuilder.Entity<PersonTPT>().HasBaseType<BaseEntityTPT>();
        modelBuilder.Entity<PersonTPT>().HasBaseType<BaseEntityTPT>();


        //TPC
        modelBuilder.Entity<BaseEntityTPC>().UseTpcMappingStrategy();
        modelBuilder.Entity<PersonTPC>().ToTable("PersonTPC");
        modelBuilder.Entity<CompanyTPC>().ToTable("CompanyTPC");


    }
    public DbSet<BaseEntityTPH> BaseEntityTPH { get; set; }
    public DbSet<BaseEntityTPT> BaseEntityTPT { get; set; }

    public DbSet<BaseEntityTPC> BaseEntityTPC { get; set; }
    */
}

