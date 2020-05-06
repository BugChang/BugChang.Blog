using System;
using System.Collections.Generic;
using System.Text;

namespace BugChang.Blog.Application.CategoryApp.Dto
{
    public class CategoryPreviewDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public int PostCount { get; set; }
    }

    public class CategoryNavDto : CategoryPreviewDto
    {

    }
}
