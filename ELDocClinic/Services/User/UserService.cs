using ELDocClinic.Models;
using ELDocClinic.Respositories.Interfaces;

namespace ELDocClinic.Services.User
{
    public class UserService : IUserService
    {

        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ApplicationUser> GetAll()
        {
            List<ApplicationUser> Users = new List<ApplicationUser>();
            
            Users = _unitOfWork.Repository<ApplicationUser>().Get()
                .ToList();
            
            return Users;
        }


        public void AddUser(ApplicationUser user)
        {
            _unitOfWork.Repository<ApplicationUser>().Add(user);
            _unitOfWork.Save();
        }

        public void DeleteUser(int UserId)
        {
            ApplicationUser user = _unitOfWork.Repository<ApplicationUser>().GetById(UserId);
            _unitOfWork.Repository<ApplicationUser>().Delete(user);
            _unitOfWork.Save();
        }


        public ApplicationUser GetUserById(string UserId)
        {
            return _unitOfWork.Repository<ApplicationUser>().GetById(UserId);
        }

        public void UpdateUser(ApplicationUser User)
        {
            ApplicationUser user = _unitOfWork.Repository<ApplicationUser>().GetById(User.Id);
            user.UserName = User.UserName;
            user.Email = User.Email;
            user.PasswordHash = User.PasswordHash;
            _unitOfWork.Repository<ApplicationUser>().Update(user);
            _unitOfWork.Save();
        }

    }
}
