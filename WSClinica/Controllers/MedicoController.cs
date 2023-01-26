using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WSClinica.Data;
using WSClinica.Models;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly DbClinicaContext context;

        public MedicoController(DbClinicaContext context)
        {
            this.context = context;
        }

        // Get
        [HttpGet]
        public ActionResult<IEnumerable<Medico>> GetClinica()
        {
            return context.Medicos.ToList();
        }

        //Get por Id
        [HttpGet("{id}")]
        public ActionResult<Medico> GetByID(int id)
        {
            Medico medico = (from m in context.Medicos
                             where id == m.MedicoId
                             select m).SingleOrDefault();
            return medico;
        }

        //Put                        
        [HttpPut("{id}")]
        public ActionResult Put(int id, Medico m)
        {
            if (id != m.MedicoId)
            {
                return BadRequest();
            }

            context.Entry(m).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //Post
        [HttpPost]
        public ActionResult Post(Medico m)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Medicos.Add(m);
            context.SaveChanges();
            return Ok();
        }

        //Delete
        [HttpDelete("{id}")]
        public ActionResult<Medico> Delete(int id)
        {
            var medico = (from m in context.Medicos
                          where m.MedicoId == id
                          select m).SingleOrDefault();

            if (medico == null)
            {
                return NotFound();
            }

            context.Medicos.Remove(medico);
            context.SaveChanges();

            return medico;
        }
    }
}
