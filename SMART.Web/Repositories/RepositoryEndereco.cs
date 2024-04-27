using SMART.Web.Interfaces;
using SMART.Web.Models;

namespace SMART.Web.Repositories
{
    public class RepositoryEndereco : RepositoryBase<Endereco>, IEndereco
    {
        public RepositoryEndereco(bool SaveChanges = true) : base(SaveChanges)
        {

        }

    }
}
