using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace projetoWebServices.Controllers
{
    //definindo a rota para a requisição do serviço nesse caso api/nome do controler
    [Route("api/[controller]")]
    public class PrimeiraController : Controller
    {
        //metodo get com parametro id
        [HttpGet("{id}")]
        
        //action que enumera uma string
        //sobrecarga de requisição
        public string Get(int id)
        {
            //retornar um elemento do array de cidades de acordo com o paramentro id
            return new string[]{
                "Curitiba",
                "Porto Alegra",
                "Salvador",
                "Belo Horizonte"
            }[id];
        }

        //metodo get
        [HttpGet]
        
        //action que enumera uma lista de string string
        public IEnumerable<string> Get()
        {
            //retornar um elemento do array de cidades
            return new string[]{
                "Curitiba",
                "Porto Alegra",
                "Salvador",
                "Belo Horizonte"
            };
        }
    }
}