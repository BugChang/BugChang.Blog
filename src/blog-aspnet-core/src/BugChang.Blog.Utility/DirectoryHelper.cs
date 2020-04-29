using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BugChang.Blog.Utility
{
   public static class DirectoryHelper
    {
        public static void Create(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
