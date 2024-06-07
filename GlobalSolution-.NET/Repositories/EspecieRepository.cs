using GlobalSolution_.NET.Models;
using GlobalSolution_.NET.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution_.NET.Repositories
{
    public class EspecieRepository : IEspecieRepository
    {
        private readonly OracleDbContext _bancoContext;

        public EspecieRepository(OracleDbContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public EspecieModel ListarPorId(int id_especie)
        {
            return _bancoContext.Especie.FirstOrDefault(x => x.id_especie == id_especie);
        }

        public List<EspecieModel> BuscarTodos()
        {
            return _bancoContext.Especie.ToList();
        }

        public EspecieModel Adicionar(EspecieModel especies)
        {
            _bancoContext.Especie.Add(especies);
            _bancoContext.SaveChanges();
            return especies;
        }

        public EspecieModel Atualizar(EspecieModel especies)
        {
            EspecieModel especieDb = ListarPorId(especies.id_especie);

            if (especieDb == null)
            {
                throw new Exception("Espécie não encontrada.");
            }

            especieDb.nome_comum = especies.nome_comum;
            especieDb.especie = especies.especie;

            try
            {
                _bancoContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar a atualização da espécie no banco de dados: " + ex.Message);
            }

            return especieDb;
        }


        public bool Apagar(int id_especie)
        {
            EspecieModel especieDb = ListarPorId(id_especie);

            if (especieDb == null) throw new Exception("Erro ao atualizar espécie.");

            _bancoContext.Remove(especieDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
