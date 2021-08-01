using System.Collections.Generic;
using System.Threading.Tasks;
using Toy.Chat.Domain.Models.ChatRooms;

namespace Toy.Chat.Domain.Managers
{
    public interface IChatRoomManager
    {
        int CurrentRoomCount();
        Task AddRoomAsync(int roomId, string roomName);
        Task RemoveRoomAsync(int roomId);

        ICollection<ChatRoomInfo> GetAllRoomInfo();
    }
}
