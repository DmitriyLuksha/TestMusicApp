using System.ComponentModel.DataAnnotations;
using TestMusicAppServer.Shared.Domain.Queries;

namespace TestMusicAppServer.User.Domain.Queries
{
    public class IsEmailUniqueQuery : BaseQuery<bool>
    {
        [Required]
        public string Email { get; set; }
    }
}
