using GlobalSolution_.NET.Models;

namespace GlobalSolution_.NET.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(OracleDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Coordenadas.Count() == 0)
            {
                var coordenadas = new CoordenadasModel[]
                {
                new() {longitude = 45.0, latitude = -23.0},
                new CoordenadasModel {longitude = 120.0, latitude = 43.0},
                new CoordenadasModel {longitude = -100.0, latitude = -80.0},
                new CoordenadasModel {longitude = 9.0, latitude = 10.0},
                new CoordenadasModel {longitude = 180.0, latitude = 90.0},

                new CoordenadasModel {longitude = 78.0, latitude = 22.0},
                new CoordenadasModel {longitude = 57.0, latitude = 61.0},
                new CoordenadasModel {longitude = 45.0, latitude = -23.0},
                new CoordenadasModel {longitude = -48.0, latitude = 74.0},
                new CoordenadasModel {longitude = 129.0, latitude = 14.0}
                };

                foreach(var coord in  coordenadas)
                {
                    context.Coordenadas.Add(coord);
                }
                context.SaveChanges();
            }

            if (context.Tiporisco.Count() == 0)
            {
                var tiporiscos = new TiporiscoModel[]
                {
                    new TiporiscoModel {categoria = Enums.CategoriaRisco.VU},
                    new TiporiscoModel {categoria = Enums.CategoriaRisco.EN},
                    new TiporiscoModel {categoria = Enums.CategoriaRisco.VU},
                    new TiporiscoModel {categoria = Enums.CategoriaRisco.VU},
                    new TiporiscoModel {categoria = Enums.CategoriaRisco.EN},

                    new TiporiscoModel {categoria = Enums.CategoriaRisco.VU},
                    new TiporiscoModel {categoria = Enums.CategoriaRisco.CR},
                    new TiporiscoModel {categoria = Enums.CategoriaRisco.EN},
                    new TiporiscoModel {categoria = Enums.CategoriaRisco.VU},
                    new TiporiscoModel {categoria = Enums.CategoriaRisco.VU}
                };

                foreach (var tipos in tiporiscos)
                {
                    context.Tiporisco.Add(tipos);
                }
                context.SaveChanges();
            }

            if (context.Especie.Count() == 0) 
            {
                var especies = new EspecieModel[] 
                {
                    new EspecieModel {nome_comum = "Amaripim", especie = "Megalops atlanticus", id_risco = 1},
                    new EspecieModel {nome_comum = "Peixe-rei", especie = "Apareiodon davisi", id_risco = 2},
                    new EspecieModel {nome_comum = "Canivete", especie = "Apareiodon vladii", id_risco = 3},
                    new EspecieModel {nome_comum = "Desconhecido", especie = "Prochilodus Vimboides", id_risco = 4},
                    new EspecieModel {nome_comum = "Tumburé", especie = "Hypomasticus thayeri", id_risco = 5},

                    new EspecieModel {nome_comum = "Aracu", especie = "Leporinnus guttatus", id_risco = 6},
                    new EspecieModel {nome_comum = "Aracu", especie = "Leporinnus pitingai", id_risco = 7},
                    new EspecieModel {nome_comum = "Aracu-boca-pra-cima", especie = "Saitor tucuruiense", id_risco = 8},
                    new EspecieModel {nome_comum = "Desconhecido", especie = "Lebiasina marilynae", id_risco = 9},
                    new EspecieModel {nome_comum = "Desconhecido", especie = "Lebiasina melanoguttata", id_risco = 10}
                };
                foreach (var esp in especies)
                {
                    context.Especie.Add(esp);
                }
                context.SaveChanges();
            };

            if (context.Deteccao.Count() == 0)
            {
                var deteccoes = new DeteccaoModel[]
                {
                    new DeteccaoModel {data = DateTime.Now, id_coordenadas = 1, id_especie = 1},
                    new DeteccaoModel {data = DateTime.Now, id_coordenadas = 2, id_especie = 2},
                    new DeteccaoModel {data = DateTime.Now, id_coordenadas = 3, id_especie = 3},
                    new DeteccaoModel {data = DateTime.Now, id_coordenadas = 4, id_especie = 4},
                    new DeteccaoModel {data = DateTime.Now, id_coordenadas = 5, id_especie = 5},

                    new DeteccaoModel {data = DateTime.Now, id_coordenadas = 6, id_especie = 6},
                    new DeteccaoModel {data = DateTime.Now, id_coordenadas = 7, id_especie = 7},
                    new DeteccaoModel {data = DateTime.Now, id_coordenadas = 8, id_especie = 8},
                    new DeteccaoModel {data = DateTime.Now, id_coordenadas = 9, id_especie = 9},
                    new DeteccaoModel {data = DateTime.Now, id_coordenadas = 10, id_especie = 10}
                };
                foreach (var deteccao in deteccoes)
                {
                    context.Deteccao.Add(deteccao);
                }
                context.SaveChanges();
            }
        }

    }
}
