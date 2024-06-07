using GlobalSolution_.NET.Models;
using GlobalSolution_.NET.Persistence;

namespace GlobalSolution_.NET.Repositories
{
    public class CoordenadasRepository : ICoordenadasRepository
    {
        private readonly OracleDbContext _bancoContext;

        public CoordenadasRepository(OracleDbContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public CoordenadasModel ListarPorId(int id_coordenadas)
        {
            return _bancoContext.Coordenadas.FirstOrDefault(x => x.id_coordenadas == id_coordenadas);
        }

        public List<CoordenadasModel> BuscarTodos()
        {
            return _bancoContext.Coordenadas.ToList();
        }

        public CoordenadasModel Adicionar(CoordenadasModel coordenadas)
        {
            _bancoContext.Coordenadas.Add(coordenadas);
            _bancoContext.SaveChanges();
            return coordenadas;
        }

        public CoordenadasModel Atualizar (CoordenadasModel coordenadas)
        {
            CoordenadasModel coordenadasDb = ListarPorId(coordenadas.id_coordenadas);

            if (coordenadasDb == null) throw new Exception("Erro ao atualizar as coordenadas!");

            coordenadasDb.longitude = coordenadas.longitude;
            coordenadasDb.latitude = coordenadas.latitude;

            _bancoContext.Coordenadas.Update(coordenadasDb);
            _bancoContext.SaveChanges();
            return coordenadasDb;
        }

        public bool Apagar(int id_coordenadas)
        {
            CoordenadasModel coordenadasDb = ListarPorId(id_coordenadas);

            if (coordenadasDb == null) throw new Exception("Erro ao apagar as coordenadas!");

            _bancoContext.Coordenadas.Remove(coordenadasDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
