﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel;

namespace Thinktecture.IdentityServer.Core.Configuration
{
    public static class IDataProtectorExtensions
    {
        public static string Protect(this IDataProtector protector, string data, string entropy = "")
        {
            var dataBytes = Encoding.UTF8.GetBytes(data);
            var protectedBytes = protector.Protect(dataBytes, entropy);

            return Base64Url.Encode(protectedBytes);
        }

        public static string Unprotect(this IDataProtector protector, string data, string entropy = "")
        {
            var protectedBytes = Base64Url.Decode(data);
            var bytes = protector.Unprotect(protectedBytes, entropy);

            return Encoding.UTF8.GetString(bytes);
        }
    }
}