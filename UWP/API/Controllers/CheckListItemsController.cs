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
    public class CheckListItemsController : ControllerBase
    {
        private readonly ICheckListItemRepository _repo;

        public CheckListItemsController(ICheckListItemRepository repo)
        {
            _repo = repo;

        }

        // GET: api/CheckListItems
        [HttpGet]
        public IEnumerable<CheckListItem> GetCheckListItems()
        {
            return _repo.GetCheckListItems();
        }

        // GET: api/CheckListItems/5
        [HttpGet("{id}")]
        public CheckListItem GetCheckListItem([FromRoute] int id)
        {
            return _repo.GetCheckListItemById(id);
        }

        // PUT: api/CheckListItems/5
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
        // POST: api/CheckListItems
        [HttpPost]
        public ActionResult<CheckListItem> Post(CheckListItem checklistitem)
        {
            _repo.Add(checklistitem);
            _repo.SaveChanges();

            return CreatedAtAction(nameof(GetCheckListItem), new { id = checklistitem.Id }, checklistitem);
        }
        // DELETE: api/CheckListItems/5
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