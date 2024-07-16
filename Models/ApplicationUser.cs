using Microsoft.AspNetCore.Identity;

namespace UserAccessControl.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Adicione propriedades adicionais aqui
        public string FullName { get; set; }
    }
}
