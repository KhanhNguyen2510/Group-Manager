namespace GM.API.Models.Products;

public class GetProductsModel : QueryParameter
{
    public string keyword { get; set; }
    //public int id { get; set; }
    //public string name { get; set; }
    public decimal? price { set; get; }
    //public string note { get; set; }
    //public int? managerId { get; set; }
}
