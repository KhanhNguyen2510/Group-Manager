global using GM.API.Models;
using GM.API.Models.HealthInformations;

namespace GM.API.Areas.Admin.Controllers;

public class HealthInformationController : ApiBaseController
{
    private readonly IHealthInformationService _healthInformationService;
    public HealthInformationController(IHealthInformationService healthInformationService)
    {
        _healthInformationService = healthInformationService;
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
