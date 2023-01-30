using NPOI.SS.Formula.Functions;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Repository
{
    public class BaseRepository
    {
        public List<Produto> BdProduto {get; set;}
        public List<Vendedor> BdVendedor { get; set; }
        public List<Venda> BdVenda { get; set;}

        public BaseRepository()
        {
            if(BdProduto == null || !BdProduto.Any())
                BdProduto = new List<Produto>();

            if(BdVendedor == null || !BdVendedor.Any())
                BdVendedor = new List<Vendedor>();

            if (BdVenda == null || !BdVenda.Any())
                BdVenda = new List<Venda>();
        }

    }
}
