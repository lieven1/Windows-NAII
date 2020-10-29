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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategorieRepository _repo;

        public CategoriesController(ICategorieRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Categorie> GetCategories()
        {
            return _repo.GetCategories();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public Categorie GetCategorieById( int id)
        {
            return _repo.GetCategorieById(id);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Categorie categorie)
        {
            if (id != categorie.Id)
            {
                return BadRequest();
            }
            _repo.Update(categorie);
            _repo.SaveChanges();
            return NoContent();
        }

        // POST: api/Categories
        [HttpPost]
        public ActionResult<Categorie> Post(Categorie categorie)
        {
            _repo.Add(categorie);
            _repo.SaveChanges();

            return CreatedAtAction(nameof(GetCategorieById), new { id = categorie.Id }, categorie);
        }
        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public ActionResult<Categorie> Delete(int id)
        {
            Categorie categorie = _repo.GetCategorieById(id);
            if (categorie == null)
            {
                return NotFound();
            }

            _repo.Delete(categorie);
            _repo.SaveChanges();
            return categorie;
        }


      
    }
}