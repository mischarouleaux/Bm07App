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
    public class ClientNoteController : BaseApiController<ClientNoteController>
    {
        private readonly IClientNoteService _clientNoteService;
        public ClientNoteController(IClientNoteService clientNoteService)
        {
            _clientNoteService = clientNoteService;
        }
        // Get single observation
        [HttpGet, Route("api/clientnote/get/{id}", Name = nameof(GetClientNoteById))]
        public HttpResponseMessage GetClientNoteById(HttpRequestMessage request, int id)
        {
            return Execute(request, () =>
            {
                if (id != null)
                {
                    var clientNote = _clientNoteService.GetClientNoteById(id);

                    return request.CreateResponse(HttpStatusCode.OK, clientNote);
                }
                return request.CreateResponse(HttpStatusCode.BadRequest);
            });
        }

        [HttpGet, Route("api/clientnote/getbyclient/{id}", Name = nameof(GetClientNoteByClientId))]
        public HttpResponseMessage GetClientNoteByClientId(HttpRequestMessage request, int id)
        {
            return Execute(request, () =>
            {
                if (id != null)
                {
                    var clientNote = _clientNoteService.GetClientNotesByClientId(id);

                    return request.CreateResponse(HttpStatusCode.OK, clientNote);
                }
                return request.CreateResponse(HttpStatusCode.BadRequest);
            });
        }

        // Add client note
        [HttpPut, Route("api/clientnote/add", Name = nameof(AddClientNote))]
        public HttpResponseMessage AddClientNote(HttpRequestMessage request, [FromBody]ClientNote clientNote)
        {
            return Execute(request, () =>
            {
                _clientNoteService.Add(clientNote);

                return request.CreateResponse(HttpStatusCode.OK);
            });
        }

        // Edit client note
        [HttpPut, Route("api/clientnote/edit/{id}", Name = nameof(EditClientNote))]
        public HttpResponseMessage EditClientNote(HttpRequestMessage request, [FromBody]ClientNote clientNote)
        {
            return Execute(request, () =>
            {
                _clientNoteService.Edit(clientNote);

                return request.CreateResponse(HttpStatusCode.OK);
            });
        }
    }
}