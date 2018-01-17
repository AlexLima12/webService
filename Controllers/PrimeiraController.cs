using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using projetoWebServices.Models;

namespace projetoWebServices.Controllers
{
    //definindo a rota para a requisição do serviço nesse caso api/nome do controler
    [Route("api/[controller]")]
    public class PrimeiraController : Controller
    {
        // //metodo get com parametro id
        // [HttpGet("{id}")]

        // //action que enumera uma string
        // //sobrecarga de requisição
        // public string Get(int id)
        // {
        //     //retornar um elemento do array de cidades de acordo com o paramentro id
        //     return new string[]{
        //         "Curitiba",
        //         "Porto Alegra",
        //         "Salvador",
        //         "Belo Horizonte"
        //     }[id];
        // }

        // //metodo get
        // [HttpGet]

        // //action que enumera uma lista de string string
        // public IEnumerable<string> Get()
        // {
        //     //retornar um elemento do array de cidades
        //     return new string[]{
        //         "Curitiba",
        //         "Porto Alegra",
        //         "Salvador",
        //         "Belo Horizonte"
        //     };
        // }

        //instanciando classe
        DAOCidades cidades = new DAOCidades();
        //requisição get
        [HttpGet]

        //action que enumera elementos de uma lista
        public IEnumerable<Cidades> Get()
        {
            //retornando dados da lista
            return cidades.Listar();
        }

        //requisição get com parametro e com nome para ser usado como rota
        [HttpGet("{Id}",Name="cidadeAtual")]
        //action que retonar um obj Cidades e recebe um parametro do EndPoint
        public Cidades Get(int Id)
        {
            //retornando metodo e filtrando com Linq e Lambda
            return cidades.Listar().Where(c => c.Id == Id).FirstOrDefault();
        }

        //meto post
        // [HttpPost]
        // //pegando dados do body da pagina
        // public bool Cadastrar([FromBody] Cidades cidade)
        // {
        //     //chamando metodo do cadastrar
        //     return cidades.Cadastrar(cidade);
        // }
        
        //metodo post
        [HttpPost]
        //retornando rota, puxando dados do body
        public IActionResult Post([FromBody] Cidades cidade)
        {
            //chamando metodo
            cidades.Cadastrar(cidade);
            //criando rota de retorno, nome da rota, parametro, formato dos dados
            return CreatedAtRoute("cidadeAtual", new {id = cidade.Id}, cidades);
        }
        // [HttpPut("{Id}")]
        // public bool editar(int Id) {
        //     return cidades.Atualizar(Id);
        // }
    }
}