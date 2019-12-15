using System;
using TestMusicAppServer.Shared.Domain.Dto;

namespace TestMusicAppServer.Playlist.Domain.Dto
{
    public class PlaylistDto : BaseDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
