using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace FagronTech.Infrastructure.Web
{
    /// <summary> Classe base p/ um API controller versionado </summary>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json", "application/problem+json")]
    [ProducesResponseType(Status401Unauthorized)]
    [ProducesResponseType(Status403Forbidden)]
    [ProducesResponseType(Status500InternalServerError)]
    [ProducesResponseType(Status502BadGateway)]
    [ProducesResponseType(Status504GatewayTimeout)]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
