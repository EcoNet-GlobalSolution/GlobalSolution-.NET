using GlobalSolution_.NET.Models;

namespace GlobalSolution_.NET.Repositories
{
    public interface ITiporiscoRepository
    {
        TiporiscoModel ListarPorId(int id_risco);
        List<TiporiscoModel> BuscarTodos();
        TiporiscoModel Adicionar(TiporiscoModel risco);
        TiporiscoModel Atualizar(TiporiscoModel risco);
        bool Apagar(int id_risco);
    }
}
