namespace GM.API.Models.Events;

public class UpdateEventModel
{
    public string name { get; set; }
    public string content { get; set; }
    public DateTime? startDate { get; set; }
    public DateTime? endDate { get; set; }
}
