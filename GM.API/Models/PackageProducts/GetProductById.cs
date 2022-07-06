namespace GM.API.Models.PackageProducts;

public class GetProductById
{
    public int PackageProductId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
