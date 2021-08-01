namespace Toy.Chat.Domain.Models.ChatRooms
{
    public class ChatRoom
    {
        private ChatRoomInfo _chatRoomInfo;

        public ChatRoom(ChatRoomInfo chatRoomInfo)
        {
            _chatRoomInfo = chatRoomInfo;
        }

        public ChatRoomInfo GetRoomInfo()
        {
            return _chatRoomInfo.MemberwiseClone();
        }
    }
}
