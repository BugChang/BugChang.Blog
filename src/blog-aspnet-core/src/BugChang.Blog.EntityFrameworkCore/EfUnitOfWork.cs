using System;
using System.Collections.Generic;
using System.Text;
using BugChang.Blog.Domain.Interface;

namespace BugChang.Blog.EntityFrameworkCore
{
   public class EfUnitOfWork:IUnitOfWork
   {
       private readonly BlogContext _blogContext;

       public EfUnitOfWork(BlogContext blogContext)
       {
           _blogContext = blogContext;
       }

       public void Commit()
       {
           _blogContext.SaveChanges();
       }
    }
}
