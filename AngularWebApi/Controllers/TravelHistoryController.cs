using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace VehicleTracking.Controllers
{
    public class TravelHistoryController : ApiController
    {

        internal readonly ITravelHistoryRepository travelHistoryRepository;

        public TravelHistoryController(ITravelHistoryRepository travelHistoryRepository)
        {
            this.travelHistoryRepository = travelHistoryRepository;

        }
        [Route("api/GetTravelHistorys")]
        public IHttpActionResult GetTravelHistorys()
        {
            var TravelHistorys = travelHistoryRepository.GetAll().OrderBy(p => p.Lat);
            return Ok(TravelHistorys.ToList());
        }

        [Route("api/GetTravelHistory")]
        public IHttpActionResult GetTravelHistory(int id)
        {
            var TravelHistory = travelHistoryRepository.GetById(id);
            return Ok(TravelHistory);
        }

        [Route("api/SaveTravelHistory")]
        public IHttpActionResult SaveTravelHistory(TravelHistory TravelHistory)
        {
            travelHistoryRepository.InsertAndSubmit(TravelHistory);
            return Ok();
        }

        [Route("api/SaveAllTravelHistory")]
        public IHttpActionResult SaveTravelHistory(List<TravelHistory> travelHistories)
        {
            foreach (var travelHistory in travelHistories)
            {
                var utcDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(travelHistory.TimeStamp);
                string indianTimeZoneKey = "India Standard Time";
                TimeZoneInfo indianTimeZone = TimeZoneInfo.FindSystemTimeZoneById(indianTimeZoneKey);
                travelHistory.DateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, indianTimeZone);
                travelHistoryRepository.InsertAndSubmit(travelHistory);
            }
            
            return Ok();
        }
        [Route("api/UpdateTravelHistory")]
        public IHttpActionResult UpdateTravelHistory(TravelHistory TravelHistory)
        {
            travelHistoryRepository.UpdateAndSubmit(TravelHistory);
            return Ok();
        }
        [Route("api/DeleteTravelHistory")]
        public IHttpActionResult DeleteTravelHistory(TravelHistory TravelHistory)
        {
            travelHistoryRepository.DeleteAndSubmit(TravelHistory);
            return Ok();
        }
        [Route("api/SoftDeleteTravelHistory")]
        public IHttpActionResult SoftDeleteTravelHistory(TravelHistory TravelHistory)
        {
            travelHistoryRepository.SoftDeleteAndSubmit(TravelHistory);
            return Ok();
        }
    }
}
