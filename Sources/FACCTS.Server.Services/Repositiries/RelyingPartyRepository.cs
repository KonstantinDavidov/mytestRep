/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Linq;
using Thinktecture.IdentityServer.Models;
using Thinktecture.IdentityServer.Repositories;

namespace FACCTS.Server.Services.Repositiries
{
    [Export(typeof(IRelyingPartyRepository))]
    public class RelyingPartyRepository : IRelyingPartyRepository
    {
        public bool TryGet(string realm, out RelyingParty relyingParty)
        {
            relyingParty = null;

            using (var entities = DatabaseContext.Get())
            {
                var match = (from rp in entities.RelyingParties
                             where rp.Realm.Equals(realm, StringComparison.OrdinalIgnoreCase) &&
                                   rp.Enabled == true
                             orderby rp.Realm descending
                             select rp)
                            .FirstOrDefault();

                if (match != null)
                {
                    relyingParty = match.ToDomainModel();
                    return true;
                }
            }

            return false;
        }

        #region Management
        public bool SupportsWriteAccess
        {
            get { return true; }
        }

        public IEnumerable<RelyingParty> List(int pageIndex, int pageSize)
        {
            using (var entities = DatabaseContext.Get())
            {
                var rps = from e in entities.RelyingParties
                          orderby e.Name
                          select e;

                if (pageIndex != -1 && pageSize != -1)
                {
                    rps = rps.Skip(pageIndex * pageSize).Take(pageSize).OrderBy(rp => rp.Name);
                }

                return rps.ToList().ToDomainModel();
            }
        }

        public RelyingParty Get(string id)
        {
            var uniqueId = int.Parse(id);

            using (var entities = DatabaseContext.Get())
            {
                return
                    (from rp in entities.RelyingParties
                     where rp.Id == uniqueId
                     select rp)
                    .First()
                    .ToDomainModel();
            }
        }

        public void Add(RelyingParty relyingParty)
        {
            using (var entities = DatabaseContext.Get())
            {
                entities.RelyingParties.Add(relyingParty.ToEntity());
                entities.SaveChanges();
            }
        }

        public void Update(RelyingParty relyingParty)
        {
            var rpEntity = relyingParty.ToEntity();

            using (var entities = DatabaseContext.Get())
            {
                entities.RelyingParties.Attach(rpEntity);
                entities.Entry(rpEntity).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (var entities = DatabaseContext.Get())
            {
                var rpEntity = new RelyingParties { Id = int.Parse(id) };
                entities.RelyingParties.Attach(rpEntity);
                entities.Entry(rpEntity).State = EntityState.Deleted;
                entities.SaveChanges();
            }
        }
        #endregion
    }
}
