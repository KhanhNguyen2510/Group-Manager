namespace GM.Data.Repositories;

public interface INcRepository : IDataRepository<NC>
{
}

public class NcRepository : DataRepository<NC>, INcRepository
{
    public NcRepository(GMDbContext context) : base(context)
    {
    }
}
