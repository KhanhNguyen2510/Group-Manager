namespace GM.API.Models.HealthInformations;

public class GetHealthInformationModel : QueryParameter
{
    public int? nccId { get; set; }
    public int? creatorId { get; set; }
    public float? height { get; set; }
    public float? weight { get; set; }
    public float? slush { get; set; }
}
