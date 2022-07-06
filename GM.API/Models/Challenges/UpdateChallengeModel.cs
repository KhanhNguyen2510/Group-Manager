namespace GM.API.Models.Challenges;

public class UpdateChallengeModel
{
    public string name { get; set; }
    public string content { get; set; }
    public DateTime? startDate { get; set; }
    public DateTime? endDate { get; set; }
}
