using tech_test_payment_api.Models.Enums;

namespace tech_test_payment_api.Models
{
    public class Venda
    {
        public Guid Id { get; private set; }
        public Guid IdVendedor { get; set; }
        public Vendedor Vendedor { get; set; }
        public DateTime Data { get; private set; }
        public List<ItemPedido> ItemPedido { get; private set; }
        public EnumStatusPedido StatusPedido { get; private set; }

    }
}
