using BackEndPruebaTecnicsLaureate.Business;
using BackEndPruebaTecnicsLaureate.Models.Request;
using BackEndPruebaTecnicsLaureate.Models.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEndPruebaTecnicsLaureate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogInController : Controller
    {
        [HttpPost]
        [EnableCors("AllowSpecificOrigin")]
        public async ValueTask<ActionResult<VMLogIn>> PostLogIn([FromBody] ReqLogIn logIn)
        {
            BLogIn function = new();
            var response = await function.PostLogIn(logIn);
            if (!response.code)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
