using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TogglRedmine.Configuration;
using TogglRedmine.Model.Redmine;
using TogglRedmine.Model.Redmine.Client;

namespace TogglRedmine.Clients
{
    public class RedmineClient : IRedmineClient
    {
        private HttpClient _httpClient;

        public RedmineClient(IOptions<RedmineSettings> settings)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://redmine.acsi.lan/");
            _httpClient.DefaultRequestHeaders.Add("X-Redmine-API-Key", settings.Value.ApiToken);
        }

        public async Task<TimeEntryActivitiesResponse> GetTimeEntryActivities()
        {
            var result = await _httpClient.GetAsync("enumerations/time_entry_activities.json");
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TimeEntryActivitiesResponse>(content);
            }

            throw new HttpRequestException($"Invalid response: {result.StatusCode}");
        }

        public async Task<TimeEntriesResponse> GetTimeEntries()
        {
            var result = await _httpClient.GetAsync("time_entries.json");
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TimeEntriesResponse>(content);
            }

            throw new HttpRequestException($"Invalid response: {result.StatusCode}");
        }

        public async Task<bool> AddTimeEntry(AddTimeEntryRequest entry)
        {
            var json = JsonConvert.SerializeObject(entry, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateFormatString = "yyyy-MM-dd" });

            var result = await _httpClient.PostAsync("time_entries.json", new StringContent(json, Encoding.UTF8, "application/json"));

            var whatwentwrong = await result.Content.ReadAsStringAsync();

            return result.IsSuccessStatusCode;
        }
    }
}
