using System;

namespace TestMusicAppServer.ClientNotifications.NotificationMessages
{
    public class TrackUploadFinishedNotificationMessage : BaseNotificationMessage
    {
        public Guid PlaylistId { get; set; }

        public bool IsSuccess { get; set; }

        public string TrackName { get; set; }
    }
}
