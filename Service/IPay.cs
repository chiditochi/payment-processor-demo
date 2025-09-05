
namespace Cyberspace.Service;

using Cyberspace.Model;

interface IPay
{
    string ProcessPayment(PaymentDto payload);
}