using Integration.API.Configuration;
using Integration.API.Requests;
using Integration.API.Responses;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Integration.API.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly HttpClient _httpClient;
        private readonly MicrosoftApiOptions _microsoftApiOptions;
        public CalendarService(HttpClient httpClient,
                               MicrosoftApiOptions microsoftApiOptions)
        {
            _httpClient = httpClient;
            _microsoftApiOptions = microsoftApiOptions;

        }

        public async Task<EventResponse> CreateEvent(string token, EventRequest eventRequest)
        {
            var url = _microsoftApiOptions.BaseUrl;

            var message = new HttpRequestMessage(HttpMethod.Post, new Uri(url));

            message.Headers.Add("Authorization", token);

            message.Content = new StringContent(JsonConvert.SerializeObject(eventRequest, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }), Encoding.UTF8, "application/json");

            HttpResponseMessage response;
            EventResponse eventResponse;
            try
            {
                response = await _httpClient.SendAsync(message);
                eventResponse = JsonConvert.DeserializeObject<EventResponse>(await response.Content?.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException(response.ReasonPhrase);

            if (response.StatusCode != HttpStatusCode.Created)
                throw new Exception();

            return eventResponse;
        }

        public async Task<ListEventResponse> GetEvents(string token)
        {
            var url = _microsoftApiOptions.BaseUrl;

            var message = new HttpRequestMessage(HttpMethod.Get, new Uri(url));

            message.Headers.Add("Authorization", token);

            HttpResponseMessage response;
            ListEventResponse calendarResponse;
            try
            {
                response = await _httpClient.SendAsync(message);
                calendarResponse = JsonConvert.DeserializeObject<ListEventResponse> (await response.Content?.ReadAsStringAsync());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException(response.ReasonPhrase);

            return calendarResponse;
        }

        public async Task<EventResponse> GetEventById(string token, string id)
        {
            var url = $"{_microsoftApiOptions.BaseUrl}/{id}";

            var message = new HttpRequestMessage(HttpMethod.Get, new Uri(url));

            message.Headers.Add("Authorization", token);

            HttpResponseMessage response;
            EventResponse calendarResponse;
            try
            {
                response = await _httpClient.SendAsync(message);
                calendarResponse = JsonConvert.DeserializeObject<EventResponse>(await response.Content?.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException(response.ReasonPhrase);

            return calendarResponse;
        }

        public async Task<HttpResponseMessage> Remove(string token, string id)
        {
            var url = $"{_microsoftApiOptions.BaseUrl}/{id}";

            var message = new HttpRequestMessage(HttpMethod.Delete, new Uri(url));

            message.Headers.Add("Authorization", token);

            HttpResponseMessage response;
            try
            {
                response = await _httpClient.SendAsync(message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException(response.ReasonPhrase);

            return response;
        }

        public async Task<HttpResponseMessage> EditEvent(string token, string id, EditRequest editRequest)
        {
            var url = $"{_microsoftApiOptions.BaseUrl}/{id}";

            var message = new HttpRequestMessage(HttpMethod.Patch, new Uri(url));

            message.Headers.Add("Authorization", token);
            message.Content = new StringContent(JsonConvert.SerializeObject(editRequest, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }), Encoding.UTF8, "application/json");

            HttpResponseMessage response;
            try
            {
                response = await _httpClient.SendAsync(message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException(response.ReasonPhrase);

            return response;
        }
    }
}