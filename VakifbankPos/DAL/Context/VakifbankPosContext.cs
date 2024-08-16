using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using VakifbankPos.DAL.Entities;

namespace VakifbankPos.DAL.Context
{
    public class VakifbankPosContext : DbContext
    {
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=VakifbankPosProject;Username=postgres;Password=12345678;");
            }
        }

        public DbSet<PosAction> PosActions { get; set; }
        public DbSet<PosInventory> PosInventories { get; set; }
        public DbSet<PosReceiver> PosReceivers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PosAction>()
                .HasOne(pa => pa.PosInventory)
                .WithMany(pi => pi.PosActions)
                .HasForeignKey(pa => pa.PosId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PosAction>()
                .HasOne(pa => pa.PosReceiver)
                .WithMany(pr => pr.PosActions)
                .HasForeignKey(pa => pa.PosReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

          
        }

    }


}


