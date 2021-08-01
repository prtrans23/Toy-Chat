using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toy.Chat.Domain.Models.ChatRooms
{
    public class ChatRoomInfo
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }

        public new ChatRoomInfo MemberwiseClone() 
        {
            return this.MemberwiseClone();
        }
    }
}
