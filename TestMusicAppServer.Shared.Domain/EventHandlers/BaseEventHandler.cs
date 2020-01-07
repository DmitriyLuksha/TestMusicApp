using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace TestMusicAppServer.Shared.Domain.EventHandlers
{
    public abstract class BaseEventHandler<T> : INotificationHandler<T>
        where T: INotification
    {
        public abstract Task Handle(T @event, CancellationToken cancellationToken);
    }
}
