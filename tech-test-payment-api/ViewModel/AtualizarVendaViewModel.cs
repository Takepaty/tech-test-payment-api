using tech_test_payment_api.Models.Enums;

namespace tech_test_payment_api.ViewModel
{
    public class AtualizarVendaViewModel
    {
        public Guid IdVenda { get; set; }
        public EnumStatusPedido StatusPedido { get; set;}
    }
}
