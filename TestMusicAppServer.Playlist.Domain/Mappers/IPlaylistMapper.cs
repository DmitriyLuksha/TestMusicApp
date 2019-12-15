using System.Collections.Generic;
using TestMusicAppServer.Common.Contracts;
using TestMusicAppServer.Playlist.Domain.Dto;

namespace TestMusicAppServer.Playlist.Domain.Mappers
{
    public interface IPlaylistMapper : IMapperRoot
    {
        IEnumerable<PlaylistDto> MapToPlaylistDtoEnumerable(IEnumerable<Entities.Playlist> playlist);
    }
}
