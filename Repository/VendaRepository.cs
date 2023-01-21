using tech_test_payment_api.Models;
using tech_test_payment_api.Repository.Interfaces;

namespace tech_test_payment_api.Repository
{
    public class VendaRepository : IVendaRepository
    {
        private List<Venda> bdVenda = new List<Venda>();

        public bool Atualizar(Venda item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = bdVenda.FindIndex(v => v.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            bdVenda.RemoveAt(index);
            bdVenda.Add(item);
            return true;        
        }

        public Venda Criar(Venda venda)
        {
            bdVenda.Add(venda);

            return venda;          
        }

        public void Excluir(Guid id)
        {
            bdVenda.RemoveAll(v => v.Id == id);            
        }

        public Venda Obter(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Identificador da venda informado não é válido");
            }
            return bdVenda.Find(v => v.Id == id);
        }

        public IEnumerable<Venda> ObterTodos()
        {
            return bdVenda;
        }
    }
}
