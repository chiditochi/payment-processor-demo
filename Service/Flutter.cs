namespace Service;


class Flutter : IPay
{
    public string ProcessPayment(PaymentDto payload)
    {
        // Implementation for processing payment via Paystack
        string message = $"Payment of {payload.Amount} processed successfully via Flutter.";
        return message;
    }
}