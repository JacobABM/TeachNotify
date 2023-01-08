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

        public int IdDocente { get; set; }
        public string NombreDocente { get; set; } = null!;

        public virtual ICollection<Mensaje> Mensajes { get; set; }
    }
}
