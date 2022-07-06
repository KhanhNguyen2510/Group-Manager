namespace GM.API.Models.Users;

public class UserQuery : QueryParameter
{
    public string Keyword { get; set; }
    //public string fullname { get; set; }
    //public string username { get; set; }
    //public string numberphone { get; set; }
    public UserRole? UserRole { get; set; }

}
