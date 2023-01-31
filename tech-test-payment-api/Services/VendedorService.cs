using System.Net;
using tech_test_payment_api.Filters;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repository;
using tech_test_payment_api.Repository.Interfaces;
using tech_test_payment_api.Services.Interfaces;

namespace tech_test_payment_api.Services
{
    public class VendedorService : IVendedorService
    {
        static readonly IVendedorRepository repository = new VendedorRepository();

        public bool Atualizar(Vendedor item)
        {
            try
            {
                return repository.Atualizar(item);
            }
            catch (Exception ex)
            {
                throw new MyCustomHttpException((int)HttpStatusCode.BadRequest, $"Houve um erro ao atualizar o vendedor.", $"Detalhes técnicos: {ex.Message}");
            }
        }

        public Vendedor Criar(Vendedor item)
        {
            try
            {
                return repository.Criar(item);
            }
            catch (Exception ex)
            {
                throw new MyCustomHttpException((int)HttpStatusCode.BadRequest, $"Houve um erro ao criar o vendedor.", $"Detalhes técnicos: {ex.Message}");
            }
        }

        public void Excluir(Guid id)
        {
            try
            {
                repository.Excluir(id);
            }
            catch (Exception ex)
            {
                throw new MyCustomHttpException((int)HttpStatusCode.BadRequest, $"Houve um erro ao criar o vendedor.", $"Detalhes técnicos: {ex.Message}");
            }
        }

        public Vendedor Obter(Guid id)
        {
            try
            {
                var resultado = repository.Obter(id);
                if (resultado == null || resultado.Id == default)
                    throw new Exception("Não foi localizado o vendedor com o identificador informado!");

                return resultado;
            }
            catch (Exception ex)
            {
                throw new MyCustomHttpException((int)HttpStatusCode.BadRequest, $"Houve um erro ao obter o vendedor.", $"Detalhes técnicos: {ex.Message}");
            }
        }

        public IEnumerable<Vendedor> ObterTodos()
        {
            try
            {
                return repository.ObterTodos();
            }
            catch (Exception ex)
            {
                throw new MyCustomHttpException((int)HttpStatusCode.BadRequest, $"Houve um erro ao obter todos os vendedores.", $"Detalhes técnicos: {ex.Message}");
            }

        }
    }
}
