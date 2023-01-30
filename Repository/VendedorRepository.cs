using tech_test_payment_api.Models;
using tech_test_payment_api.Repository.Interfaces;

namespace tech_test_payment_api.Repository
{
    public class VendedorRepository : IVendedorRepository
    {
        private List<Vendedor> bdVendedor = new List<Vendedor>();

        public VendedorRepository(){}

        public IEnumerable<Vendedor> ObterTodos()
        {
            return bdVendedor;
        }

        public Vendedor Obter(Guid id)
        {
            return bdVendedor.Find(v => v.Id == id);
        }

        public Vendedor Criar(Vendedor item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Favor informar os dados do vendedor!");
            }
            if (bdVendedor.Any(v => v.Cpf == item.Cpf))
            {
                throw new ArgumentException("Cpf já cadastrado!");
            }

            bdVendedor.Add(item);
            return item;
        }

        public bool Atualizar(Vendedor item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = bdVendedor.FindIndex(v => v.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            bdVendedor.RemoveAt(index);
            bdVendedor.Add(item);
            return true;
        }

        public void Excluir(Guid id)
        {
            bdVendedor.RemoveAll(v => v.Id == id);
        }
    }
}