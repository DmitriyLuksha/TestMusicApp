namespace TestMusicAppServer.ClientNotifications.NotificationMessages
{
    public abstract class BaseNotificationMessage
    {
        // Returns name of the notification that will be received by the client
        public string NotificationName => this.GetType().Name;
    }
}
