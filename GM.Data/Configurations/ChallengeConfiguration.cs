global using GM.Data.Entitis;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GM.Data.Configurations;

public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
{
    public void Configure(EntityTypeBuilder<Challenge> builder)
    {
        builder.ToTable("Challenge");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Name).IsUnicode().IsRequired();
        builder.Property(x => x.Content).IsRequired(false);
        builder.Property(x => x.ManagerId).IsRequired();
        builder.Property(x => x.StartDate).HasColumnType("datetime").IsRequired();
        builder.Property(x => x.EndDate).HasColumnType("datetime").IsRequired();
        //builder.HasOne(x => x.User).WithMany(x => x.Challenges).HasForeignKey(x => x.ManagerId);

        builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.CreatorId).IsRequired();
        builder.Property(x => x.TimeDelete).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.CreateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
    }
}
