using System;
using System.Collections.Generic;

namespace TeachNotifyApi.Modelos
{
    public partial class Docente
    {
        public Docente()
        {
            Mensajes = new HashSet<Mensaje>();
        }

        public int IdDocentes { get; set; }
        public int IdAlumnos { get; set; }
        public int IdMensajes { get; set; }
        public string NombreDocente { get; set; } = null!;

        public virtual ICollection<Mensaje> Mensajes { get; set; }
    }
}
