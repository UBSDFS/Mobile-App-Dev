
using MAUIWebAPI.Models;
using MAUIWebAPI.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace MAUIWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // GET: api/Person
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return new PersonData().GetPeople();
        }

        // POST: api/Person
        [HttpPost]
        public void Post([FromBody] Person value)
        {
            var pd = new PersonData();
            pd.SavePerson(value);
        }
    }
}
