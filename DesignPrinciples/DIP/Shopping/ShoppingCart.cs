using DesignPrinciples.DIP.Payment;

namespace DesignPrinciples.DIP.Shopping
{
    public class ShoppingCart : IShoppingService
    {
        private readonly IPaymentService _paymentService;

        // Wir sollten hier nicht gegen die konkrete Implementierung gehen sondern gegen eine Schnittstelle
        private readonly BankTransferPaymentService _paymentService_Bad = new BankTransferPaymentService();

        // DIP: Die Abhängigkeit soll von außen kommen 
        public ShoppingCart(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public void Checkout()
        {
            Console.WriteLine("Pay order");
            _paymentService.MakePayment();
        }
    }
}
