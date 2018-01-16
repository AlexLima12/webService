using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace projetoWebServices.Controllers
{
    //definindo a rota para a requisição do serviço nesse caso api/nome do controler
    [Route("api/[controller]")]
    public class PrimeiraController : Controller
    {
        //metodo get
        [HttpGet]
        
        //action que enumera uma string
        public IEnumerable<string> Get()
        {
            //retornar um array de cidades
            return new string[]{
                "Curitiba","Porto Alegra","Salvador","Belo Horizonte"
            };
        }
    }
}