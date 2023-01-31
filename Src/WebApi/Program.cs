using Application;
using Microsoft.EntityFrameworkCore;
using Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();

builder.Services
    .AddHttpContextAccessor()
    .AddControllers();

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IStoreDbContext>());

var app = builder.Build();

/*var storeContext = app.Services.GetRequiredService<StoreDbContext>();
storeContext.Database.Migrate();*/

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
