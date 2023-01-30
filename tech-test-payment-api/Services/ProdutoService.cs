using tech_test_payment_api.Repository.Interfaces;
using tech_test_payment_api.Repository;
using tech_test_payment_api.Services.Interfaces;
using tech_test_payment_api.Models;
using System.Net;
using tech_test_payment_api.Filters;

namespace tech_test_payment_api.Services
{
    public class ProdutoService : IProdutoService
    {
        static readonly IProdutoRepository repository = new ProdutoRepository();        

        public bool Atualizar(Produto item)
        {
            try
            {
                if (item == null)
                {
                    throw new Exception("Informe os dados do produto!");
                }
                return repository.Atualizar(item);
            }
            catch (Exception ex)
            {
                throw new MyCustomHttpException((int)HttpStatusCode.BadRequest, $"Houve um erro ao atualizar o produto.", $"Detalhes técnicos: {ex.Message}");
            }
        }

        public Produto Criar(Produto item)
        {
            try
            {
                if (item == null || string.IsNullOrWhiteSpace(item.Nome))
                {
                    throw new Exception("Informe os dados do produto!");
                }
                if (repository.ObterTodos().Any(p => p.Nome == item.Nome))
                {
                    throw new Exception("Este produto já foi cadastrado!");
                }

                return repository.Criar(item);
            }
            catch (Exception ex)
            {
                throw new MyCustomHttpException((int)HttpStatusCode.BadRequest, $"Houve um erro ao criar o produto.", $"Detalhes técnicos: {ex.Message}");
            }
        }

        public void Excluir(Guid id)
        {
            try
            {
                var item = repository.Obter(id);
                if (item == null)
                {
                    throw new Exception("Não foi localizado o produto com os parâmetros informados");
                }
                repository.Excluir(id);
            }
            catch (Exception ex)
            {
                throw new MyCustomHttpException((int)HttpStatusCode.BadRequest, $"Houve um erro ao tentar excluir o produto", $"Detalhes técnicos: {ex.Message}");
            }
        }

        public Produto Obter(Guid id)
        {
            try
            {
                var produto = repository.Obter(id);
                if (produto == null)
                    throw new Exception("Não foi possível localizar o produto com o identificador informado!");

                return produto;
            }
            catch (Exception ex)
            {
                throw new MyCustomHttpException((int)HttpStatusCode.BadRequest, $"Houve um erro ao tentar obter o produto.", $"Detalhes técnicos: { ex.Message }");
            }
        }

        public IEnumerable<Produto> ObterTodos()
        {
            try
            {
                return repository.ObterTodos();
            }
            catch (Exception ex)
            {
                throw new MyCustomHttpException((int)HttpStatusCode.BadRequest, $"Houve um erro ao tentar obter todos os produto", $"Detalhes técnicos: {ex.Message}");
            }
        }
    }
}
