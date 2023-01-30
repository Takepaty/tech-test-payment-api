using tech_test_payment_api.Models;
using tech_test_payment_api.Repository.Interfaces;

namespace tech_test_payment_api.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private List<Produto> bdProduto = new List<Produto>();

        public ProdutoRepository(){}

        public Produto Criar(Produto item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (bdProduto.Any(p => p.Nome == item.Nome))
            {
                throw new Exception("Este produto já foi cadastrado!");
            }

            bdProduto.Add(item);
            return item;
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return bdProduto;
        }

        public Produto Obter(Guid id)
        {
            return bdProduto.Find(p => p.Id == id);
        }

        public void Excluir(Guid id)
        {
            bdProduto.RemoveAll(p => p.Id == id);
        }

        public bool Atualizar(Produto item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = bdProduto.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            bdProduto.RemoveAt(index);
            bdProduto.Add(item);
            return true;
        }
    }

}
