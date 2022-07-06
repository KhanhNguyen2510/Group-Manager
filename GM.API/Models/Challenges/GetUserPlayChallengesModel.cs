global using GM.API.Models.Common;
global using GM.Data.Entitis;

namespace GM.API.Models.Challenges;

public class GetUserPlayChallengesModel : QueryParameter
{
    public int? nccId { get; set; }
    public Complete? complete { get; set; }
    public int? managerId { get; set; }
}
