namespace GM.API.Models.Challenges
{
    public class DeleteUserPlayChallengModel
    {
        /// <summary>
        /// nco
        /// </summary>
        [Required(ErrorMessage = "Nhập người quản lý")]
        public int ManagerId { get; set; }
    }
}
