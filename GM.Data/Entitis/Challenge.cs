namespace GM.Data.Entitis;

public class Challenge : Entity
{
    /// <summary>
    /// Id tạo thử thách
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Tên thử thách
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Nội dung thử thách
    /// </summary>
    public string Content { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    /// <summary>
    /// Nco
    /// </summary>
    public int ManagerId { get; set; }

    public User User { get; set; }
    public IEnumerable<UserPlayChallenge> UserPlayChallenges { get; set; }
}
