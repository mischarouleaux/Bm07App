using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bm07App.Models;
using Bm07App.Interfaces.Services;

namespace Bm07App.WebApi.Controllers
{
    public class ParticipationController : BaseApiController<ParticipationController>
    {
        private readonly IParticipationService _participationService ;
        public ParticipationController(IParticipationService participationService)
        {
        _participationService = participationService;
        }
        
        [HttpGet, Route("api/participation/get/{id}", Name = nameof(GetParticipationById))]
        public HttpResponseMessage GetParticipationById(HttpRequestMessage request, int id)
        {
            return Execute(request, () =>
            {
                
                var client = _participationService.GetParticipationById(id);

                return request.CreateResponse(HttpStatusCode.OK, client);
                
            });
        }

        [HttpPost, Route("api/participation/add/", Name = nameof(AddParticipation))]
        public HttpResponseMessage AddParticipation(HttpRequestMessage request, [FromBody] Participation participation)
        {
            return Execute(request, () =>
            {

                var client = _participationService.AddParticipation(participation);

                return request.CreateResponse(HttpStatusCode.OK, client);

            });
        }

        [HttpPut, Route("api/participation/edit/", Name = nameof(EditParticipation))]
        public HttpResponseMessage EditParticipation(HttpRequestMessage request, [FromBody] Participation participation)
        {
            return Execute(request, () =>
            {

                var client = _participationService.EditParticipation(participation);

                return request.CreateResponse(HttpStatusCode.OK, client);

            });
        }

        [HttpGet, Route("api/participation/getfromactivityid/{activityId}", Name = nameof(GetParticipationFromActivityId))]
        public HttpResponseMessage GetParticipationFromActivityId(HttpRequestMessage request, int activityId)
        {
            return Execute(request, () =>
            {

                IQueryable<Participation> allParticipationsFromId = _participationService.GetParticipationFromActivityId(activityId);

                return request.CreateResponse(HttpStatusCode.OK, allParticipationsFromId);

            });
        }


    }
}