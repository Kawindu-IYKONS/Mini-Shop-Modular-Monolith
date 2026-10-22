
using Mini_Shop.Exceptions;
using Mini_Shop.Modules.Orders.Services;
using Mini_Shop.Modules.Products.Services;
using Mini_Shop.Modules.Users.Users_Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUserServices, UserServices>();
builder.Services.AddSingleton<IProductServices, ProductServices>();
builder.Services.AddSingleton<IOrderServices, OrderServices>();

// Global exception handling
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "Mini Shop API");

        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
