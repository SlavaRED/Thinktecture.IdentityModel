﻿/*
 * Copyright (c) Dominick Baier, Brock Allen.  All rights reserved.
 * see LICENSE
 */

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Thinktecture.IdentityModel.Extensions
{
    public static class ClaimsExtensions
    {
        public static bool HasClaim(this ClaimsPrincipal user, string type)
        {
            if (user != null)
            {
                return user.HasClaim(x => x.Type == type);
            }
            return false;
        }
        
        public static bool HasClaim(this ClaimsIdentity user, string type)
        {
            if (user != null)
            {
                return user.HasClaim(x => x.Type == type);
            }
            return false;
        }

        public static string GetValue(this IEnumerable<Claim> claims, string type)
        {
            if (claims != null)
            {
                var claim = claims.SingleOrDefault(x => x.Type == type);
                if (claim != null) return claim.Value;
            }

            return null;
        }

        public static IEnumerable<string> GetValues(this IEnumerable<Claim> claims, string claimType)
        {
            if (claims == null) return Enumerable.Empty<string>();

            var query =
                from claim in claims
                where claim.Type == claimType
                select claim.Value;
            return query;
        }
    }
}
