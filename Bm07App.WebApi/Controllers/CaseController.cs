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
    public class CaseController : BaseApiController<CaseController>
    {
        private readonly ICaseService _caseService ;
        public CaseController(ICaseService caseService)
        {
            _caseService = caseService;
        }
        
        
        [HttpGet, Route("api/case/get/{id}", Name = nameof(GetCaseById))]
        public HttpResponseMessage GetCaseById(HttpRequestMessage request, int id)
        {
            return Execute(request, () =>
            {
                
                var obsCase = _caseService.GetCaseById(id);

                return request.CreateResponse(HttpStatusCode.OK, obsCase);
                
            });
        }

        [HttpPost, Route("api/case/add/", Name = nameof(AddCase))]
        public HttpResponseMessage AddCase(HttpRequestMessage request, [FromBody] Case obsCase)
        {
            return Execute(request, () =>
            {

                bool completed = _caseService.AddCase(obsCase);

                return request.CreateResponse(completed);

            });
        }

        [HttpPut, Route("api/case/edit/", Name = nameof(EditCase))]
        public HttpResponseMessage EditCase(HttpRequestMessage request, [FromBody] Case obsCase)
        {
            return Execute(request, () =>
            {

                bool completed = _caseService.EditCase(obsCase);

                return request.CreateResponse(completed);

            });
        }

        [HttpGet, Route("api/case/getfromcompetance/{competanceId}", Name = nameof(GetFromCompetanceId))]
        public HttpResponseMessage GetFromCompetanceId(HttpRequestMessage request, int competanceId)
        {
            return Execute(request, () =>
            {

                IQueryable<Case> allCasesFromCompetance = _caseService.GetFromCompetanceId(competanceId);

                return request.CreateResponse(allCasesFromCompetance);

            });
        }
    }
}