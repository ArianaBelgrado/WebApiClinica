using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WSClinica.Data;
using WSClinica.Models;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly DbClinicaContext context;

        public EspecialidadController(DbClinicaContext context)
        {
            this.context = context;
        }
       
        // Get
        [HttpGet]
        public ActionResult<IEnumerable<Especialidad>> GetClinica()
        {
            return context.Especialidades.ToList();
        }

        //Get por Id
        [HttpGet("{id}")]
        public ActionResult<Especialidad> GetByID(int id)
        {
            Especialidad especialidad = (from c in context.Especialidades
                                         where id == c.EspecialidadId
                                         select c).SingleOrDefault();
            return especialidad;
        }        
       
        //Put
        [HttpPut("{id}")]
        public ActionResult Put(int id, Especialidad especialidad)
        {
            if (id != especialidad.EspecialidadId)
            {
                return BadRequest();
            }

            context.Entry(especialidad).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //Post
        [HttpPost]
        public ActionResult Post(Especialidad e)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Especialidades.Add(e);
            context.SaveChanges();
            return Ok();
        }

        //Delete
        [HttpDelete("{id}")]
        public ActionResult<Especialidad> Delete(int id)
        {
            var especialidad = (from e in context.Especialidades
                                where e.EspecialidadId == id
                                select e).SingleOrDefault();

            if (especialidad == null)
            {
                return NotFound();
            }

            context.Especialidades.Remove(especialidad);
            context.SaveChanges();

            return especialidad;
        }
    }
}
