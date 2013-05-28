﻿/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

using FACCTS.Server.Model.DataModel;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Thinktecture.IdentityServer.Repositories;
using Models = Thinktecture.IdentityServer.Models;


namespace FACCTS.Server.Model
{
    [Export(typeof(IIdentityProviderRepository))]
    public class IdentityProviderRepository : IIdentityProviderRepository
    {
        IEnumerable<Models.IdentityProvider> IIdentityProviderRepository.GetAll()
        {
            using (var entities = DatabaseContext.Get())
            {
                return entities.IdentityProviders.ToList().ToDomainModel();
            }
        }

        public bool TryGet(string name, out Models.IdentityProvider identityProvider)
        {
            using (var entities = DatabaseContext.Get())
            {
                identityProvider = entities.IdentityProviders.Where(idp => idp.Name == name).FirstOrDefault().ToDomainModel();
                return (identityProvider != null);
            }
        }

        public void Add(Models.IdentityProvider item)
        {
            using (var entities = DatabaseContext.Get())
            {
                ValidateUniqueName(item, entities);
                var entity = item.ToEntity();
                entities.IdentityProviders.Add(entity);
                entities.SaveChanges();
                item.ID = entity.ID;
            }
        }

        private static void ValidateUniqueName(Models.IdentityProvider item, DatabaseContext entities)
        {
            var othersWithSameName =
                from e in entities.IdentityProviders
                where e.Name == item.Name && e.ID != item.ID
                select e;
            if (othersWithSameName.Any()) throw new ValidationException(string.Format(Resources.IdentityProviderRepository.NameAlreadyInUseError, item.Name));
        }

        public void Delete(int id)
        {
            using (var entities = DatabaseContext.Get())
            {
                var item = entities.IdentityProviders.Where(idp => idp.ID == id).FirstOrDefault();
                if (item != null)
                {
                    entities.IdentityProviders.Remove(item);
                    entities.SaveChanges();
                }
            }
        }

        public void Update(Models.IdentityProvider item)
        {
            using (var entities = DatabaseContext.Get())
            {
                ValidateUniqueName(item, entities);

                var dbitem = entities.IdentityProviders.Where(idp => idp.ID == item.ID).FirstOrDefault();
                if (dbitem != null)
                {
                    item.UpdateEntity(dbitem);
                    entities.SaveChanges();
                }
            }
        }


        public Models.IdentityProvider Get(int id)
        {
            using (var entities = DatabaseContext.Get())
            {
                var item = entities.IdentityProviders.SingleOrDefault(x=>x.ID == id);
                if (item != null)
                {
                    return item.ToDomainModel();
                }
                return null;
            }
        }
    }
}
