using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repository;
using tech_test_payment_api.Repository.Interfaces;

namespace tech_test_payment_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        static readonly IProdutoRepository repository = new ProdutoRepository();

        [Route("ObterTodos"), HttpGet]
        public IEnumerable<Produto> ObterTodos()
        {
            return repository.ObterTodos();
        }

        [Route("ObterPorId"), HttpGet]
        public Produto ObterPorId(Guid id)
        {
            var item = repository.Obter(id);
            return item;
        }

        [Route("Criar"), HttpPost]
        public Produto Criar(Produto produto)
        {
            produto = repository.Criar(produto);
            return produto;
        }

        [Route("Atualizar"), HttpPut]
        public string Atualizar(Guid id, Produto produto)
        {
            produto.Id = id;
            if (!repository.Atualizar(produto))
            {
                return "Produto não foi alterado, verifique se o id do produto foi informado";
            }

            return "Produto alterado com sucesso!";
        }

        [Route("Excluir"), HttpDelete]
        public string Excluir(Guid id)
        {
            Produto item = repository.Obter(id);
            if (item == null)
            {
                return "Não foi localizado o produto com os parâmetros informados";
            }

            repository.Excluir(id);

            return "Produto foi excluido com sucesso!";
        }
    }
}
