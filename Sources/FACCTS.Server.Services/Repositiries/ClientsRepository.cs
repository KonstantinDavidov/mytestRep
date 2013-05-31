/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

using FACCTS.Server.Common;
using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Thinktecture.IdentityServer.Repositories;
using Models = Thinktecture.IdentityServer.Models;

namespace FACCTS.Server.Data.Repositiries
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [Export(typeof(IClientsRepository))]
    public class ClientsRepository : IClientsRepository
    {
        public bool ValidateClient(string clientId, string clientSecret)
        {
            using (var entities = DatabaseContext.Get())
            {
                var record = (from c in entities.Clients
                              where c.ClientId.Equals(clientId, StringComparison.Ordinal)
                              select c).SingleOrDefault();
                if (record != null)
                {
                    return CryptoHelper.VerifyHashedPassword(record.ClientSecret, clientSecret);
                }
                return false;
            }
        }

        public bool TryGetClient(string clientId, out Models.Client client)
        {
            using (var entities = DatabaseContext.Get())
            {
                var record = (from c in entities.Clients
                              where c.ClientId.Equals(clientId, StringComparison.Ordinal)
                              select c).SingleOrDefault();

                if (record != null)
                {
                    client = record.ToDomainModel();
                    return true;
                }

                client = null;
                return false;
            }
        }

        public bool ValidateAndGetClient(string clientId, string clientSecret, out Models.Client client)
        {
            using (var entities = DatabaseContext.Get())
            {
                var record = (from c in entities.Clients
                              where c.ClientId.Equals(clientId, StringComparison.Ordinal)
                              select c).SingleOrDefault();
                if (record != null)
                {
                    if (CryptoHelper.VerifyHashedPassword(record.ClientSecret, clientSecret))
                    {
                        client = record.ToDomainModel();
                        return true;
                    }
                }

                client = null;
                return false;
            }
        }
        
        public IEnumerable<Models.Client> GetAll()
        {
            using (var entities = DatabaseContext.Get())
            {
                return entities.Clients.ToArray().Select(x => x.ToDomainModel()).ToArray();
            }
        }


        public void Delete(int id)
        {
            using (var entities = DatabaseContext.Get())
            {
                var item = entities.Clients.Where(x => x.Id == id).SingleOrDefault();
                if (item != null)
                {
                    entities.Clients.Remove(item);
                    entities.SaveChanges();
                }
            }
        }
        public void Update(Models.Client model)
        {
            if (model == null) throw new ArgumentException("model");

            using (var entities = DatabaseContext.Get())
            {
                var item = entities.Clients.Where(x => x.Id == model.ID).Single();
                model.UpdateEntity(item);
                entities.SaveChanges();
            }
        }

        public void Create(Models.Client model)
        {
            if (model == null) throw new ArgumentException("model");

            using (var entities = DatabaseContext.Get())
            {
                var item = new Client();
                model.UpdateEntity(item);
                entities.Clients.Add(item);
                entities.SaveChanges();
                model.ID = item.Id;
            }
        }


        public Models.Client Get(int id)
        {
            using (var entities = DatabaseContext.Get())
            {
                var item = entities.Clients.Where(x => x.Id == id).SingleOrDefault();
                if (item != null)
                {
                    return item.ToDomainModel();
                }
                return null;
            }
        }
    }
}
