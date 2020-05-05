using Markdig;

namespace BugChang.Blog.Utility
{
    public static class MarkdownHelper
    {
        public static string ToPlainText(string markdown)
        {
            return Markdown.ToPlainText(markdown);
        }

        public static string ToHtml(string markdown)
        {
            return Markdown.ToHtml(markdown);
        }
    }
}
