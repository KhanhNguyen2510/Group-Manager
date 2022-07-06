namespace GM.Data.Entitis;

public class UserPlayChallenge : Entity
{
    public int Id { get; set; }
    public int ChallengerId { get; set; }
    public int NccId { get; set; }
    public Complete Complete { get; set; } = Complete.Wait;
    public string Note { get; set; }
    
    public NCC Ncc { get; set; }
    public Challenge Challenge { get; set; }
}
public enum Complete
{
    Expires,
    Wait,
    InProcess,
    Done
}    
