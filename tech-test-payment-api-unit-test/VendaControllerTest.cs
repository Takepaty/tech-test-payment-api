using tech_test_payment_api.Controllers;
using tech_test_payment_api.ViewModel;
using tech_test_payment_api.Models;
using tech_test_payment_api.Models.Enums;
using tech_test_payment_api.Util;

namespace tech_test_payment_api_unit_test
{
    [TestFixture]
    public class VendaControllerTest
    {
        [Test]
        public void Criar_QuandoUsuarioInformarOsDadosDaVenda_RetornaVendaRegistrada()
        {
            var vendaController = new VendaController();
            var registrarVenda = new RegistrarVendaViewModel();

            //Criando vendedor para registrar a registrarVenda
            var vendedorController = new VendedorController();
            var vendedor = vendedorController.Criar(new Vendedor(GeradorCpf.GerarCpf(), "Mauricio","mauricio@gmail.com", "(12) 99978-2458"));
            registrarVenda.IdVendedor = vendedor.Id;

            //Obtendo um produto para registrar a registrarVenda
            var produtoController = new ProdutoController();
            var produto = produtoController.Criar(new Produto("Caderno",15));

            //Adiciono os dados do produto obtido
            var item = new RegistrarItemVendaViewModel { IdProduto = produto.Id, Quantidade = 12 };

            //Adiciono o item na lista
            registrarVenda.Items = new List<RegistrarItemVendaViewModel>
            {
                item
            };

            var resultadoVenda = vendaController.RegistrarVenda(registrarVenda);


            Assert.IsNotNull(resultadoVenda);
            Assert.IsInstanceOf(typeof(Venda), resultadoVenda);
        }

        [Test]
        public void Atualizar_QuandoUsuarioInformarIdExistenteEStatus_RetornaVendaAtualizada()
        {
            var vendaController = new VendaController();

            var vendaCriada = CriarVenda(vendaController);

            var dadosVenda = new AtualizarVendaViewModel
            {
                IdVenda = vendaCriada.Id,
                StatusPedido = EnumStatusPedido.PagamentoAprovado
            };

            vendaController.AtualizarStatusVenda(dadosVenda);

            var resultadoVenda = vendaController.ObterPorId(dadosVenda.IdVenda);

            Assert.IsNotNull(resultadoVenda);
            Assert.IsTrue(resultadoVenda.StatusPedido == EnumStatusPedido.PagamentoAprovado);
        }

        [Test]
        public void Obter_QuandoIdExistente_RetornaVenda()
        {
            var vendaController = new VendaController();
            var novaVenda = CriarVenda(vendaController);

            var consultaVenda = vendaController.ObterPorId(novaVenda.Id);

            Assert.IsNotNull(consultaVenda);
            Assert.IsTrue(novaVenda.Id == consultaVenda.Id);
        }

        public Venda CriarVenda(VendaController vendaController)
        {
            var registrarVenda = new RegistrarVendaViewModel();

            //Criando vendedor para registrar a registrarVenda
            var vendedorController = new VendedorController();
            var vendedor = vendedorController.Criar(new Vendedor(GeradorCpf.GerarCpf(), "Luzia", "luzia@gmail.com", "(12) 99977-2458"));
            registrarVenda.IdVendedor = vendedor.Id;

            //Obtendo um produto para registrar a registrarVenda
            var produtoController = new ProdutoController();
            var produto = produtoController.ObterTodos().FirstOrDefault();
            //Adiciono os dados do produto obtido
            var item = new RegistrarItemVendaViewModel();
            item.IdProduto = produto.Id;
            item.Quantidade = 12;
            //Adiciono o item na lista
            var listaItens = new List<RegistrarItemVendaViewModel>();
            listaItens.Add(item);

            registrarVenda.Items = listaItens;

            return vendaController.RegistrarVenda(registrarVenda);
        }   
    }
}
