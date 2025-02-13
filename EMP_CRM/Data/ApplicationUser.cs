using Microsoft.AspNetCore.Identity;

namespace EMP_CRM.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
