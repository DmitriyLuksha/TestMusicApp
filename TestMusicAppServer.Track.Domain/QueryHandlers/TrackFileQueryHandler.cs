using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TestMusicAppServer.Common.Constants;
using TestMusicAppServer.Shared.Domain.Contracts;
using TestMusicAppServer.Shared.Domain.QueryHandlers;
using TestMusicAppServer.Track.Domain.Dto;
using TestMusicAppServer.Track.Domain.Queries;
using TestMusicAppServer.Track.Domain.Storages;

namespace TestMusicAppServer.Track.Domain.QueryHandlers
{
    public class TrackFileQueryHandler : BaseQueryHandler<TrackFileQuery, TrackFileDto>
    {
        public TrackFileQueryHandler(
            IRepository<Entities.Track> repository,
            IAudioStorage audioStorage
        )
        {
            this._repository = repository;
            this._audioStorage = audioStorage;
        }

        private readonly IRepository<Entities.Track> _repository;
        private readonly IAudioStorage _audioStorage;

        public override async Task<TrackFileDto> Handle(TrackFileQuery query, CancellationToken cancellationToken)
        {
            var track = await _repository.GetByIdAsync(query.TrackId);

            var trackContent = new MemoryStream();
            await _audioStorage.ReadAudioFileAsync(track.FileName, trackContent);

            var trackFileDto = new TrackFileDto
            {
                Content = trackContent,
                ContentType = MimeTypes.Audio.Mpeg
            };

            return trackFileDto;
        }
    }
}
