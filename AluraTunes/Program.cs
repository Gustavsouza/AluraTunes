using AluraTunes;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //listar os gêneros rock
        var generos = new List<Genero>
        {
            new Genero { Id = 1, Nome = "Rock"},
            new Genero { Id = 2, Nome =  "Reggae"},
            new Genero { Id = 3, Nome =  "Rock Progressivo"},
            new Genero { Id = 4, Nome =  "Punk"},
            new Genero { Id = 5, Nome =  "Clássica"}
        };

        foreach (var genero in generos)
        {
            if (genero.Nome.Contains("Rock"))
            {
                Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
            }
        }


        var query = from g in generos
                    where g.Nome.Contains("Rock")
                    select g;

        foreach (var genero in query)
        {
            Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
        }

        //listar músicas

        var musicas = new List<Musica>
{
    new Musica { Id = 1, Nome = "Sweet Child O'Mine", GeneroId = 1 },
    new Musica { Id = 2, Nome = "I Shoot The Sheriff", GeneroId = 2},
    new Musica { Id = 3, Nome = "Danúbio Azul", GeneroId = 5},
};

        //var musicaQuery = from m in musicas
        //                  select m;


        var musicQuery = from m in musicas
                         join g in generos on m.GeneroId equals g.Id
                         select new { m, g };

        foreach (var musica in musicQuery)
        {
            Console.WriteLine("{0}\t{1}\t{2}", musica.m.Id, musica.m.Nome, musica.m.GeneroId);
        }
    }
}

