using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TogglRedmine.Clients;
using TogglRedmine.Model.Redmine;
using TogglRedmine.Model.Redmine.Client;

namespace TogglRedmine.Repositories.Redmine
{
    public class TimeEntriesRepository : IDisposable
    {
        private IRedmineClient _redmineClient;

        public TimeEntriesRepository(IRedmineClient redmineClient)
        {
            _redmineClient = redmineClient;
        }

        public async Task<ActivityCollection> TimeEntryActivities()
        {
            var response = await _redmineClient.GetTimeEntryActivities();

            return response.TimeEntryActivities;
        }
            
        public async Task<TimeEntryCollection> GetAll()
        {
            var response = await _redmineClient.GetTimeEntries();

            return response.TimeEntries;
        }

        public async Task<bool> Add(TimeEntry entry)
        {
            var response = await _redmineClient.AddTimeEntry(new AddTimeEntryRequest(entry));

            return response;
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _redmineClient = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
