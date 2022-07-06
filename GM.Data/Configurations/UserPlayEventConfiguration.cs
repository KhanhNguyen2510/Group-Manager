namespace GM.Data.Configurations;

public class UserPlayEventConfiguration : IEntityTypeConfiguration<UserPlayEvent>
{
    public void Configure(EntityTypeBuilder<UserPlayEvent> builder)
    {
        builder.ToTable("UserPlayEvent");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.NccId).IsRequired();
        builder.Property(x => x.EventId).IsRequired();
        builder.Property(x => x.Note).IsRequired(false);
        builder.Property(x => x.Complete).HasDefaultValue(Complete.Wait).IsRequired();
        //builder.HasOne(x => x.Event).WithMany(x => x.UserPlayEvents).HasForeignKey(x => x.EventId);
        //builder.HasOne(x => x.NCCs).WithMany(x => x.UserPlayEvents).HasForeignKey(x => x.NccId);


        builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.CreatorId).IsRequired();
        builder.Property(x => x.TimeDelete).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.CreateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
    }
}
