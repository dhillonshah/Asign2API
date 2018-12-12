using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NBA.Models;

namespace NBA.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        // db
        private NBAModel db;

        public TeamsController(NBAModel db)
        {
            this.db = db;
        }

        // GET: api/teams
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return db.Teams.OrderBy(a => a.Name);
        }

        // GET: api/teams/4
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Team team = db.Teams.SingleOrDefault(a => a.TeamId == id);

            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        // POST: api/teams
        [HttpPost]
        public ActionResult Post([FromBody] Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teams.Add(team);
            db.SaveChanges();
            return CreatedAtAction("Post", new { id = team.TeamId });
        }

        // PUT: api/teams/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Team team) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(team).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return AcceptedAtAction("Put", team);
        }

        // DELETE: api/teams/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Team team = db.Teams.SingleOrDefault(a => a.TeamId == id);

            if (team == null)
            {
                return NotFound();
            }

            db.Teams.Remove(team);
            db.SaveChanges();
            return Ok();
        }
    }
}