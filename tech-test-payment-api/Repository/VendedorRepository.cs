using tech_test_payment_api.Models;
using tech_test_payment_api.Repository.Interfaces;

namespace tech_test_payment_api.Repository
{
    public class VendedorRepository : BaseRepository, IVendedorRepository
    {
        public VendedorRepository()
        {
            if (BdVendedor == null || BdVendedor.Count <= 0)
            {
                Criar(new Vendedor("123.123.456-98", "Fulano", "teste@teste.com", "1199999-9999"));
                Criar(new Vendedor("123.123.456-97", "Ciclano", "teste_do_teste_que_estou_testando@teste.com", "1199999-9999"));
            }
        }

        public IEnumerable<Vendedor> ObterTodos()
        {
            return BdVendedor;
        }

        public Vendedor Obter(Guid id)
        {
            return BdVendedor.Find(v => v.Id == id);
        }

        public Vendedor Criar(Vendedor item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Favor informar os dados do vendedor!");
            }
            if (BdVendedor.Any(v => v.Cpf == item.Cpf))
            {
                throw new ArgumentException("Cpf já cadastrado!");
            }

            BdVendedor.Add(item);
            return item;
        }

        public bool Atualizar(Vendedor item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = BdVendedor.FindIndex(v => v.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            BdVendedor.RemoveAt(index);
            BdVendedor.Add(item);
            return true;
        }

        public void Excluir(Guid id)
        {
            BdVendedor.RemoveAll(v => v.Id == id);
        }
    }
}