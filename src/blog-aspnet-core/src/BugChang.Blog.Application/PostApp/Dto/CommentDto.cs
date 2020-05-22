using System;

namespace BugChang.Blog.Application.PostApp.Dto
{
   public class CommentDto
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? ReplyId { get; set; }

        public int PostId { get; set; }

        public string Content { get; set; }

        public string CreateTime { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }

        public bool IsNotice { get; set; }
    }
}
