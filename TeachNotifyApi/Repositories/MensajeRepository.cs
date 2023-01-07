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
            return base.GetAll();
        }
    }

}
