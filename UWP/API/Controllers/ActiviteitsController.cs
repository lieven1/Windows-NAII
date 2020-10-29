using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account.Manage;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiviteitsController : ControllerBase
    {
        private readonly IActiviteitsRepository _repo;

        public ActiviteitsController(IActiviteitsRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Activiteits
        [HttpGet]
        public IEnumerable<Activiteit> GetActiviteit()
        {
            return _repo.GetActiviteiten();
        }

        // GET: api/Activiteits/5
        
        [HttpGet("{id}")]
        public Activiteit GetById(int id)
        {
            return _repo.GetActiviteitById(id);
        }
        // POST: api/Activiteits
        [HttpPost]
        public ActionResult<Activiteit> Post(Activiteit activiteit)
        {
            _repo.Add(activiteit);
            _repo.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = activiteit.ActiviteitId }, activiteit);
        }
        // PUT api/Activiteits/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Activiteit activiteit)
        {
            if (id != activiteit.ActiviteitId)
            {
                return BadRequest();
            }
            _repo.Update(activiteit);
            _repo.SaveChanges();
            return NoContent();
        }
        // DELETE api/Activiteits/5
        [HttpDelete("{id}")]
        public ActionResult<Activiteit> Delete(int id)
        {
            Activiteit activiteit = _repo.GetActiviteitById(id);
            if (activiteit == null)
            {
                return NotFound();
            }

            _repo.Delete(activiteit);
            _repo.SaveChanges();
            return activiteit;
        }
    }
}