using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TogglRedmine.Configuration;
using TogglRedmine.Model.Toggl.Client;

namespace TogglRedmine.Clients
{
    public class TogglClient : ITogglClient
    {

        private HttpClient _httpClient;
        private TogglSettings _settings;

        public TogglClient(IOptions<TogglSettings> settings)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://toggl.com");
            _httpClient.DefaultRequestHeaders.Authorization = GetAuthorizationHeader(settings.Value.ApiToken);

            _settings = settings.Value;
        }

        private AuthenticationHeaderValue GetAuthorizationHeader(string apiToken)
        {
            var userPass = $"{apiToken}:api_token";
            var userPassBytes = Encoding.UTF8.GetBytes(userPass);

            var encodedUserPass = Convert.ToBase64String(userPassBytes);

            return new AuthenticationHeaderValue("Basic", encodedUserPass);
        }

        private string AddRequiredQueryParams(string requestUri, string since = "", long userId = -1)
        {
            var selectedUserId = userId != -1 ? userId : Convert.ToInt64(_settings.UserId);
            var url = $"{requestUri}?workspace_id={_settings.WorkspaceId}&user_agent={_settings.UserAgent}&uid={selectedUserId}";
            if (!string.IsNullOrWhiteSpace(since))
            {
                url += $"&since={since}";
            }
            return url;
        }

        public async Task<DetailedReportsResponse> GetDetailedReports(string since = "", long userId = -1)
        {

            var result = await _httpClient.GetAsync(AddRequiredQueryParams("reports/api/v2/details", since, userId));

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DetailedReportsResponse>(content);
            }

            throw new HttpRequestException($"Invalid response: {result.StatusCode}");
        }

        public async Task<UserResponse> GetUserInfo()
        {

            var result = await _httpClient.GetAsync("api/v8/me");

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserResponse>(content);
            }

            throw new HttpRequestException($"Invalid response: {result.StatusCode}");
        }
    }
}
