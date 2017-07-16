using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TogglRedmine.Configuration;

namespace TogglRedmine.Repositories
{
    public class AppStateRepository : IDisposable
    {
        public readonly AppStatusSettingsContext _dbContext;
        public AppStateRepository(AppStatusSettingsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AppStatusSettings GetState()
        {
            var state = _dbContext.AppStatusSettings.OrderByDescending(s => s.LastSynchronized).FirstOrDefault();
            return state ?? new AppStatusSettings { LastSynchronized = DateTimeOffset.UtcNow.AddDays(-1) };
        }

        public void SetState(AppStatusSettings state)
        {
            if (state.Id == 0)
            {
                _dbContext.Add(state);
            }
            else
            {
                _dbContext.Update(state);
            }
            _dbContext.SaveChanges();
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
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
