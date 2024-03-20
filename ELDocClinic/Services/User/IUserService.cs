using ELDocClinic.Models;

namespace ELDocClinic.Services.User
{
    public interface IUserService
    {
        List<ApplicationUser> GetAll();

        void AddUser(ApplicationUser user);

        void DeleteUser(int UserId);

        ApplicationUser GetUserById(string UserId);

        void UpdateUser(ApplicationUser User);
    }
}
