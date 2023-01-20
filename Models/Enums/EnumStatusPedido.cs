using System.ComponentModel;

namespace tech_test_payment_api.Models.Enums
{
    public enum EnumStatusPedido
    {
        [Description("Aguardando pagamento")]
        aguardandoPagamento,
        [Description("Pagamento aprovado")]
        PagamentoAprovado,
        [Description("Enviado para transportadora")]
        EnviadoParaTransportadora,
        [Description("Entregue")]
        Entregue,
        [Description("Cancelada")]
        Cancelado
    }
}
