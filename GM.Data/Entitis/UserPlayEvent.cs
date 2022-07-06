namespace GM.Data.Entitis;

public class UserPlayEvent : Entity
{
    public int Id { get; set; }
    public int NccId { get; set; }
    public int EventId { get; set; }
    public string Note { get; set; }
    public Complete Complete { get; set; }

    public NCC Ncc { get; set; }
    public Event Event { get; set; }
}
