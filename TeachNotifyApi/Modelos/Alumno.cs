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

        public int IdAlumnos { get; set; }
        public int IdDocentes { get; set; }
        public int IdMensajes { get; set; }
        public string NombreAlumnos { get; set; } = null!;

        public virtual ICollection<Mensaje> Mensajes { get; set; }
    }
}
