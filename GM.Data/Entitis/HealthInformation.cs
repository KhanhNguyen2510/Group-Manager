namespace GM.Data.Entitis;

public class HealthInformation : Entity
{
    public int Id { get; set; }
    public int NccId { get; set; }
    public DateTime TimeOfDay { get; set; } = DateTime.Now;
    public float Height { get; set; }
    public float Weight { get; set; }
    public float Slush { get; set; }

    public User User { get; set; }
    public NCC Ncc { get; set; }
}
