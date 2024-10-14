using RaoClinicAPI.DbTable;
using RaoClinicAPI.Model;

namespace RaoClinicAPI.Service
{
    public interface IUserService : IDisposable
    {
        User CheckLoginUser(LoginModel model);
        List<User> GetUserList();
        User GetUserById(int UserId);
        void SaveUser(User user);
       
    }
}