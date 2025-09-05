namespace Cyberspace.Service.Payment;

using Cyberspace.Model;
using Cyberspace.Service.PaymentProcessors;

class PaymentService : IPaymentService
{
    public PaymentService()
    {

    }

    private IPay GetPaymentFactory(double amount)
    {
        if (amount < 600000) return new Paystack();
        else if (amount < 2000000) return new ArcaPayment();
        else return new Flutter();
    }

    public string MakePayment(PaymentDto payment)
    {
        string result = string.Empty;
        try
        {
            var processor = GetPaymentFactory(payment.Amount);
            result = processor.ProcessPayment(payment);
        }
        catch (Exception ex)
        {
            result = ex.Message;
        }
        return result;
    }

}