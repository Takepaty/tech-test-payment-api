using tech_test_payment_api.Models;
using tech_test_payment_api.Services;
using tech_test_payment_api.Services.Interfaces;
using tech_test_payment_api.ViewModel;
using Microsoft.AspNetCore.Mvc;

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
        public Venda RegistrarVenda(RegistrarVendaViewModel venda)
        {
            return service.RegistrarVenda(venda);
        }


        [Route("AtualizarStatusVenda"), HttpPatch]
        public Venda RegistrarVenda(AtualizarVendaViewModel venda)
        {
            return service.Atualizar(venda);
        }

    }
}