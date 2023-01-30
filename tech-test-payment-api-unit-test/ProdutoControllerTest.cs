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

        [Test]
        public void Excluir_QuandoIdExistir_RetornaMensagemSucesso()
        {

            var controller = new ProdutoController();
            Produto produtoExperado;
            string resultadoExclusao = "";
            Exception exception = new Exception();

            try
            {
                produtoExperado = controller.Criar(new Produto("Álcool em Gel", 10));
                resultadoExclusao = controller.Excluir(produtoExperado.Id);
                var resultadoConsulta = controller.ObterPorId(produtoExperado.Id);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            var statusCode = ((tech_test_payment_api.Filters.MyCustomHttpException)exception).StatusCode;

            Assert.IsTrue(resultadoExclusao == "Produto foi excluido com sucesso!");
            Assert.IsInstanceOf(typeof(int), statusCode);
            Assert.IsTrue(statusCode == 400);

        }

        [Test]
        public void Atualizar_QuandoIdExistir_RetornaMensagemSucesso()
        {
            var controller = new ProdutoController();
            //Crio o novo vendedor
            var produtoExperado = controller.Criar(new Produto("Caneta", 10));

            //Alterando o telefone do novo vendedor
            var produtoAtualizado = new Produto("Lapis", 1);

            //Solicitando alteração do telefone
            var resultadoAtualizacao = controller.Atualizar(produtoExperado.Id, produtoAtualizado);

            //Consultando se foi alterado o telefone
            produtoAtualizado = controller.ObterPorId(produtoExperado.Id);

            Assert.IsTrue(resultadoAtualizacao == "Produto alterado com sucesso!");
            Assert.AreNotEqual(produtoExperado.Nome, produtoAtualizado.Nome);
        }
    }
}
