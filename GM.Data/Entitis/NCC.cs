namespace GM.Data.Entitis;

public class NCC : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDay { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    /// <summary>
    /// nc
    /// </summary>
    public int ManagerId { get; set; }

    public IEnumerable<HealthInformation> HealthInformations { get; set; }
    public IEnumerable<Invoice> Invoices { get; set; }
    public NC Nc { get; set; }
}
