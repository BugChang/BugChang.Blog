using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugChang.Blog.Domain.Entity;
using BugChang.Blog.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace BugChang.Blog.EntityFrameworkCore.Repository
{
   public class CategoryRepository:RepositoryBase<Category>,ICategoryRepository
    {
        public CategoryRepository(BlogContext blogContext) : base(blogContext)
        {
        }


    }
}
