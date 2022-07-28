using Meter_Project.Inputs;
using Meter_Project.Models;
using Meter_Project.Models.MeterContext;
using Meter_Project.Repository_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Meter_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterController : ControllerBase
    {
        private IMeterRepository _meterRepository;

        public MeterController(IMeterRepository meterRepository)
        {
            _meterRepository = meterRepository;

        }

        [HttpPost]
        [Route("/getAll")]
        public IActionResult GetAll([FromBody] Request req)
        {
            if (req.SearchLevel != null)
            {
                if (req.DateRange == null)
                {
                    return BadRequest("Please enter date range .");
                }
                if (req.SearchLevel == "City")
                    return Ok(_meterRepository.FindDetailsAtCityLevel(req.DateRange));
                else if (req.SearchLevel == "Facility")
                    return Ok(_meterRepository.FindDetailsAtFacilityLevel(req.DateRange));
                else if (req.SearchLevel == "Building")
                    return Ok(_meterRepository.FindDetailsAtBuildingLevel(req.DateRange));
                else if (req.SearchLevel == "Floor")
                    return Ok(_meterRepository.FindDetailsAtFloorLevel(req.DateRange));
                else if (req.SearchLevel =="Zone")
                    return Ok(_meterRepository.FindDetailsAtZoneLevel(req.DateRange));
                else if (req.SearchLevel =="Meter")
                    return Ok(_meterRepository.FindDetailsAtMeterLevel(req.DateRange));

                else return BadRequest("Please enter Valid LevelOfSearch");

            }
            return BadRequest("Both Fields are required. Please enter the values again !");
        }



    }
}
