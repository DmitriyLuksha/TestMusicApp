using System.Collections.Generic;
using AutoMapper;
using TestMusicAppServer.Track.Domain.Dto;

namespace TestMusicAppServer.Track.Domain.Mappers
{
    public class TrackMapper : ITrackMapper
    {
        private static readonly IMapper Mapper;

        static TrackMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Entities.Track, TrackDto>();
            });

            Mapper = config.CreateMapper();
        }

        public IEnumerable<TrackDto> MapToPlaylistDtoEnumerable(IEnumerable<Entities.Track> tracks)
        {
            var trackDtos = Mapper.Map<IEnumerable<TrackDto>>(tracks);
            return trackDtos;
        }
    }
}
