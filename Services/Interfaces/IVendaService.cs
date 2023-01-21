using tech_test_payment_api.Models;

namespace tech_test_payment_api.Services.Interfaces
{
    public interface IVendaService
    {
        Venda RegistrarVenda(Guid idVendedor, List<ItemVenda> listaItensVenda);
        Venda Obter(Guid id);
    }
}
