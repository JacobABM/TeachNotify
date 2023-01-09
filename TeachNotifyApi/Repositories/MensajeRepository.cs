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

        public Mensaje? GetbyId(int id)
        {
            return Context
                .Set<Mensaje>()
                .Include(x => x.IdAlumnoNavigation)
                .Include(x => x.IdDocenteNavigation)
                .FirstOrDefault(x => x.IdMensajes == id);
        }

        public override void Insert(Mensaje entity)
        {         
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
