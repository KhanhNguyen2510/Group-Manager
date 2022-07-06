namespace GM.API.Models.Ncs;

public class GetNCsModel : QueryParameter
{
    public int? ncId { get; set; }
    /// <summary>
    /// Name, note
    /// </summary>
    public string keyWord { get; set; }
    public int? managerId { get; set; }
}
