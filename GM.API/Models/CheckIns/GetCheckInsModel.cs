namespace GM.API.Models.CheckIns;

public class GetCheckInsModel : QueryParameter
{
    public int? invoiceId { get; set; }
    public int? remain { get; set; }
    public Session? session { get; set; }
    public int? managerId { get; set; }
}
