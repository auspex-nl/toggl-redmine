using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TogglRedmine.Model.Redmine;
using TogglRedmine.Model.Redmine.Client;

namespace TogglRedmine.Clients
{
    public interface IRedmineClient
    {
        Task<TimeEntryActivitiesResponse> GetTimeEntryActivities();

        Task<TimeEntriesResponse> GetTimeEntries();

        Task<bool> AddTimeEntry(AddTimeEntryRequest entry);

    }
}
