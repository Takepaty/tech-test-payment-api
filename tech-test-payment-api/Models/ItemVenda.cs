namespace tech_test_payment_api.Models
{
    public class ItemVenda
    {
        public ItemVenda(Guid idVenda, Guid idProduto, int quantidade)
        {
            Id = Guid.NewGuid();
            IdVenda = idVenda;
            IdProduto = idProduto;
            Quantidade = quantidade;
        }

        public Guid Id { get; private set; }
        public Guid IdVenda { get; private set; }
        public Guid IdProduto { get; private set; }
        public int Quantidade { get; private set; }

        public Produto Produto { get; set; }

    }
}