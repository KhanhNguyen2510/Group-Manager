namespace GM.Data.Repositories;

public interface IEventRepository : IDataRepository<Event>
{
}

public class EventRepository : DataRepository<Event>, IEventRepository
{
    public EventRepository(GMDbContext context) : base(context)
    {
    }
}
