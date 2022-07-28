using Integration.API.Requests;
using Integration.API.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace Integration.API.Services
{
    public interface ICalendarService
    {
        Task<EventResponse> CreateEvent(string token, EventRequest eventRequest);
        Task<ListEventResponse> GetEvents(string token);
        Task<EventResponse> GetEventById(string token, string id);
        Task<HttpResponseMessage> Remove(string token, string id);
        Task<HttpResponseMessage> EditEvent(string token, string id, EditRequest editRequest);
    }
}