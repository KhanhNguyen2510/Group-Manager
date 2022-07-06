namespace GM.Data.Configurations;

public class NCConfiguration : IEntityTypeConfiguration<NC>
{
    public void Configure(EntityTypeBuilder<NC> builder)
    {
        builder.ToTable("NC");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Name).IsUnicode().IsRequired();
        builder.Property(x => x.Note).IsRequired(false);
        builder.Property(x => x.ManagerId).IsRequired();
        //builder.HasOne(x => x.User).WithMany(x => x.NCs).HasForeignKey(x => x.ManagerId);

        builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.CreatorId).IsRequired();
        builder.Property(x => x.TimeDelete).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.CreateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
    }
}
