using tech_test_payment_api.Models;

namespace tech_test_payment_api.Repository.Interfaces
{
    public interface IVendaRepository
    {
        IEnumerable<Venda> ObterTodos();
        Venda Obter(Guid id);
        Venda Criar(Venda venda);
        void Excluir(Guid id);
        bool Atualizar(Venda item);
    }
}