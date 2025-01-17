﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team4NetCoreCAProject.Models;

namespace Team4NetCoreCAProject.Db
{
    public class Database :DbContext
    {
        protected IConfiguration configuration;
        public Database(DbContextOptions<Database> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<CartDetail>().HasKey(x => new { x.CartId, x.ProductId });
            model.Entity<PurchaseDetail>().HasKey(x => new { x.PurchaseId, x.ProductId });
            model.Entity<ActivationKey>().HasIndex(x => x.PdtAtvKey).IsUnique();
        }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Purchase> Purchases { get; set;}
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<ActivationKey> ActivationKeys { get; set; }
    }
}
