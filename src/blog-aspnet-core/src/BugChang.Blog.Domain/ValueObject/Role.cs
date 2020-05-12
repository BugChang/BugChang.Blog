using System.ComponentModel;

namespace BugChang.Blog.Domain.ValueObject
{
    public enum Role
    {
        [Description("管理员")]
        Admin,
        [Description("普通用户")]
        Normal,
        [Description("作者")]
        Author
    }
}
