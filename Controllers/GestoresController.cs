using ApiProyecto1002.Context;
using ApiProyecto1002.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProyecto1002.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {


        private readonly AppDbContext context;

        public GestoresController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]

        public ActionResult Get()
        {
            try
            {
                return Ok(context.usuarios.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // GET api/<Store>/5
        [HttpGet("{id}", Name = "Usuarios")]
        public ActionResult Get(int id)
        {
            try
            {
                var user = context.usuarios.FirstOrDefault(x => x.id == id);
                return Ok(user);
            }
            catch (Exception ex) //Atrapar los datos y mandarlos a la base de datos 
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<Store>
        [HttpPost]
        public ActionResult Post([FromBody] usuarios user)
        {
            try
            {
                context.usuarios.Add(user);
                context.SaveChanges();
                return CreatedAtRoute("Usuarios", new { id = user.id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<Store>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] usuarios user)
        {
            try
            {
                if (user.id == id)
                {
                    context.Entry(user).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("Usuarios", new { id = user.id }, user);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<Store>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var user = context.usuarios.FirstOrDefault(x => x.id == id);
                if (user != null)
                {
                    context.usuarios.Remove(user);
                    context.SaveChanges();
                    return Ok(id);

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
