using GM.API.Models.PackageProducts;

namespace GM.API.Areas.Nco.Controllers;

public class PackageProductController : ApiBaseController
{
    private readonly IPackageProductService _packageProductService;
    public PackageProductController(IPackageProductService packageProductService)
    {
        _packageProductService = packageProductService;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Tạo gói dinh dưỡng")]
    public async Task<ApiResponse> Create([FromBody] CreatePackageProductModel request)
    {
        var gPackageProduct = await _packageProductService.Create((int)CurrentUserId, request);
        return gPackageProduct;
    }

    [HttpPatch("{packageProductId}")]
    [SwaggerOperation(Summary = "Cập nhật gói dinh dưỡng")]
    public async Task<ApiResponse> Update(int packageProductId, [FromBody] UpdatePackageProductModel request)
    {
        var gPackageProduct = await _packageProductService.Update(CurrentUserId,packageProductId,request);
        return gPackageProduct;
    }

    [HttpDelete("{packageProductId}")]
    [SwaggerOperation(Summary = "Xóa gói dinh dưỡng")]
    public async Task<ApiResponse> Delete(int packageProductId)
    {
        var gPackageProduct = await _packageProductService.Delete((int)CurrentUserId,packageProductId);
        return gPackageProduct;
    }

    [HttpGet("{packageProductId}")]
    [SwaggerOperation(Summary = "Xem gói dinh dưỡng theo mã")]
    public async Task<ApiResponse> PackageProductById(int packageProductId)
    {
        var gPackageProduct = await _packageProductService.PackageProductById((int)CurrentUserId,packageProductId);
        return gPackageProduct;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Xem danh sách dinh dưỡng")]
    public async Task<ApiResponse> PackageProducts([FromQuery] GetPackageProductsModel request)
    {
        var gPackageProduct = await _packageProductService.PackageProducts((int)CurrentUserId, request);
        return gPackageProduct;
    }

    [HttpPost("{packageProductId}")]
    [SwaggerOperation(Summary = "Tạo chi tiết gói dinh dưỡng")]
    public async Task<ApiResponse> CreateDetail(int packageProductId, [FromBody] CreatePackageProductDetailModel request)
    {
        var gPackageProduct = await _packageProductService.CreateDetail((int)CurrentUserId,packageProductId,  request);
        return gPackageProduct;
    }

    [HttpPatch("{packageProductId}/products/{productId}")]
    [SwaggerOperation(Summary = "Cập nhật chi tiết gói dinh dưỡng")]
    public async Task<ApiResponse> UpdateDetail(int packageProductId, int productId, [FromBody] UpdatePackageProductDetailModel request)
    {
        var gPackageProduct = await _packageProductService.UpdateDetail((int)CurrentUserId,packageProductId, productId,  request);
        return gPackageProduct;
    }

    [HttpDelete("{packageProductId}/products/{productId}")]
    [SwaggerOperation(Summary = "Xóa gói dinh dưỡng")]
    public async Task<ApiResponse> DeleteDetail(int packageProductId, int productId)
    {
        var gPackageProduct = await _packageProductService.DeleteDetail((int)CurrentUserId,packageProductId, productId);
        return gPackageProduct;
    }

    [HttpGet("{packageProductId}/products/{productId}")]
    [SwaggerOperation(Summary = "Xem chi tiết gói dinh dưỡng theo mã")]
    public async Task<ApiResponse> PackageProductDetailById(int packageProductId, int productId)
    {
        var gPackageProduct = await _packageProductService.PackageProductDetailById((int)CurrentUserId,packageProductId, productId);
        return gPackageProduct;
    }

    [HttpGet("{packageProductId}/products")]
    [SwaggerOperation(Summary = "Xem danh sách gói dinh dưỡng")]
    public async Task<ApiResponse> PackageProductDetails(int packageProductId,[FromQuery] PackageProductDetailsModel request)
    {
        var gPackageProduct = await _packageProductService.PackageProductDetails((int)CurrentUserId,packageProductId,request);
        return gPackageProduct;
    }
}
