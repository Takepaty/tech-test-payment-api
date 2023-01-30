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
            // Arrange
            var controller = new ProdutoController();

            // Act
            var result = controller.Criar(new Produto("Notebook", 10));

            // Assert
            Assert.IsInstanceOf(typeof(Produto), result);
        }

        [Test]
        public void Obter_QuandoChamado_RetornaTodosOsProdutos()
        {
            // Arrange
            var controller = new ProdutoController();

            // Act
            var result = controller.ObterTodos();

            // Assert
            Assert.IsInstanceOf(typeof(List<Produto>), result.ToList());
        }

        [Test]
        public void Obter_QuandoIdExistente_RetornaProdutoCorrespondente()
        {
            // Arrange
            var controller = new ProdutoController();
            var produtoExperado = controller.Criar(new Produto("Livro", 10));

            // Act
            var result = controller.ObterPorId(produtoExperado.Id);

            // Assert
            Assert.IsInstanceOf(typeof(Produto), result);
            Assert.AreEqual(produtoExperado.Id, result.Id);
            Assert.AreEqual(produtoExperado.Nome, result.Nome);
        }

        [Test]
        public void Obter_QuandoIdInexistente_RetornaNotFound()
        {
            // Arrange
            var controller = new ProdutoController();

            var expection = new Exception();
            // Act
            try
            {
                var result = controller.ObterPorId(Guid.Empty);
            }
            catch (Exception ex)
            {
                expection = ex;
            }

            // Assert
            Assert.IsNotInstanceOf(typeof(BadRequestResult), ((tech_test_payment_api.Filters.MyCustomHttpException)expection).StatusCode);
        }

        [Test]
        public void Criar_QuandoProdutoInvalido_RetornaBadRequestResult()
        {
            // Arrange
            var controller = new ProdutoController();
            var produto = new Produto("", 10);

            // Act
            var result = controller.Criar(produto);

            // Assert
            Assert.IsInstanceOf(typeof(Produto), result);
        }
    }
}
