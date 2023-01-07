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
                x.IdMensajes              
            }
         ));
        }
    }
}