using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecklistsController : ControllerBase
    {
        private readonly ICheckListRepository _repo;

        public ChecklistsController(ICheckListRepository repo)
        {
            _repo = repo; ;
        }

        // GET: api/Checklists
        [HttpGet]
        public IEnumerable<Checklist> GetChecklisten()
        {
            return _repo.GetChecklisten();
        }

        // GET: api/Checklists/5
        [HttpGet("{id}")]
        public Checklist GetChecklist([FromRoute] int id)
        {
            return _repo.GetChecklistById(id);
        }
        // PUT api/Checklists/5
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
        // POST: api/Checklists
        [HttpPost]
        public ActionResult<Checklist> Post(Checklist checklist)
        {
            _repo.Add(checklist);
            _repo.SaveChanges();

            return CreatedAtAction(nameof(GetChecklist), new { id = checklist.Id }, checklist);
        }
        // DELETE api/Activiteits/5
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