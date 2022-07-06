namespace GM.API.Models.Nccs;

public class GetNccModel : QueryParameter
{
    /// <summary>
    /// Name, phone, address
    /// </summary>
    public string keyWord { get; set; }
    public int? nccId { get; set; }
    /// <summary>
    /// nc
    /// </summary>
    public int? managerId { get; set; }
}
