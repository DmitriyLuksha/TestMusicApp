using System;
using System.Collections.Generic;
using TestMusicAppServer.Common.CloseableListeners;
using TestMusicAppServer.Track.Infrastructure.Listeners;

namespace TestMusicAppServer.Api.CloseableListenersHandlers
{
    public static class CloseableListenersHandler
    {
        static CloseableListenersHandler()
        {
            ListenerTypes = new List<Type>
            {
                typeof(IAudioUploadingResultListener)
            };
        }

        private static readonly List<Type> ListenerTypes;

        private static List<ICloseableListener> _listeners;

        public static void ResolveListeners(IServiceProvider serviceProvider)
        {
            _listeners = new List<ICloseableListener>();

            foreach (var type in ListenerTypes)
            {
                _listeners.Add((ICloseableListener)serviceProvider.GetService(type));
            }
        }

        public static void RegisterListeners()
        {
            foreach (var listener in _listeners)
            {
                listener.RegisterListener();
            }
        }

        public static void CloseListeners()
        {
            foreach (var listener in _listeners)
            {
                listener.CloseListener();
            }
        }
    }
}
