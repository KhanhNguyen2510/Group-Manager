namespace GM.Data.Entitis;

public class CheckIn : Entity
{
    public int Id { get; set; }
    /// <summary>
    /// Hóa đơn ID
    /// </summary>
    public int InvoiceId { get; set; }
    public int NcId { get; set; }
    /// <summary>
    /// Khoản thời gian nào trong ngày
    /// </summary>
    public DateTime TimeOfDay { get; set; }
    /// <summary>
    /// Số còn lại
    /// </summary>
    public int Remain { get; set; }
    //[Column(TypeName = "Money")]
    ////public decimal Price { set; get; }
    /// <summary>
    /// Thời hạn
    /// </summary>
    public int Duration { get; set; }

    public string Note { get; set; }
    /// <summary>
    /// Buổi trong ngày
    /// </summary>
    public Session Session { get; set; }

    public Invoice Invoice { get; set; }

}
public enum Session
{
    Morning,
    Noon,
    Afternoon,
    Night
}
