namespace Cyberspace.Service.PaymentProcessors;

using Cyberspace.Model;


public class Flutter : IPay
{
    public string ProcessPayment(PaymentDto payload)
    {
        // Implementation for processing payment via Flutter
        string message = $"Payment of {payload.Amount} by {payload.Name} processed successfully via Flutter.";
        return message;
    }
}