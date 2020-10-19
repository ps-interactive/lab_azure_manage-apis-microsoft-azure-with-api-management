using Microsoft.AspNetCore.Mvc;
using Globomantics.TrafficInfo.Api.Models;
using System;

namespace Globomantics.TrafficInfo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrafficController: Controller
    {

        private readonly ITrafficJamRepository trafficJamRepository;

        public TrafficController(ITrafficJamRepository trafficJamRepository)
        {   
            this.trafficJamRepository = trafficJamRepository;
        }

        [HttpGet("top10")]
        public IActionResult GetTopTenLongestTrafficJams()
        {
            return Ok(trafficJamRepository.GetTopTenLongestTrafficJams());
        }

        [HttpGet("all")]
        public IActionResult GetAllTrafficJams()
        {
            return Ok(trafficJamRepository.GetAllTrafficJams());
        }

        [HttpGet("historic/{date}")]
        public IActionResult GetHistoricTrafficJams(DateTime date)
        {
            return Ok(trafficJamRepository.GetHistoricTrafficJams(date));
        }

        [HttpGet("region/{regionId}")]
        public IActionResult GetTrafficJamsForRegion(Guid regionId)
        {
            return Ok(trafficJamRepository.GetTrafficJamsForRegion(regionId));
        }

        [HttpPost]
        public IActionResult AddTrafficJam([FromBody]TrafficJam trafficJam)
        {
            TrafficJam newTrafficJam = trafficJamRepository.AddTrafficJam(trafficJam);
            return Created("trafficJam", newTrafficJam);
        }

        [HttpPut]
        public IActionResult UpdateTrafficJam([FromBody] TrafficJam trafficJam)
        {
            trafficJamRepository.UpdateTrafficJam(trafficJam);
            return NoContent();
        }
    }
}
