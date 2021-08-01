using System.Collections.Generic;
using System.Threading.Tasks;
using Toy.Chat.Attibute;
using Toy.Chat.Domain.Exceptions;
using Toy.Chat.Domain.Managers;
using Toy.Chat.Domain.Test.Models;
using Xunit;

namespace Toy.Chat.Domain.Test
{
    public class ChatRoomManagerTests
    {

        // https://blog.benhall.me.uk/2008/01/introduction-to-xunit-net-extensions/
        // https://github.com/leealso/blog-examples/blob/master/xUnitCustomDataAttribute/xUnitCustomDataAttribute.Test/Service/CourseServiceTest.cs
        private readonly IChatRoomManager _chatRoomManager;

        public ChatRoomManagerTests()
        {
            _chatRoomManager = new ChatRoomManager();
        }

        #region Add Room
        [Theory]
        [JsonFileData("Assets/chat_room.json", "ChatRoom")]
        public async Task ShouldSuccessAddRoom(RoomRequest roomRequest)
        {
            var roomId = roomRequest.RoomId;
            var roomName = roomRequest.RoomName;

            await _chatRoomManager.AddRoomAsync(roomId, roomName);
            var currentRoomCount = _chatRoomManager.CurrentRoomCount();

            Assert.Equal(1, currentRoomCount);
        }

        [Theory]
        [JsonFileData("Assets/chat_room.json", "ChatRoom")]
        public async Task ShouldFailAddRoomDuplicateById(RoomRequest roomRequest)
        {
            var roomId = roomRequest.RoomId;
            var roomName = roomRequest.RoomName;

            await _chatRoomManager.AddRoomAsync(roomId, roomName);

            await Assert.ThrowsAsync<ChatRoomIdDuplicateException>(
                async () => await _chatRoomManager.AddRoomAsync(roomId, roomName));

            var currentRoomCount = _chatRoomManager.CurrentRoomCount();
            Assert.Equal(1, currentRoomCount);
        }
        #endregion
    }
}
