using System.Collections.Generic;

namespace BugChang.Blog.Application.Core
{
    public class PageSearchOutput<T>
    {
        public int Count { get; set; }

        public IEnumerable<T> Records { get; set; }
    }
}
