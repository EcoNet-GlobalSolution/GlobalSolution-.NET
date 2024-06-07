using GlobalSolution_.NET.Models;

namespace GlobalSolution_.NET.Repositories
{
    public interface IEspecieRepository
    {
        EspecieModel ListarPorId(int id_especie);
        List<EspecieModel> BuscarTodos();
        EspecieModel Adicionar(EspecieModel especie);
        EspecieModel Atualizar(EspecieModel especie);
        bool Apagar(int id_especie);
    }
}
