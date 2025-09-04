namespace Service;

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

    private string ValidatePaymentDto(PaymentDto payload)
    {
        if (payload.Amount == 0) return "Amount is cannot be zero";
        if (payload.Pan.Length < 16) return "Invalid Pan";
        if (payload.Cvv.Length != 4) return "Invalid CVV";
        //if (payload.Expiry)

        return string.Empty;
    }

    public string MakePayment(PaymentDto payment)
    {
        string result = string.Empty;
        try
        {
            var processor = GetPaymentFactory(payment.Amount);
            string validationResult = ValidatePaymentDto(payment);
            if (!string.IsNullOrEmpty(validationResult)) throw new Exception(validationResult);

            result = processor.ProcessPayment(payment);
        }
        catch (Exception ex)
        {
            result = ex.Message;
        }
        return result;
    }

}