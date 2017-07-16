using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TogglRedmine.Model.Toggl.Client;

namespace TogglRedmine.Clients
{
    public interface ITogglClient
    {
        Task<DetailedReportsResponse> GetDetailedReports();
    }
}
