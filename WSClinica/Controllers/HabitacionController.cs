using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WSClinica.Data;
using WSClinica.Models;
using Microsoft.EntityFrameworkCore;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private DbClinicaContext context;

        public HabitacionController(DbClinicaContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Habitacion>> Get()
        {
            return context.Habitaciones.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Habitacion> Get(int id)
        {
            return context.Habitaciones.Find(id);
        }

        [HttpPost]
        public ActionResult Create(Habitacion habitacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            context.Habitaciones.Add(habitacion);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Habitacion habitacion)
        {
            if (id != habitacion.HabitacionId)
            {
                return BadRequest();
            }
            context.Entry(habitacion).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Habitacion> Delete(int id)
        {
            var habitacion = context.Habitaciones.Find(id);

            if(habitacion == null)
            {
                return NotFound();
            }

            context.Habitaciones.Remove(habitacion);
            context.SaveChanges();
            return habitacion;
        }
    }
}
