using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugChang.Blog.Domain.Entity
{
    public class Comment : EntityBase
    {
        public int? UserId { get; set; }

        public int? ReplyId { get; set; }

        public int PostId { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;

        public string NickName { get; set; }

        public string Email { get; set; }

        public bool IsNotice { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ReplyId")]
        public Comment Reply { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }
    }
}
