using NPOI.SS.Formula.Functions;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repository;
using tech_test_payment_api.Repository.Interfaces;
using tech_test_payment_api.Services.Interfaces;

namespace tech_test_payment_api.Services
{
    public class VendedorService : IVendedorService
    {
        static readonly IVendedorRepository repository = new VendedorRepository();

        public bool Atualizar(Vendedor item)
        {
            return repository.Atualizar(item);
        }

        public Vendedor Criar(Vendedor item)
        {
            return repository.Criar(item);
        }

        public void Excluir(Guid id)
        {
            repository.Excluir(id);
        }

        public Vendedor Obter(Guid id)
        {
            return repository.Obter(id);
        }

        public IEnumerable<Vendedor> ObterTodos()
        {
            return repository.ObterTodos();
        }
    }
}
