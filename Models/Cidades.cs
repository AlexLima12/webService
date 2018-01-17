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

        //metodo que cria e retorna lista
        public List<Cidades> Listar()
        {
            return new List<Cidades>(){
                new Cidades(10,"Leme","SP",154),
                new Cidades(51,"Curitiba","PR",547),
                new Cidades(22,"Itu","SP",4578),
                new Cidades(58,"Santos","SP",6589)
            };
        }
    }
}