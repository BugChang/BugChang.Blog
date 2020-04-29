using System.Collections.Generic;

namespace BugChang.Blog.Application.PostApp.Dto
{
   public class PostPreviewDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CoverImgUrl { get; set; }

        public string Summary { get; set; }

        public int CategoryId { get; set; }

        public string CategoryColor { get; set; }

        public string CategoryName { get; set; }

        public bool IsPublish { get; set; }

        public bool IsSticky { get; set; }

        public IList<string> Tags { get; set; }

        public string CreateTime { get; set; }

        public string LastPublishTime { get; set; }

        public int ViewCount { get; set; }
    }
}
