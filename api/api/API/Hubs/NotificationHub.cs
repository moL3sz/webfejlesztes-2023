using Microsoft.AspNetCore.SignalR;

namespace api.API.Hubs {
    public class NotificationHub : Hub {


        public async Task AddUser(string userId) {
            await this.Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }
        public async Task RemoveUser(string userId) {
            await this.Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
        }
    }
}
