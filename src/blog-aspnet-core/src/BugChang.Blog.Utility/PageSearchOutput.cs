﻿using System;
using System.Collections.Generic;

namespace BugChang.Blog.Utility
{
    public class PageSearchOutput<T>
    {
        public PageSearchOutput(PageSearchInput input)
        {
            Page = input.Page;
            Size = input.Size;
        }
        public int Total { get; set; }

        public int Page { get; }

        public int Size { get; }

        public int PageCount => (int)Math.Ceiling((double)Total / Size);

        public IEnumerable<T> Records { get; set; }


    }
}
