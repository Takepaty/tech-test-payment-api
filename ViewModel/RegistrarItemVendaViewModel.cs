using System.Text.Json.Serialization;

namespace tech_test_payment_api.ViewModel
{
    public class RegistrarItemVendaViewModel
    {
        [JsonIgnore]
        public Guid IdVenda { get; set; }
        public Guid IdProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
