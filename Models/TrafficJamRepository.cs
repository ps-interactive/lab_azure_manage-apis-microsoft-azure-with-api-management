using System;
using System.Collections.Generic;
using System.Linq;

namespace Globomantics.TrafficInfo.Api.Models
{
    public class TrafficJamRepository : ITrafficJamRepository
    {
        private List<TrafficJam> allTrafficJams;

        public TrafficJamRepository()
        {
            allTrafficJams = new List<TrafficJam>()
            {
                new TrafficJam(){
                    Id = new Guid("24068E2B-49DF-46BC-BF57-4538CBEAC0B9"),
                    Region = new Guid("27C43A0F-445F-4635-A8E1-86E8D35E98FF"),
                    FromLocation = "London",
                    ToLocation = "Birmingham",
                    Duration=45,
                    RoadName="M50",
                    IsActive = true,
                    StartedAt=DateTime.Now.Subtract(new TimeSpan(1, 0,0)),
                    DateTimeAdded = DateTime.Now
                },
                new TrafficJam(){
                    Id = new Guid("5A2F319F-63BE-49D5-8F5D-7FD69E6C22BD"),
                    Region = new Guid("FB42150D-DF1D-4B95-8738-7E609060FB8A"),
                    FromLocation = "Aberdeen",
                    ToLocation = "Glasgow",
                    Duration=15,
                    IsActive = true,
                    RoadName="E40",
                    DateTimeAdded = DateTime.Now,
                    StartedAt=DateTime.Now.Subtract(new TimeSpan(0, 45,0))}
            };
        }

        public List<TrafficJam> GetAllTrafficJams()
        {
            return allTrafficJams;
        }

        public List<TrafficJam> GetTopTenLongestTrafficJams()
        {
            return allTrafficJams.Where(x => x.IsActive).OrderByDescending(x => x.Duration).Take(10).ToList();
        }

        public List<TrafficJam> GetTrafficJamsForRegion(Guid regionId)
        {
            return allTrafficJams.Where(x => x.IsActive && x.Region == regionId).ToList();
        }

        public List<TrafficJam> GetHistoricTrafficJams(DateTime dateTime)
        {
            return allTrafficJams.Where(x => x.DateTimeAdded.Date == dateTime.Date).ToList();
        }

        public TrafficJam AddTrafficJam(TrafficJam trafficJam)
        {
            trafficJam.Id = Guid.NewGuid();
            allTrafficJams.Add(trafficJam);
            return trafficJam;
        }

        public void UpdateTrafficJam(TrafficJam trafficJam)
        {
            TrafficJam trafficJamToUpdate = allTrafficJams.FirstOrDefault(x => x.Id == trafficJam.Id);
            if(trafficJam!=null)
            {
                trafficJamToUpdate.IsActive = trafficJam.IsActive;
                trafficJamToUpdate.Duration = trafficJam.Duration;
            }
        }
    }
}
