using System.IO;

namespace TestMusicAppServer.Track.Domain.Dto
{
    public class TrackFileDto
    {
        public Stream Content { get; set; }

        public string ContentType { get; set; }
    }
}
