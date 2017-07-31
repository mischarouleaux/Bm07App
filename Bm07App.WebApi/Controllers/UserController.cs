using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bm07App.Models;
using Bm07App.Interfaces.Services;
using Newtonsoft.Json;

namespace Bm07App.WebApi.Controllers
{
    public class UserController : BaseApiController<UserController>
    {
        private readonly IApplicationUserService _userService;
        private readonly ISessionTokenService _tokenService;
        public UserController(IApplicationUserService userSerivce, ISessionTokenService tokenService)
        {
            _userService = userSerivce;
            _tokenService = tokenService;
        }

        [HttpPost, Route("api/user/verify/{username}/{token}", Name = nameof(Verify))]
        public HttpResponseMessage Verify(HttpRequestMessage request, [FromBody]string username, [FromBody]string token)
        {
            return Execute(request, () =>
            {
                bool valid = _userService.Verify(username, token);

                return Request.CreateResponse(HttpStatusCode.OK, valid);
            });
        }

        [HttpGet, Route("api/user/getById/{id}", Name = nameof(GetApplicationUserById))]
        public HttpResponseMessage GetApplicationUserById(HttpRequestMessage request, int id)
        {
            return Execute(request, () =>
            {
                var user = _userService.GetApplicationUserById(id);

                return request.CreateResponse(HttpStatusCode.OK, user);
            });
        }

        [HttpGet, Route("api/user/getActiveUsers", Name = nameof(GetActiveUsers))]
        public HttpResponseMessage GetActiveUsers(HttpRequestMessage request)
        {
            return Execute(request, () =>
            {
                var users = _userService.GetAllUsers();

                return request.CreateResponse(HttpStatusCode.OK, users);
            });
        }

        [HttpPost, Route("api/user/validateUser/{id}", Name = nameof(validateUser))]
        public HttpResponseMessage validateUser(HttpRequestMessage request, int id, bool active)
        {
            return Execute(request, () =>
            {
                _userService.validateUser(id, active);
                return request.CreateResponse(HttpStatusCode.OK);
            });
        }

        [HttpGet, Route("api/user/login/{username}/{password}", Name = nameof(Login))]
        public HttpResponseMessage Login(HttpRequestMessage request, string username, string password)
        {
            return Execute(request, () =>
            {
                ApplicationUser user = _userService.GetUserByCredentials(username, password);
                bool isValidCredentials = user != null;
                string userSessionToken = isValidCredentials ? _tokenService.GetSessionToken(user) : string.Empty;

                var responseData = new
                {
                    IsValidCredentials = isValidCredentials,
                    SessionToken = userSessionToken
                };

                return request.CreateResponse(HttpStatusCode.OK, responseData);
            });
        }

        [HttpPut, Route("api/user/lock", Name = nameof(LockAccount))]
        public HttpResponseMessage LockAccount(HttpRequestMessage request, [FromBody]string sessionToken, [FromBody]long accountId)
        {
            return Execute(request, () =>
            {
                bool isLocked = false;

                try
                {
                    ApplicationUser requestingUser = _tokenService.GetUserByToken(sessionToken);
                    isLocked = _userService.TryLock(requestingUser, accountId);
                }
                catch (ArgumentException ex)
                {
                    // Log message
                    throw;
                }

                return request.CreateResponse(HttpStatusCode.OK, isLocked);
            });
        }

        [HttpGet, Route("api/user/logout/{sessionToken}", Name = nameof(Logout))]
        public HttpResponseMessage Logout(HttpRequestMessage request, string sessionToken)
        {
            return Execute(request, () =>
            {
                bool loggedOut = _tokenService.InvalidateToken(sessionToken);

                return request.CreateResponse(HttpStatusCode.OK, loggedOut);
            });
        }

        [HttpPost, Route("api/user/updateuser/{jsonstring}", Name = nameof(UpdateUser))]
        public HttpResponseMessage UpdateUser(HttpRequestMessage request, [FromBody]string jsonstring)
        {
            Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonstring);
            ApplicationUser user = (ApplicationUser)values["User"];
            string password = (string)values["Password"];
            return Execute(request, () =>
            {
                bool completed = _userService.UpdateUser(user, password);
                return request.CreateResponse(HttpStatusCode.Created, completed);
            });
        }

        [HttpGet, Route("api/user/getallusernames", Name = nameof(GetAllUserNames))]
        public HttpResponseMessage GetAllUserNames(HttpRequestMessage request)
        {
            return Execute(request, () =>
            {
                var userlist = _userService.GetAllUserNames();

                return request.CreateResponse(HttpStatusCode.OK, userlist);
            });
        }

        [HttpGet, Route("api/user/getuser/{username}", Name = nameof(GetUser))]
        public HttpResponseMessage GetUser(HttpRequestMessage request, [FromBody]string username)
        {
            return Execute(request, () =>
            {
                var user = _userService.GetUser(username);

                return request.CreateResponse(HttpStatusCode.OK, user);
            });
        }

        [HttpGet, Route("api/user/deleteuser/{username}", Name = nameof(DeleteUser))]
        public HttpResponseMessage DeleteUser(HttpRequestMessage request, [FromBody]string username)
        {
            return Execute(request, () =>
            {
                _userService.DeleteUser(username);

                return request.CreateResponse(HttpStatusCode.OK);
            });
        }
    }
}


