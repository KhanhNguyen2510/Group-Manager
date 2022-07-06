using GM.API.Models.Challenges;

namespace GM.API.Areas.Nco.Controllers;

public class ChallengeController : ApiBaseController
{
    private readonly IChallengeService _challengeService;

    public ChallengeController(IChallengeService challengeService)
    {
        _challengeService = challengeService;
    }
    #region Challenge

    [HttpGet("{challengerId}/user-play-challegers")]
    [SwaggerOperation(Summary = "Hiển thị danh sách người tham gia thử thách")]
    public async Task<ApiResponse> GetUserPlayChallengersAsync(int challengerId)
    {
        var gChallenge = await _challengeService.GetUserPlayChallengersAsync(CurrentUserId,challengerId);
        return gChallenge;
    }



    [HttpGet]
    [SwaggerOperation(Summary = "Hiển thị danh sách thử thách")]
    public async Task<ApiResponse> Challenges([FromQuery] GetChallengesModel request)
    {
        var gChallenge = await _challengeService.Challenges(CurrentUserId, request);
        return gChallenge;
    }

    [HttpGet("{challengeId}")]
    [SwaggerOperation(Summary = "Hiển thị thử thách theo mã")]
    public async Task<ApiResponse> ChallengerById(int challengeId)
    {
        var gChallenge = await _challengeService.ChallengerById(CurrentUserId ,challengeId);
        return gChallenge;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Thêm thử thách")]
    public async Task<ApiResponse> Create([FromBody] CreateChallengeModel request)
    {
        var gChallenge = await _challengeService.Create(CurrentUserId, request);
        return gChallenge;
    }


    [HttpPatch("{challengeId}")]
    [SwaggerOperation(Summary = "Cập nhật thử thách")]
    public async Task<ApiResponse> Update(int challengeId, [FromBody] UpdateChallengeModel request)
    {
        var gChallenge = await _challengeService.Update(CurrentUserId,challengeId, request);
        return gChallenge;
    }

    [HttpDelete("{challengeId}")]
    [SwaggerOperation(Summary = "Xóa thử thách")]
    public async Task<ApiResponse> Delete(int challengeId)
    {
        var gChallenge = await _challengeService.Delete(CurrentUserId,challengeId);
        return gChallenge;
    }
    #endregion

    #region UsePlayChallenge

    [HttpGet("{challengeId}/users/{nccId}")]
    [SwaggerOperation(Summary = "Hiển thị người tham gia thử thách theo mã thử thách")]
    public async Task<ApiResponse> UserPlayChallengerById(int challengeId, int nccId)
    {
        var gUsePlayChallenge = await _challengeService.UserPlayChallengerById(CurrentUserId,challengeId, nccId);
        return gUsePlayChallenge;
    }

    [HttpPost("{challengeId}/users")]
    [SwaggerOperation(Summary = "Tạo người tham gia thử thách")]
    public async Task<ApiResponse> CreatePlayChallenge(int challengeId, int nccId,[FromBody] CreateUserPlayChallegeModel request)
    {
        var gUsePlayChallenge = await _challengeService.CreateUserChallenge(CurrentUserId, challengeId, nccId,request);
        return gUsePlayChallenge;
    }

    [HttpPatch("{challengeId}/users/{nccId}")]
    [SwaggerOperation(Summary = "Cập nhật người tham gia thử thách")]
    public async Task<ApiResponse> UpdatePlayChallenge(int challengeId, int nccId, [FromBody] UpdateUserPlayChallengeModel request)
    {
        var gUsePlayChallenge = await _challengeService.UpdatePlayChallenge((int)CurrentUserId,challengeId, nccId,  request);
        return gUsePlayChallenge;
    }

    [HttpDelete("{challengeId}/users/{nccId}")]
    [SwaggerOperation(Summary = "Xóa người tham gia thử thách")]
    public async Task<ApiResponse> DeletePlayChallenge(int challengeId, int nccId)
    {
        var gUsePlayChallenge = await _challengeService.DeletePlayChallenge((int)CurrentUserId,challengeId, nccId);
        return gUsePlayChallenge;
    }
    #endregion
}
