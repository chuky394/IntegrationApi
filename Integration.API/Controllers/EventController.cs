using Integration.API.Requests;
using Integration.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net;
using System.Threading.Tasks;

namespace Integration.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ICalendarService _calendarService;
        public EventController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        [HttpPost]
        [Route("Create")]       
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadGateway)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> CreateAsync(EventRequest eventRequest)
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString();

            if (token == null)
                return Unauthorized();

            var response = await _calendarService.CreateEvent(token, eventRequest);

            return Ok(response);
        }

        [HttpPatch]
        [Route("Edit")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadGateway)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> EditAsync([FromQuery]string id, [FromBody] EditRequest editRequest)
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString();

            if (token == null)
                return Unauthorized();

            var response = await _calendarService.EditEvent(token, id, editRequest);

            return (response.StatusCode == HttpStatusCode.NotFound ? NotFound() : Ok());
        }

        [HttpGet]
        [Route("Get")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadGateway)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAsync()
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString();

            if (token == "" || token == null)
                return Unauthorized();

            var response = await _calendarService.GetEvents(token);

            return (response.Value.Count == 0 ? NoContent() : Ok(response));
        }

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadGateway)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult> GetByIdAsync(string id)
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString();

            if (token == "" || token == null)
                return Unauthorized();

            var response = await _calendarService.GetEventById(token, id);

            return (response.Id == null ? NotFound() : Ok(response));
        }

        [HttpDelete]
        [Route("Remove")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadGateway)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult> RemoveAsync(string id)
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString();

            if (token == "" || token == null)
                return Unauthorized();

            var response = await _calendarService.Remove(token, id);

            return (response.StatusCode != HttpStatusCode.NoContent ? NotFound() : Ok() );
        }
    }
}