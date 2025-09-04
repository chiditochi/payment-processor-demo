namespace Service;

interface IPaymentService
{
    public string MakePayment(PaymentDto payment);
}