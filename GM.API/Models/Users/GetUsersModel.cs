namespace GM.API.Models.Users;

public class GetUsersModel : QueryParameter
{
    /// <summary>
    /// fullname, usename, numbephon
    /// </summary>
    public string keyWord { get; set; }
    //public string fullname { get; set; }
    //public string username { get; set; }
    //public string numberphone { get; set; }
    public UserRole? userRole { get; set; }
}
