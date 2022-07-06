namespace GM.API.Models.PackageProducts;

public class CreatePackageProductDetailModel
{
    [Required(ErrorMessage = "Nhập mả sản phẩm")]
    public int productId { get; set; }
    [Required(ErrorMessage = "Nhập số lượng")]
    public int quantity { get; set; } = 0;
}
