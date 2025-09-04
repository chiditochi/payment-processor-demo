
namespace Service;


interface IPay
{
    string ProcessPayment(PaymentDto payload);
}