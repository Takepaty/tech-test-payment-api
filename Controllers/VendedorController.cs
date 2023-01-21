using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repository;
using tech_test_payment_api.Repository.Interfaces;

namespace tech_test_payment_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        static readonly IVendedorRepository repository = new VendedorRepository();

        [Route("ObterTodos"), HttpGet]
        public IEnumerable<Vendedor> ObterTodos()
        {
            return repository.ObterTodos();
        }

        [Route("ObterPorId"), HttpGet]
        public Vendedor ObterPorId(Guid id)
        {
            var item = repository.Obter(id);
            return item;
        }

        [Route("Criar"), HttpPost]
        public Vendedor Criar([FromBody] Vendedor vendedor)
        {
            vendedor = repository.Criar(vendedor);
            return vendedor;
        }

        [Route("Atualizar"), HttpPut]
        public string Atualizar(Guid id, Vendedor vendedor)
        {
            vendedor.Id = id;
            if (!repository.Atualizar(vendedor))
            {
                return "Vendedor não foi alterado, verifique se o id do vendedor foi informado";
            }

            return "Vendedor alterado com sucesso!";
        }

        [Route("Excluir"), HttpDelete]
        public string Excluir(Guid id)
        {
            Vendedor item = repository.Obter(id);
            if (item == null)
            {
                return "Não foi localizado o vendedor com os parâmetros informados";
            }

            repository.Excluir(id);

            return "Vendedor foi excluido com sucesso!";
        }
    }
}
