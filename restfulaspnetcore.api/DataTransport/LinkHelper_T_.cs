using System.Collections.Generic;

namespace restfulaspnetcore.api.DataTransport
{
    public class LinkHelper<T> where T : class
    {
        public T Value { get; set; }
        public IEnumerable<Link> Links { get; set; }
    }
}