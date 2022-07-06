global using GM.Data.EFs;

namespace GM.Data.Repositories;

public interface IChallengeRepository : IDataRepository<Challenge>
{
}

public class ChallengeRepository : DataRepository<Challenge>, IChallengeRepository
{
    public ChallengeRepository(GMDbContext context) : base(context)
    {
    }
}
