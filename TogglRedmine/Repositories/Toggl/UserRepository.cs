using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TogglRedmine.Clients;
using TogglRedmine.Model.Toggl;

namespace TogglRedmine.Repositories.Toggl
{
    public class UserRepository : IDisposable
    {
        private ITogglClient _togglClient;

        public UserRepository(ITogglClient togglClient)
        {
            _togglClient = togglClient;
        }

        public async Task<User> GetInfo()
        {
            var result = await _togglClient.GetUserInfo();

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
