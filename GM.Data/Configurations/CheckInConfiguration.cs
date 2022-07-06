namespace GM.Data.Configurations;

public class CheckInConfiguration : IEntityTypeConfiguration<CheckIn>
{
    public void Configure(EntityTypeBuilder<CheckIn> builder)
    {
        builder.ToTable("CheckIn");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.InvoiceId).IsRequired();
        builder.Property(x => x.TimeOfDay).IsRequired().HasColumnType("datetime");
        builder.Property(x => x.Remain).IsRequired();
        builder.Property(x => x.Duration).IsRequired();
        builder.Property(x => x.Session).IsRequired();
        builder.Property(x => x.Note).IsRequired(false);
        builder.Property(x => x.NcId).IsRequired();

        //builder.HasOne(x => x.Invoice).WithMany(x => x.CheckIns).HasForeignKey(x => x.InvoiceId);


        builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.CreatorId).IsRequired();
        builder.Property(x => x.TimeDelete).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.CreateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
    }
}

