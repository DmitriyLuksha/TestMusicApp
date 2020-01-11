using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using System.Threading.Tasks;
using TestMusicAppServer.Common.Exceptions;

namespace TestMusicAppServer.ClientNotifications.Hubs
{
    public class NotificationHub : Hub
    {
        private static readonly Dictionary<Guid, string> Connections = new Dictionary<Guid, string>();

        internal static string GetConnectionId(Guid userId)
        {
            return Connections[userId];
        }
        
        public override Task OnConnectedAsync()
        {
            var userId = GetUserId();

            if (!userId.HasValue)
            {
                throw new UserNotLoggedInException();
            }

            Connections.Add(userId.Value, Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var userId = GetUserId();

            if (userId.HasValue)
            {
                Connections.Remove(userId.Value);
            }

            return base.OnDisconnectedAsync(exception);
        }

        private Guid? GetUserId()
        {
            var idClaim = Context.User.FindFirst(ClaimTypes.NameIdentifier);

            if (idClaim == null || string.IsNullOrEmpty(idClaim.Value))
            {
                return null;
            }

            var userId = Guid.Parse(idClaim.Value);

            return userId;
        }
    }
}
