﻿using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using FACCTS.Server.Controllers;
using FACCTS.Server.DataContracts;

namespace FACCTS.Server.Areas.Admin.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CourtMembersController : ApiControllerBase
    {
        public CourtMembersController()
        {
            
        }
        // GET api/all
        [ActionName("all")]
        public IEnumerable<CourtMember> Get()
        {
           return this.DataManager.CourtMemberRepository.GetAll().ToList();
        }
        [ActionName("memberbyid")]
        // GET api/courtmembers/5
        public CourtMember Get(long id)
        {
            var member = this.DataManager.CourtMemberRepository.GetById(id); ;
            if (member != null) return member;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }
        [ActionName("memberbyname")]
        // GET api/courtmembers/5
        public CourtMember Get(string username)
        {
            var member = this.DataManager.CourtMemberRepository.GetAll().Where(cm => cm.Username == username).AsNoTracking().FirstOrDefault();
            if (member != null) return member;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }
        [ActionName("substitutes")]
        public IDictionary<long, string> GetAvailableSubstitutes([FromBody]CourtMember member)
        {
            var roleId = member.Roles.FirstOrDefault() == null ? 0 : member.Roles.FirstOrDefault().Id;
            return this.DataManager.CourtMemberRepository.GetCourtMembersByRole(roleId).ToDictionary(cm => cm.Id, cm => (cm.FirstName + " " + cm.LastName)); 
        }

        // POST api/courtmembers
        public HttpResponseMessage Post([FromBody]CourtMember member)
        {
            this.DataManager.CourtMemberRepository.Insert(member);
            this.DataManager.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, member);

            response.Headers.Location =
                new Uri(Url.Link(AdminAreaRegistration.ControllerAndId, new { id = member.Id }));

            return response;
        }

        public HttpResponseMessage Put([FromBody]CourtMember value)
        {
            this.DataManager.CourtMemberRepository.Update(value);
            this.DataManager.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/courtmembers/5
        public HttpResponseMessage Delete(int id)
        {
            this.DataManager.CourtMemberRepository.Delete(id);
            this.DataManager.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
