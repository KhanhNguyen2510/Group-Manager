using GM.API.Models.Ncs;

namespace GM.API.Areas.Nco.Controllers
{
    public class NcController : ApiBaseController 
        // xem thông tin nc của  nco hiện tại - không có quyền tạo nc chỉ có admin
    {
        private readonly INcService _ncService;
        public NcController(INcService ncService)
        {
            _ncService = ncService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Hiển thị danh sách NC")]
        public async Task<ApiResponse> Ncs([FromQuery] GetNCsModel request)
        {
            var gNc = await _ncService.Ncs(CurrentUserId,request);
            return gNc;
        }

        [HttpGet("{ncId}")]
        [SwaggerOperation(Summary = "Hiển thị Nc theo mã")]
        public async Task<ApiResponse> NcById(int ncId)
        {
            var gNc = await _ncService.NcById(ncId);
            return gNc;
        }
    }
}
