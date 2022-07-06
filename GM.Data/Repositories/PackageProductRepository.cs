namespace GM.Data.Repositories;

public interface IPackageProductRepository : IDataRepository<PackageProduct>
{
}
public class PackageProductRepository : DataRepository<PackageProduct>, IPackageProductRepository
{
    public PackageProductRepository(GMDbContext context) : base(context)
    {
    }
}

