using Microsoft.AspNetCore.Http;
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
    public class ClinicaController : ControllerBase
    {
        private readonly DbClinicaContext context;

        public ClinicaController(DbClinicaContext context)
        {
            this.context = context;
        }
         
        // Get
        [HttpGet]
        public ActionResult<IEnumerable<Clinica>> GetClinica()
        {
            return context.Clinicas.ToList();
        }
        
        //Get por Id
        [HttpGet("{id}")]
        public ActionResult<Clinica> GetByID(int id)
        {
            Clinica clinica = (from c in context.Clinicas
                               where id == c.ClinicaId
                               select c).SingleOrDefault();
            return clinica;
        }
       
        //UPDATE        
        [HttpPut("{id}")]
        public ActionResult Put(int id, Clinica clinica)
        {
            if (id != clinica.ClinicaId)
            {
                return BadRequest();
            }

            context.Entry(clinica).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //INSERT
        [HttpPost]
        public ActionResult Post(Clinica clinica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Clinicas.Add(clinica);
            context.SaveChanges();
            return Ok();
        }

        //DELETE        
        [HttpDelete("{id}")]
        public ActionResult<Clinica> Delete(int id)
        {
            var clinica = (from p in context.Clinicas
                           where p.ClinicaId == id
                           select p).SingleOrDefault();

            if (clinica == null)
            {
                return NotFound();
            }

            context.Clinicas.Remove(clinica);
            context.SaveChanges();
            return clinica;

        }
    }
}
