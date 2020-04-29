using System.Collections.Generic;

namespace BugChang.Blog.Application.PostApp.Dto
{
   public class PostDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CoverImgUrl { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public bool IsPublish { get; set; }

        public bool IsSticky { get; set; }

        public IList<string> Tags { get; set; }
    }
}
