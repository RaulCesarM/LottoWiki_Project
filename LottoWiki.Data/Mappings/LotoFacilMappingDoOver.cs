using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LottoWiki.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LottoWiki.Data.Mappings
{
    public class LotoFacilMappingDoOver : IEntityTypeConfiguration<LotoFacilDoOver>
    {
        public void Configure(EntityTypeBuilder<LotoFacilDoOver> builder)
        {
            builder.ToTable("bola.repetida");
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
        }
    }
}