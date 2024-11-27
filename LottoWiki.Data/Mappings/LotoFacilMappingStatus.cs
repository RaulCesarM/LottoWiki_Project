using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LottoWiki.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LottoWiki.Data.Mappings
{
    public class LotoFacilMappingStatus : IEntityTypeConfiguration<LotoFacilStatus>
    {
        public void Configure(EntityTypeBuilder<LotoFacilStatus> builder)
        {
            builder.ToTable("bola.status");
            builder.HasKey(l => new { l.Concurso, l.ConcursoAnterior, l.ProximoConcurso });
            builder.Property(L => L.Concurso).HasMaxLength(4).HasColumnType("int");
            builder.Property(L => L.ConcursoAnterior).HasMaxLength(4).HasColumnType("int");
            builder.Property(L => L.ProximoConcurso).HasMaxLength(4).HasColumnType("int");
            builder.Property(L => L.Bola_01).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_02).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_03).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_04).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_05).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_06).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_07).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_08).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_09).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_10).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_11).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_12).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_13).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_14).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_15).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_16).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_17).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_18).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_19).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_20).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_21).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_22).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_23).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_24).HasMaxLength(1).HasColumnType("char");
            builder.Property(L => L.Bola_25).HasMaxLength(1).HasColumnType("char");

            builder.HasData(new LotoFacilStatus
            {
                Concurso = 1,
                ConcursoAnterior = 0,
                ProximoConcurso = 2,
                Bola_01 = 'A',
                Bola_02 = 'N',
                Bola_03 = 'N',
                Bola_04 = 'A',
                Bola_05 = 'N',
                Bola_06 = 'N',
                Bola_07 = 'A',
                Bola_08 = 'A',
                Bola_09 = 'N',
                Bola_10 = 'N',
                Bola_11 = 'N',
                Bola_12 = 'A',
                Bola_13 = 'N',
                Bola_14 = 'N',
                Bola_15 = 'A',
                Bola_16 = 'N',
                Bola_17 = 'A',
                Bola_18 = 'N',
                Bola_19 = 'A',
                Bola_20 = 'N',
                Bola_21 = 'A',
                Bola_22 = 'A',
                Bola_23 = 'N',
                Bola_24 = 'N',
                Bola_25 = 'N'
            },
            new LotoFacilStatus
            {
                Concurso = 2,
                ConcursoAnterior = 1,
                ProximoConcurso = 3,
                Bola_01 = 'R',
                Bola_02 = 'R',
                Bola_03 = 'R',
                Bola_04 = 'R',
                Bola_05 = 'R',
                Bola_06 = 'R',
                Bola_07 = 'R',
                Bola_08 = 'R',
                Bola_09 = 'R',
                Bola_10 = 'R',
                Bola_11 = 'R',
                Bola_12 = 'R',
                Bola_13 = 'R',
                Bola_14 = 'R',
                Bola_15 = 'R',
                Bola_16 = 'R',
                Bola_17 = 'R',
                Bola_18 = 'R',
                Bola_19 = 'R',
                Bola_20 = 'R',
                Bola_21 = 'R',
                Bola_22 = 'R',
                Bola_23 = 'R',
                Bola_24 = 'R',
                Bola_25 = 'R'
            },
            new LotoFacilStatus
            {
                Concurso = 3,
                ConcursoAnterior = 2,
                ProximoConcurso = 4,
                Bola_01 = 'A',
                Bola_02 = 'A',
                Bola_03 = 'A',
                Bola_04 = 'A',
                Bola_05 = 'A',
                Bola_06 = 'A',
                Bola_07 = 'A',
                Bola_08 = 'A',
                Bola_09 = 'A',
                Bola_10 = 'A',
                Bola_11 = 'A',
                Bola_12 = 'A',
                Bola_13 = 'A',
                Bola_14 = 'A',
                Bola_15 = 'A',
                Bola_16 = 'A',
                Bola_17 = 'A',
                Bola_18 = 'A',
                Bola_19 = 'A',
                Bola_20 = 'A',
                Bola_21 = 'A',
                Bola_22 = 'A',
                Bola_23 = 'A',
                Bola_24 = 'A',
                Bola_25 = 'A'
            });
        }
    }
}