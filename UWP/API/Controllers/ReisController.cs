using System.Collections.Generic;
using API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ReisController : ControllerBase
    {
        private readonly IReisRepository _repo;

        public ReisController(IReisRepository repo)
        {
            _repo = repo;
        }

        // GET api/Reis
        [HttpGet]
        public IEnumerable<Reis> Get()
        {
            return _repo.GetReizen();
        }

        // GET api/Reis/5
        [HttpGet("{id}")]
        public Reis GetById(int id)
        {
            return _repo.GetReisById(id);
        }

        // POST api/Reis
        [HttpPost]
        public ActionResult<Reis> Post(Reis reis)
        {
            _repo.Add(reis);
            _repo.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = reis.Id }, reis);
        }

        // PUT api/Reis/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Reis reis)
        {
            if (id != reis.Id)
            {
                return BadRequest();
            }
            _repo.Update(reis);
            _repo.SaveChanges();
            return NoContent();
        }

        // DELETE api/Reis/5
        [HttpDelete("{id}")]
        public ActionResult<Reis> Delete(int id)
        {
            Reis reis = _repo.GetReisById(id);
            if (reis == null)
            {
                return NotFound();
            }

            _repo.Delete(reis);
            _repo.SaveChanges();
            return reis;
        }
    }
}
