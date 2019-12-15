using System;
using System.Collections.Generic;
using System.Text;
using TestMusicAppServer.Shared.Domain.Entities;

namespace TestMusicAppServer.Playlist.Domain.Entities
{
    public class Playlist : BaseEntity
    {
        private Playlist() { }

        public Playlist(Guid id, string name, Guid userId)
        {
            this.Id = id;
            this.Name = name;
            this.UserId = userId;
        }

        public string Name { get; private set; }

        public Guid UserId { get; private set; }
    }
}
