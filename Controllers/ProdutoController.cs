using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repository;

namespace tech_test_payment_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        static readonly IProdutoRepository repository = new ProdutoRepository();

        [Route("ObterTodosProdutos"), HttpGet]
        public IEnumerable<Produto> ObterTodosProdutos()
        {
            return repository.ObterTodos();
        }

        [Route("ObterProduto/{id}"), HttpGet]
        public Produto ObterProduto(Guid id)
        {
            var item = repository.Obter(id);
            return item;
        }
    }
}
