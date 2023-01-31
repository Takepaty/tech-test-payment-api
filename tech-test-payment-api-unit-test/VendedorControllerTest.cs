using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Controllers;
using tech_test_payment_api.Models;

namespace tech_test_payment_api_unit_test
{
    [TestFixture]
    public class VendedorControllerTest
    {

        [Test]
        public void Criar_QuandoChamado_RetornaVendedorCriado()
        {
            var controller = new VendedorController();
            var vendedor = new Vendedor("123.322.123-68", "Jack", "jack@gmail.com", "(11) 99070-7070");

            var resultado = controller.Criar(vendedor);

            Assert.IsNotNull(resultado);
            Assert.IsInstanceOf(typeof(Vendedor), resultado);
        }

        [Test]
        public void Obter_QuandoChamado_RetornarUmaListaVendedor()
        {
            var controller = new VendedorController();

            var resultado = controller.ObterTodos();

            Assert.IsNotNull(resultado);
            Assert.IsInstanceOf(typeof(List<Vendedor>), resultado);
            Assert.IsTrue(resultado.Any());
        }

        [Test]
        public void Obter_QuandoChamado_RetornaUmVendedor()
        {
            var controller = new VendedorController();
            var vendedor = new Vendedor("123.322.123-69", "Jack", "jack@gmail.com", "(11) 99070-7070");

            controller.Criar(vendedor);

            var resultado = controller.ObterPorId(vendedor.Id);

            Assert.IsNotNull(resultado);
            Assert.IsInstanceOf(typeof(Vendedor), resultado);
            Assert.IsTrue(resultado.Nome == "Jack");

        }

        [Test]
        public void Obter_QuandoIdInexistente_RetornaNotFound()
        {
            //Arranjo
            var controller = new VendedorController();
            var expection = new Exception();

            //Agir
            try
            {
                var resultado = controller.ObterPorId(Guid.Empty);
            }
            catch (Exception ex)
            {
                expection = ex;
            }

            //Afirmar
            Assert.IsNotInstanceOf(typeof(BadRequestResult), ((tech_test_payment_api.Filters.MyCustomHttpException)expection).StatusCode);
            Assert.IsTrue(((tech_test_payment_api.Filters.MyCustomHttpException)expection).StatusCode == 400);
        }

        [Test]
        public void Atualizar_QuandoChamado_E_IdExistir_DeveRetornarMensagemDeSucesso()
        {
            var controller = new VendedorController();
            //Crio o novo vendedor
            var vendedorExperado = controller.Criar(new Vendedor("123.322.123-70", "Mingau", "mingau@gmail.com", "(11) 99071-7070"));

            //Alterando o telefone do novo vendedor
            vendedorExperado.Telefone = "(11) 99071-7171";

            //Solicitando alteração do telefone
            var resultadoAtualizacao = controller.Atualizar(vendedorExperado.Id, vendedorExperado);

            //Consultando se foi alterado o telefone
            var vendedorAtual = controller.ObterPorId(vendedorExperado.Id);

            Assert.IsTrue(resultadoAtualizacao == "Vendedor alterado com sucesso!");
            Assert.AreEqual(vendedorExperado.Telefone, vendedorAtual.Telefone);

        }

        [Test]
        public void Excluir_QuandoIdExistir_RetornaMensagemSucesso()
        {

            var controller = new VendedorController();
            Vendedor vendedorExperado;
            string resultadoExclusao = "";
            Exception exception = new Exception();

            try
            {
                vendedorExperado = controller.Criar(new Vendedor("123.332.123-73", "Nescau", "nescau@gmail.com", "(11) 99072-7273"));
                resultadoExclusao = controller.Excluir(vendedorExperado.Id);
                var resultadoConsulta = controller.ObterPorId(vendedorExperado.Id);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            var statusCode = ((tech_test_payment_api.Filters.MyCustomHttpException)exception).StatusCode;

            Assert.IsTrue(resultadoExclusao == "Vendedor foi excluido com sucesso!");
            Assert.IsInstanceOf(typeof(int), statusCode);
            Assert.IsTrue(statusCode == 400);

        }
    }
}
