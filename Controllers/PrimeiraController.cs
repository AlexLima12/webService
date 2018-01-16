using Microsoft.AspNetCore.Mvc;

namespace projetoWebServices.Controllers
{
    //definindo a rota para a requisição do serviço
    [Route("api/[controller]")]
    public class PrimeiraController : Controller
    {
        public IActionResult primeira()
        {
            return View();
        }
    }
}