using Microsoft.AspNetCore.Mvc;

namespace Toy.Chat.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("chat")]
    public class ChatController : Controller
    {

        [HttpPut("join")]
        public IActionResult Index(int roomId)
        {
            return View();
        }

        [HttpPut("send")]
        public IActionResult Index(string message)
        {
            return View();
        }
    }
}
