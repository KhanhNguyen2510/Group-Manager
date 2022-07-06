namespace GM.Data.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Event");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsUnicode().IsRequired();
        builder.Property(x => x.Content).IsUnicode().IsRequired(false);
        builder.Property(x => x.StartDate).HasColumnType("datetime").IsRequired();
        builder.Property(x => x.EndDate).HasColumnType("datetime").IsRequired();
        builder.Property(x => x.ManagerId).IsRequired();
        //builder.HasOne(x => x.User).WithMany(x => x.Events).HasForeignKey(x => x.ManagerId);


        builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.CreatorId).IsRequired();
        builder.Property(x => x.TimeDelete).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.CreateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
    }
}
