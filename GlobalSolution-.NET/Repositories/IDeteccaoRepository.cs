using GlobalSolution_.NET.Models;

namespace GlobalSolution_.NET.Repositories
{
    public interface IDeteccaoRepository
    {
        DeteccaoModel ListarPorId(int id_deteccao);
        List<DeteccaoModel> BuscarTodos();
        DeteccaoModel Adicionar(DeteccaoModel deteccao);
        DeteccaoModel Atualizar(DeteccaoModel deteccao);
        bool Apagar(int id_deteccao);
    }
}
