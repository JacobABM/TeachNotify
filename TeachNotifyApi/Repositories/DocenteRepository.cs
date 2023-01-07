using Microsoft.EntityFrameworkCore;
using TeachNotifyApi.Repositories;
using TeachNotifyApi.Modelos;

namespace TeachNotifyApi.Repositories
{
    public class DocenteRepository : Repository<Docente>
    {
        public DocenteRepository(DbContext context) : base(context) { }

        public override IEnumerable<Docente> GetAll()
        {
            return base.GetAll();
        }
    }

}
