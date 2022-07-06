namespace GM.API.Models.Events;

public class GetEventsModel : QueryParameter
{
    public string keyWord { get; set; }
    public DateTime? startDate { get; set; }

    public DateTime? endDate { get; set; }
    /// <summary>
    /// nco
    /// </summary>
    public int? managerId { get; set; }
}
