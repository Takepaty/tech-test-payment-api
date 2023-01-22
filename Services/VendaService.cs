using tech_test_payment_api.Models;
using tech_test_payment_api.Repository;
using tech_test_payment_api.Repository.Interfaces;
using tech_test_payment_api.Services.Interfaces;
using tech_test_payment_api.ViewModel;

namespace tech_test_payment_api.Services
{
    public class VendaService : IVendaService
    {
        static readonly IProdutoRepository bdProduto = new ProdutoRepository();
        static readonly IVendedorRepository bdVendedor = new VendedorRepository();
        static readonly IVendaRepository bdVenda = new VendaRepository();

        public Venda RegistrarVenda(RegistrarVendaViewModel registrarVenda)
        {

            if (registrarVenda.IdVendedor == null && registrarVenda.Items != null && !registrarVenda.Items.Any())
            {
                throw new ArgumentNullException("Verifique se foi informado o id do vendedor e itens do pedido");
            }

            //Crio o pedido de venda
            var venda = new Venda(registrarVenda.IdVendedor);

            //Localizo o vendedor no banco e adiciono na model para exibição amigável
            venda.AdicionarVendedor(bdVendedor.Obter(registrarVenda.IdVendedor));

            //Adiciono os itens do pedido na minha venda
            foreach (var item in registrarVenda.Items)
            {
                var itemVenda = new ItemVenda(venda.Id, item.IdProduto,item.Quantidade, item.Valor );
                venda.listaItensVenda.Add(itemVenda);
            }

            //Percorro a lista e localizo o produto para exibição amigável
            foreach (var item in venda.listaItensVenda)
                item.AdicionarProduto(bdProduto.Obter(item.IdProduto));

            // Gravo no banco de dados (em memória)
            bdVenda.Criar(venda);

            return venda;
        }


        public Venda Obter(Guid id)
        {
            return bdVenda.Obter(id);
        }
    }
}
