using System;
using TestMusicAppServer.Shared.Domain.Dto;

namespace TestMusicAppServer.Track.Domain.Dto
{
    public class TrackDto : BaseDto
    {
        public Guid Id { get; set; }

        public Guid PlaylistId { get; set; }

        public string TrackName { get; set; }

        public string FileName { get; set; }
    }
}
