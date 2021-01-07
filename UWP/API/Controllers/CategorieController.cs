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
    public class CategorieController : ControllerBase
    {
        private readonly ICategorieRepository _repo;

        public CategorieController(ICategorieRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Categorie
        [HttpGet]
        public IEnumerable<Categorie> GetCategories()
        {
            return _repo.GetCategories();
        }

        // GET: api/Categorie/5
        [HttpGet("{id}")]
        public Categorie GetCategorieById( int id)
        {
            return _repo.GetCategorieById(id);
        }

        // PUT: api/Categorie/5
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

        // POST: api/Categorie
        [HttpPost]
        public ActionResult<Categorie> Post(Categorie categorie)
        {
            _repo.Add(categorie);
            _repo.SaveChanges();

            return CreatedAtAction(nameof(GetCategorieById), new { id = categorie.Id }, categorie);
        }
        // DELETE: api/Categorie/5
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