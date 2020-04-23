using System.Collections.Generic;

namespace BugChang.Blog.Domain.Entity
{
    public class Category : EntityBase
    {
        public static readonly IList<string> Colors = new List<string>
        {
            "red",
            "pink",
            "purple",
            "deep-purple",
            "indigo",
            "blue",
            "light-blue",
            "cyan",
            "teal",
            "green",
            "light-green",
            "lime",
            "yellow",
            "amber",
            "orange",
            "deep-orange",
            "brown",
            "blue-grey",
            "grey"
        };

        public string Name { get; set; }

        public string Color { get; set; }

        public IEnumerable<Post> Posts { get; set; }    
    }
}
