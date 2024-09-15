using API.DBContext;
using API.DBModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly dbcontext _db;
        public EventsController(dbcontext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            try
            {
                var events = _db.Events.Select(u => new
                {
                    u.Id,
                    u.UniId,
                    u.Title,
                    u.EventDate,
                    Adress = u.Street + ", " + u.City + ", " + u.State + " " + u.ZipCode,
                    u.EventPlace,
                    u.Description,
                    Marker = new { u.Lat, u.Lng }

                });
                return Ok(events);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetEvent(int id)
        {
            try
            {
                var @event = _db.Events.Where(e => e.Id == id).Select(u => new
                {
                    u.Id,
                    u.UniId,
                    u.Title,
                    u.EventDate,
                    Adress = u.Street + ", " + u.City + ", " + u.State + " " + u.ZipCode,
                    u.EventPlace,
                    u.Description,
                    Marker = new { u.Lat, u.Lng }

                }).FirstOrDefault();
                return Ok(@event);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetEventByUni(int id)
        {
            try
            {
                var events = _db.Events.Where(e => e.UniId == id).Select(u => new
                {
                    u.Id,
                    u.UniId,
                    u.Title,
                    u.EventDate,
                    Adress = u.Street + ", " + u.City + ", " + u.State + " " + u.ZipCode,
                    u.EventPlace,
                    u.Description,
                    Marker = new { u.Lat, u.Lng }

                });
                return Ok(events);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult PostNewEvent([FromBody] Event @event)
        {
            try
            {
                var campus = _db.Campus.Where(c => c.Name == @event.EventPlace).FirstOrDefault();
                if (campus != null)
                {
                    @event.UniId = campus.Id;
                    _db.Events.Add(@event);
                    _db.SaveChanges();
                }
                else
                {
                    _db.Events.Add(@event);
                    _db.SaveChanges();
                }

                return Ok("Event added");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
