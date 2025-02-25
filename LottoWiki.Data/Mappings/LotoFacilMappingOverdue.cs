using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LottoWiki.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LottoWiki.Data.Mappings
{
    public class LotoFacilMappingOverdue : IEntityTypeConfiguration<LotoFacilOverdue>
    {
        public void Configure(EntityTypeBuilder<LotoFacilOverdue> builder)
        {
            builder.ToTable("bola.atraso");
            builder.HasKey(l => new { l.Concurso, l.ConcursoAnterior, l.ProximoConcurso });
            builder.Property(L => L.Concurso).HasMaxLength(4).HasColumnType("int");
            builder.Property(L => L.ConcursoAnterior).HasMaxLength(4).HasColumnType("int");
            builder.Property(L => L.ProximoConcurso).HasMaxLength(4).HasColumnType("int");
            builder.Property(L => L.Bola_01).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_02).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_03).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_04).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_05).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_06).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_07).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_08).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_09).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_10).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_11).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_12).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_13).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_14).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_15).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_16).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_17).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_18).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_19).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_20).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_21).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_22).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_23).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_24).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Bola_25).HasMaxLength(3).HasColumnType("int");
            builder.Property(L => L.Macro_Estado).HasMaxLength(4).HasColumnType("int");
            builder.Property(l => l.MediaConcurso).HasColumnType("decimal(18,2)");
            builder.Property(l => l.MediaGlobal).HasColumnType("decimal(18,2)");
            builder.Property(l => l.DesvioPadraoConcurso).HasColumnType("decimal(18,2)");
            builder.Property(l => l.DesvioPadraoGlobal).HasColumnType("decimal(18,2)");

            builder.HasData(
            new LotoFacilOverdue
            {
                ConcursoAnterior = 0,
                Concurso = 1,
                ProximoConcurso = 2,
                Bola_01 = 1,
                Bola_02 = 0,
                Bola_03 = 1,
                Bola_04 = 1,
                Bola_05 = 0,
                Bola_06 = 0,
                Bola_07 = 1,
                Bola_08 = 1,
                Bola_09 = 0,
                Bola_10 = 0,
                Bola_11 = 0,
                Bola_12 = 1,
                Bola_13 = 0,
                Bola_14 = 0,
                Bola_15 = 1,
                Bola_16 = 0,
                Bola_17 = 0,
                Bola_18 = 1,
                Bola_19 = 1,
                Bola_20 = 0,
                Bola_21 = 1,
                Bola_22 = 1,
                Bola_23 = 0,
                Bola_24 = 0,
                Bola_25 = 0,
                Macro_Estado = 10,
                MediaConcurso = 1.0,
                MediaGlobal = 1.0,
                DesvioPadraoConcurso = 1.0,
                DesvioPadraoGlobal = 1.0
            },
            new LotoFacilOverdue
            {
                ConcursoAnterior = 1,
                Concurso = 2,
                ProximoConcurso = 3,
                Bola_01 = 2,
                Bola_02 = 1,
                Bola_03 = 1,
                Bola_04 = 0,
                Bola_05 = 0,
                Bola_06 = 0,
                Bola_07 = 0,
                Bola_08 = 1,
                Bola_09 = 0,
                Bola_10 = 1,
                Bola_11 = 0,
                Bola_12 = 0,
                Bola_13 = 0,
                Bola_14 = 1,
                Bola_15 = 0,
                Bola_16 = 0,
                Bola_17 = 1,
                Bola_18 = 1,
                Bola_19 = 0,
                Bola_20 = 0,
                Bola_21 = 2,
                Bola_22 = 2,
                Bola_23 = 0,
                Bola_24 = 0,
                Bola_25 = 1,
                Macro_Estado = 10,
                MediaConcurso = 1.0,
                MediaGlobal = 1.0,
                DesvioPadraoConcurso = 1.0,
                DesvioPadraoGlobal = 1.0
            },
            new LotoFacilOverdue
            {
                ConcursoAnterior = 2,
                Concurso = 3,
                ProximoConcurso = 4,
                Bola_01 = 0,
                Bola_02 = 2,
                Bola_03 = 2,
                Bola_04 = 0,
                Bola_05 = 1,
                Bola_06 = 0,
                Bola_07 = 0,
                Bola_08 = 0,
                Bola_09 = 0,
                Bola_10 = 0,
                Bola_11 = 0,
                Bola_12 = 0,
                Bola_13 = 1,
                Bola_14 = 0,
                Bola_15 = 1,
                Bola_16 = 0,
                Bola_17 = 0,
                Bola_18 = 2,
                Bola_19 = 1,
                Bola_20 = 0,
                Bola_21 = 3,
                Bola_22 = 3,
                Bola_23 = 0,
                Bola_24 = 0,
                Bola_25 = 2,
                Macro_Estado = 10,
                MediaConcurso = 1.0,
                MediaGlobal = 1.0,
                DesvioPadraoConcurso = 1.0,
                DesvioPadraoGlobal = 1.0
            });
        }
    }
}