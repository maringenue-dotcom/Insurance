using API.DBContext;
using API.DBModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UniController : ControllerBase
    {
        private readonly dbcontext _db;

        public UniController(dbcontext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetUnis()
        {
            try
            {
                var unis = _db.Campus.Select(u=>new
                {
                    u.Id,
                    u.Name,
                    Adress = u.Street + ", " + u.City + ", " + u.State + " " + u.ZipCode,
                    u.Type,
                    u.Students,
                    SoonestEvent = "In Progress",
                    Marker = new { u.Lat, u.Lng }

                });
                return Ok(unis);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetUni(int id)
        {
            try
            {
                var uni = _db.Campus.Where(e => e.Id == id).Select(u => new
                {
                    u.Id,
                    u.Name,
                    Adress = u.Street + ", " + u.City + ", " + u.State + " " + u.ZipCode,
                    u.Type,
                    u.Students,
                    SoonestEvent = "In Progress",
                    Marker = new { u.Lat, u.Lng }

                }).FirstOrDefault();
                return Ok(uni);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult PostNewUni([FromBody] Campus uni)
        {
            try
            {
                foreach (var u in _db.Campus)
                {
                    if (u.Name == uni.Name)
                        return Ok($"Sorry this campus {uni.Name} already added");
                    else
                    {
                        _db.Campus.Add(uni);
                        _db.SaveChanges();
                    }
                }
                        return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
