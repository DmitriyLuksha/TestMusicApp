using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestMusicAppServer.Shared.Domain.Queries;
using TestMusicAppServer.Track.Domain.Dto;

namespace TestMusicAppServer.Track.Domain.Queries
{
    public class GetTracksByPlaylistQuery: IQuery<List<TrackDto>>
    {
        [Required]
        public Guid PlaylistId { get; set; }
    }
}
