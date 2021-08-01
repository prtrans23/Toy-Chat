using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Toy.Chat.Domain.Exceptions;
using Toy.Chat.Domain.Services;

// TODO : (mark) How to use status code return asp .net core
// https://stackoverflow.com/questions/38630076/asp-net-core-web-api-exception-handling
// https://developer.mozilla.org/ko/docs/Web/HTTP/Status

namespace Toy.Chat.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("chat-room")]
    public class ChatRoomController : Controller
    {
        private readonly IChatRoomService chatRoomService;

        public ChatRoomController(IChatRoomService chatRoomService)
        {
            this.chatRoomService = chatRoomService;
        }

        [HttpGet("all-room")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllRoom()
        {
            // TODO : (dh) Add Global Exception
            var roomInfos = chatRoomService.GetAllRoomInfo();
            return Ok(roomInfos);
        }

        [HttpPut("room")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddRoom(string roomName)
        {
            // Test
            try
            {
                await chatRoomService.AddRoomAsync(roomName);
            }
            catch (ChatRoomIdDuplicateException)
            {
                return Conflict();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("room/{roomId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveRoom(int roomId)
        {
            try
            {
                await chatRoomService.RemoveRoomAsync(roomId);
            }
            catch (ChatRoomIdNotFoundException)
            {
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
