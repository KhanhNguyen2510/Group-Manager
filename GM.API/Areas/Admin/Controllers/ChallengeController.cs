using GM.API.Models.Challenges;

namespace GM.API.Areas.Admin.Controllers
{
    public class ChallengeController : ApiBaseController
    {
        private readonly IChallengeService _challengeService;

        public ChallengeController(IChallengeService challengeService)
        {
            _challengeService = challengeService;
        }

        [HttpGet("{challengerId}/user-play-challegers")]
        [SwaggerOperation(Summary = "Hiển thị danh sách người tham gia thử thách")]
        public async Task<ApiResponse> GetUserPlayChallengersAsync(int challengerId)
        {
            var gChallenge = await _challengeService.GetUserPlayChallengersAsync(CurrentUserId, challengerId);
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
            var gChallenge = await _challengeService.ChallengerById(CurrentUserId, challengeId);
            return gChallenge;
        }
    }
}
