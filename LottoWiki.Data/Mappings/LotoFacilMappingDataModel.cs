using LottoWiki.Domain.Models.MachineLearning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LottoWiki.Data.Mappings
{
    public class LotoFacilMappingDataModel : IEntityTypeConfiguration<LotoFacilDataModel>
    {
        public void Configure(EntityTypeBuilder<LotoFacilDataModel> builder)
        {
            builder.ToTable("bola.datamodel");
            builder.HasKey(l => new { l.Id });
            builder.Property(L => L.NextLetter).HasMaxLength(5).HasColumnType("varchar");
            builder.Property(L => L.NextNumber).HasMaxLength(4).HasColumnType("int");
            builder.Property(L => L.LuckyBall).HasMaxLength(2).HasColumnType("int");

            builder.Property(L => L.ValidNextLetterSugestion).HasMaxLength(5).HasColumnType("varchar");
            builder.Property(L => L.TrueFriendLetter).HasMaxLength(5).HasColumnType("varchar");

            builder.Property(L => L.Id).HasMaxLength(4).HasColumnType("int");
            builder.Property(L => L.StatusId).HasMaxLength(4).HasColumnType("int");

            builder.Property(L => L.LunarSeasonality).HasMaxLength(5).HasColumnType("varchar");
            builder.Property(L => L.FirstFriend).HasMaxLength(2).HasColumnType("int");
            builder.Property(L => L.SecondFriend).HasMaxLength(2).HasColumnType("int");
            builder.Property(L => L.ThirdFriend).HasMaxLength(2).HasColumnType("int");

            builder.Property(L => L.FirstFriendLetter).HasMaxLength(5).HasColumnType("varchar");
            builder.Property(L => L.SecondFriendLetter).HasMaxLength(5).HasColumnType("varchar");
            builder.Property(L => L.ThirdFriendLetter).HasMaxLength(5).HasColumnType("varchar");

            builder.Property(L => L.RLetterCount).HasMaxLength(4).HasColumnType("int");
            builder.Property(L => L.NLetterCount).HasMaxLength(4).HasColumnType("int");
            builder.Property(L => L.ALetterCount).HasMaxLength(4).HasColumnType("int");

            builder.Property(L => L.NextLetterSugestion).HasMaxLength(5).HasColumnType("varchar");
            builder.Property(L => L.FirstOption).HasMaxLength(2).HasColumnType("varchar");
            builder.Property(L => L.SecondOption).HasMaxLength(2).HasColumnType("varchar");

            builder.Property(L => L.ThreeSequence).HasMaxLength(5).HasColumnType("varchar");
            builder.Property(L => L.NumeredSequence).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(L => L.HorizontalSequence).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(L => L.VerticalSequence).HasMaxLength(50).HasColumnType("varchar");
        }
    }
}