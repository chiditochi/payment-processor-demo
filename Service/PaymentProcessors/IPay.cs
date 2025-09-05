
namespace Cyberspace.Service.PaymentProcessors;

using Cyberspace.Model;

public interface IPay
{
    string ProcessPayment(PaymentDto payload);
}