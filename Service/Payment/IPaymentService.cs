namespace Cyberspace.Service.Payment;

using Cyberspace.Model;

public interface IPaymentService
{
    public string MakePayment(PaymentDto payment);
}