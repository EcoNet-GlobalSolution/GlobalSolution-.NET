using GlobalSolution_.NET.Models;
using GlobalSolution_.NET.Persistence;

namespace GlobalSolution_.NET.Repositories
{
    public class TiporiscoRepository : ITiporiscoRepository
    {
        private readonly OracleDbContext _bancoContext;

        public TiporiscoRepository(OracleDbContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public TiporiscoModel ListarPorId(int id_risco)
        {
            return _bancoContext.Tiporisco.FirstOrDefault(x => x.id_risco == id_risco);
        }

        public List<TiporiscoModel> BuscarTodos()
        {
            return _bancoContext.Tiporisco.ToList();
        }

        public TiporiscoModel Adicionar(TiporiscoModel tiporiscos)
        {
            _bancoContext.Tiporisco.Add(tiporiscos);
            _bancoContext.SaveChanges();
            return tiporiscos;
        }

        public TiporiscoModel Atualizar (TiporiscoModel tiporiscos)
        {
            TiporiscoModel tiporiscoDb = ListarPorId(tiporiscos.id_risco);

            if (tiporiscoDb == null) throw new Exception("Erro ao atualizar Tipo risco.");

            tiporiscoDb.categoria = tiporiscos.categoria;

            _bancoContext.Tiporisco.Update(tiporiscoDb);
            _bancoContext.SaveChanges();

            return tiporiscoDb;
        }

        public bool Apagar(int id_risco)
        {
            TiporiscoModel tiporiscoDb = ListarPorId(id_risco);

            if (tiporiscoDb == null) throw new Exception("Erro ao apagar Tipo risco");

            _bancoContext.Remove(tiporiscoDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
