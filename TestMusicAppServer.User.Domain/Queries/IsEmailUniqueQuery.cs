using System.ComponentModel.DataAnnotations;
using TestMusicAppServer.Shared.Domain.Queries;

namespace TestMusicAppServer.User.Domain.Queries
{
    public class IsEmailUniqueQuery : IQuery<bool>
    {
        [Required]
        public string Email { get; set; }
    }
}
