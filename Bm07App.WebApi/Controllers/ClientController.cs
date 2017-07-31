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
    public class ClientController : BaseApiController<ClientController>
    {
        private readonly IClientService _clientService;
        private readonly IApplicationUserService _userService;
        private readonly ISessionTokenService _sessionTokenService;

        public ClientController(IClientService clientService, ISessionTokenService sessionTokenService, IApplicationUserService userService)
        {
            _clientService = clientService;
            _sessionTokenService = sessionTokenService;
            _userService = userService;
        }

        [HttpPost, Route("api/client/create", Name = nameof(Add))]
        public HttpResponseMessage Add(HttpRequestMessage request, [FromBody] Client client)
        {
            return Execute(request, () =>
            {
                _clientService.Add(client);

                return request.CreateResponse(HttpStatusCode.Created);
            });
        }

        //geef info over 1 client
        [HttpGet, Route("api/client/get/{id}", Name = nameof(GetClientById))]
            public HttpResponseMessage GetClientById(HttpRequestMessage request, int id)
            {
                return Execute(request, () =>
                {
                    if (id != null)
                    {
                        var client = _clientService.GetClientById(id);

                        return request.CreateResponse(HttpStatusCode.OK, client);
                    }
                    return request.CreateResponse(HttpStatusCode.BadRequest);
                });
            }

        //lijst v clients
        [HttpGet, Route("api/client/getall", Name = nameof(GetAll))]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return Execute(request, () =>
            {
                if (request.Content != null)
                {
                    var clientlist = _clientService.GetAll();

                    return request.CreateResponse(HttpStatusCode.OK, clientlist);
                }
                return request.CreateResponse(HttpStatusCode.BadRequest);
            });
        }
        //change clientactive status
        [HttpPost, Route("api/client/changeactive/{id}", Name = nameof(ChangeActive))]
        public HttpResponseMessage ChangeActive(HttpRequestMessage request, int id)
        {
            return Execute(request, () =>
            {
                if (id != null)
                {
                    _clientService.ChangeActive(id);
                    return request.CreateResponse(HttpStatusCode.OK);
                }
                return request.CreateResponse(HttpStatusCode.BadRequest);
            });
        }
    


        [HttpPut, Route("api/client/edit/", Name = nameof(Edit))]
        public HttpResponseMessage Edit(HttpRequestMessage request, [FromBody]Client client)
        {
            return Execute(request, () =>
            {
                _clientService.Edit(client);

                return request.CreateResponse(HttpStatusCode.OK);
            });
        }

        [HttpGet, Route("api/client/observations/{sessionToken}", Name = nameof(GetObservations))]
        public HttpResponseMessage GetObservations(HttpRequestMessage request, string sessionToken)
        {
            return Execute(request, () =>
            {
                try
                {
                    ApplicationUser user = _sessionTokenService.GetUserByToken(sessionToken);
                    Client[] clients = _clientService.GetClients(user);
                    Observation[] observations = (from client in clients
                                                  select client.Observations)
                                                  .SelectMany(observation => observation)
                                                  .ToArray();

                    bool observationsFound = observations != null && observations.Length > 0;

                    var responseData = new
                    {
                        ObservationsFound = observationsFound,
                        Observations = observations
                    };

                    return request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                catch (ArgumentException)
                {
                    return request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Provided session token and/or client id do not match.");
                }
            });
        }
    }
}