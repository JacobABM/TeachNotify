using System;
using System.Collections.Generic;

namespace TeachNotifyApi.Modelos
{
    public partial class Mensaje
    {
        public int IdMensajes { get; set; }
        public int IdAlumnos { get; set; }
        public int IdDocentes { get; set; }
        public string Mensajes { get; set; } = null!;
        public DateTime Fecha { get; set; }

        public virtual Alumno IdAlumnosNavigation { get; set; } = null!;
        public virtual Docente IdDocentesNavigation { get; set; } = null!;
    }
}
