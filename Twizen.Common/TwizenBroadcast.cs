using TwitchLib.Api.Helix.Models.Streams;
using TwitchLib.Api.Helix.Models.Users;

namespace Twizen.Common
{
    public class TwizenBroadcast
    {
        public TwizenBroadcast(Stream stream, User user)
        {
            Stream = stream;
            User = user;
        }

        public Stream Stream { get; }
        public User User { get; }
    }
}
