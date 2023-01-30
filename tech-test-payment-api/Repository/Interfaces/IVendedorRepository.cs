using tech_test_payment_api.Models;

namespace tech_test_payment_api.Repository.Interfaces
{
    public interface IVendedorRepository
    {
        IEnumerable<Vendedor> ObterTodos();
        Vendedor Obter(Guid id);
        Vendedor Criar(Vendedor item);
        void Excluir(Guid id);
        bool Atualizar(Vendedor item);
    }
}