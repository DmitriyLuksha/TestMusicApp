using System;
using System.ComponentModel.DataAnnotations;
using TestMusicAppServer.Shared.Domain.Queries;
using TestMusicAppServer.Track.Domain.Dto;

namespace TestMusicAppServer.Track.Domain.Queries
{
    public class TrackFileQuery : IQuery<TrackFileDto>
    {
        [Required]
        public Guid TrackId { get; set; }
    }
}
