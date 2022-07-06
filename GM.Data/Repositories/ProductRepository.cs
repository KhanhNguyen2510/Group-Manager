namespace GM.Data.Repositories;


public interface IProductRepository : IDataRepository<Product>
{
}

public class ProductRepository : DataRepository<Product>, IProductRepository
{
    public ProductRepository(GMDbContext context) : base(context)
    {
    }
}

