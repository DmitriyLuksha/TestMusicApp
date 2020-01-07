using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestMusicAppServer.Shared.Domain.Contracts;
using TestMusicAppServer.Shared.Domain.QueryHandlers;
using TestMusicAppServer.Track.Domain.Dto;
using TestMusicAppServer.Track.Domain.Mappers;
using TestMusicAppServer.Track.Domain.Queries;

namespace TestMusicAppServer.Track.Domain.QueryHandlers
{
    public class GetTracksByPlaylistQueryHandler : BaseQueryHandler<GetTracksByPlaylistQuery, List<TrackDto>>
    {
        public GetTracksByPlaylistQueryHandler(
            IRepository<Entities.Track> repository,
            ITrackMapper trackMapper
        )
        {
            this._repository = repository;
            this._trackMapper = trackMapper;
        }

        private readonly IRepository<Entities.Track> _repository;
        private readonly ITrackMapper _trackMapper;

        public override async Task<List<TrackDto>> Handle(GetTracksByPlaylistQuery query, CancellationToken cancellationToken)
        {
            var tracks = await _repository.FindListAsync(pl => pl.PlaylistId == query.PlaylistId);

            var trackDtos = _trackMapper
                .MapToPlaylistDtoEnumerable(tracks)
                .ToList();

            return trackDtos;
        }
    }
}
