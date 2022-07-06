using GM.API.Models.HealthInformations;

namespace GM.API.Areas.Nco.Controllers;

public class HealthInformationController : ApiBaseController
{
    private readonly IHealthInformationService _healthInformationService;
    public HealthInformationController(IHealthInformationService healthInformationService)
    {
        _healthInformationService = healthInformationService;
    }


    [HttpPost]
    [SwaggerOperation(Summary = "Thêm thông tin sức khỏe")]
    public async Task<ApiResponse> Create(int nccId,[FromBody] CreateHealInformationModel request)
    {
        var gHealth = await _healthInformationService.Create(CurrentUserId, nccId,request);
        return gHealth;
    }

    [HttpPatch("{healthInformationId}")]
    [SwaggerOperation(Summary = "Cập nhật thông tin sức khỏe")]
    public async Task<ApiResponse> Update(int healthInformationId, [FromBody]UpdateHealInformationModel request)
    {
        var gHealth = await _healthInformationService.Update(CurrentUserId,healthInformationId ,  request);
        return gHealth;
    }

    [HttpDelete("{healthInformationId}")]
    [SwaggerOperation(Summary = "Xóa thông tin sức khỏe")]
    public async Task<ApiResponse> Delete(int healthInformationId)
    {
        var gHealth = await _healthInformationService.Delete(CurrentUserId,healthInformationId );
        return gHealth;
    }

    [HttpGet("{healthInformationId}")]
    [SwaggerOperation(Summary = "Hiển thị thông tin sức khỏe theo mã")]
    public async Task<ApiResponse> GetHealthInformationById(int healthInformationId)
    {
        var gHealth = await _healthInformationService.GetHealthInformationById(CurrentUserId,healthInformationId);
        return gHealth;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Hiển thị danh sách thông tin sức khỏe")]
    public async Task<ApiResponse> GetHealthInformation([FromQuery]GetHealthInformationModel request)
    {
        var gHealth = await _healthInformationService.GetHealthInformation(CurrentUserId, request);
        return gHealth;
    }
}
