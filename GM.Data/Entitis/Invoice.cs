namespace GM.Data.Entitis;

public class Invoice : Entity
{
    public int Id { get; set; }
    public int NccId { get; set; }
    public int NcId { get; set; }
    public int? PackageProductId { get; set; }
    public decimal TotalAmount { set; get; } = 0;
    /// <summary>
    /// Số lượng còn lại
    /// </summary>
    public int Remain { get; set; } = 0;
    /// <summary>
    /// Trang thái Hoàn thành / Chưa hoàn thành
    /// </summary>
    public Status Status { get; set; }  = Status.UnFinished;
    /// <summary>
    /// Thời hạn
    /// </summary>
    public int Duration { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public NCC Ncc { get; set; }
    public PackageProduct PackageProduct { get; set; }
    public IEnumerable<InvoiceDetail> InvoiceDetails { get; set; }
    public IEnumerable<CheckIn> CheckIns { get; set; }
}
public enum Status
{
    UnFinished,
    Finished
}
