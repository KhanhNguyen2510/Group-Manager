namespace GM.Data.Configurations;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoice");
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.NccId).IsRequired();
        builder.Property(x => x.PackageProductId).IsRequired(false);
        builder.Property(x => x.TotalAmount).HasPrecision(18,3);
        builder.Property(x => x.Remain).HasDefaultValue(0).IsRequired();
        builder.Property(x => x.Status).HasDefaultValue(Status.UnFinished).IsRequired();
        builder.Property(x => x.Duration).IsRequired();
        builder.Property(x => x.NcId).IsRequired();
        builder.Property(x => x.StartDate).HasColumnType("datetime").IsRequired();
        builder.Property(x => x.EndDate).HasColumnType("datetime").IsRequired();
        //builder.HasOne(x => x.NCC).WithMany(x => x.Invoices).HasForeignKey(x => x.NccId);
        //builder.HasOne(x => x.PackageProduct).WithMany(x => x.Invoices).HasForeignKey(x => x.PackageProductId);


        builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.CreatorId).IsRequired();
        builder.Property(x => x.TimeDelete).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.CreateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
    }
}
