namespace GM.API.Models.PackageProducts;

public class DeletePackageProductDetailModel
{
    [Required(ErrorMessage = "Nhập mã người quản lý")]
    public int ManagerId { get; set; }
}
