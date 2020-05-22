using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Mesi.Io.Api.Clipboard.Controllers
{
    public abstract class AuthorizedController : ControllerBase
    {
        protected bool IsAuthorizedBySubject(string expectedSubject)
        {
            var subClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (subClaim == null) return false;
            return expectedSubject == subClaim.Value;
        }
    }
}