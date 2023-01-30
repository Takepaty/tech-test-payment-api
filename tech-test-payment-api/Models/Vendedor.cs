namespace tech_test_payment_api.Models
{
    public class Vendedor
    {
        public Vendedor(string cpf, string nome, string email, string telefone)
        {
            Id = Guid.NewGuid();
            Cpf = cpf;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public Guid Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

    }
}