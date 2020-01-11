using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TestMusicAppServer.ClientNotifications.Hubs;
using TestMusicAppServer.ClientNotifications.NotificationMessages;
using TestMusicAppServer.Common.Exceptions;

namespace TestMusicAppServer.ClientNotifications.Services
{
    public class ClientNotificationService : IClientNotificationService
    {
        private readonly IHubContext<NotificationHub> _notificationHubContext;

        private const string NotificationMethodName = "notification";

        public ClientNotificationService(IHubContext<NotificationHub> notificationHubContext)
        {
            this._notificationHubContext = notificationHubContext;
        }

        public string GetConnectionId(Guid userId)
        {
            return NotificationHub.GetConnectionId(userId);
        }

        public Task SendNotificationMessageAsync(ClaimsPrincipal user, BaseNotificationMessage message)
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier);

            if (userId == null || string.IsNullOrEmpty(userId.Value))
            {
                throw new UserNotLoggedInException();
            }

            return SendNotificationMessageAsync(Guid.Parse(userId.Value), message);
        }

        public Task SendNotificationMessageAsync(Guid userId, BaseNotificationMessage message)
        {
            return _notificationHubContext
                .Clients
                .User(userId.ToString())
                .SendAsync(NotificationMethodName, message);
        }
    }
}
