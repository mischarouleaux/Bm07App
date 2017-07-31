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
    public class ActivityController : BaseApiController<ActivityController>
    {
        private readonly IActivityService _activityService ;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        
        [HttpGet, Route("api/activity/get/{id}", Name = nameof(GetActivityById))]
        public HttpResponseMessage GetActivityById(HttpRequestMessage request, int id)
        {
            return Execute(request, () =>
            {
                
                var activity = _activityService.GetActivityById(id);

                return request.CreateResponse(HttpStatusCode.OK, activity);
                
            });
        }

        [HttpPost, Route("api/activity/add/", Name = nameof(AddActivity))]
        public HttpResponseMessage AddActivity(HttpRequestMessage request, [FromBody]Activity activity)
        {
            return Execute(request, () =>
            {

                bool completed = _activityService.AddActivity(activity);

                return request.CreateResponse(completed);

            });
        }

        [HttpPut, Route("api/activity/edit/", Name = nameof(EditActivity))]
        public HttpResponseMessage EditActivity(HttpRequestMessage request, [FromBody]Activity activity)
        {
            return Execute(request, () =>
            {

                bool completed = _activityService.EditActivity(activity);

                return request.CreateResponse(HttpStatusCode.OK, completed);

            });
        }

        [HttpGet, Route("api/activity/getall/", Name = nameof(GetAllActivity))]
        public HttpResponseMessage GetAllActivity(HttpRequestMessage request)
        {
            return Execute(request, () =>
            {

                IQueryable<Activity> allActivities = _activityService.GetAllActivity();

                return request.CreateResponse(allActivities);

            });
        }
    }
}