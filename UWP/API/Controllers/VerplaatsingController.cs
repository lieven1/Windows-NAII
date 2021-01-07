using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class VerplaatsingController : ControllerBase
    {

        private readonly IVerplaatsingRepository _repo;

        public VerplaatsingController(IVerplaatsingRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Verplaatsing
        [HttpGet]
        public IEnumerable<Verplaatsing> GetVerplaatsingen()
        {
            return _repo.GetVerplaatsingen();
        }
        // GET api/Verplaatsing/5
        [HttpGet("{id}")]
        public Verplaatsing GetById(int id)
        {
            return _repo.GetVerplaatsingById(id);
        }
        // PUT api/Verplaatsing/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Verplaatsing verplaatsing)
        {
            if (id != verplaatsing.Id)
            {
                return BadRequest();
            }
            _repo.Update(verplaatsing);
            _repo.SaveChanges();
            return NoContent();
        }

        // POST api/Verplaatsing
        [HttpPost]
        public ActionResult<Verplaatsing> Post(Verplaatsing verplaatsing)
        {
            _repo.Add(verplaatsing);
            _repo.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = verplaatsing.Id }, verplaatsing);
        }

        // DELETE: api/Verplaatsing/5
        [HttpDelete("{id}")]
        public ActionResult<Verplaatsing> Delete(int id)
        {
            Verplaatsing verplaatsing = _repo.GetVerplaatsingById(id);
            if (verplaatsing == null)
            {
                return NotFound();
            }

            _repo.Delete(verplaatsing);
            _repo.SaveChanges();
            return verplaatsing;
        }

      
    }
}