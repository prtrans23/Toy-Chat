using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;
using Xunit;

namespace Toy.Chat.API.Test
{
    // https://docs.microsoft.com/ko-kr/aspnet/core/test/integration-tests?view=aspnetcore-5.0
    public class RoomBehaviourTests
        : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public RoomBehaviourTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("room1")]
        [InlineData("room2")]
        public async Task ShouldSuccessAddRoom(string roomName)
        {
            // Given, When
            var response = await AddRoomAsync(roomName);

            // Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task ShouldSuccessRemoveRoom(int roomId)
        {
            // Given
            await AddRoomAsync("room1");
            await AddRoomAsync("room2");
            await AddRoomAsync("room3");

            // When
            var response = await RemoveRoomAsync(roomId);

            // Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        private async Task<HttpResponseMessage> AddRoomAsync(string roomName)
        {
            var url = "/chat-room/room";
            var client = _factory.CreateClient();

            var pairs = new Dictionary<string, string>()
            {
                { "roomName", roomName }
            };
            var content = new FormUrlEncodedContent(pairs);

            return await client.PutAsync(url, content);
        }

        private async Task<HttpResponseMessage> RemoveRoomAsync(int roomId)
        {
            var requestUri = $"/chat-room/room/{roomId}";
            var client = _factory.CreateClient();
            return await client.DeleteAsync(requestUri);
        }
    }
}
