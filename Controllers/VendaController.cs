using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repository;
using tech_test_payment_api.Repository.Interfaces;
using tech_test_payment_api.Services;
using tech_test_payment_api.Services.Interfaces;

namespace tech_test_payment_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VendaController : ControllerBase
    {
        static readonly IVendaService service = new VendaService();

        [Route("BuscarVenda"), HttpGet]
        public Venda ObterPorId(Guid id)
        {
            return service.Obter(id);
        }


        [Route("RegistrarVenda"), HttpPost]
        public Venda Criar(Guid idVendedor, List<ItemVenda> listaItensVenda)
        {
            return service.RegistrarVenda(idVendedor, listaItensVenda);
        }

    }
}