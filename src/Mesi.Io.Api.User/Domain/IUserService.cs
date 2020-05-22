using System;
using System.Threading.Tasks;

namespace Mesi.Io.Api.User.Domain
{
    /// <summary>
    /// Performs crud operations on users
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Registers a new user with given (unique) email, password and (unique) username
        /// Will throw if email or username already given
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<Models.User> Register(string email, string password, string username);

        /// <summary>
        /// Authenticates a user by given email/password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<Models.User?> Authenticate(string email, string password);
        
        /// <summary>
        /// Generates a jwt for the a given user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string GenerateJWT(Models.User user);

        /// <summary>
        /// Retrieves a user by given username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<Models.User?> GetByName(string username);
        
        /// <summary>
        /// Retrieves a user by given id
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<Models.User?> GetById(Guid userId);
    }
}