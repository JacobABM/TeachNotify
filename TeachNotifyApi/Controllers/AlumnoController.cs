using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TeachNotifyApi.Repositories;
using TeachNotifyApi.Modelos;

namespace TeachNotifyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        public itesrcne_teachnotifyContext Context { get; set; }

        AlumnoRepository repo;

        public AlumnoController(itesrcne_teachnotifyContext con)
        {
            Context = con;
            repo = new AlumnoRepository(Context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alumnos = repo.GetAll();
            return Ok(alumnos.Select(x => new
            {
                x.IdAlumno,
                x.NombreAlumno,
            }
         )) ;
        }
    }
}
       