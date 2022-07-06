namespace GM.Data.Entitis;

public class PackageProductDetail : Entity
{
    public int Id { get; set; }
    public int PackageProductId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public PackageProduct PackageProduct { get; set; }
    public Product Product { get; set; }
}
