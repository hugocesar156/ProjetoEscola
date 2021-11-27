using Microsoft.AspNetCore.Mvc;

namespace ProjetoEscolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public ActionResult<string> Get()
        {
            return string.Empty;
        }
    }
}
