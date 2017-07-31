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
    public class ICFController : BaseApiController<ClientController>
    {
        private readonly IICFService _ICFService;
        public ICFController(IICFService ICFService)
        {
            _ICFService = ICFService;
        }
        //GET List of all ICF's
        [HttpGet, Route("api/icf/getallicf", Name = nameof(GetAllICF))]
        public HttpResponseMessage GetAllICF(HttpRequestMessage request)
        {
            return Execute(request, () =>
            {
                if (request.Content != null)
                {
                    var clientlist = _ICFService.GetAllICF();

                    return request.CreateResponse(HttpStatusCode.OK, clientlist);
                }
                return request.CreateResponse(HttpStatusCode.BadRequest);
            });
        }
        //GET One ICF by ID
        [HttpGet, Route("api/icf/geticf/{id}", Name = nameof(GetICF))]
        public HttpResponseMessage GetICF(HttpRequestMessage request, int id)
        {
            return Execute(request, () =>
            {
                if (id != null)
                {
                    var client = _ICFService.GetICF(id);

                    return request.CreateResponse(HttpStatusCode.OK, client);
                }
                return request.CreateResponse(HttpStatusCode.BadRequest);
            });
        }

        //Edit ICF
        [HttpPut, Route("api/icf/editicf/{id}", Name = nameof(EditICF))]
        public HttpResponseMessage EditICF(HttpRequestMessage request, [FromBody]ICF icf)
        {
            return Execute(request, () =>
            {
                _ICFService.EditICF(icf);

                return request.CreateResponse(HttpStatusCode.OK);
            });
        }

        //ADD ICF
        [HttpPut, Route("api/icf/addicf/", Name = nameof(AddICF))]
        public HttpResponseMessage AddICF(HttpRequestMessage request, [FromBody]ICF icf)
        {
            return Execute(request, () =>
            {
                _ICFService.AddICF(icf);
                return request.CreateResponse(HttpStatusCode.OK);
            });
        }



    }
}