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
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ActiviteitController : ControllerBase
    {
        private readonly IActiviteitsRepository _repo;

        public ActiviteitController(IActiviteitsRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Activiteit
        [HttpGet]
        public IEnumerable<Activiteit> GetActiviteit()
        {
            return _repo.GetActiviteiten();
        }

        // GET: api/Activiteit/5
        
        [HttpGet("{id}")]
        public Activiteit GetById(int id)
        {
            return _repo.GetActiviteitById(id);
        }
        // POST: api/Activiteit
        [HttpPost]
        public ActionResult<Activiteit> Post(Activiteit activiteit)
        {
            _repo.Add(activiteit);
            _repo.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = activiteit.Id }, activiteit);
        }
        // PUT api/Activiteit/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Activiteit activiteit)
        {
            if (id != activiteit.Id)
            {
                return BadRequest();
            }
            _repo.Update(activiteit);
            _repo.SaveChanges();
            return NoContent();
        }
        // DELETE api/Activiteit/5
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