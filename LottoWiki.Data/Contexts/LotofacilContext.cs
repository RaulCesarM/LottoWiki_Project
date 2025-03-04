﻿using LottoWiki.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using LottoWiki.Data.Mappings;

namespace LottoWiki.Data.Contexts
{
    public class LotofacilContext : DbContext
    {
        public LotofacilContext(DbContextOptions<LotofacilContext> options) : base(options)
        {
        }

        public DbSet<LotoFacil> LotoFacil_Context { get; set; }
        public DbSet<LotoFacilStatus> LotoFacil_Status_Context { get; set; }
        public DbSet<LotoFacilOverdue> LotoFacil_OverDue_Context { get; set; }
        public DbSet<LotoFacilDoOver> LotoFacil_DoOver_Context { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LotoFacilMapping());
            modelBuilder.ApplyConfiguration(new LotoFacilMappingOverdue());
            modelBuilder.ApplyConfiguration(new LotoFacilMappingStatus());
            modelBuilder.ApplyConfiguration(new LotoFacilMappingDoOver());
        }
    }
}