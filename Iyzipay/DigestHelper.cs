﻿using System;
using System.Text;

namespace Iyzipay
{
    public sealed class DigestHelper
    {
        private DigestHelper()
        {
        }

        public static string DecodeString(string content)
        {
            return (!string.IsNullOrEmpty(content)) ? Encoding.UTF8.GetString(Convert.FromBase64String(content)) : null;
        }
    }
}
