using System.Collections.Generic;
using AutoMapper;
using TestMusicAppServer.Playlist.Domain.Dto;

namespace TestMusicAppServer.Playlist.Domain.Mappers
{
    public class PlaylistMapper : IPlaylistMapper
    {
        private static readonly IMapper Mapper;

        static PlaylistMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Entities.Playlist, PlaylistDto>();
            });

            Mapper = config.CreateMapper();
        }

        public IEnumerable<PlaylistDto> MapToPlaylistDtoEnumerable(IEnumerable<Entities.Playlist> playlist)
        {
            var playlistDtos = Mapper.Map<IEnumerable<PlaylistDto>>(playlist);
            return playlistDtos;
        }
    }
}
