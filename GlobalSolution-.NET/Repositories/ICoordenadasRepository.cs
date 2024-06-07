using GlobalSolution_.NET.Models;

namespace GlobalSolution_.NET.Repositories
{
    public interface ICoordenadasRepository
    {
        CoordenadasModel ListarPorId(int id_coordenadas);
        List<CoordenadasModel> BuscarTodos();
        CoordenadasModel Adicionar(CoordenadasModel coordenadas);
        CoordenadasModel Atualizar(CoordenadasModel coordenadas);
        bool Apagar(int id_coordenadas);
    }
}
