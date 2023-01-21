using tech_test_payment_api.Models;
using tech_test_payment_api.Repository.Interfaces;

namespace tech_test_payment_api.Repository
{
    public class VendedorRepository : IVendedorRepository
    {
        private List<Vendedor> vendedor = new List<Vendedor>();

        public VendedorRepository()
        {
            Criar(new Vendedor("123.123.456-98","Fulano","teste@teste.com","1199999-9999"));
            Criar(new Vendedor("123.123.456-97","Ciclano","teste_do_teste_que_estou_testando@teste.com","1199999-9999"));
        }

        public IEnumerable<Vendedor> ObterTodos()
        {
            return vendedor;
        }

        public Vendedor Obter(Guid id)
        {
            return vendedor.Find(v => v.Id == id);
        }

        public Vendedor Criar(Vendedor item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Favor informar os dados do vendedor!");
            }
            if (vendedor.Any(v => v.Cpf == item.Cpf))
            {
                throw new ArgumentException("Cpf já cadastrado!");
            }

            vendedor.Add(item);
            return item;
        }

        public bool Atualizar(Vendedor item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = vendedor.FindIndex(v => v.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            vendedor.RemoveAt(index);
            vendedor.Add(item);
            return true;
        }

        public void Excluir(Guid id)
        {
            vendedor.RemoveAll(v => v.Id == id);
        }
    }
}