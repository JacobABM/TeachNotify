using Microsoft.EntityFrameworkCore;
using TeachNotifyApi.Repositories;
using TeachNotifyApi.Modelos;


namespace TeachNotifyApi.Repositories
{
    public class MensajeRepository : Repository<Mensaje>
    {
        public MensajeRepository(DbContext context) : base(context) { }

        public override IEnumerable<Mensaje> GetAll()
        {
             return Context.Set<Mensaje>().Include(x => x.IdAlumnoNavigation).Include(x => x.IdDocenteNavigation).OrderBy(x => x.IdMensajes);

        }

        public override void Insert(Mensaje entity)
        {
            entity.IdMensajes = 1;
            entity.IdDocente = 1;
            entity.IdAlumno = 1;
            base.Insert(entity);
            
        }

        public override void Update(Mensaje entity)
        {
            base.Update(entity);
        }

        public override void Delete(Mensaje entity)
        {
            base.Delete(entity);
        }


    }

}
