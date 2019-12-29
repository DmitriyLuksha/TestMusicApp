using System.ComponentModel.DataAnnotations;
using TestMusicAppServer.Shared.Domain.Queries;

namespace TestMusicAppServer.User.Domain.Queries
{
    public class IsUsernameUniqueQuery : IQuery<bool>
    {
        [Required]
        public string Username { get; set; }
    }
}
