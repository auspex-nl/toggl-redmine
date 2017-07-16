using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TogglRedmine.Clients;
using TogglRedmine.Model.Toggl;

namespace TogglRedmine.Repositories.Toggl
{
    public class ReportsRepository : IDisposable
    {
        private ITogglClient _togglClient;

        public ReportsRepository(ITogglClient togglClient)
        {
            _togglClient = togglClient;
        }

        public async Task<DetailedReportCollection> GetAll()
        {
            var result = await _togglClient.GetDetailedReports();

            return result.Data;
        }

        public async Task<DetailedReportCollection> GetAll(DateTimeOffset since)
        {
            var result = await _togglClient.GetDetailedReports(since.LocalDateTime.ToString("yyyy-MM-dd"));

            return result.Data;
        }


        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _togglClient = null;
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
