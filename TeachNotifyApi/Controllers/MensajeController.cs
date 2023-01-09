using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TeachNotifyApi.Repositories;
using TeachNotifyApi.Modelos;
using TeachNotifyApi.Controllers;

namespace TeachNotifyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensajeController : ControllerBase
    {
        public itesrcne_teachnotifyContext Context { get; set; }

        MensajeRepository repo;

        public MensajeController(itesrcne_teachnotifyContext con)
        {
            Context = con;
            repo = new MensajeRepository(Context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var mensajes = repo.GetAll();
            return Ok(mensajes.Select(x => new
            {
                x.IdMensajes,
                x.IdAlumnoNavigation.NombreAlumno,
                x.IdDocenteNavigation.NombreDocente,
                x.Mensajes,
                x.Fecha
            }
         ));
        }

        [HttpPost("AgregarMensaje")]
        public IActionResult Post([FromBody] Mensaje x)
        {
            try
            {

                    repo.Insert(x);
                    return Ok(new
                    {
                        x.IdMensajes,
                        x.IdAlumno,
                        x.IdDocente,    
                        x.Mensajes,
                        x.Fecha
                    });
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null) { return StatusCode(500, ex.InnerException.Message); }
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("EditarMensaje")]
        public IActionResult Put([FromBody] Mensaje mj)
        {
            try
            {
                var aviso = repo.GetPut(mj.IdMensajes);
                if (aviso != null)
                {
                    aviso.Mensajes = mj.Mensajes;
                    repo.Update(aviso);
                    return Ok();
                }
            
                else { NotFound(); }
            }
           
            catch (Exception ex)
            {
                if (ex.InnerException != null) { return StatusCode(500, ex.InnerException.Message);
            }
                return StatusCode(500, ex.Message);
            }
            return BadRequest();
        }

        [HttpDelete("EliminarMensaje")]
        public IActionResult Delete([FromBody] Mensaje mj)
        {
            try
            {
                var aviso = repo.GetPut(mj.IdMensajes);
                if (aviso != null)
                {
                    repo.Delete(aviso);
                    return Ok();
                }
                else { NotFound(); }

                return BadRequest();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null) { return StatusCode(500, ex.InnerException.Message); }
                return StatusCode(500, ex.Message);
            }
        }



    }
}