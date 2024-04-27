using SMART.Web.Interfaces;
using SMART.Web.Models;


namespace SMART.Web.Repositories
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IUsuario
    {
        public RepositoryUsuario(bool SaveChanges = true) : base(SaveChanges)
        {

        }

    }
}
