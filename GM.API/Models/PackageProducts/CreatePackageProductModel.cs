namespace GM.API.Models.PackageProducts;

public class CreatePackageProductModel
{
    [Required(ErrorMessage = "Nhập tên gói sản phẩm")]
    public string name { get; set; }
    public string note { get; set; }
    [Required(ErrorMessage = "Nhập thời hạn")]
    public int duration { get; set; }
    //[Required(ErrorMessage = "Nhập giá gói sản phẩm")]
    //public decimal Price { get; set; }
    //[Required(ErrorMessage = "Nhập ngày bắt đầu")]
    //public DateTime startDate { get; set; }
    //public DateTime? endDate { get; set; }

    public List<Products> products { get; set; }
}
public class Products
{
    public int productId { get; set; }
    public int quantity { get; set; }
}
