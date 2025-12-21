using APIrest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APIrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class UsuarioController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public ActionResult<Response<string>> GetUsuario()
        {
            Response<string> response = new Response<string>();
            response.Menssagem = "Acessei";

            return Ok(response);
        }
    }
}
