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
    public class ObservationRowController : BaseApiController<ObservationRowController>
    {
        private readonly IObservationRowService _observationRowService ;
        public ObservationRowController(IObservationRowService observationRowService)
        {
            _observationRowService = observationRowService;
        }
        
        
        [HttpGet, Route("api/observationRow/get/{id}", Name = nameof(GetObservationRowById))]
        public HttpResponseMessage GetObservationRowById(HttpRequestMessage request, int id)
        {
            return Execute(request, () =>
            {
                
                var obsObservationRow = _observationRowService.GetObservationRowById(id);

                return request.CreateResponse(HttpStatusCode.OK, obsObservationRow);
                
            });
        }

        [HttpPost, Route("api/observationRow/add/", Name = nameof(AddObservationRow))]
        public HttpResponseMessage AddObservationRow(HttpRequestMessage request, [FromBody] ObservationRow obsObservationRow)
        {
            return Execute(request, () =>
            {

                bool completed = _observationRowService.AddObservationRow(obsObservationRow);

                return request.CreateResponse(completed);

            });
        }

        [HttpPut, Route("api/observationRow/edit/", Name = nameof(EditObservationRow))]
        public HttpResponseMessage EditObservationRow(HttpRequestMessage request, [FromBody] ObservationRow obsObservationRow)
        {
            return Execute(request, () =>
            {

                bool completed = _observationRowService.EditObservationRow(obsObservationRow);

                return request.CreateResponse(completed);

            });
        }

        [HttpGet, Route("api/observationRow/getfromobservation/{observationId}", Name = nameof(GetFromObservationId))]
        public HttpResponseMessage GetFromObservationId(HttpRequestMessage request, int observationId)
        {
            return Execute(request, () =>
            {

                IQueryable<ObservationRow> allObservationRowsFromCompetance = _observationRowService.GetFromObservationId(observationId);

                return request.CreateResponse(allObservationRowsFromCompetance);

            });
        }
    }
}