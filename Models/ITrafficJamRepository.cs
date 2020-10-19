using System;
using System.Collections.Generic;

namespace Globomantics.TrafficInfo.Api.Models
{
    public interface ITrafficJamRepository
    {
        TrafficJam AddTrafficJam(TrafficJam trafficJam);
        List<TrafficJam> GetAllTrafficJams();
        List<TrafficJam> GetHistoricTrafficJams(DateTime dateTime);
        List<TrafficJam> GetTopTenLongestTrafficJams();
        List<TrafficJam> GetTrafficJamsForRegion(Guid regionId);
        void UpdateTrafficJam(TrafficJam trafficJam);
    }
}