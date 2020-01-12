using System;
using System.ComponentModel.DataAnnotations;
using TestMusicAppServer.Shared.Domain.Commands;

namespace TestMusicAppServer.Track.Domain.Commands
{
    public class UploadYoutubeCommand : ICommand
    {
        public Guid UserId { get; set; }

        [Required]
        public Guid PlaylistId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string VideoId { get; set; }
    }
}
