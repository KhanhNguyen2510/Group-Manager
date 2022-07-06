namespace GM.API.Models.Challenges;

public class GetChallengesModel : QueryParameter
{
    public string keyWord { get; set; }
    public DateTime? startDate { get; set; }
    public DateTime? endDate { get; set; }
    /// <summary>
    /// nco
    /// </summary>
    public int? managerId { get; set; }
}
