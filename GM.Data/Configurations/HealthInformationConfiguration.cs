namespace GM.Data.Configurations;

public class HealthInformationConfiguration : IEntityTypeConfiguration<HealthInformation>
{
    public void Configure(EntityTypeBuilder<HealthInformation> builder)
    {
        builder.ToTable("HealthInformation");
        builder.HasKey(x =>x.Id );
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.NccId).IsRequired();
        builder.Property(x => x.TimeOfDay).HasColumnType("datetime").IsRequired();
        builder.Property(x => x.Height).IsRequired();
        builder.Property(x => x.Weight).IsRequired();
        builder.Property(x => x.Slush).IsRequired();
        //builder.HasOne(x => x.NCC).WithMany(x => x.HealthInformation).HasForeignKey(x => x.NccId);
        //builder.HasOne(x => x.User).WithMany(x => x.HealthInformation).HasForeignKey(x => x.ManagerId);


        builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.CreatorId).IsRequired();
        builder.Property(x => x.TimeDelete).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.CreateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
    }
}
