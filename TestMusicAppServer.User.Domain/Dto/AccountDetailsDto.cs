using System;
using TestMusicAppServer.Shared.Domain.Dto;

namespace TestMusicAppServer.User.Domain.Dto
{
    public class AccountDetailsDto : BaseDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
