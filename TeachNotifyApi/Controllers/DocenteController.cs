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
    public class DocenteController : ControllerBase
    {
        public itesrcne_teachnotifyContext Context { get; set; }

        DocenteRepository repo;

        public DocenteController(itesrcne_teachnotifyContext con)
        {
            Context = con;
            repo = new DocenteRepository(Context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var docentes = repo.GetAll();
            return Ok(docentes.Select(x => new
            {
                x.IdDocente,
                x.NombreDocente
            }
         ));
        }
    }
}