
namespace Cyberspace.Service.PaymentProcessors;

using Cyberspace.Model;

interface IPay
{
    string ProcessPayment(PaymentDto payload);
}