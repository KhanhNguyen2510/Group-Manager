namespace GM.Data.Configurations;

public class PackageProductConfiguration : IEntityTypeConfiguration<PackageProduct>
{
    public void Configure(EntityTypeBuilder<PackageProduct> builder)
    {
        builder.ToTable("PackageProduct");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Name).IsUnicode().IsRequired();
        builder.Property(x => x.Note).IsRequired(false);
        builder.Property(x => x.TotalAmount).HasPrecision(18,3).IsRequired();
        builder.Property(x => x.Duration).IsRequired();
        builder.Property(x => x.StartDate).HasColumnType("datetime").IsRequired();
        builder.Property(x => x.EndDate).HasColumnType("datetime").IsRequired();

        builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.CreatorId).IsRequired();
        builder.Property(x => x.TimeDelete).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.CreateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
    }
}
