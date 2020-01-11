using System;
using System.Security.Claims;
using System.Threading.Tasks;
using TestMusicAppServer.ClientNotifications.NotificationMessages;
using TestMusicAppServer.Common.Contracts;

namespace TestMusicAppServer.ClientNotifications.Services
{
    public interface IClientNotificationService : IService
    {
        string GetConnectionId(Guid userId);

        Task SendNotificationMessageAsync(ClaimsPrincipal user, BaseNotificationMessage message);

        Task SendNotificationMessageAsync(Guid userId, BaseNotificationMessage message);
    }
}
