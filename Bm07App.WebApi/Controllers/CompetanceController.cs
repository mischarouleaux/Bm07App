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
    public class CompetanceController : BaseApiController<CompetanceController>
    {
        private readonly ICompetanceService _CompetanceService ;
        public CompetanceController(ICompetanceService CompetanceService)
        {
            _CompetanceService = CompetanceService;
        }
        
        [HttpGet, Route("api/Competance/get/{id}", Name = nameof(GetCompetanceById))]
        public HttpResponseMessage GetCompetanceById(HttpRequestMessage request, int id)
        {
            return Execute(request, () =>
            {
                
                var Competance = _CompetanceService.GetCompetanceById(id);

                return request.CreateResponse(HttpStatusCode.OK, Competance);
                
            });
        }

        [HttpPost, Route("api/Competance/add/", Name = nameof(AddCompetance))]
        public HttpResponseMessage AddCompetance(HttpRequestMessage request, [FromBody]Competance Competance)
        {
            return Execute(request, () =>
            {

                bool completed = _CompetanceService.AddCompetance(Competance);

                return request.CreateResponse(completed);

            });
        }

        [HttpPut, Route("api/Competance/edit/", Name = nameof(EditCompetance))]
        public HttpResponseMessage EditCompetance(HttpRequestMessage request, [FromBody]Competance Competance)
        {
            return Execute(request, () =>
            {

                bool completed = _CompetanceService.EditCompetance(Competance);

                return request.CreateResponse(HttpStatusCode.OK, completed);

            });
        }

        [HttpGet, Route("api/Competance/GetAll/", Name = nameof(GetAllCompetance))]
        public HttpResponseMessage GetAllCompetance(HttpRequestMessage request)
        {
            return Execute(request, () =>
            {

                IQueryable<Competance> allCompetances = _CompetanceService.GetAllCompetance();

                return request.CreateResponse(allCompetances);

            });
        }


    }
}