namespace tech_test_payment_api.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }

        public Produto(string nome, decimal valor)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Valor = valor;
        }

    }
}