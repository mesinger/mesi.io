using System.Threading.Tasks;

namespace Mesi.Io.Api.User.Data
{
    /// <summary>
    /// Repository for user entities
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Persists a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        void Save(Models.User user);
        
        /// <summary>
        /// Retrieve a user by given id
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<Models.User?> GetById(string userId);

        /// <summary>
        /// Retrieve a user by given username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<Models.User?> GetByName(string username);

        /// <summary>
        /// Retrieve a user by given email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<Models.User?> GetByEmail(string email);
    }
}