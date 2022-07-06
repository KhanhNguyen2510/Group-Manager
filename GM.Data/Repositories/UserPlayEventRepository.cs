namespace GM.Data.Repositories;

public interface IUserPlayEventRepository : IDataRepository<UserPlayEvent>
{
}

public class UserPlayEventRepository : DataRepository<UserPlayEvent>, IUserPlayEventRepository
{
    public UserPlayEventRepository(GMDbContext context) : base(context)
    {
    }
}
