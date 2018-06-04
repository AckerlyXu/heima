using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace cn.itcast.bookshop.Common
{
    public class Md5Util
    {
        public static string GetMd5(string source) {
            MD5 md5=MD5.Create();
           Byte[] bys= md5.ComputeHash(Encoding.Default.GetBytes(source));
            StringBuilder builder = new StringBuilder();
            foreach (var item in bys)
            {
                builder.Append(item.ToString("x2"));
            }
            md5.Clear();
            return builder.ToString();

        }
    }
}
