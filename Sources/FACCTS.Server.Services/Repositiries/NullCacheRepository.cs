/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

using Thinktecture.IdentityServer.Repositories;
namespace FACCTS.Server.Data.Repositiries
{   
    public class NullCacheRepository : ICacheRepository
    {
        public void Put(string name, object value, int ttl)
        { }

        public object Get(string name)
        {
            return null;
        }

        public void Invalidate(string name)
        { }
    }
}
