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

        //requisição get com parametro
        [HttpGet("{Id}")]
        //action que retonar um obj Cidades e recebe um parametro do EndPoint
        public Cidades Get(int Id) {
            //retornando metodo e filtrando com Linq e Lambda
            return cidades.Listar().Where(c => c.Id == Id).FirstOrDefault();
        }
    }
}