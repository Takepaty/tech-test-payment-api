using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Models;
using tech_test_payment_api.Services.Interfaces;
using tech_test_payment_api.Services;

namespace tech_test_payment_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        static readonly IProdutoService service = new ProdutoService();

        [Route("ObterTodos"), HttpGet]
        public IEnumerable<Produto> ObterTodos()
        {
            return service.ObterTodos();
        }

        [Route("ObterPorId"), HttpGet]
        public Produto ObterPorId(Guid id)
        {
            var item = service.Obter(id);
            return item;
        }

        [Route("Criar"), HttpPost]
        public Produto Criar(Produto produto)
        {
            produto = service.Criar(produto);
            return produto;
        }

        [Route("Atualizar"), HttpPut]
        public string Atualizar(Guid id, Produto produto)
        {
            produto.Id = id;
            if (!service.Atualizar(produto))
            {
                return "Produto não foi alterado, verifique se o id do produto foi informado";
            }

            return "Produto alterado com sucesso!";
        }

        [Route("Excluir"), HttpDelete]
        public string Excluir(Guid id)
        {
            Produto item = service.Obter(id);
            if (item == null)
            {
                return "Não foi localizado o produto com os parâmetros informados";
            }

            service.Excluir(id);

            return "Produto foi excluido com sucesso!";
        }
    }
}
