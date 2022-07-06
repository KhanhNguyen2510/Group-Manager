namespace GM.Data.Entitis;

public class Product : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { set; get; } = 0;
    public string Note { get; set; }
    public int ManagerId { get; set; }

    public User User { get; set; }
    public IEnumerable<InvoiceDetail> InvoiceDetails { get; set; }
    public IEnumerable<PackageProductDetail> PackageProductDetails { get; set; }
}
