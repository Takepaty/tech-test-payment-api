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

        private Guid Id { get; set; }
        private string Cpf { get; set; }
        private string Nome { get; set; }
        private string Email { get; set; }
        private string Telefone { get; set; }

    }
}