using System.Security.Claims;

namespace DS.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor _context;
        public int UserId { get; set; }
        public BaseController(IHttpContextAccessor context)
        {
            this._context = context;
            var authorizationHeader = _context.HttpContext.Request.Headers["Authorization"];

            if (int.TryParse(_context.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier).Value, out var parsedId))
            {
                this.UserId = parsedId;
            }
            string authToken = String.Empty;
            if (authorizationHeader.ToString().StartsWith("Bearer"))
            {
                authToken = authorizationHeader.ToString().Substring("Bearer ".Length).Trim();
                AppSetting.AuthToken = authToken;
            }

        }
    }
}
