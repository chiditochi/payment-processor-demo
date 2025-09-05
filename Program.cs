

using Microsoft.AspNetCore.Mvc;
using Cyberspace.Service;
using Cyberspace.Model;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Cyberspace.Model.Validators;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IPaymentService, PaymentService>();

// Add FluentValidation and register a single validator.
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<PaymentDto>, PaymentDtoValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.MapPost("/pay", async (IValidator<PaymentDto> validator,[FromBody]PaymentDto payload, IPaymentService paymentService) =>
{
    var validationResult = await validator.ValidateAsync(payload);
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    string result = paymentService.MakePayment(payload);
    return Results.Ok(result);   
})
.WithName("Pay");

app.Run();

