using ELDocClinic.Models;
using ELDocClinic.ViewModels;

namespace ELDocClinic.Services.JWT
{
    public interface IJwtService
    {
        public AuthenticationResponseVM CreateToken(ApplicationUser user);

    }
}
