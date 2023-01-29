using tech_test_payment_api.Models.Enums;

namespace tech_test_payment_api.Models
{
    public class Venda
    {

        public Guid Id { get; private set; }  
        public DateTime Data { get; private set; }
        public EnumStatusPedido StatusPedido { get; private set; }
        public decimal ValorTotal { get; set; }

        public List<ItemVenda> listaItensVenda { get; private set; }        
        public Vendedor Vendedor { get; set; }

        public Venda()
        {
            if (Id == Guid.Empty)
                Id = Guid.NewGuid();

            if(listaItensVenda == null || listaItensVenda.Any())
                listaItensVenda = new List<ItemVenda>();

            Data = DateTime.Now;
            StatusPedido = EnumStatusPedido.aguardandoPagamento;
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
