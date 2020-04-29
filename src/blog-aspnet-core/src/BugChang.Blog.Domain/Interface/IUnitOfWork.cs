using System;
using System.Collections.Generic;
using System.Text;

namespace BugChang.Blog.Domain.Interface
{
   public interface IUnitOfWork
   {
       void Commit();
   }
}
