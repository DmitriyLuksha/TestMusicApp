using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using TestMusicAppServer.Shared.Domain.Commands;

namespace TestMusicAppServer.Track.Domain.Commands
{
    public class UploadFileCommand : ICommand
    {
        public Guid UserId { get; set; }

        [Required]
        public Guid PlaylistId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        public Stream File { get; set; }
    }
}
