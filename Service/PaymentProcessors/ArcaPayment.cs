namespace Cyberspace.Service.PaymentProcessors;

using Cyberspace.Model;

class ArcaPayment : IPay
{
    public string ProcessPayment(PaymentDto payload)
    {
        // Implementation for processing payment via ArcaPayment
        string message = $"Payment of {payload.Amount} by {payload.Name} processed successfully via ArcaPayment.";
        return message;
    }
}