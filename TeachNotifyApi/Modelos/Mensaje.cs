using System;
using System.Collections.Generic;

namespace TeachNotifyApi.Modelos
{
    public partial class Mensaje
    {
        public int IdMensajes { get; set; }
        public int IdAlumno { get; set; }
        public int IdDocente { get; set; }
        public string Mensajes { get; set; } = null!;
        public DateTime Fecha { get; set; }

        public virtual Alumno IdAlumnoNavigation { get; set; } = null!;
        public virtual Docente IdDocenteNavigation { get; set; } = null!;
    }
}
