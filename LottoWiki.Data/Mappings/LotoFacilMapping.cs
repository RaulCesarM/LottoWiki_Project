using LottoWiki.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LottoWiki.Data.Mappings
{
    public class LotoFacilMapping : IEntityTypeConfiguration<LotoFacil>
    {
        public void Configure(EntityTypeBuilder<LotoFacil> builder)
        {
            builder.ToTable("base.lotoFacil");
            builder.HasKey(l => new { l.Concurso, l.ConcursoAnterior, l.ProximoConcurso });
            builder.Property(L => L.Concurso).HasMaxLength(4).HasColumnType("int");
            builder.Property(L => L.ConcursoAnterior).HasMaxLength(4).HasColumnType("int");
            builder.Property(L => L.ProximoConcurso).HasMaxLength(4).HasColumnType("int");
            builder.Property(L => L.DataApuracao).HasMaxLength(20).HasColumnType("varchar");
            builder.Property(L => L.NomeMunicipioUFSorteio).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(L => L.LuaDoSorteio).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(L => L.Casa_01).HasMaxLength(2).HasColumnType("int");
            builder.Property(L => L.Casa_02).HasMaxLength(2).HasColumnType("int");
            builder.Property(L => L.Casa_03).HasMaxLength(2).HasColumnType("int");
            builder.Property(L => L.Casa_04).HasMaxLength(2).HasColumnType("int");
            builder.Property(L => L.Casa_05).HasMaxLength(2).HasColumnType("int");
            builder.Property(L => L.Casa_06).HasMaxLength(2).HasColumnType("int");
            builder.Property(L => L.Casa_07).HasMaxLength(2).HasColumnType("int");
            builder.Property(L => L.Casa_08).HasMaxLength(2).HasColumnType("int");
            builder.Property(L => L.Casa_09).HasMaxLength(2).HasColumnType("int");
            builder.Property(L => L.Casa_10).HasMaxLength(2).HasColumnType("int");
            builder.Property(L => L.Casa_11).HasMaxLength(2).HasColumnType("int");
            builder.Property(L => L.Casa_12).HasMaxLength(2).HasColumnType("int");
            builder.Property(L => L.Casa_13).HasMaxLength(2).HasColumnType("int");
            builder.Property(L => L.Casa_14).HasMaxLength(2).HasColumnType("int");
            builder.Property(L => L.Casa_15).HasMaxLength(2).HasColumnType("int");
            builder.Property(L => L.Macro_Estado).HasMaxLength(4).HasColumnType("int");

            builder.HasData(new LotoFacil
            {
                Concurso = 1,
                ConcursoAnterior = 0,
                ProximoConcurso = 2,
                DataApuracao = "01/02/1989",
                NomeMunicipioUFSorteio = "CRUZ ALTA, RS",
                LuaDoSorteio = "Crescente",
                Casa_01 = 18,
                Casa_02 = 20,
                Casa_03 = 25,
                Casa_04 = 23,
                Casa_05 = 10,
                Casa_06 = 11,
                Casa_07 = 24,
                Casa_08 = 14,
                Casa_09 = 06,
                Casa_10 = 02,
                Casa_11 = 13,
                Casa_12 = 09,
                Casa_13 = 05,
                Casa_14 = 16,
                Casa_15 = 03,
                Macro_Estado = 100
            },
            new LotoFacil
            {
                Concurso = 2,
                ConcursoAnterior = 1,
                ProximoConcurso = 3,
                DataApuracao = "02/02/1989",
                NomeMunicipioUFSorteio = "CRUZ ALTA, RS",
                LuaDoSorteio = "Crescente",
                Casa_01 = 23,
                Casa_02 = 15,
                Casa_03 = 05,
                Casa_04 = 04,
                Casa_05 = 12,
                Casa_06 = 16,
                Casa_07 = 20,
                Casa_08 = 06,
                Casa_09 = 11,
                Casa_10 = 19,
                Casa_11 = 24,
                Casa_12 = 01,
                Casa_13 = 09,
                Casa_14 = 13,
                Casa_15 = 07,
                Macro_Estado = 100
            },
           new LotoFacil
           {
               Concurso = 3,
               ConcursoAnterior = 2,
               ProximoConcurso = 4,
               DataApuracao = "02/02/1989",
               NomeMunicipioUFSorteio = "CRUZ ALTA, RS",
               LuaDoSorteio = "Crescente",
               Casa_01 = 20,
               Casa_02 = 23,
               Casa_03 = 12,
               Casa_04 = 08,
               Casa_05 = 06,
               Casa_06 = 01,
               Casa_07 = 07,
               Casa_08 = 11,
               Casa_09 = 14,
               Casa_10 = 04,
               Casa_11 = 16,
               Casa_12 = 10,
               Casa_13 = 09,
               Casa_14 = 17,
               Casa_15 = 24,
               Macro_Estado = 100
           });
        }
    }
}