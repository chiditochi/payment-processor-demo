namespace Service;

class Paystack : IPay
{
    public string ProcessPayment(PaymentDto payload)
    {
        // Implementation for processing payment via Paystack
        string message = $"Payment of {payload.Amount} processed successfully via Paystack.";
        return message;
    }
}