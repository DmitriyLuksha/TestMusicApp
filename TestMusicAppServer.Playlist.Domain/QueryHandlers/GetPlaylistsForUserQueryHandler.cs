using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestMusicAppServer.Playlist.Domain.Dto;
using TestMusicAppServer.Playlist.Domain.Mappers;
using TestMusicAppServer.Playlist.Domain.Queries;
using TestMusicAppServer.Shared.Domain.Contracts;
using TestMusicAppServer.Shared.Domain.QueryHandlers;

namespace TestMusicAppServer.Playlist.Domain.QueryHandlers
{
    public class GetPlaylistsForUserQueryHandler : BaseQueryHandler<GetPlaylistsForUserQuery, List<PlaylistDto>>
    {
        public GetPlaylistsForUserQueryHandler(
            IRepository<Entities.Playlist> repository,
            IPlaylistMapper playlistMapper
        )
        {
            this._repository = repository;
            this._playlistMapper = playlistMapper;
        }

        private readonly IRepository<Entities.Playlist> _repository;
        private readonly IPlaylistMapper _playlistMapper;

        public override async Task<List<PlaylistDto>> Handle(GetPlaylistsForUserQuery query,
            CancellationToken cancellationToken)
        {
            var playlists = await _repository.FindListAsync(pl => pl.UserId == query.UserId);

            var playlistDtos = _playlistMapper
                .MapToPlaylistDtoEnumerable(playlists)
                .ToList();

            return playlistDtos;
        }
    }
}
