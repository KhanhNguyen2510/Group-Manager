namespace GM.Data.Repositories;

public interface ICheckInRepository : IDataRepository<CheckIn>
{
}

public class CheckInRepository : DataRepository<CheckIn>, ICheckInRepository
{
    public CheckInRepository(GMDbContext context) : base(context)
    {
    }
}