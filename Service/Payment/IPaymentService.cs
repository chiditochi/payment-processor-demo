namespace Cyberspace.Service.Payment;

using Cyberspace.Model;

interface IPaymentService
{
    public string MakePayment(PaymentDto payment);
}