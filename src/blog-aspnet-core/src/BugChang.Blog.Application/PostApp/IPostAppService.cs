using System;
using System.Collections.Generic;
using System.Text;
using BugChang.Blog.Application.PostApp.Dto;

namespace BugChang.Blog.Application.PostApp
{
   public interface IPostAppService
    {
        void InsertPost(PostDto postDto);
    }
}
