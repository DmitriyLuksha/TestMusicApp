using System.Collections.Generic;
using TestMusicAppServer.Common.Contracts;
using TestMusicAppServer.Track.Domain.Dto;

namespace TestMusicAppServer.Track.Domain.Mappers
{
    public interface ITrackMapper : IMapperRoot
    {
        IEnumerable<TrackDto> MapToPlaylistDtoEnumerable(IEnumerable<Entities.Track> tracks);
    }
}
