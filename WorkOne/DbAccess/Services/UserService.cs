using Domain;
using WorkOne.DbAccess.Repository;
using WorkOne.Models.UserModels;

namespace WorkOne.DbAccess.Services
{
    public interface IUserService
    {
        Task<String> Register(RegisterUserModel model);
    }

    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Сервис для регистрация
        /// </summary>
        /// <param name="modal"></param>
        /// <returns></returns>
        public async Task<string> Register(RegisterUserModel modal)
        {
            AppUser user = await _repository.GetByName(modal.Email);
            if(user == null)
            {
                user = new AppUser { Id = Guid.NewGuid().ToString(), Name = modal.Email, PasswordHash = modal.Password, Address = modal.Address };
                await _repository.SaveUser(user);
                return user.Id;
            }
            else
            {
                return "Пользователь уже зарегистрировано!";
            }
        }
    }
}
