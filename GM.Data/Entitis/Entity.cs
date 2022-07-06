namespace GM.Data.Entitis;

public class Entity
{
    public int? CreatorId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? TimeDelete { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime UpdateDate { get; set; } = DateTime.Now;
}
