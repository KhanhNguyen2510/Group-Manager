namespace GM.Data.Repositories;

public interface IPackageProductDetailRepository : IDataRepository<PackageProductDetail>
{
}
public class PackageProductDetailRepository : DataRepository<PackageProductDetail>, IPackageProductDetailRepository
{
    public PackageProductDetailRepository(GMDbContext context) : base(context)
    {
    }
}

