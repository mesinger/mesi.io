using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mesi.Io.Domain.Contract.DTO
{
    /// <summary>
    /// Represents an authorized user in the system
    /// </summary>
    public class UserResponse
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("email")] public string Email { get; set; }
        [JsonProperty("roles")] public IEnumerable<string> Roles { get; set; }
    }
}