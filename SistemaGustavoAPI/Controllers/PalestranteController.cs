using Infra.Http.Seedwork.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SistemaGustavoAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PalestranteController : ApiController
    {
        public PalestranteController()
        {

        }

        [HttpGet("palestrantes")]
        public async Task<IActionResult> GetPalestrante()
        {
            return Ok();
        }
    }
}
