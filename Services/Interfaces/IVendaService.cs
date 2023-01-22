using tech_test_payment_api.Models;
using tech_test_payment_api.ViewModel;

namespace tech_test_payment_api.Services.Interfaces
{
    public interface IVendaService
    {
        Venda RegistrarVenda(RegistrarVendaViewModel venda);
        Venda Obter(Guid id);
    }
}
