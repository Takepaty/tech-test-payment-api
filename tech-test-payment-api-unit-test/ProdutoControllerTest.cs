using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Controllers;
using tech_test_payment_api.Models;

namespace tech_test_payment_api_unit_test
{
    [TestFixture]
    public class ProdutoControllerTest
    {
        [Test]
        public void Criar_QuandoChamado_RetornaProdutoCriado()
        {
            // Arranjo
            var controller = new ProdutoController();

            // Agir
            var result = controller.Criar(new Produto("Notebook", 10));

            // Afirmar
            Assert.IsInstanceOf(typeof(Produto), result);
        }

        [Test]
        public void Obter_QuandoChamado_RetornaTodosOsProdutos()
        {
            // Arranjo
            var controller = new ProdutoController();

            // Agir
            var result = controller.ObterTodos();

            // Afirmar
            Assert.IsInstanceOf(typeof(List<Produto>), result.ToList());
        }

        [Test]
        public void Obter_QuandoIdExistente_RetornaProdutoCorrespondente()
        {
            // Arranjo
            var controller = new ProdutoController();
            var produtoExperado = controller.Criar(new Produto("Livro", 10));

            // Agir
            var result = controller.ObterPorId(produtoExperado.Id);

            // Afirmar
            Assert.IsInstanceOf(typeof(Produto), result);
            Assert.AreEqual(produtoExperado.Id, result.Id);
            Assert.AreEqual(produtoExperado.Nome, result.Nome);
        }

        [Test]
        public void Obter_QuandoIdInexistente_RetornaNotFound()
        {
            // Arranjo
            var controller = new ProdutoController();

            var expection = new Exception();
            // Agir
            try
            {
                var result = controller.ObterPorId(Guid.Empty);
            }
            catch (Exception ex)
            {
                expection = ex;
            }

            // Afirmar
            Assert.IsNotInstanceOf(typeof(BadRequestResult), ((tech_test_payment_api.Filters.MyCustomHttpException)expection).StatusCode);
        }

        [Test]
        public void Criar_QuandoProdutoInvalido_RetornaBadRequestResult()
        {
            var expection = new Exception();
            try
            {
                var controller = new ProdutoController();
                var produto = new Produto("", 10);

                var result = controller.Criar(produto);
            }
            catch (Exception ex)
            {
                expection = ex;
            }

            // Afirmar
            Assert.IsInstanceOf(typeof(int), ((tech_test_payment_api.Filters.MyCustomHttpException)expection).StatusCode);
            Assert.IsTrue(((tech_test_payment_api.Filters.MyCustomHttpException)expection).StatusCode == 400);
        }
    }
}
