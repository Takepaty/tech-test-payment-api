using tech_test_payment_api.Models;
using tech_test_payment_api.Repository.Interfaces;

namespace tech_test_payment_api.Repository
{
    public class VendaRepository : BaseRepository, IVendaRepository
    {

        public bool Atualizar(Venda item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = BdVenda.FindIndex(v => v.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            BdVenda.RemoveAt(index);
            BdVenda.Add(item);
            return true;
        }

        public Venda Criar(Venda venda)
        {
            BdVenda.Add(venda);

            return venda;
        }

        public void Excluir(Guid id)
        {
            BdVenda.RemoveAll(v => v.Id == id);
        }

        public Venda Obter(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Identificador da venda informado não é válido");
            }
            return BdVenda.Find(v => v.Id == id);
        }

        public IEnumerable<Venda> ObterTodos()
        {
            return BdVenda;
        }
    }
}
