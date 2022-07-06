namespace GM.Data.Entitis;

public class PackageProduct : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Note { get; set; }
    public decimal TotalAmount { set; get; } = 0;
    public int Duration { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }


    public IEnumerable<Invoice> Invoices { get; set; }
    public IEnumerable<PackageProductDetail> PackageProductDetails { get; set; }
}
