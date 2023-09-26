
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string fullName { get; set; }
    public DateTime birthDay { get; set; }
}
