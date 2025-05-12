namespace Club.Infrastructure.Models;

public class Member
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime JoinDate { get; set; }
}