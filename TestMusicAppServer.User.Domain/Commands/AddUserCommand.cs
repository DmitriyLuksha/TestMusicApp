using System;
using System.ComponentModel.DataAnnotations;
using TestMusicAppServer.Shared.Domain.Commands;

namespace TestMusicAppServer.User.Domain.Commands
{
    public class AddUserCommand : ICommand
    {
        public Guid UserId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
