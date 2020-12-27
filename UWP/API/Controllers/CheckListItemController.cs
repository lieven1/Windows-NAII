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
    public class CheckListItemController : ControllerBase
    {
        private readonly ICheckListItemRepository _repo;

        public CheckListItemController(ICheckListItemRepository repo)
        {
            _repo = repo;

        }

        // GET: api/CheckListItem
        [HttpGet]
        public IEnumerable<CheckListItem> GetCheckListItems()
        {
            return _repo.GetCheckListItems();
        }

        // GET: api/CheckListItem/5
        [HttpGet("{id}")]
        public CheckListItem GetCheckListItem([FromRoute] int id)
        {
            return _repo.GetCheckListItemById(id);
        }

        // PUT: api/CheckListItem/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, CheckListItem checkListItem)
        {
            if (id != checkListItem.Id)
            {
                return BadRequest();
            }
            _repo.Update(checkListItem);
            _repo.SaveChanges();
            return NoContent();
        }
        // POST: api/CheckListItem
        [HttpPost]
        public ActionResult<CheckListItem> Post(CheckListItem checklistitem)
        {
            _repo.Add(checklistitem);
            _repo.SaveChanges();

            return CreatedAtAction(nameof(GetCheckListItem), new { id = checklistitem.Id }, checklistitem);
        }
        // DELETE: api/CheckListItem/5
        [HttpDelete("{id}")]
        public ActionResult<CheckListItem> Delete(int id)
        {
            CheckListItem checklistItem = _repo.GetCheckListItemById(id);
            if (checklistItem == null)
            {
                return NotFound();
            }

            _repo.Delete(checklistItem);
            _repo.SaveChanges();
            return checklistItem;
        }

    }
}