using GM.API.Models.Products;

namespace GM.API.Areas.Nco.Controllers
{
    public class ProductController : ApiBaseController // chỉ được xem không có quyền tạo
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
            var gProduct = await _productService.Products( request);
            return gProduct;
        }

        [HttpGet("{productId}")]
        [SwaggerOperation(Summary = "Hiển thị sản phẩm theo mã")]
        public async Task<ApiResponse> ProductById(int productId)
        {
            var gProduct = await _productService.ProductById(productId);
            return gProduct;
        }
    }
}
