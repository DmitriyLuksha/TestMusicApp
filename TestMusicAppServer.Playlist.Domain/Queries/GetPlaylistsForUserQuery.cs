using System;
using System.Collections.Generic;
using TestMusicAppServer.Playlist.Domain.Dto;
using TestMusicAppServer.Shared.Domain.Queries;

namespace TestMusicAppServer.Playlist.Domain.Queries
{
    public class GetPlaylistsForUserQuery : IQuery<List<PlaylistDto>>
    {
        public Guid UserId { get; set; }
    }
}
