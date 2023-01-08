using System;
using System.Collections.Generic;

namespace TeachNotifyApi.Modelos
{
    public partial class Alumno
    {
        public Alumno()
        {
            Mensajes = new HashSet<Mensaje>();
        }

        public int IdAlumno { get; set; }
        public string NombreAlumno { get; set; } = null!;

        public virtual ICollection<Mensaje> Mensajes { get; set; }
    }
}
