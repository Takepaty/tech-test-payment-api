using System.Net;
using tech_test_payment_api.Filters;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repository;
using tech_test_payment_api.Repository.Interfaces;
using tech_test_payment_api.Services.Interfaces;
using tech_test_payment_api.ViewModel;

namespace tech_test_payment_api.Services
{
    public class VendaService : IVendaService
    {
        static readonly IProdutoService srvProduto = new ProdutoService();
        static readonly IVendedorService srvVendedor = new VendedorService();
        static readonly IVendaRepository bdVenda = new VendaRepository();

        public Venda RegistrarVenda(RegistrarVendaViewModel registrarVenda)
        {
            try
            {
                if (registrarVenda.IdVendedor == null && registrarVenda.Items != null && !registrarVenda.Items.Any() && registrarVenda.Items.Any(p => p.Quantidade <= 0))
                {
                    throw new Exception("Verifique se foi informado o id do vendedor e itens do pedido e quantidade");
                }

                //Crio o pedido de venda
                var venda = new Venda();

                //Localizo o vendedor no banco e adiciono na model para exibição amigável
                venda.Vendedor = srvVendedor.Obter(registrarVenda.IdVendedor);

                //Adiciono os itens do pedido na minha venda
                foreach (var item in registrarVenda.Items)
                {
                    var itemVenda = new ItemVenda(venda.Id, item.IdProduto, item.Quantidade);
                    //localizo o produto para exibição amigável
                    itemVenda.Produto = srvProduto.Obter(itemVenda.IdProduto);

                    venda.ValorTotal += itemVenda.Quantidade * itemVenda.Produto.Valor;
                    venda.listaItensVenda.Add(itemVenda);
                }
                // Gravo no banco de dados (em memória)
                bdVenda.Criar(venda);

                return venda;
            }
            catch (Exception ex)
            {
                throw new MyCustomHttpException((int)HttpStatusCode.BadRequest, $"Houve um erro ao registrar a venda.", $"Detalhes técnicos: {ex.Message}");
            }
        }


        public Venda Obter(Guid id)
        {
            try
            {
                return bdVenda.Obter(id);
            }
            catch (Exception ex)
            {
                throw new MyCustomHttpException((int)HttpStatusCode.BadRequest, $"Houve um erro ao obter a venda.", $"Detalhes técnicos: {ex.Message}");
            }
        }

        public Venda Atualizar(AtualizarVendaViewModel vendaViewModel)
        {
            try
            {
                var venda = bdVenda.Obter(vendaViewModel.IdVenda);

                if (venda != null)
                {
                    venda.AtualizarStatusVenda(vendaViewModel.StatusPedido);
                    bdVenda.Atualizar(venda);
                }

                return venda;
            }
            catch (Exception ex)
            {
                throw new MyCustomHttpException((int)HttpStatusCode.BadRequest, $"Houve um erro ao atualizar a venda.", $"Detalhes técnicos: {ex.Message}");
            }
        }
    }
}
