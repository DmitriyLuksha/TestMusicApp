using System;
using System.ComponentModel.DataAnnotations;
using TestMusicAppServer.Shared.Domain.Commands;

namespace TestMusicAppServer.Playlist.Domain.Commands
{
    public class AddPlaylistCommand : BaseCommand
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
