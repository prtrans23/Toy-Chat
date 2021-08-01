namespace Toy.Chat.Domain.Test.Models
{
    public class RoomRequest
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }

        public RoomRequest(int roomId, string roomName)
        {
            RoomId = roomId;
            RoomName = roomName;
        }
    }
}
