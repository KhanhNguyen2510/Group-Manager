using GM.Data.EFs;

namespace GM.Data.Repositories;

public interface IUserRepository : IDataRepository<User>
{
}

public class UserRepository : DataRepository<User>, IUserRepository
{
    public UserRepository(GMDbContext context) : base(context)
    {
    }
}