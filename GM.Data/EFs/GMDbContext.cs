using GM.Data.Configurations;

namespace GM.Data.EFs;

public class GMDbContext : DbContext
{
    public GMDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Challenge> Challenges { get; set; }
    public DbSet<CheckIn> CheckIns { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<HealthInformation> HealthInformation { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    public DbSet<NC> NCs { get; set; }
    public DbSet<NCC> NCCs { get; set; }
    public DbSet<PackageProduct> PackageProducts { get; set; }
    public DbSet<PackageProductDetail> PackageProductDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserPlayChallenge> UserPlayChallenges { get; set; }
    public DbSet<UserPlayEvent> UserPlayEvents { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ChallengeConfiguration());
        modelBuilder.ApplyConfiguration(new CheckInConfiguration());
        modelBuilder.ApplyConfiguration(new EventConfiguration());
        modelBuilder.ApplyConfiguration(new HealthInformationConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceDetailConfiguration());
        modelBuilder.ApplyConfiguration(new NCCConfiguration());
        modelBuilder.ApplyConfiguration(new NCConfiguration());
        modelBuilder.ApplyConfiguration(new PackageProductConfiguration());
        modelBuilder.ApplyConfiguration(new PackageProductDetailConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserPlayChallengeConfiguration());
        modelBuilder.ApplyConfiguration(new UserPlayEventConfiguration());
    }
}
