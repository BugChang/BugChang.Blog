namespace BugChang.Blog.Application.Core
{
    public class PageSearchInput
    {
        public int Page { get; set; } = 1;

        public int Size { get; set; } = 10;

        public int Skip => (Page - 1) * Size;

        public int Take => Size;
    }
}
