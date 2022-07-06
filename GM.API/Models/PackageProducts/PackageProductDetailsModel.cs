namespace GM.API.Models.PackageProducts;

public class PackageProductDetailsModel : QueryParameter
{
    public int? productId { get; set; }
    public int? packageproductId { get; set; }
    public int? managerId { get; set; }
}
