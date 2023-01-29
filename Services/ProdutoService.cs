using tech_test_payment_api.Repository.Interfaces;
using tech_test_payment_api.Repository;
using tech_test_payment_api.Services.Interfaces;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Services
{
    public class ProdutoService : IProdutoService
    {
        static readonly IProdutoRepository repository = new ProdutoRepository();

        public bool Atualizar(Produto item)
        {
            return repository.Atualizar(item);
        }

        public Produto Criar(Produto item)
        {
            return repository.Criar(item);
        }

        public void Excluir(Guid id)
        {
            repository.Excluir(id);
        }

        public Produto Obter(Guid id)
        {
            return repository.Obter(id);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return repository.ObterTodos();
        }
    }
}
