namespace GM.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Fullname).IsUnicode().IsRequired(false);
        builder.Property(x => x.PhoneNumber).IsUnicode(false).IsRequired(false);
        builder.Property(x => x.Email).IsUnicode().IsRequired(false);
        builder.Property(x => x.Username).IsRequired();
        builder.Property(x => x.Password).IsRequired(false);
        builder.Property(x => x.AccessToken).IsRequired(false);
        builder.Property(x => x.RefreshToken).IsRequired(false);
        builder.Property(x => x.Role).IsRequired();

        builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.CreatorId).IsRequired();
        builder.Property(x => x.TimeDelete).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.CreateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
    }
}
