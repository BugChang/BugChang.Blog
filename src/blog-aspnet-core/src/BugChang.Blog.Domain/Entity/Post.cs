using System;

namespace BugChang.Blog.Domain.Entity
{
    public class Post:EntityBase
    {
        public string Title { get; set; }

        public string CoverImgUrl { get; set; }

        public string Content { get; set; }

        public Category Category { get; set; }

        public int ViewCount { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? LastPublishTime { get; set; }

        public bool IsPublish { get; set; }

        public bool IsSticky { get; set; }

        public string Tags { get; set; }

        public void Update(Post targetPost)
        {
            Title = targetPost.Title;
            Content = targetPost.Content;
            Category = targetPost.Category;
            IsPublish = targetPost.IsPublish;
            IsSticky = targetPost.IsSticky;
            Tags = targetPost.Tags;
        }
    }
}
