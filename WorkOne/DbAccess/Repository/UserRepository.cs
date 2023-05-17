using Domain;
using Microsoft.EntityFrameworkCore;

namespace WorkOne.DbAccess.Repository
{

    public interface IUserRepository
    {
        Task SaveUser(AppUser user);
        Task<AppUser> GetByName(string Email);
    }


    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Получение одного пользователя
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<AppUser?> GetByName(string email)
        {
            return await _context.AppUsers.Where(o => o.Name == email).FirstOrDefaultAsync();
        }



        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task SaveUser(AppUser user)
        {
            await _context.AppUsers.AddAsync(user);
            await _context.SaveChangesAsync();
        }

    }
}
