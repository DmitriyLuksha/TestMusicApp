using System;
using TestMusicAppServer.Shared.Domain.ValidationRequests;

namespace TestMusicAppServer.Playlist.Definitions.ValidationRequests
{
    public class PlaylistAccessibilityValidationRequest : IValidationRequest
    {
        public Guid PlaylistId { get; set; }

        public Guid UserId { get; set; }
    }
}
