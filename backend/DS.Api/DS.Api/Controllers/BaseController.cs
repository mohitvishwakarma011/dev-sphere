namespace DS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor _context;

        public BaseController(IHttpContextAccessor context)
        {
            this._context = context;
            var authorizationHeader = _context.HttpContext.Request.Headers["Authorization"];
            string authToken = String.Empty;
            if (authorizationHeader.ToString().StartsWith("Bearer"))
            {
                authToken = authorizationHeader.ToString().Substring("Bearer ".Length).Trim();
                AppSetting.AuthToken = authToken;
            }

        }
    }
}
