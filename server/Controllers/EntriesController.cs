using Microsoft.AspNetCore.Mvc;
using Blog_WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        // GET: api/<EntriesController>
        [HttpGet]
        public List<Entry> Get()
        {
            var db = new DBConnection();
            var entries = db.GetAllEntries();
            return entries;
        }

        // GET api/<EntriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var db = new DBConnection();
            var entry = db.GetEntryById(id);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        // POST api/<EntriesController>
        [HttpPost]
        public void Post([FromBody] Entry entry)
        {
            var db = new DBConnection();
            db.SaveEntry(entry);
        }

        // PUT api/<EntriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Entry entry)
        {
            var db = new DBConnection();
            db.UpdateEntry(id, entry);
        }

        // DELETE api/<EntriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var db = new DBConnection();
            db.DeleteEntryById(id);
        }
    }
}
