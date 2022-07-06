using GM.API.Models.Products;

namespace GM.API.Areas.Admin.Controllers
{
    public class ProductController : ApiBaseController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Hiển thị danh sách sản phẩm")]
        public async Task<ApiResponse> Products([FromQuery]GetProductsModel request)
        {
            var gProduct = await _productService.Products(request);
            return gProduct;
        }

        [HttpGet("{productId}")]
        [SwaggerOperation(Summary = "Hiển thị sản phẩm theo mã")]
        public async Task<ApiResponse> ProductById(int productId)
        {
            var gProduct = await _productService.ProductById(productId);
            return gProduct;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Tạo sản phẩm")]
        public async Task<ApiResponse> Create([FromBody]CreateProductModel request)
        {
            var gProduct = await _productService.Create(CurrentUserId,request);
            return gProduct;
        }

        [HttpPatch("{productId}")]
        [SwaggerOperation(Summary = "Cập nhật sản phẩm")]
        public async Task<ApiResponse> Update(int productId, [FromBody]UpdateProductModel request)
        {
            var gProduct = await _productService.Update(productId, request);
            return gProduct;
        }
 
        [HttpDelete("{productId}")]
        [SwaggerOperation(Summary = "Xóa sản phẩm")]
        public async Task<ApiResponse> Delete(int productId)
        {
            var gProduct = await _productService.Delete(productId);
            return gProduct;
        }
    }
}
