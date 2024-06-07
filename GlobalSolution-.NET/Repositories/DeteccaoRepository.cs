using GlobalSolution_.NET.Models;
using GlobalSolution_.NET.Persistence;

namespace GlobalSolution_.NET.Repositories
{
    public class DeteccaoRepository : IDeteccaoRepository
    {
        private readonly OracleDbContext _bancoContext;

        public DeteccaoRepository(OracleDbContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public DeteccaoModel ListarPorId(int id_deteccao)
        {
            return _bancoContext.Deteccao.FirstOrDefault(x => x.id_deteccao == id_deteccao);
        }

        public List<DeteccaoModel> BuscarTodos()
        {
            return _bancoContext.Deteccao.ToList();
        }

        public DeteccaoModel Adicionar(DeteccaoModel deteccao)
        {
            _bancoContext.Deteccao.Add(deteccao);
            _bancoContext.SaveChanges();
            return deteccao;
        }

        public DeteccaoModel Atualizar(DeteccaoModel deteccao)
        {
            DeteccaoModel deteccaoDb = ListarPorId(deteccao.id_deteccao);
            if (deteccaoDb == null) throw new Exception("Erro ao atualizar a detecção.");

            deteccaoDb.data = deteccao.data;
            
            _bancoContext.Deteccao.Update(deteccaoDb);
            _bancoContext.SaveChanges();
            return deteccaoDb;
        }

        public bool Apagar(int id_deteccao)
        {
            DeteccaoModel deteccaoDb = ListarPorId(id_deteccao);

            if (deteccaoDb == null) throw new Exception("Erro ao apagar detecção.");

            _bancoContext.Deteccao.Remove(deteccaoDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
