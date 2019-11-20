using System.ComponentModel.DataAnnotations;
using TestMusicAppServer.Shared.Domain.Queries;

namespace TestMusicAppServer.User.Domain.Queries
{
    public class IsUsernameUniqueQuery : BaseQuery<bool>
    {
        [Required]
        public string Username { get; set; }
    }
}
