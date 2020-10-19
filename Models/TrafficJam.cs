using System;

namespace Globomantics.TrafficInfo.Api.Models
{
    public class TrafficJam
    {
        public Guid Id { get; set; }
        public Guid Region { get; set; }
        public string RoadName { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Duration { get; set; }
        public DateTime StartedAt { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateTimeAdded { get; set; }
    }
}
