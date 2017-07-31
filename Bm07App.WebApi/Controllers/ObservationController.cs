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
    public class ObservationController : BaseApiController<ObservationController>
    {
        private readonly IObservationService _observationService;
        public ObservationController(IObservationService observationService)
        {
            _observationService = observationService;
        }
        // Get single observation
        [HttpGet, Route("api/observation/get/{id}", Name = nameof(GetObservationById))]
        public HttpResponseMessage GetObservationById(HttpRequestMessage request, int id)
        {
            return Execute(request, () =>
            {
                if (id != null)
                {
                    var observation = _observationService.GetObservationById(id);

                    return request.CreateResponse(HttpStatusCode.OK, observation);
                }
                return request.CreateResponse(HttpStatusCode.BadRequest);
            });
        }

        // Add observation
        [HttpPut, Route("api/observation/add", Name = nameof(AddObservation))]
        public HttpResponseMessage AddObservation(HttpRequestMessage request, [FromBody]Observation observation)
        {
            return Execute(request, () =>
            {
                _observationService.Add(observation);

                return request.CreateResponse(HttpStatusCode.OK);
            });
        }

        // Edit observation
        [HttpPut, Route("api/observation/edit/{id}", Name = nameof(EditObservation))]
        public HttpResponseMessage EditObservation(HttpRequestMessage request, [FromBody]Observation observation)
        {
            return Execute(request, () =>
            {
                _observationService.Edit(observation);

                return request.CreateResponse(HttpStatusCode.OK);
            });
        }
    }
}