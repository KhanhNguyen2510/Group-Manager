namespace GM.Data.Configurations;

public class NCCConfiguration : IEntityTypeConfiguration<NCC>
{
    public void Configure(EntityTypeBuilder<NCC> builder)
    {
        builder.ToTable("NCC");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Name).IsUnicode().IsRequired();
        builder.Property(x => x.BirthDay).HasColumnType("datetime").IsRequired();
        builder.Property(x => x.PhoneNumber).IsRequired(false);
        builder.Property(x => x.Address).IsRequired(false);
        builder.Property(x => x.ManagerId).IsRequired();
        //builder.HasOne(x => x.NCs).WithMany(x => x.NCCs).HasForeignKey(x => x.ManagerId);

        builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.CreatorId).IsRequired();
        builder.Property(x => x.TimeDelete).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.CreateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
    }
}
