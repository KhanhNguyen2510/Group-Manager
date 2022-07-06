namespace GM.Data.Repositories;

public interface IHealthInformationRepository : IDataRepository<HealthInformation>
{
}

public class HealthInformationRepository : DataRepository<HealthInformation>, IHealthInformationRepository
{
    public HealthInformationRepository(GMDbContext context) : base(context)
    {
    }
}