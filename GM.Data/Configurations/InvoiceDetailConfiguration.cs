namespace GM.Data.Configurations;

public class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
{
    public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
    {
        builder.ToTable("InvoiceDetail");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.InvoiceId).IsRequired();
        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.Price).HasPrecision(18,3).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        //builder.HasOne(x => x.Product).WithMany(x => x.InvoiceDetails).HasForeignKey(x => x.ProductId);
        //builder.HasOne(x => x.Invoice).WithMany(x => x.InvoiceDetails).HasForeignKey(x => x.InvoiceId);


        builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.CreatorId).IsRequired();
        builder.Property(x => x.TimeDelete).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.CreateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
    }
}
