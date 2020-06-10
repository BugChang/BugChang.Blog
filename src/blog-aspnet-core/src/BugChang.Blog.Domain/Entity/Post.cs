using System;
using System.ComponentModel.DataAnnotations.Schema;
using BugChang.Blog.Utility;

namespace BugChang.Blog.Domain.Entity
{
    public class Post : EntityBase
    {
        public string Title { get; set; }

        public string CoverImgUrl { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public int ViewCount { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? LastPublishTime { get; set; }

        public bool IsPublish { get; set; }

        public bool IsSticky { get; set; }

        public string Tags { get; set; }


        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public string GetSummary(int length)
        {
            var plainText = MarkdownHelper.ToPlainText(Content);
            length = plainText.Length > length ? length : plainText.Length;
            return plainText.Substring(0, length);
        }

        public string GetHtmlContent()
        {
            var html = MarkdownHelper.ToHtml(Content);
            return html;
        }

        public void ViewCountPlus()
        {
            ViewCount++;
        }

        public bool CanRead()
        {
            if (IsPublish)
            {
                return true;
            }

            return false;
        }

    }
}
