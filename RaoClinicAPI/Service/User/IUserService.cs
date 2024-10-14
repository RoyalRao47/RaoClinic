using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RaoClinicAPI.Database;
using RaoClinicAPI.DbTable;
using RaoClinicAPI.Service;
using RaoClinicAPI.Model;

namespace RaoClinicAPI.Service
{
    public class UserService : IUserService
    {
        private bool disposedValue = false;
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }
        public User CheckLoginUser(LoginModel model)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email.ToLower() == model.Username  && x.Password == model.Password) ?? null;
            return user;
        }
        public List<User> GetUserList()
        {
            var userList = _context.Users.ToList();
            return userList;
        }

        public User GetUserById(int UserId)
        {
            var userList = GetUserList();
            var user = userList.FirstOrDefault(x => x.UserID == UserId);
            return user;
        }

        public void SaveUser(User user)
        {
            if (user.UserID > 0)
            {
                var existingUser = _context.Users.FirstOrDefault(i => i.UserID == user.UserID);
                if (existingUser != null)
                {
                    existingUser.Name = user.Name;
                    existingUser.Password = user.Password;
                    existingUser.Email = user.Email;
                    existingUser.MobileNo = user.MobileNo;
                    existingUser.UpdatedAt = DateTime.Now;
                    _context.Entry(existingUser).State = EntityState.Modified;
                    _context.SaveChangesAsync();
                }
            }
            else
            {
                user.CreatedAt = DateTime.Now;
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}