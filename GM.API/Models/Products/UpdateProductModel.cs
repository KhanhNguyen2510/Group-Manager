namespace GM.API.Models.Products;

public class UpdateProductModel
{
    public string name { get; set; }
    public decimal? price { set; get; }
    public string note { get; set; }
}
