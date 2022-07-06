namespace GM.API.Models.Products;

public class CreateProductModel
{
    [Required(ErrorMessage = "Nhập tên sản phầm")]
    public string name { get; set; }
    [Required(ErrorMessage = "Nhập giá sản phầm")]
    public decimal price { set; get; }
    public string note { get; set; }
}
