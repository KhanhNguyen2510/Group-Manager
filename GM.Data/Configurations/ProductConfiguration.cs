namespace GM.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Name).IsUnicode().IsRequired();
        builder.Property(x => x.Price).HasPrecision(18,3).IsRequired();
        builder.Property(x => x.Note).IsRequired(false);
        builder.Property(x => x.ManagerId).IsRequired();
        //builder.HasOne(x => x.User).WithMany(x => x.Products).HasForeignKey(x => x.ManagerId);

        builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.CreatorId).IsRequired();
        builder.Property(x => x.TimeDelete).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.CreateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
    }
}
