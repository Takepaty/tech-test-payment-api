using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var vendedor = new Vendedor("123.322.123-68","Jack","jack@gmail.com","(11) 99070-7070");

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
            var vendedor = new Vendedor("123.322.123-68", "Jack", "jack@gmail.com", "(11) 99070-7070");

            controller.Criar(vendedor);

            var resultado = controller.ObterPorId(vendedor.Id);
            
            Assert.IsNotNull(resultado);
            Assert.IsInstanceOf(typeof(Vendedor), resultado);
            Assert.IsTrue(resultado.Nome == "Jack");
        }
    }
}
