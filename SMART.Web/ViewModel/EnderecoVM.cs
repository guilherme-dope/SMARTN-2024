using SMART.Web.Models;

namespace SMART.Web.ViewModel
{
    public class EnderecoVM
    {
        public int CodigoEndereco { get; set; }
        public int CodigoUsuario { get; set; }
        public string? Nome { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }

        public EnderecoVM()
        {

        }

        public static EnderecoVM SelecionarUsuario(int id)
        {
            var db = new SMARTNContext();
            var usuario = db.Usuarios.Find(id);

            var endereco = db.Enderecos.FirstOrDefault(x => x.Enidusuario == id);

            var retorno = new EnderecoVM()
            {
                CodigoEndereco = endereco.Enid,
                CodigoUsuario = id,
                Nome = db.Usuarios.FirstOrDefault(x => x.Usid == id).Usnome,
                Bairro = endereco.Enbairro,
                CEP = endereco.Encep,
                Cidade = endereco.Encidade,
                Complemento = endereco.Encomplemento,
                Estado = endereco.Enestado,
                Logradouro = endereco.Enlogradouro,
                Numero = endereco.Ennumero
            };

            return retorno;

        }

        public static List<EnderecoVM> ListarEnderecos()
        {
            var db = new SMARTNContext();
            var listaRetorno = new List<EnderecoVM>();
            var enderecos = db.Enderecos.ToList();

            foreach (var endereco in enderecos)
            {
                var usuario = db.Usuarios.FirstOrDefault(x => x.Usid == endereco.Enidusuario);
                var retorno = new EnderecoVM()
                {
                    Bairro = endereco.Enbairro,
                    CEP = endereco.Encep,
                    Cidade = endereco.Encidade,
                    CodigoEndereco = endereco.Enid,
                    CodigoUsuario = usuario.Usid,
                    Complemento = endereco.Encomplemento,
                    Estado = endereco.Enestado,
                    Logradouro = endereco.Enlogradouro,
                    Nome = db.Usuarios.FirstOrDefault(x => x.Usid == endereco.Enidusuario).Usnome,
                    Numero = endereco.Ennumero
                };
                listaRetorno.Add(retorno);
            }
            return listaRetorno;
        }

        public static EnderecoVM PesquisarEndereco(int id)
        {
            var db = new SMARTNContext();
            var endereco = db.Enderecos.FirstOrDefault(x => x.Enid == id);
            var usuario = db.Usuarios.FirstOrDefault(x => x.Usid == endereco.Enidusuario);
            var retorno = new EnderecoVM();

            if (endereco != null)
            {
                retorno.Bairro = endereco.Enbairro;
                retorno.CEP = endereco.Encep;
                retorno.Cidade = endereco.Encidade;
                retorno.CodigoEndereco = endereco.Enid;
                retorno.CodigoUsuario = usuario.Usid;
                retorno.Complemento = endereco.Encomplemento;
                retorno.Estado = endereco.Enestado;
                retorno.Logradouro = endereco.Enlogradouro;
                retorno.Nome = db.Usuarios.FirstOrDefault(x => x.Usid == endereco.Enidusuario).Usnome;
                retorno.Numero = endereco.Ennumero;
            }
            return retorno;
        }
    }
}
