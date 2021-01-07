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
    public class ChecklistController : ControllerBase
    {
        private readonly ICheckListRepository _repo;

        public ChecklistController(ICheckListRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Checklist
        [HttpGet]
        public IEnumerable<Checklist> GetChecklisten()
        {
            return _repo.GetChecklisten();
        }

        // GET: api/Checklist/5
        [HttpGet("{id}")]
        public Checklist GetChecklist([FromRoute] int id)
        {
            return _repo.GetChecklistById(id);
        }
        // PUT api/Checklist/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Checklist checklist)
        {
            if (id != checklist.Id)
            {
                return BadRequest();
            }
            _repo.Update(checklist);
            _repo.SaveChanges();
            return NoContent();
        }
        // POST: api/Checklist
        [HttpPost]
        public ActionResult<Checklist> Post(Checklist checklist)
        {
            _repo.Add(checklist);
            _repo.SaveChanges();

            return CreatedAtAction(nameof(GetChecklist), new { id = checklist.Id }, checklist);
        }
        // DELETE api/Activiteit/5
        [HttpDelete("{id}")]
        public ActionResult<Checklist> Delete(int id)
        {
            Checklist checklist = _repo.GetChecklistById(id);
            if (checklist == null)
            {
                return NotFound();
            }

            _repo.Delete(checklist);
            _repo.SaveChanges();
            return checklist;
        }
        
    }
}