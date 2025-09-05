namespace Cyberspace.Service;

using Cyberspace.Model;

interface IPaymentService
{
    public string MakePayment(PaymentDto payment);
}