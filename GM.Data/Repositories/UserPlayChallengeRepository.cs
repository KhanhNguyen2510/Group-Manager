namespace GM.Data.Repositories;

public interface IUserPlayChallengeRepository :IDataRepository<UserPlayChallenge>
{
    
}
public class UserPlayChallengeRepository : DataRepository<UserPlayChallenge>, IUserPlayChallengeRepository
{
    public UserPlayChallengeRepository(GMDbContext context) : base(context)
    {
    }

}
