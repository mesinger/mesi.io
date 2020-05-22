namespace Mesi.Io.Api.User.Domain
{
    /// <summary>
    /// Hashes a password
    /// </summary>
    public interface IPasswordHasher
    {
        /// <summary>
        /// Applies a hash function on the given password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        string hash(string password);
    }
}