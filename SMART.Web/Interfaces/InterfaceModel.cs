namespace SMART.Web.Inferfaces
{
    public interface InterfaceModel<T> where T : class
    {
        List<T> SelecionarTodos();
        T SelecionarPk(params object[] variavel);
        T Incluir(T objeto);
        T Alterar(T objeto);
        void Excluir(T objeto);
        Task<T> IncluirAsync(T objeto);
        void Excluir(params object[] variavel);
        void SaveChanges();
    }
}
