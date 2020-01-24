using System.Linq;
using System.Web.Http;
using WebServices.Data;
using WebServices.Data.Models;

namespace WebApiSelfHosting.Controllers
{
    public class CitiesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(Db.Cities.FirstOrDefault(c => c.Id == id));
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(Db.Cities);
        }

        [HttpPost]
        public IHttpActionResult Post(City city)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Db.Cities.Add(city);

            return Ok(Db.Cities);
        }
    }
}
