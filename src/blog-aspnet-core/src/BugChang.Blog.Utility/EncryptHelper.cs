using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BugChang.Blog.Utility
{
    public static class EncryptHelper
    {


        /// <summary>
        /// 基于MD5的自定义加密字符串方法：输入一个字符串，返回一个由40个字符组成的十六进制的哈希散列（字符串）。
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>加密后的十六进制的哈希散列（字符串）</returns>
        public static string Md5(this string str)
        {
            var buffer = Encoding.UTF8.GetBytes(str);
            var data = MD5.Create().ComputeHash(buffer);

            var sb = new StringBuilder();
            foreach (var t in data)
            {
                sb.Append(t.ToString("x2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 基于Sha1的自定义加密字符串方法：输入一个字符串，返回一个由40个字符组成的十六进制的哈希散列（字符串）。
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>加密后的十六进制的哈希散列（字符串）</returns>
        public static string Sha1(this string str)
        {
            var buffer = Encoding.UTF8.GetBytes(str);
            var data = SHA1.Create().ComputeHash(buffer);

            var sb = new StringBuilder();
            foreach (var t in data)
            {
                sb.Append(t.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
