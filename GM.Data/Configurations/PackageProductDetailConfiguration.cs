namespace GM.Data.Configurations;

public class PackageProductDetailConfiguration : IEntityTypeConfiguration<PackageProductDetail>
{
    public void Configure(EntityTypeBuilder<PackageProductDetail> builder)
    {
        builder.ToTable("PackageProductDetail");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.PackageProductId).IsRequired();
        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        //builder.HasOne(x => x.PackageProduct).WithMany(x => x.PackageProductDetails).HasForeignKey(x => x.PackageProductId);
        //builder.HasOne(x => x.Product).WithMany(x => x.PackageProductDetails).HasForeignKey(x => x.ProductId);

        builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.CreatorId).IsRequired();
        builder.Property(x => x.TimeDelete).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.CreateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
    }
}
