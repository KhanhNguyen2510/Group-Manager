namespace GM.Data.Configurations;

public class UserPlayChallengeConfiguration : IEntityTypeConfiguration<UserPlayChallenge>
{
    public void Configure(EntityTypeBuilder<UserPlayChallenge> builder)
    {
        builder.ToTable("UserPlayChallenge");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.ChallengerId).IsRequired();
        builder.Property(x => x.NccId).IsRequired();
        builder.Property(x => x.Complete).HasDefaultValue(Complete.Wait).IsRequired();
        builder.Property(x => x.Note).IsRequired(false);
        //builder.HasOne(x => x.Challenge).WithMany(x => x.UserPlayChallenge).HasForeignKey(x => x.ChallengeId);
        //builder.HasOne(x => x.NCCs).WithMany(x => x.UserPlayChallenges).HasForeignKey(x => x.NccId);


        builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.CreatorId).IsRequired();
        builder.Property(x => x.TimeDelete).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.CreateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
    }
}    
