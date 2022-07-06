namespace GM.Data.Entitis;

public class User : Entity
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public UserRole Role { get; set; }

    public IEnumerable<HealthInformation> HealthInformations { get; set; }
    public IEnumerable<Challenge> Challenges { get; set; }
    public IEnumerable<Event> Events { get; set; }
    public IEnumerable<NC> Ncs { get; set; }
    public IEnumerable<CheckIn> CheckIns { get; set; }
    public IEnumerable<Product> Products { get; set; }
}
public enum UserRole
{
    Nco = 1,
    Admin = 2
}
