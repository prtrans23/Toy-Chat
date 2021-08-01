using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Toy.Chat.Domain.Managers;
using Toy.Chat.Domain.Models.ChatRooms;

namespace Toy.Chat.Domain.Services
{
    public class ChatRoomService : IChatRoomService
    {
        private static int _roomIdx = 0;
        private readonly IChatRoomManager _chatRoomManager;

        public ChatRoomService(IChatRoomManager chatRoomManager)
        {
            _chatRoomManager = chatRoomManager;
        }

        public async Task AddRoomAsync(string roomName)
        {
            // TODO : (mark) get roomId, generate by database
            var roomId = Interlocked.Increment(ref _roomIdx);
            await _chatRoomManager.AddRoomAsync(roomId, roomName);
        }

        public async Task RemoveRoomAsync(int roomId)
        {
            await _chatRoomManager.RemoveRoomAsync(roomId);
        }

        public ICollection<ChatRoomInfo> GetAllRoomInfo() 
        {
            return _chatRoomManager.GetAllRoomInfo();
        }
    }
}
