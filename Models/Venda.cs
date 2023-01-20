using tech_test_payment_api.Models.Enums;

namespace tech_test_payment_api.Models
{
    public class Venda
    {

        public Guid Id { get; private set; }      
        public DateTime Data { get; private set; }
        public EnumStatusPedido StatusPedido { get; private set; }

        public Vendedor Vendedor { get; private set; }
        public List<ItemVenda> ItemVenda { get; private set; }
        
        public List<Venda> ListaVendas { get; private set; }

        public void RegistrarVenda(Vendedor vendedor, List<ItemVenda> itemVendas)
        {
            Id = Guid.NewGuid();
            Vendedor = vendedor;
            ItemVenda.AddRange(itemVendas);
            Data = DateTime.Now;
            StatusPedido = EnumStatusPedido.aguardandoPagamento;
        }

        private void GravarVenda(Venda venda)
        {
            ListaVendas.Add(venda);
        }


        public void AtualizarStatusVenda(EnumStatusPedido statusPedido)
        {
            if (StatusPedido == EnumStatusPedido.aguardandoPagamento && statusPedido == EnumStatusPedido.PagamentoAprovado)
                StatusPedido = statusPedido;

            if (StatusPedido == EnumStatusPedido.aguardandoPagamento && statusPedido == EnumStatusPedido.Cancelada)
                StatusPedido = statusPedido;

            if (StatusPedido == EnumStatusPedido.PagamentoAprovado && statusPedido == EnumStatusPedido.EnviadoParaTransportadora)
                StatusPedido = statusPedido;

            if (StatusPedido == EnumStatusPedido.PagamentoAprovado && statusPedido == EnumStatusPedido.Cancelada)
                StatusPedido = statusPedido;

            if (StatusPedido == EnumStatusPedido.EnviadoParaTransportadora && statusPedido == EnumStatusPedido.Entregue)
                StatusPedido = statusPedido;
        }

    }
}
