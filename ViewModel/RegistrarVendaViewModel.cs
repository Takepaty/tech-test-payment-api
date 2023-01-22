namespace tech_test_payment_api.ViewModel
{
    public class RegistrarVendaViewModel
    {
        public Guid IdVendedor { get; set; }
        public IEnumerable<RegistrarItemVendaViewModel> Items { get; set; }
    }
}
