using System.Collections.Generic;

namespace projetoWebServices.Models
{
    public class Cidades
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public int Habitantes { get; set; }

        //construtor vazio
        public Cidades()
        {

        }

        //construtor passando dados
        public Cidades(int Id, string Nome, string Estado, int Habitantes)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Estado = Estado;
            this.Habitantes = Habitantes;

        }

    }
}