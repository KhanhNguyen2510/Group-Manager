namespace GM.Data.Entitis;

public class Event : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    /// <summary>
    /// Nco
    /// </summary>
    public int ManagerId { get; set; }

    public User User { get; set; }
    public IEnumerable<UserPlayEvent> UserPlayEvents { get; set; }
}
