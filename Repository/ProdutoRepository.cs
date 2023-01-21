using tech_test_payment_api.Models;
using tech_test_payment_api.Repository.Interfaces;

namespace tech_test_payment_api.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private List<Produto> produto = new List<Produto>();

        public ProdutoRepository()
        {
            Criar(new Produto("Teclado",  1.39M));
            Criar(new Produto("Mouse", 3.75M));
            Criar(new Produto("Monitor",16.99M));
        }

        public Produto Criar(Produto item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if(produto.Any(p => p.Nome == item.Nome))
            {
                throw new Exception("Este produto já foi cadastrado!");
            }

            produto.Add(item);
            return item;
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return produto;
        }

        public Produto Obter(Guid id)
        {
            return produto.Find(p => p.Id == id);
        }

        public void Excluir(Guid id)
        {
            produto.RemoveAll(p => p.Id == id);
        }

        public bool Atualizar(Produto item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = produto.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            produto.RemoveAt(index);
            produto.Add(item);
            return true;
        }
    }

}
