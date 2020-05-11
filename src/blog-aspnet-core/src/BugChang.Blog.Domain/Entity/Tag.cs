using System;
using System.Collections.Generic;
using System.Text;

namespace BugChang.Blog.Domain.Entity
{
    public class Tag : EntityBase
    {
        public string Name { get; set; }

        public int ArticleCount { get; set; }
    }
}
