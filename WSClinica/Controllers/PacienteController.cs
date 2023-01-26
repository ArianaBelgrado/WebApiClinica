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
    public class PacienteController : ControllerBase
    {
        private readonly DbClinicaContext context;

        public PacienteController(DbClinicaContext context)
        {
            this.context = context;
        }

        // Get
        [HttpGet]
        public ActionResult<IEnumerable<Paciente>> GetClinica()
        {
            return context.Pacientes.ToList();
        }

        //Get por Id
        [HttpGet("{id}")]
        public ActionResult<Paciente> GetByID(int id)
        {
            Paciente paciente = (from p in context.Pacientes
                                 where id == p.PacienteId
                                 select p).SingleOrDefault();
            return paciente;
        }

        //UPDATE
        //PUT api/autor/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, Paciente paciente)
        {
            if (id != paciente.PacienteId)
            {
                return BadRequest();
            }

            context.Entry(paciente).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //INSERT
        [HttpPost]
        public ActionResult Post(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Pacientes.Add(paciente);
            context.SaveChanges();
            return Ok();
        }

        //DELETE
        //DELETE api/autor/{id}
        [HttpDelete("{id}")]
        public ActionResult<Paciente> Delete(int id)
        {
            var paciente = (from p in context.Pacientes
                            where p.PacienteId == id
                            select p).SingleOrDefault();

            if (paciente == null)
            {
                return NotFound();
            }

            context.Pacientes.Remove(paciente);
            context.SaveChanges();

            return paciente;
        }
    }
}
