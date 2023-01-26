using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApiLibros.Data;
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly DbLibrosContext context;

        public LibroController(DbLibrosContext context)
        {
            this.context = context;
        }
        // Get
        [HttpGet]
        public ActionResult<IEnumerable<Libro>> GetAll()
        {
            return context.Libros.ToList();
        }

        //GET por id 
        [HttpGet("{id}")]
        public ActionResult<Libro> GetbyId(int id)
        {
            var libro = (from c in context.Libros
                                     where c.LibroId == id
                                     select c).SingleOrDefault();

            return libro;

        }

        //UPDATE
        //PUT api/libro/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, Libro libro)
        {
            if (id != libro.LibroId)
            {
                return BadRequest();
            }

            context.Entry(libro).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //INSERT
        [HttpPost]
        public ActionResult Post(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Libros.Add(libro);
            context.SaveChanges();
            return Ok();
        }

        //DELETE
        //DELETE api/libro/{id}
        [HttpDelete("{id}")]
        public ActionResult<Libro> Delete(int id)
        {
            var libro = (from c in context.Libros
                             where c.LibroId == id
                             select c).SingleOrDefault();

            if (libro == null)
            {
                return NotFound();
            }

            context.Libros.Remove(libro);
            context.SaveChanges();

            return libro;
        }
    }


}
