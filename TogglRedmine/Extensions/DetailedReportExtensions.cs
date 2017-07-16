using System;
using TogglRedmine.Model.Toggl;

namespace TogglRedmine.Extensions
{
    public static class DetailedReportExtensions
    {
        public static double GetDurationInHours(this DetailedReport report)
        {
            var seconds = report.Duration / 1000;
            var hours = seconds / 3600.0;

            return hours;
        }     
    }
}
