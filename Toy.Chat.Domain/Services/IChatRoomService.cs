using System.Collections.Generic;
using System.Threading.Tasks;
using Toy.Chat.Domain.Models.ChatRooms;

namespace Toy.Chat.Domain.Services
{
    public interface IChatRoomService
    {
        Task AddRoomAsync(string roomName);
        Task RemoveRoomAsync(int roomId);

        ICollection<ChatRoomInfo> GetAllRoomInfo();
    }
}
