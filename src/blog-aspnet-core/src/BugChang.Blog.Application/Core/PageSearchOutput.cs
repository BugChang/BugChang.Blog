using System;
using System.Collections.Generic;

namespace BugChang.Blog.Application.Core
{
    public class PageSearchOutput<T>
    {
        public PageSearchOutput(PageSearchInput input)
        {
            Page = input.Page;
            Size = input.Size;
        }
        public int Count { get; set; }

        public int Page { get; set; }

        public int Size { get; set; }

        public int PageCount => (int)Math.Ceiling((double)Count / Size);

        public IEnumerable<T> Records { get; set; }


    }
}
