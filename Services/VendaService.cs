using tech_test_payment_api.Models;
using tech_test_payment_api.Repository;
using tech_test_payment_api.Repository.Interfaces;
using tech_test_payment_api.Services.Interfaces;

namespace tech_test_payment_api.Services
{
    public class VendaService : IVendaService
    {
        static readonly IProdutoRepository bdProduto = new ProdutoRepository();
        static readonly IVendedorRepository bdVendedor = new VendedorRepository();
        static readonly IVendaRepository bdVenda = new VendaRepository();

        public Venda RegistrarVenda(Guid idVendedor, List<ItemVenda> listaItensVenda)
        {
            if (idVendedor == null && listaItensVenda != null && !listaItensVenda.Any())
            {
                throw new ArgumentNullException("Verifique se foi informado o id do vendedor e itens do pedido");
            }

            //Crio o pedido de venda
            var venda = new Venda(idVendedor);

            //Localizo o vendedor no banco e adiciono na model para exibição amigável
            venda.AdicionarVendedor(bdVendedor.Obter(idVendedor));

            //Percorro a lista e localizo o produto para exibição amigável
            foreach (var item in listaItensVenda)
                item.AdicionarProduto(bdProduto.Obter(item.IdProduto));

            //Adiciono os itens do pedido na minha venda
            venda.AdicionarItensVenda(listaItensVenda);

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
