namespace GM.API.Models.Ncs;

public class CreateNcModel
{
    [Required(ErrorMessage = "Nhập tên NC")]
    public string name { get; set; }
    public string note { get; set; }
}
