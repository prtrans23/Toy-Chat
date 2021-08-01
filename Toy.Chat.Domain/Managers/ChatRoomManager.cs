using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toy.Chat.Domain.Exceptions;
using Toy.Chat.Domain.Models.ChatRooms;

namespace Toy.Chat.Domain.Managers
{
    public class ChatRoomManager : IChatRoomManager
    {
        private ConcurrentDictionary<int, ChatRoom> _chatRooms;

        public ChatRoomManager()
        {
            _chatRooms = new ConcurrentDictionary<int, ChatRoom>();
        }

        public async Task AddRoomAsync(int roomId, string roomName)
        {
            await Task.Run(() =>
            {
                var chatRoomInfo = new ChatRoomInfo()
                {
                    RoomId = roomId,
                    RoomName = roomName
                };

                var chatRoom = new ChatRoom(chatRoomInfo);

                if (_chatRooms.TryAdd(roomId, chatRoom) == false)
                {
                    throw new ChatRoomIdDuplicateException();
                }
            });
        }

        public async Task RemoveRoomAsync(int roomId)
        {
            await Task.Run(() =>
            {
                if (_chatRooms.TryRemove(roomId, out var chatRoom) == false)
                {
                    throw new ChatRoomIdNotFoundException();
                }
            });
        }

        public int CurrentRoomCount() => _chatRooms.Count;

        public ICollection<ChatRoomInfo> GetAllRoomInfo()
        {
            return _chatRooms.Select(c => c.Value.GetRoomInfo()).ToList();
        }
    }
}
