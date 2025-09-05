namespace Cyberspace.Service.PaymentProcessors;

using Cyberspace.Model;

class Paystack : IPay
{
    public string ProcessPayment(PaymentDto payload)
    {
        // Implementation for processing payment via Paystack
        string message = $"Payment of {payload.Amount} by {payload.Name} processed successfully via Paystack.";
        return message;
    }
}