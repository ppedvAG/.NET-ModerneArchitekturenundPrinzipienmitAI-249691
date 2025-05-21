using DesignPrinciples.DIP.Shopping;

namespace DesignPrinciples.DIP.Payment
{
    public class BankTransferPaymentService : IPaymentService
    {
        public void MakePayment()
        {
            Console.WriteLine($"Payment made [Transaction={GetHashCode()}]");
        }
    }
}
