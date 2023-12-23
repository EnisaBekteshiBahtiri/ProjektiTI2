using Microsoft.AspNetCore.Identity;

namespace ProjektiTI2.Data.Identity;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
}

