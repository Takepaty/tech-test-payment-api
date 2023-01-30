using tech_test_payment_api.Models;

namespace tech_test_payment_api.Services.Interfaces
{
    public interface IProdutoService
    {
        IEnumerable<Produto> ObterTodos();
        Produto Obter(Guid id);
        Produto Criar(Produto item);
        void Excluir(Guid id);
        bool Atualizar(Produto item);
    }
}
