using Microsoft.EntityFrameworkCore;
using TeachNotifyApi.Repositories;
using TeachNotifyApi.Modelos;


namespace TeachNotifyApi.Repositories
{
    public class AlumnoRepository : Repository<Alumno>
    {
        public AlumnoRepository(DbContext context) : base(context) { }

        public override IEnumerable<Alumno> GetAll()
        {
            return base.GetAll();
        }
    }

}
