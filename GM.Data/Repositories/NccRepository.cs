namespace GM.Data.Repositories;

public interface INccRepository : IDataRepository<NCC>
{
}

public class NccRepository : DataRepository<NCC>, INccRepository
{
    public NccRepository(GMDbContext context) : base(context)
    {
    }
}

