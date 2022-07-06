namespace GM.API.Models.Events;

public class GetUserPlayEventsModel : QueryParameter
{
    public int? nccId { get; set; }
    public Complete? complete { get; set; }
    public int? managerId { get; set; }
}
